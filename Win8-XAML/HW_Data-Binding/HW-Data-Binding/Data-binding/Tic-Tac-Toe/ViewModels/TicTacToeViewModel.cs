using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Tic_Tac_Toe.Model;

namespace Tic_Tac_Toe.ViewModels
{
    public class TicTacToeViewModel:INotifyPropertyChanged
    {
        private ObservableCollection<Cell> cells;
        private string currentPlayerName;
        private int currentMoveNumber;
        private RelayCommand moveCommand;
        private static int dimension = 3;

        public ObservableCollection<Cell> Cells
        {
            get
            {
                return cells;
            }
        }

        public string CurrentPlayerName
        {
            get
            {
                return currentPlayerName;
            }
            private set
            {
                if (currentPlayerName == value)
                {
                    return;
                }
                currentPlayerName = value;
                Notify("CurrentPlayerName");
            }
        }
        
        

        public void NewGame()
        {
            // reset the Move property of all the Cell objects         
            for (int i = 0; i < this.cells.Count; i++)
            {
                this.cells[i].Move = null;
            }

            // set the current player name and current move number            
            CurrentPlayerName = "x";
            currentMoveNumber = 1;
        }

        private bool CanMove(int cellNumber)
        {
            if (cellNumber >= dimension * dimension)
            {
                return false;
            }
            else if (cells[cellNumber].Move == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void Move(int cellNumber)
        {
            cells[cellNumber].Move = new PlayerMove(currentPlayerName, currentMoveNumber++);

            // Check if the game is over, i.e. the current player wins the game or the game is tie. If 
            // so, raise the GameOver event and starts a new game.            
            if (HasWon(currentPlayerName))
            {
                RaiseGameOverEvent(new GameOverEventArgs()
                {
                    IsTie = false,
                    WinnerName = currentPlayerName
                });
                NewGame();
            }
            else if (TieGame())
            {
                RaiseGameOverEvent(new GameOverEventArgs() { IsTie = true });
                NewGame();
            }

            // If the game isn't over, switch the current player    
            else
            {
                if (currentPlayerName.Equals("x"))
                {
                    CurrentPlayerName = "o";
                }
                else
                {
                    CurrentPlayerName = "x";
                }
            }
        }

        bool HasWon(string player)
        {

            // check the rows in the game grid       
            for (int i = 0; i <= (dimension - 1) * dimension; i += dimension)
            {
                int j = 0;
                for (; j <= dimension - 1; j++)
                {
                    if (cells[i + j].Move == null || !cells[i + j].Move.PlayerName.Equals(player))
                    {
                        break;
                    }
                }
                if (j == dimension)
                {
                    for (j = 0; j <= dimension - 1; j++)
                    {
                        cells[i + j].Move.IsPartOfWin = true;
                    }
                    return true;
                }
            }

            // check the columns in the game grid       
            for (int j = 0; j <= dimension - 1; j++)
            {
                int i = 0;
                for (; i <= (dimension - 1) * dimension; i += dimension)
                {
                    if (cells[i + j].Move == null || !cells[i + j].Move.PlayerName.Equals(player))
                    {
                        break;
                    }
                }
                if (i == dimension * dimension)
                {
                    for (i = 0; i <= (dimension - 1) * dimension; i += dimension)
                    {
                        cells[i + j].Move.IsPartOfWin = true;
                    }
                    return true;
                }
            }

            // check the diagonal line ( "\" ) in the game grid             
            int x = 0;
            for (; x < dimension * dimension; x += dimension + 1)
            {
                if (cells[x].Move == null || !cells[x].Move.PlayerName.Equals(player))
                {
                    break;
                }
            }
            if (x == dimension * dimension + dimension)
            {
                for (x = 0; x < dimension * dimension; x += dimension + 1)
                {
                    cells[x].Move.IsPartOfWin = true;
                }
                return true;
            }

            // check the diagonal line ( "/" ) in the game grid            
            int y = dimension - 1;
            for (; y <= dimension * (dimension - 1); y += dimension - 1)
            {
                if (cells[y].Move == null || !cells[y].Move.PlayerName.Equals(player))
                {
                    break;
                }
            }
            if (y == dimension * dimension - 1)
            {
                for (y = dimension - 1; y <= dimension * (dimension - 1); y += dimension - 1)
                {
                    cells[y].Move.IsPartOfWin = true;
                }
                return true;
            }

            // If all the checks above fail, return false     
            return false;
        }

        bool TieGame()
        {
            bool nomove = true;
            for (int i = 0; i < dimension * dimension; i++)
            {
                if (cells[i].Move == null)
                {
                    nomove = false;
                    break;
                }
            }
            if (nomove)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        void Notify(string propName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }

        void RaiseGameOverEvent(GameOverEventArgs e)
        {
            if (GameOverEvent != null)
            {
                GameOverEvent(this, e);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public class GameOverEventArgs : EventArgs
        {
            public bool IsTie
            {
                get;
                set;
            }
            public string WinnerName
            {
                get;
                set;
            }
        }
        public delegate void GameOverEventHandler(object sender, GameOverEventArgs e);
        public event GameOverEventHandler GameOverEvent;

    }

    
}
