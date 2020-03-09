using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConnectFourLogic
{
	public enum eGameMode : byte
	{
		PlayerVsPlayer = 1,
		PlayerVsDumbComputer, // Dumb Computer is playing randomly.
		PlayerVsAi
	}
}
