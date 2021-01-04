using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CICDAPI.Models;

namespace CICDAPI
{
    public class GameRepository : IRepository<Game>
    {
        public List<Game> Games = new List<Game>();

        public List<Game> GetEntities()
        {
            // Lire fichier JSON
            
            return (Games);
        }

        public IEnumerable<Game> Filter(Func<Game, bool> fct)
        {
            return (GetEntities().Where(fct));
        }
    }
}
