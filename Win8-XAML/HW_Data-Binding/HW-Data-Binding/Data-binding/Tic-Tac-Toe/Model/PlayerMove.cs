using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tic_Tac_Toe.Model
{
    public class PlayerMove : INotifyPropertyChanged
    {
        string playerName;
        /// <summary>
        /// The PlayerName property gets and sets the player's name
        /// </summary>
        public string PlayerName
        {
            get
            {
                return playerName;
            }
            set
            {
                if (string.Compare(playerName, value) == 0)
                {
                    return;
                }
                playerName = value;
                Notify("PlayerName");
            }
        }

        int moveNumber;
        /// <summary>
        /// The MoveNumber property gets and sets the number of this move of the player
        /// </summary>
        public int MoveNumber
        {
            get
            {
                return moveNumber;
            }
            set
            {
                if (moveNumber == value)
                {
                    return;
                }
                moveNumber = value;
                Notify("MoveNumber");
            }
        }

        bool isPartOfWin = false;
        /// <summary>
        /// The IsPartOfWin property gets and sets whether the move is part of all the moves of 
        /// the winner
        /// </summary>
        public bool IsPartOfWin
        {
            get
            {
                return isPartOfWin;
            }
            set
            {
                if (isPartOfWin == value)
                {
                    return;
                }
                isPartOfWin = value;
                Notify("IsPartOfWin");
            }
        }

        public PlayerMove(string playerName, int moveNumber)
        {
            this.playerName = playerName;
            this.moveNumber = moveNumber;
        }

        // INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;
        void Notify(string propName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
    }
}
