using System;
using System.Collections.Generic;
using System.Text;
using CICDAPI;
using CICDAPI.Models;

namespace TestsUnitaires
{
    public class FakeGameRepository : IRepository<Game>
    {
        public List<Game> Games = new List<Game>
        {
            new Game {Genre = "RPG", Id = 1, Name = "Cyberpunk 2077"}
        };

        public List<Game> GetEntities()
        {
            return (Games);
        }

        public IEnumerable<Game> Filter(Func<Game, bool> fct)
        {
            return (new List<Game>());
        }
    }
}
