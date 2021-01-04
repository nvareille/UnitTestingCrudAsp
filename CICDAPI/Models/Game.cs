using System;
using System.Collections.Generic;
using System.Text;

namespace CICDAPI.Models
{
    public class Game
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }
    }

    public class GameDto
    {  
        public string Name { get; set; }
        public string Genre { get; set; }

        public void Transfert(Game game)
        {
            Name = game.Name;
            Genre = game.Genre;
        }
    }
}

