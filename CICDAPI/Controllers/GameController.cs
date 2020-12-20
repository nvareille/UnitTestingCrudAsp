using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using CICDAPI.Models;
using Newtonsoft.Json;


namespace CICDAPI.Controllers
{
    [Route("api/[controller]")]
    public class GameController : Controller
    {

        /// <summary>
        ///On affiche les objets du json dans la view 
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            List<Game> data = JsonConvert.DeserializeObject<List<Game>>(System.IO.File.ReadAllText("Libs/data.json"));
            this.ViewBag.monTitre = "Nos jeux vidéos";
            
            return View(data);
        }


        /// <summary>
        /// Page 404 pour les éventuelles erreurs (pages qui ne devraient pas exister)
        /// </summary>
        /// <returns></returns>
        [HttpGet("Error404")]
        public IActionResult Error404()
        {
            return View();
        }

        
        /// <summary>
        /// Affichage la vue de create
        /// </summary>
        /// <returns></returns>
        [HttpGet("Create")]
        public IActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Méthode create - les objets sont stockés dans le path libs/data.json
        /// </summary>
        /// <param name="game"></param>
        /// <returns></returns>
        [HttpPost("Create")]
        public IActionResult Create(Game game)
        {
            List<Game> data = JsonConvert.DeserializeObject<List<Game>>(System.IO.File.ReadAllText("Libs/data.json"));
            data.Add(game);
            string serializeJson = JsonConvert.SerializeObject(data, Formatting.Indented);
            System.IO.File.WriteAllText("Libs/data.json", serializeJson);

            return RedirectToAction("Index");
        }


        /// <summary>
        /// Affichage de la vue edit si l'objet existe dans le json sinon redirige vers la page 404
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("edit/{id}")]
        public IActionResult Edit(int id)
        {
            Game gameSelected = null;
            List<Game> data = JsonConvert.DeserializeObject<List<Game>>(System.IO.File.ReadAllText("Libs/data.json"));
            gameSelected = data.FirstOrDefault(item => item.Id == id);

            if (gameSelected == null)
            {
                return RedirectToAction("Error404");
            }

            return View(gameSelected);
        }

        /// <summary>
        /// Méthode Edit - Les objets sont modifiés dans le path Libs/data.json
        /// </summary>
        /// <param name="id"></param>
        /// <param name="game"></param>
        /// <returns></returns>
        [HttpPost("Edit/{id}")]
        public IActionResult Edit(int id, Game game)
        {
            Game gameSelected = game;
            List<Game> data = JsonConvert.DeserializeObject<List<Game>>(System.IO.File.ReadAllText("Libs/data.json"));
            gameSelected = data.FirstOrDefault(item => item.Id == id);
            gameSelected.Name = game.Name;
            gameSelected.Genre = game.Genre;

            string serializeJson = JsonConvert.SerializeObject(data, Formatting.Indented);
            System.IO.File.WriteAllText("Libs/data.json", serializeJson);
            return RedirectToAction("Index");

        }

        /// <summary>
        /// Affichage de la vue delete si l'objet existe dans le json sinon redirige vers la page 404
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            Game gameSelected = null;
            List<Game> data = JsonConvert.DeserializeObject<List<Game>>(System.IO.File.ReadAllText("Libs/data.json"));
            gameSelected = data.FirstOrDefault(item => item.Id == id);

            if (gameSelected == null)
            {
                return RedirectToAction("Error404");
            }

            return View(gameSelected); 
        }

        /// <summary>
        /// Méthode Delete - Les objets sont supprimés dans le path Libs/data.json
        /// </summary>
        /// <param name="id"></param>
        /// <param name="game"></param>
        /// <returns></returns>
        [HttpPost("Delete/{id}")]
        public IActionResult Delete(int id, Game game)
        {
            Game gameSelected = null;
            List<Game> data = JsonConvert.DeserializeObject<List<Game>>(System.IO.File.ReadAllText("Libs/data.json"));
            gameSelected = data.FirstOrDefault(item => item.Id == id);
            data.Remove(gameSelected); 

            string serializeJson = JsonConvert.SerializeObject(data, Formatting.Indented);
            System.IO.File.WriteAllText("Libs/data.json", serializeJson);
            return RedirectToAction("Index");

        }
    }
}
