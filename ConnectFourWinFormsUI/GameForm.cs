using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ConnectFourLogic;

namespace B16_Ex05
{
    public partial class GameForm : Form
    {
        private readonly int r_SpaceBetweenButtons = 10;
        private readonly List<Button> r_ColumnInsertButtonArr;
        private readonly Button[,] r_ButtonsMat;
        private GameModel m_GameModel;
        private eGameMode m_GameMode;
        private bool m_FirstPlayerTurn = true;

        public GameModel GameModel
        {
            get
            {
                return m_GameModel;
            }

            set
            {
                m_GameModel = value;
            }
        }

        public GameForm(GameModel i_GameModel, eGameMode i_GameMode)
        {
            InitializeComponent();
            m_GameModel = i_GameModel;
            m_GameMode = i_GameMode;
            r_ColumnInsertButtonArr = new List<Button>(m_GameModel.GameBoard.BoardColumns);
            r_ButtonsMat = new Button[m_GameModel.GameBoard.BoardRows, m_GameModel.GameBoard.BoardColumns];
            setSettings();
            m_GameModel.CurrentPlayer = GameModel.FirstPlayer;
        }

        private void insertFuncAndMoreAhSheli(int i_ColumnIndex)
        {
        }

        private void setSettings()
        {
            createColumnInsertButtons();
            createButtonsMat();
            setFormSize();
            setLabelsLocation();
            setPlayersScoreStatus();
        }

        private void setPlayersScoreStatus()
        {
            m_PlayerOneLbl.Text = m_GameModel.FirstPlayer.Name + ": " + m_GameModel.FirstPlayer.Score.ToString();
            m_PlayerTwoLbl.Text = m_GameModel.SecondPlayer.Name + ": " + m_GameModel.SecondPlayer.Score.ToString();
        }

        private void createColumnInsertButtons()
        {
            Size buttonSize = new Size(50, 25);
            Point buttonLocation = new Point(20, 20);
            for (int i = 0; i < r_ColumnInsertButtonArr.Capacity; i++)
            {
                Button currentButton = new Button();
                currentButton.Location = buttonLocation;
                currentButton.Size = buttonSize;
                currentButton.Text = (i + 1).ToString();
                currentButton.Click += new EventHandler(insertButton_Click);
                r_ColumnInsertButtonArr.Add(currentButton);
                this.Controls.Add(currentButton);
                buttonLocation.X += r_SpaceBetweenButtons + buttonSize.Width;
            }
        }

        private void createButtonsMat()
        {
            Size buttonSize = new Size(50, 50);
            Point buttonLocation = new Point(20, 55);

            for (int i = 0; i < m_GameModel.GameBoard.BoardRows; i++)
            {
                for (int j = 0; j < m_GameModel.GameBoard.BoardColumns; j++)
                {
                    // $G$ DSN-001 (-7) You should have used an inherited control (inherited from Button) in order to save additional data on each control 
                    Button currentButton = new Button();
                    currentButton.Location = buttonLocation;
                    currentButton.Size = buttonSize;
                    r_ButtonsMat[i, j] = currentButton;
                    this.Controls.Add(currentButton);
                    buttonLocation.X += r_SpaceBetweenButtons + buttonSize.Width;
                }

                buttonLocation.X = 20;
                buttonLocation.Y += r_SpaceBetweenButtons + buttonSize.Height;
            }
        }

        private void setFormSize()
        {
            int newFormHeight = ((m_GameModel.GameBoard.BoardRows + 2) * r_ButtonsMat[0, 0].Size.Width) + (r_SpaceBetweenButtons * m_GameModel.GameBoard.BoardRows) + r_SpaceBetweenButtons;
            int newFormWidth = ((m_GameModel.GameBoard.BoardColumns + 1) * r_ButtonsMat[0, 0].Size.Width) + (r_SpaceBetweenButtons * (m_GameModel.GameBoard.BoardColumns - 1)) + (r_SpaceBetweenButtons / 2);
            this.Size = new Size(newFormWidth, newFormHeight);
        }

        private void setLabelsLocation()
        {
            m_PlayerOneLbl.Location = new Point((ClientSize.Width / 2) - (6 * r_SpaceBetweenButtons), ClientSize.Height - (2 * r_SpaceBetweenButtons));
            m_PlayerTwoLbl.Location = new Point((ClientSize.Width / 2) + (3 * r_SpaceBetweenButtons), ClientSize.Height - (2 * r_SpaceBetweenButtons));
        }

        private void GameForm_Load(object sender, EventArgs e)
        {
        }

        private void insertButton_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            int buttonIndex = int.Parse(button.Text) - 1;
            currentPlayerTurn(buttonIndex);
        }

        private void currentPlayerTurn(int i_ColumnToInsert)
        {
            int rowInserted = -1;
            switch (m_GameModel.CurrentPlayer.PlayerChosen)
            {
                case ePlayer.Human:
                    rowInserted = humanMove(i_ColumnToInsert);
                    break;
                case ePlayer.DumbComputer:
                    rowInserted = dumbComputerMove(out i_ColumnToInsert);
                    break;
                case ePlayer.Ai:
                    rowInserted = aiMove(out i_ColumnToInsert);
                    break;
                default:
                    break;
            }

            r_ButtonsMat[rowInserted, i_ColumnToInsert].Text = m_GameModel.CurrentPlayer.PlayerNumber == eCell.PlayerOne ? "X" : "O";

            if (rowInserted == 0)
            {
                r_ColumnInsertButtonArr[i_ColumnToInsert].Enabled = false;
            }

            if (m_GameModel.IsCurrentPlayerWon(rowInserted, i_ColumnToInsert))
            {
                playerWonMode();
            }
            else if (m_GameModel.IsTie())
            {
                tieMode();
            }

                m_GameModel.CurrentPlayer = m_FirstPlayerTurn ? m_GameModel.SecondPlayer : m_GameModel.FirstPlayer;
                m_FirstPlayerTurn = !m_FirstPlayerTurn;
                if (!m_GameModel.CurrentPlayer.PlayerChosen.Equals(ePlayer.Human))
                {
                    currentPlayerTurn(-1);
                }
        }

        private void tieMode()
        {
            DialogResult dialogResult = MessageBox.Show("Tie!!, Another round?", "Another Round?", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                playAnotherRound();
            }
            else
            {
                Environment.Exit(0);
            }
        }

        private void playerWonMode()
        {
            setPlayersScoreStatus();
            DialogResult dialogResult = MessageBox.Show(m_GameModel.CurrentPlayer.Name + " Won!!, Another Round?", "Another Round?", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                playAnotherRound();
            }
            else
            {
                Environment.Exit(0);
            }
        }

        private void playAnotherRound()
        {
            m_GameModel.GameBoard.ClearBoard();
            clearButtonsMat();
            clearColumnInsertButtonArr();
        }

        private void clearButtonsMat()
        {
            foreach (Button currentButton in r_ButtonsMat)
            {
                currentButton.Text = string.Empty;
            }
        }

        private void clearColumnInsertButtonArr()
        {
            foreach (Button currentButton in r_ColumnInsertButtonArr)
            {
                currentButton.Enabled = true;
            }
        }

        private int humanMove(int o_ColInserted)
        {
            int rowInserted;
            m_GameModel.GameBoard.TryInsert(o_ColInserted, out rowInserted, m_GameModel.CurrentPlayer.PlayerNumber);
            return rowInserted;
        }

        // $G$ DSN-001 (-5) A main logic object held by this form should handle those calls.. not the AI/dumb cpu directly. 
        private int dumbComputerMove(out int o_ColInserted)
        {
            int rowInserted;
            o_ColInserted = DumbComputer.GetRandomMove(GameModel, out rowInserted);
            return rowInserted;
        }

        private int aiMove(out int o_ColInserted)
        {
            int rowInserted;
            o_ColInserted = Ai.GetAiMove(GameModel, out rowInserted);
            return rowInserted;
        }
    }
}
