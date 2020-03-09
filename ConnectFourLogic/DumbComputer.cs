using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConnectFourLogic
{
	public class DumbComputer
	{
		public static int GetRandomMove(GameModel i_GameModel, out int o_RowInserted)
		{
			bool flag;
			List<int> movesListArr = i_GameModel.GameBoard.NextAvailableMoveArr;
			Random rand = new Random();
			int randomCol;
			do
			{
				randomCol = rand.Next(0, movesListArr.Count);
				flag = i_GameModel.GameBoard.TryInsert(randomCol, out o_RowInserted, i_GameModel.CurrentPlayer.PlayerNumber);
			} 
			while (!flag);

			return randomCol;
		}
	}
}
