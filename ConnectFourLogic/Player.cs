using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConnectFourLogic
{
    public class Player
    {
        private readonly eCell r_PlayerNumber;
		
        public eCell PlayerNumber
        {
            get { return r_PlayerNumber; }
        }

        private readonly string r_Name;

        public string Name
        {
            get { return r_Name; }
        }

        private int m_Score;

        public int Score
        {
            get { return m_Score; }
        }

        private readonly ePlayer m_PlayerChosen;

		public ePlayer PlayerChosen
        {
            get 
            {
				return m_PlayerChosen;
            }
        }
        
        public void IncrementScore()
        {
            m_Score++;
        }

        public Player(string i_Name, eCell i_PlayerNumber, ePlayer i_PlayerChosen)
        {
            r_Name = i_Name;
            r_PlayerNumber = i_PlayerNumber;
			m_PlayerChosen = i_PlayerChosen;
        }

        public Player()
        {
        }
    }
}
