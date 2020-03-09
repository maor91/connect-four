using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConnectFourLogic
{
    public class GameModel
    {
        private const int k_MinBoardLength = 4;

        public int MinBoardLength
        {
            get { return k_MinBoardLength; }
        }

        private const int k_MaxBoardLength = 10;

        public int MaxBoardLength
        {
            get { return k_MaxBoardLength; }
        }

        private Board m_GameBoard;

        public Board GameBoard
        {
            get { return m_GameBoard; }
            set { m_GameBoard = value; }
        }

        private Player m_FirstPlayer;

        public Player FirstPlayer
        {
            get { return m_FirstPlayer; }
            set { m_FirstPlayer = value; }
        }

        private Player m_SecondPlayer;

        public Player SecondPlayer
        {
            get { return m_SecondPlayer; }
            set { m_SecondPlayer = value; }
        }

        private Player m_CurrentPlayer;

        public Player CurrentPlayer
        {
            get
            {
                return m_CurrentPlayer;
            }

            set
            {
                m_CurrentPlayer = value;
            }
        }

        public void InitializePlayer(string i_Name, ePlayer i_PlayerChosen)
        {
            if (m_FirstPlayer == null)
            {
                m_FirstPlayer = new Player(i_Name, eCell.PlayerOne, i_PlayerChosen);
            }
            else
            {
                m_SecondPlayer = new Player(i_Name, eCell.PlayerTwo, i_PlayerChosen);
            }
        }

        public bool IsSizeLegal(int i_Size)
        {
            return i_Size >= k_MinBoardLength && i_Size <= k_MaxBoardLength;
        }

        public bool IsTie()
        {
            return GameBoard.NumOfAvailableColumns == 0;
        }

		public bool IsCurrentPlayerWon(int i_RowInserted, int i_ColumnInserted)
        {
            bool playerWon = getVerticalSequence(i_RowInserted, i_ColumnInserted) == 4 || getHorizontalSequence(i_RowInserted, i_ColumnInserted) == 4 || getFirstDiagonalSequence(i_RowInserted, i_ColumnInserted) == 4 || getSecondDiagonalSequence(i_RowInserted, i_ColumnInserted) == 4;
            if (playerWon)
            {
                m_CurrentPlayer.IncrementScore();
            }

            return playerWon;
        }

		internal int getVerticalSequence(int i_RowInserted, int i_ColumnInserted)
		{
			int sequenceCount = 1;
			int possibleSequenceCount = 1;
			bool sequenceFlag = true;
			for (int i = i_RowInserted + 1; i < GameBoard.BoardRows; i++)
			{
				if (sequenceFlag && GameBoard.PlayBoardMat[i, i_ColumnInserted] == m_CurrentPlayer.PlayerNumber)
				{
					sequenceCount++;
					possibleSequenceCount++;
				}
				else if (GameBoard.PlayBoardMat[i, i_ColumnInserted] == eCell.Blank)
				{
					possibleSequenceCount++;
					sequenceFlag = false;
				}
				else
				{
					break;
				}
			}

			if (possibleSequenceCount < 4)
			{
				for (int i = i_RowInserted - 1; i >= 0; i--)
				{
					if (GameBoard.PlayBoardMat[i, i_ColumnInserted] == m_CurrentPlayer.PlayerNumber || GameBoard.PlayBoardMat[i, i_ColumnInserted] == eCell.Blank)
					{
						possibleSequenceCount++;
					}
					else
					{
						break;
					}
				}
			}

			if (possibleSequenceCount < 4)
			{
				sequenceCount = 0;
			}

			return sequenceCount;
		}

		internal int getHorizontalSequence(int i_RowInserted, int i_ColumnInserted)
		{
			int sequenceCount = 1;
			int possibleSequenceCount = 1;
			bool sequenceFlag = true;
			for (int i = i_ColumnInserted + 1; i < GameBoard.BoardColumns; i++)
			{
				if (sequenceFlag && GameBoard.PlayBoardMat[i_RowInserted, i] == m_CurrentPlayer.PlayerNumber)
				{
					sequenceCount++;
					possibleSequenceCount++;
				}
				else if (GameBoard.PlayBoardMat[i_RowInserted, i] == eCell.Blank)
				{
					possibleSequenceCount++;
					sequenceFlag = false;
				}
				else
				{
					break;
				}
			}

			if (sequenceCount < 4)
			{
				sequenceFlag = true;
				for (int i = i_ColumnInserted - 1; i >= 0; i--)
				{
					if (sequenceFlag && GameBoard.PlayBoardMat[i_RowInserted, i] == m_CurrentPlayer.PlayerNumber)
					{
						sequenceCount++;
						possibleSequenceCount++;
					}
					else if (GameBoard.PlayBoardMat[i_RowInserted, i] == eCell.Blank)
					{
						possibleSequenceCount++;
						sequenceFlag = false;
					}
					else
					{
						break;
					}
				}
			}

			if (possibleSequenceCount < 4)
			{
				sequenceCount = 0;
			}

			return sequenceCount;
		}

		internal int getFirstDiagonalSequence(int i_RowInserted, int i_ColumnInserted)
		{
			int sequenceCount = 1;
			int possibleSequenceCount = 1;
			bool sequenceFlag = true;
			for (int i = i_RowInserted + 1, j = i_ColumnInserted + 1; i < GameBoard.BoardRows && j < GameBoard.BoardColumns; i++, j++)
			{
				if (sequenceFlag && GameBoard.PlayBoardMat[i, j] == m_CurrentPlayer.PlayerNumber)
				{
					sequenceCount++;
					possibleSequenceCount++;
				}
				else if (sequenceFlag && GameBoard.PlayBoardMat[i, j] == eCell.Blank)
				{
					possibleSequenceCount++;
					sequenceFlag = false;
				}
				else
				{
					break;
				}
			}

			if (sequenceCount < 4)
			{
				sequenceFlag = true;
				for (int i = i_RowInserted - 1, j = i_ColumnInserted - 1; i >= 0 && j >= 0; i--, j--)
				{
					if (sequenceFlag && GameBoard.PlayBoardMat[i, j] == m_CurrentPlayer.PlayerNumber)
					{
						sequenceCount++;
						possibleSequenceCount++;
					}
					else if (sequenceFlag && GameBoard.PlayBoardMat[i, j] == eCell.Blank)
					{
						possibleSequenceCount++;
						sequenceFlag = false;
					}
					else
					{
						break;
					}
				}
			}

			if (possibleSequenceCount < 4)
			{
				sequenceCount = 0;
			}

			return sequenceCount;
		}

		internal int getSecondDiagonalSequence(int i_RowInserted, int i_ColumnInserted)
		{
			int sequenceCount = 1;
			int possibleSequenceCount = 1;
			bool sequenceFlag = true;
			for (int i = i_RowInserted - 1, j = i_ColumnInserted + 1; i >= 0 && j < GameBoard.BoardColumns; i--, j++)
			{
				if (sequenceFlag && GameBoard.PlayBoardMat[i, j] == m_CurrentPlayer.PlayerNumber)
				{
					sequenceCount++;
					possibleSequenceCount++;
				}
				else if (sequenceFlag && GameBoard.PlayBoardMat[i, j] == eCell.Blank)
				{
					possibleSequenceCount++;
					sequenceFlag = false;
				}
				else
				{
					break;
				}
			}

			if (sequenceCount < 4)
			{
				sequenceFlag = true;
				for (int i = i_RowInserted + 1, j = i_ColumnInserted - 1; i < GameBoard.BoardRows && j >= 0; i++, j--)
				{
					if (sequenceFlag && GameBoard.PlayBoardMat[i, j] == m_CurrentPlayer.PlayerNumber)
					{
						sequenceCount++;
						possibleSequenceCount++;
					}
					else if (sequenceFlag && GameBoard.PlayBoardMat[i, j] == eCell.Blank)
					{
						possibleSequenceCount++;
						sequenceFlag = false;
					}
					else
					{
						break;
					}
				}
			}

			if (possibleSequenceCount < 4)
			{
				sequenceCount = 0;
			}

			return sequenceCount;
		}

        public GameModel()
        {
        }
    }
}
