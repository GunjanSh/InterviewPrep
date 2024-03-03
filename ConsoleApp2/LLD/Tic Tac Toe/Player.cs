using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.LLD.Tic_Tac_Toe
{
    public class Player
    {
        public int PlayerId { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public char Symbol {  get; set; }

        public Player(int playerId, string name, string email, char symbol)
        {
            PlayerId = playerId;
            Name = name;
            Email = email;
            Symbol = symbol;
        }
    }
}
