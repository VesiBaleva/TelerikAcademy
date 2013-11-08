using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tic_Tac_Toe.Model
{
    public class Cell : INotifyPropertyChanged
    {
        public Cell(int cellNumber)
        {
            this.cellNumber = cellNumber;
        }

        private int cellNumber;
        /// <summary>
        /// The readonly CellNumber property returns the number of the cell
        /// </summary>
        public int CellNumber
        {
            get
            {
                return cellNumber;
            }
        }

        private PlayerMove move;
        /// <summary>
        /// The Move property represents a player's move on the cell
        /// </summary>
        public PlayerMove Move
        {
            get
            {
                return move;
            }
            set
            {
                if (move == value)
                {
                    return;
                }
                move = value;
                Notify("Move");
            }
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
