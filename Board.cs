﻿namespace MineSweeperClasses
{
    public class Board
    {
        //Properties
        public int Size { get; set; }
        public float DifficultyLevel { get; set; }
        public Cell[,] Cells { get; set; }
        public int RewardsRemaining { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public enum GameStatus { InProgress, Won, Lost }

        // Ranodom generator
        Random random = new Random();

        // Constructor
        public Board(int size, float difficultyLevel)
        {
            Size = size;
            DifficultyLevel = difficultyLevel;
            Cells = new Cell[size, size];
            RewardsRemaining = (int)(size * size * difficultyLevel);
            InitializeBoard();
        }
        // Method to initialize the board
        private void InitializeBoard()
        {
            for (int row = 0; row < Size; row++)
            {
                for (int col = 0; col < Size; col++)
                {
                    Cells[row, col] = new Cell(row, col);
                }

            }
            SetupBombs();
            SetupRewards();
            CalculateNumberOfBombNeighbors();
            StartTime = DateTime.Now;
        }

        // Method used when a play selects a cell and chooses to play the reward
        public void UseSpecialReward()
        {
            // We will implement this method later
        }

        // Method used after the game is over to calculate the final score
        public int DetermineFinalScore()
        {
            // We will implement this method later
            return 0;
        }

        // Method to determine if cell is out of bounds
        public bool IsCellOnBoard(int row, int col)
        {
            return row >= 0 && row < Size && col >= 0 && col < Size;
        }

        // Method to calculate the number of bomb neighbors for each cell
        public void CalculateNumberOfBombNeighbors()
        {
            for (int row = 0; row < Size; row++)
            {
                for (int col = 0; col < Size; col++)
                {
                    // If the cell is not a bomb, calculate the number of bomb neighbors
                    if (!Cells[row, col].IsBomb)
                    {
                        int bombNeighbors = 0;
                        // Check the 8 surrounding cells
                        for (int i = row - 1; i <= row + 1; i++)
                        {
                            for (int j = col - 1; j <= col + 1; j++)
                            {
                                // Skip the current cell and check if the cell is on the board and if it is a bomb
                                if (!(i == row && j == col) && IsCellOnBoard(i, j) && Cells[i, j].IsBomb)
                                {
                                    bombNeighbors++;
                                }
                            }
                        }
                        // Set the number of bomb neighbors for the cell
                        Cells[row, col].NumberOfBombNeighbors = bombNeighbors;
                    }
                }
            }
        }

        // Method to determine the number of bomb neighbors for a cell
        public int GetNumberOfBombNeighbors(int i, int j)
        {
            if (IsCellOnBoard(i, j))
            {
                return Cells[i, j].NumberOfBombNeighbors;
            }
            return -1;
        }

        // Method used during setup to place bombs on the board
        private void SetupBombs()
        {
            int numberOfBombs = (int)(Size * Size * DifficultyLevel);
            int bombsPlaced = 0;
            for (int i = 0; i < numberOfBombs; i++)
            {
                int row = random.Next(Size);
                int col = random.Next(Size);
                // Place bomb if the cell is not already a bomb
                if (!Cells[row, col].IsBomb)
                {
                    Cells[row, col].IsBomb = true;
                    bombsPlaced++;
                }
            }
        }

        // Method used during setup to place rewards on the board
        private void SetupRewards()
        {
            // We will implement this method later
        }

        // Method to determine if the game is over
        public GameStatus DetermineGameStatus()
        {
            // We will implement this method later
            return GameStatus.InProgress;
        }
    }
}
