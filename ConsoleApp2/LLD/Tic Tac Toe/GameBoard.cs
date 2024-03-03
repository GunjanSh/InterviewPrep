using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.LLD.Tic_Tac_Toe
{
    public class GameBoard
    {
        public char[][] Board;

        public List<Player> Players;

        Queue<Player> PlayerTurns;

        Dictionary<(char, int), int> RowFrequency = new Dictionary<(char, int), int>();
        Dictionary<(char, int), int> ColFrequency = new Dictionary<(char, int), int>();
        Dictionary<char, int> DiagFrequency = new Dictionary<char, int>();
        Dictionary<char, int> ReverseDiagFrequency = new Dictionary<char, int>();

        public GameBoard(int boardSize, List<Player> players)
        {
            Board = new char[boardSize][];
            Players = players;
            PlayerTurns = new Queue<Player>();

            for(var row = 0; row < Board.Length; row++)
            {
                Board[row] = new char[boardSize];
            }

            foreach(var player in Players)
            {
                PlayerTurns.Enqueue(player);
            }
        }

        public void StartGame()
        {
            //Max moves for a 3*3 board would be 9
            int moves = 0, movesAllowed = (this.Board.Length* this.Board[0].Length);

            while (moves < movesAllowed && this.PlayerTurns.Count > 0)
            {
                Player currentPlayer = this.PlayerTurns.Dequeue();
                Console.WriteLine("Enter the move for player {0} with symbol {1}", currentPlayer.Name, currentPlayer.Symbol);
                Console.Write("Enter row number < {0}", this.Board.Length);
                int row = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter col number < {0}", this.Board[0].Length);
                int col = Convert.ToInt32(Console.ReadLine());

                if (this.Move(row, col, currentPlayer))
                {
                    break;
                }

                moves++;
            }

            if (moves == movesAllowed)
            {
                Console.WriteLine("Match Draw");
            }
        }

        bool Move(int row, int col, Player currentPlayer)
        {
            if (row < Board.Length && col < Board.Length && this.Board[row][col] == '\0')
            {
                this.Board[row][col] = currentPlayer.Symbol;

                if (CheckWinningMove(currentPlayer, row, col))
                {
                    Console.WriteLine("Player {0} is the winner of the game", currentPlayer.Name);
                    return true;
                }

                this.PlayerTurns.Enqueue(currentPlayer);
            }

            return false;
        }

        bool CheckWinningMove(Player player, int rowNumber, int colNumber)
        {
            if (!this.RowFrequency.ContainsKey((player.Symbol, rowNumber)))
            {
                this.RowFrequency[(player.Symbol, rowNumber)] = 1;
            }
            else
            {
                this.RowFrequency[(player.Symbol, rowNumber)]++;

                if (this.RowFrequency[(player.Symbol, rowNumber)] == this.Board.Length)
                {
                    return true;
                }
            }

            if (!this.ColFrequency.ContainsKey((player.Symbol, colNumber)))
            {
                this.ColFrequency[(player.Symbol, colNumber)] = 1;
            }
            else
            {
                this.ColFrequency[(player.Symbol, colNumber)]++;

                if (this.ColFrequency[(player.Symbol, colNumber)] == this.Board.Length)
                {
                    return true;
                }
            }

            if (rowNumber == colNumber)
            {
                if (!this.DiagFrequency.ContainsKey(player.Symbol))
                {
                    this.DiagFrequency[player.Symbol] = 1;
                }
                else
                {
                    this.DiagFrequency[player.Symbol]++;

                    if (this.DiagFrequency[player.Symbol] == this.Board.Length)
                    {
                        return true;
                    }
                }
            }

            if ((rowNumber+colNumber) == this.Board.Length-1)
            {
                if (!this.ReverseDiagFrequency.ContainsKey(player.Symbol))
                {
                    this.ReverseDiagFrequency[player.Symbol] = 1;
                }
                else
                {
                    this.ReverseDiagFrequency[player.Symbol]++;

                    if (this.ReverseDiagFrequency[player.Symbol] == this.Board.Length)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
