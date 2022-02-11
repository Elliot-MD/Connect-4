using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Connect4_Personal
{
    public partial class Form1 : Form
    {
        //Colours for the pieces
        private readonly Color emptyPiece = Color.Black;
        private readonly Color player1Piece;
        private readonly Color player2Piece;

        //Int to determine whose turn it is
        private int playerTurn = 1;

        //Arrays for the buttons and pieces
        Button[] btnArray = new Button[7];
        Label[,] lblArray = new Label[7, 6];

        //The menu
        private Form2 menu = null;

        //Labels to visualise the score
        Label scoreRed = new Label();
        Label scoreYellow = new Label();

        //Bool for the computer to look for more piece options
        bool stillLabelsLeft;

        //List of pieces from which the computer can later choose from
        List<Label> chosenLabels = new List<Label>();
        List<Label> playersFinalPieces = new List<Label>();



        public Form1()
        {
            InitializeComponent();

        }

        //constructur which is called on in the menu
        public Form1(Form form2)
        {
            //variable for the menu so the game can access its settings
            menu = form2 as Form2;

            //setting the colours whihc were chosen in the menu
            player1Piece = menu.player1Colour;
            player2Piece = menu.player2Colour;

            InitializeComponent();
            Size = new Size(500, 550);

            //The visualisation of the scores on the top of game
            //The score for the player who plays red
            scoreRed.SetBounds(125, 35, 50, 40);
            scoreRed.Font = new Font(scoreRed.Font.Name, 25);
            scoreRed.Text = Convert.ToString(menu.scorePlayer1);
            scoreRed.ForeColor = Color.Crimson;
            Controls.Add(scoreRed);

            //The score for the player who plays yellow
            scoreYellow.SetBounds(325, 35, 50, 40);
            scoreYellow.Font = new Font(scoreRed.Font.Name, 25);
            scoreYellow.Text = Convert.ToString(menu.scorePlayer2);
            scoreYellow.ForeColor = Color.Gold;
            Controls.Add(scoreYellow);

            //The buttons to choose a column
            for (int x = 0; x < 7; x++)
            {
                
                btnArray[x] = new Button();
                btnArray[x].SetBounds(40 + (60 * x), 84, 40, 40);
                btnArray[x].BackColor = player1Piece;
                btnArray[x].Name = Convert.ToString(x);
                btnArray[x].Click += new EventHandler(this.btnEvent_Click);
                this.btnArray[x].Cursor = Cursors.Hand;
                Controls.Add(btnArray[x]);

                //Changes to the shape of the buttons
                var path = new System.Drawing.Drawing2D.GraphicsPath();
                PointF[] points = new PointF[3];
                points[0] = new Point(5, 4);
                points[1] = new Point(35, 4);
                points[2] = new Point(20, 21);
                path.AddPolygon(points);
                this.btnArray[x].Region = new Region(path);
            }

            //The Tiles
            for (int y = 0; y < 6; y++)
            {
                for (int x = 0; x < 7; x++)
                {
                    lblArray[x, y] = new Label();
                    lblArray[x, y].SetBounds(40 + (60 * x), 130 + (60 * y), 40, 40);
                    lblArray[x, y].BackColor = emptyPiece;
                    lblArray[x, y].Name = Convert.ToString(x) + "," + Convert.ToString(y);
                    Controls.Add(lblArray[x, y]);

                    //Changes to the shape of the pieces to make them round
                    //The code for these changes where taken and modified from https://stackoverflow.com/questions/11347576/how-to-make-a-circle-shape-piece-in-window-form
                    var path = new System.Drawing.Drawing2D.GraphicsPath();
                    path.AddEllipse(0, 0, lblArray[x, y].Width, lblArray[x, y].Height);
                    this.lblArray[x, y].Region = new Region(path);
                }
            }

            //The frame for the discs/pieces
            Label background = new Label();
            background.SetBounds(30, 120, 420, 360);
            background.BackColor = Color.RoyalBlue;
            Controls.Add(background);

            menu.Hide();
        }

        //Eventhandler to place a piece
        void btnEvent_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(((Button)sender).Name);
            int y = 0;

            //Checks if there is an empty piece in the chosen column
            if (lblArray[x, 0].BackColor != emptyPiece)
            {
                string msg = "Invalid move, please re-enter";
                MessageBox.Show(msg);
                return;
            }

            //Places the piece in the lowest row possible
            for (int i = 0; i < 6; i++)
            {
                if (lblArray[x, i].BackColor == emptyPiece)
                {
                    y = i;
                }
            }

            //Depending on the playerTurn, it will place a piece in the right colour
            //and signal with the buttons at the top whose turn it is next
            switch (playerTurn)
            {
                case 1:
                    lblArray[x, y].BackColor = player1Piece;
                    if (menu.computer == false)
                    {
                        for (int i = 0; i < 7; i++)
                        {
                            btnArray[i].BackColor = player2Piece;
                        }
                    }
                    break;
                case 2:
                    lblArray[x, y].BackColor = player2Piece;
                    for (int i = 0; i < 7; i++)
                    {
                        btnArray[i].BackColor = player1Piece;
                    }
                    break;
            }

            //After the placed piece it will check if the current player has won or if there is a draw
            if (checkIfWin(lblArray[x, y]) || checkIfDraw())
            {
                return;
            }

            //When the player is playing against another player, the playerTurn will change so the next player can play
            if (!menu.computer)
            {
                if (playerTurn == 1)
                {
                    ++playerTurn;
                }
                else
                {
                    --playerTurn;
                }
                return;
            }
            //If player plays against the computer, it's the computer's turn to choose a piece
            else if (menu.computer)
            {
                Label chosenOne = versusComputer();
                chosenOne.BackColor = player2Piece;

                //After the placed piece it will check if the computer has won or if there is a draw
                if (checkIfWin(chosenOne) || checkIfDraw())
                {
                    return;
                }
            }

            
        }
        
        //Boolean to check if the player of the given piece has won
        private bool checkIfWin(Label piece)
        {
            //the player has to have a row of 4 or more piece in the same colour
            //these rows can be horizontal, vertical or diagonal
            if (this.getCounter(piece) >= 4)
            {
                //it checks whose piece it is and returns a message with the result
                switch (menu.computer)
                {
                    //Player versus computer
                    case true:
                        //the player has won
                        if (piece.BackColor == player1Piece)
                        {
                            MessageBox.Show("Congratulations, you won!!");
                        }
                        //the computer has won
                        else
                        {
                            MessageBox.Show("Oh no, you lost, unlucky :'(");
                        }
                        break;

                    //Player vs Player
                    case false:
                        switch (playerTurn)
                        {
                            case 1:
                                MessageBox.Show("Player 1 has won!");
                                break;
                            case 2:
                                MessageBox.Show("Player 2 has won!");
                                break;
                        }
                        //The next player will be player 1 again so the buttons will indicate this with their colour
                        for (int i = 0; i < 7; i++)
                        {
                            btnArray[i].BackColor = player1Piece;
                        }
                        break;
                }

                //The scores are update based on who has won
                if (piece.BackColor == Color.Crimson)
                {
                    menu.scorePlayer1++;
                    scoreRed.Text = Convert.ToString(menu.scorePlayer1);
                }
                else
                {
                    menu.scorePlayer2++;
                    scoreYellow.Text = Convert.ToString(menu.scorePlayer2);
                }
                
                ResetGame();
                return true;
            }
            return false;
        }
        
        //Bool to check if there is a draw by checking for empty piece in the top row
        private bool checkIfDraw()
        {
            for (int x = 0; x < 7; x++)
            {
                if (lblArray[x, 0].BackColor == emptyPiece)
                {
                    return false;
                }
            }

            MessageBox.Show("Draw! No winners this time :)");
            ResetGame();
            return true;

        }
        
        //Returns a piece which the computer has chosen
        //it will look for the most same coloured tiles in a line and try to add a piece to that line
        private Label versusComputer()
        {
            Label chosenOne = null;

            //finds all the pieces with the computer's colour and checks if the player already has three piece in a row
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    //adds the last piece in the line to the chosenLabel list
                    if (lblArray[i, j].BackColor == player2Piece && !chosenLabels.Contains(this.getEnd(lblArray[i, j], "negative")))
                    {
                        chosenLabels.Add(this.getEnd(lblArray[i, j], "negative"));

                    }
                    //if the player has more than three pieces in a line, the end piece will be added to the playersFinalPieces list
                    else if (lblArray[i, j].BackColor == player1Piece && this.getCounter(lblArray[i, j]) == 3)
                    {
                        playersFinalPieces.Add(this.getEnd(lblArray[i, j], "negative"));
                    }
                }
            }


            //if the dificulty level is hard, the computer will block the player from reaching four pieces in a line
            if (menu.hard)
            {
                while (chosenOne == null && playersFinalPieces.Count > 0)
                {
                    chosenOne = this.chooseLabel(0, playersFinalPieces);
                    playersFinalPieces.Remove(playersFinalPieces[0]);
                }
                playersFinalPieces.Clear();
            }


            this.sortList();
            int counter = 0;

            //Computer will choose a piece at the end of a line of pieces in its colour
            while (chosenLabels.Count != 0 && chosenOne == null)
            {
                chosenOne = this.chooseLabel(counter, chosenLabels);
                counter++;

                //if all of theses lines are blocked, the computer will try to choose a pieces next to its existing pieces
                if (counter == chosenLabels.Count)
                {
                    stillLabelsLeft = true;
                    counter = 0;
                }
            }

            //if there is no suitable piece free, the computer will choose a piece randomly
            if (chosenOne == null)
            {
                Random rnd = new Random();
                int x = rnd.Next(0, 7);

                for (int i = 0; i < 6; i++)
                {
                    if (lblArray[x, i].BackColor == emptyPiece)
                    {

                        chosenOne = lblArray[x, i];
                    }
                    else if (i == 5 && chosenOne == null)
                    {
                        i = 0;
                        x = rnd.Next(0, 7);
                    }
                }
            }
            return chosenOne;
        }
        
        //Returns a pieces based on the given condtions and the given list
        private Label chooseLabel(int counter, List<Label> pieces)
        {
            //the end and the start of a line of same coloured pieces in which the first element of the given list is in
            Label end = this.getEnd(pieces[counter], "negative");
            Label start = this.getEnd(pieces[counter], "positive");
            Label chosenOne = null;

            //when there is only one piece or all the other lines are blocked,
            //the computer will choose a piece around a piece of its colour
            if ((this.getCounter(end) == 1 && !menu.hard) || stillLabelsLeft)
            {
                int xC = this.getX(end);
                int yC = this.getY(end);

                for (int i = -1; i < 2; i++)
                {
                    for (int j = -1; j < 2; j++)
                    {
                        if ((i == 0 && j == 0) || i + xC > 6 || i + xC < 0 || j + yC > 5 || j + yC < 0)
                        {
                            continue;
                        }
                        else if (lblArray[xC + i, yC + j].BackColor == emptyPiece && this.checkCol(lblArray[xC + i, yC + j]))
                        {
                            chosenOne = lblArray[xC + i, yC + j];
                            pieces.Clear();
                            stillLabelsLeft = false;

                        }
                    }

                }
                //if no piece is suitable around the given pieces, it will clear the list and a piece has to be chosen randomly
                if (chosenOne == null)
                {
                    pieces.Remove(end);
                    stillLabelsLeft = false;
                }
            }
            //The computer will first look at one end of the line and will try to continue this line
            else if (!this.OutOfRange(end, pieces[counter]))
            {
                Label nextEnd = lblArray[this.getX(end) - this.getDifX(pieces[counter]), this.getY(end) - this.getDifY(pieces[counter])];
                if (this.checkCol(nextEnd) && nextEnd.BackColor == emptyPiece)
                {
                    chosenOne = nextEnd;
                    return chosenOne;
                }
                //if the piece is blocked or does not have a piece underneath it, the computer will try the other end
                else if (!this.OutOfRange(start, end))
                {
                    Label nextStart = lblArray[this.getX(start) + this.getDifX(pieces[counter]), this.getY(start) + this.getDifY(pieces[counter])];
                    if (this.checkCol(nextStart) && nextStart.BackColor == emptyPiece)
                    {
                        chosenOne = nextStart;
                        return chosenOne;
                    }
                }

            }
            //if it is not possible to choose a piece at one end, the computer will try the other end
            else if (!this.OutOfRange(start, pieces[counter]))
            {
                Label nextStart = lblArray[this.getX(start) + this.getDifX(pieces[counter]), this.getY(start) + this.getDifY(pieces[counter])];
                if (this.checkCol(nextStart) && nextStart.BackColor == emptyPiece)
                {
                    Console.WriteLine(1234);
                    chosenOne = nextStart;
                    return chosenOne;
                }
            }
            return chosenOne;
        }
        
        //Bool to check if the next piece is out of range of the given array
        private bool OutOfRange(Label givenPiece, Label pieceDifference)
        {
            //the coordinates of the given piece
            int xL1 = this.getX(givenPiece);
            int yL1 = this.getY(givenPiece);

            //the difference between the given piece and the next one
            int xL2 = this.getDifX(pieceDifference);
            int yL2 = this.getDifY(pieceDifference);

            if (xL1 + xL2 > 6 || xL1 + xL2 < 0 || yL1 + yL2 > 5 || yL1 + yL2 < 0)
            {
                return true;
            }
            else if (xL1 - xL2 > 6 || xL1 - xL2 < 0 || yL1 - yL2 > 5 || yL1 - yL2 < 0)
            {
                return true;
            }
            return false;
        }
        
        //Returns the number of same coloured pieces which are in the same line as the given piece
        private int countDisks(Label piece, int xDif, int yDif)
        {
            int x = this.getX(piece);
            int y = this.getY(piece);
            Label next = lblArray[x, y];
            int counter = 0;

            //it finds one end of the line
            while (next.BackColor == piece.BackColor)
            {
                if ((xDif == 0 && yDif == 0) || x + xDif > 6 || x + xDif < 0 || y + yDif > 5 || y + yDif < 0)
                {
                    break;
                }
                else if (lblArray[x + xDif, y + yDif].BackColor != piece.BackColor)
                {
                    break;
                }
                x += xDif;
                y += yDif;
                next = lblArray[x, y];
            }

            //it starts counting form the found end of the line to the next end
            while (next.BackColor == piece.BackColor)
            {
                counter++;
                if ((xDif == 0 && yDif == 0) || x - xDif > 6 || x - xDif < 0 || y - yDif > 5 || y - yDif < 0)
                {
                    break;
                }
                else if (lblArray[x - xDif, y - yDif].BackColor != piece.BackColor)
                {
                    break;
                }
                x -= xDif;
                y -= yDif;
                next = lblArray[x, y];
            }
            return counter;
        }
        
        //Returns either end of the line of same coloured pieces as the given piece
        //The given string decides if the calculated difference should be added or subtracted
        private Label getEnd(Label piece, string side)
        {
            int x = this.getX(piece);
            int y = this.getY(piece);
            Label next = lblArray[x, y];

            //the difference to the next best piece
            int xDif = this.getDifX(piece);
            int yDif = this.getDifY(piece);

            if (side == "negative")
            {
                xDif = -xDif;
                yDif = -yDif;
            }

            //it will move on to the next piece until there is no piece of the same colour or no piece at all
            while (next.BackColor == piece.BackColor)
            {
                if ((xDif == 0 && yDif == 0) || x + xDif > 6 || x + xDif < 0 || y + yDif > 5 || y + yDif < 0)
                {
                    break;
                }
                else if (lblArray[x + xDif, y + yDif].BackColor != piece.BackColor)
                {
                    break;
                }
                x += xDif;
                y += yDif;
                next = lblArray[x, y];
            }
            return next;
        }
        
        //Bool to check if there is an empty piece underneath the given piece
        private bool checkCol(Label label)
        {
            int x = this.getX(label);
            for (int y = 5; y >= 0; y--)
            {

                if (y == this.getY(label))
                {
                    return true;
                }
                else if (lblArray[x, y].BackColor == emptyPiece)
                {
                    return false;
                }

            }
            return false;
        }
        
        //Function to sort the list of pieces by the number of same coloured pieces in the same line
        private void sortList()
        {
            for (int i = 0; i < chosenLabels.Count; i++)
            {
                for (int j = 0; j < chosenLabels.Count; j++)
                {
                    if (this.getCounter(chosenLabels[i]) < this.getCounter(chosenLabels[j]))
                    {
                        Label label = chosenLabels[i];
                        chosenLabels[i] = chosenLabels[j];
                        chosenLabels[j] = label;
                    }
                }
            }
        }
        //Returns the difference of the x coordinates of the given piece and the piece next to it with the same colour
        private int getDifX(Label piece)
        {
            int x = this.getX(piece);
            int y = this.getY(piece);
            int counter = 0;
            int xDif = 0;

            for (int i = -1; i < 2; i++)
            {
                for (int j = -1; j < 2; j++)
                {
                    if ((i == 0 && j == 0) || i + x > 6 || i + x < 0 || j + y > 5 || j + y < 0)
                    {
                        continue;
                    }
                    else if (lblArray[x + i, y + j].BackColor == lblArray[x, y].BackColor)
                    {
                        if (this.countDisks(piece, i, j) > counter)
                        {
                            counter = this.countDisks(piece, i, j);
                            xDif = i;
                        }

                    }
                }
            }
            return xDif;
        }

        //Returns the difference of the y coordinates of the given piece and the piece next to it with the same colour
        private int getDifY(Label piece)
        {
            int x = this.getX(piece);
            int y = this.getY(piece);
            int counter = 0;
            int yDif = 0;

            for (int i = -1; i < 2; i++)
            {
                for (int j = -1; j < 2; j++)
                {
                    if ((i == 0 && j == 0) || i + x > 6 || i + x < 0 || j + y > 5 || j + y < 0)
                    {
                        continue;
                    }
                    else if (lblArray[x + i, y + j].BackColor == lblArray[x, y].BackColor)
                    {
                        if (this.countDisks(piece, i, j) > counter)
                        {
                            counter = this.countDisks(piece, i, j);
                            yDif = j;
                        }

                    }
                }
            }
            return yDif;
        }
        
        //Returns the x coordinate from given piece
        private int getX(Label piece)
        {
            string[] coords = piece.Name.Split(',');
            return Convert.ToInt32(coords[0]);
        }

        //Returns the y coordinate from given piece
        private int getY(Label piece)
        {
            string[] coords = piece.Name.Split(',');
            return Convert.ToInt32(coords[1]);

        }

        //Returns counter of the biggest line of same coloured pieces in which the given piece exists in
        private int getCounter(Label piece)
        {
            int x = this.getDifX(piece);
            int y = this.getDifY(piece);

            return this.countDisks(piece, x, y);
        }

        //resets the game
        private void ResetGame()
        {
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    lblArray[j, i].BackColor = emptyPiece;
                }
            }
            playerTurn = 1;
        }    


        //Buttons for the strip menu
        //Rules
        private void rulesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DialogResult result;
            result = MessageBox.Show("The rules are to connect four of your coloured piece in a row, may that be horizontally, vertically or diagonal. Click a button at the top and your coloured piece will be placed in that column.", "Rules", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //Restart Game
        private void startNewGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResetGame();
        }

        //Licence
        private void licenceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result;
            result = MessageBox.Show("Created by Elliot Morgan-Davies, Pia Schroeter and Jerry Deligiannis at Dundee University (c)", "Licence", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //Menu
        private void menuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 menu = new Form2();
            this.Hide();
            menu.ShowDialog();
        }

        //Reset score
        private void resetScore_Click(object sender, EventArgs e)
        {
            menu.scorePlayer1 = 0;
            menu.scorePlayer2 = 0;

            scoreRed.Text = Convert.ToString(menu.scorePlayer1);
            scoreYellow.Text = Convert.ToString(menu.scorePlayer2);
        }
        
        //exit Game
        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
