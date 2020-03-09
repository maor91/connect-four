using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConnectFourLogic
{
	public class Ai
	{
        public static int GetAiMove(GameModel io_GameModel, out int o_RowInserted)
        {
            int maxSequenceAiColumn = -1;
			int maxSequenceOtherPlayerColumn = -1;
            int maxSequenceAi = -1;
			int maxSequenceOtherPlayer = -1;
			maxSequenceAi = getBiggestSequence(io_GameModel, ref maxSequenceAiColumn);
            io_GameModel.CurrentPlayer = io_GameModel.FirstPlayer;
			maxSequenceOtherPlayer = getBiggestSequence(io_GameModel, ref maxSequenceOtherPlayerColumn);
			int insertColumnForAi = maxSequenceAi >= maxSequenceOtherPlayer ? maxSequenceAiColumn : maxSequenceOtherPlayerColumn;
            io_GameModel.CurrentPlayer = io_GameModel.SecondPlayer;
			o_RowInserted = io_GameModel.GameBoard.NextAvailableMoveArr[insertColumnForAi];
			io_GameModel.GameBoard.Insert(insertColumnForAi, io_GameModel.CurrentPlayer.PlayerNumber);
			return insertColumnForAi;
        }

		private static int getBiggestSequence(GameModel i_GameModel, ref int io_BiggestSequenceColumn)
		{
			int maxSequence = -1;
			int currentSequence;
			for (int i = 0; i < i_GameModel.GameBoard.BoardColumns; i++)
			{
				if (i_GameModel.GameBoard.NextAvailableMoveArr[i] >= 0)
				{
					currentSequence = getSequenceForCurrentColumn(i_GameModel.GameBoard.NextAvailableMoveArr[i], i, i_GameModel);
					if (currentSequence > maxSequence)
					{
						maxSequence = currentSequence;
						io_BiggestSequenceColumn = i;
					}
				}
			}

			return maxSequence;
		}

        private static int getSequenceForCurrentColumn(int i_RowInserted, int i_ColumnInserted, GameModel i_GameModel)
        {
            int maxSequence;
            maxSequence = Math.Max(i_GameModel.getVerticalSequence(i_RowInserted, i_ColumnInserted), i_GameModel.getHorizontalSequence(i_RowInserted, i_ColumnInserted));
            maxSequence = Math.Max(maxSequence, i_GameModel.getFirstDiagonalSequence(i_RowInserted, i_ColumnInserted));
            maxSequence = Math.Max(maxSequence, i_GameModel.getSecondDiagonalSequence(i_RowInserted, i_ColumnInserted));
            return maxSequence;
        }
	}
}
