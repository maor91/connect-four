namespace ConnectFourLogic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Board
    {
        private readonly int r_BoardRows;

        public int BoardRows
        {
            get { return r_BoardRows; }
        }

        private int r_BoardColumns;

        public int BoardColumns
        {
            get { return r_BoardColumns; }
        }

        private int m_NumOfAvailableColumns;

        public int NumOfAvailableColumns
        {
            get { return m_NumOfAvailableColumns; }
            set { m_NumOfAvailableColumns = value; }
        }

        private eCell[,] m_PlayBoardMat;

        public eCell[,] PlayBoardMat
        {
            get { return m_PlayBoardMat; }
            set { m_PlayBoardMat = value; }
        }

        private List<int> m_NextAvailableMoveArr;

        public List<int> NextAvailableMoveArr
        {
            get { return m_NextAvailableMoveArr; }
            set { m_NextAvailableMoveArr = value; }
        }

        public Board(int i_BoardRows, int i_BoardColumns)
        {
            r_BoardRows = i_BoardRows;
            r_BoardColumns = i_BoardColumns;
            m_NumOfAvailableColumns = r_BoardColumns;
            m_NextAvailableMoveArr = new List<int>(r_BoardColumns);
			initNextMovesArr();
            m_PlayBoardMat = new eCell[r_BoardRows, r_BoardColumns];
        }

		public Board()
		{
		}

		private void initNextMovesArr()
		{
            int arrValue = r_BoardRows - 1;
			for (int i = 0; i < r_BoardColumns; i++)
			{
                m_NextAvailableMoveArr.Add(arrValue);
			}
		}

        private void clearNextMovesArr()
        {
            int arrValue = r_BoardRows - 1;
            for (int i = 0; i < m_NextAvailableMoveArr.Count; i++)
            {
                m_NextAvailableMoveArr[i] = arrValue;
            }
        }

		public void ClearBoard()
		{
			m_NumOfAvailableColumns = r_BoardColumns;
            clearNextMovesArr();

			for (int i = 0; i < r_BoardRows; i++)
			{
				for (int j = 0; j < r_BoardColumns; j++)
				{
					m_PlayBoardMat[i, j] = eCell.Blank;
				}
			}
		}

		public bool TryInsert(int i_InsertColumn, out int o_rowInserted, eCell i_PlayerNumber)
		{
			bool flag = m_NextAvailableMoveArr[i_InsertColumn] >= 0;

			if (flag)
			{
				o_rowInserted = NextAvailableMoveArr[i_InsertColumn];
				Insert(i_InsertColumn, i_PlayerNumber);
			}
			else
			{
				o_rowInserted = -1;
			}

			return flag;
		}

		public void Insert(int i_InsertColumn, eCell i_PlayerNumber)
		{
			PlayBoardMat[NextAvailableMoveArr[i_InsertColumn], i_InsertColumn] = i_PlayerNumber;
			NextAvailableMoveArr[i_InsertColumn]--;

			if (NextAvailableMoveArr[i_InsertColumn] == -1)
			{
				NumOfAvailableColumns--;
			}
		}
    }
}
