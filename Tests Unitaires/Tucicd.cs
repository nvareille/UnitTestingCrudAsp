using System;
using System.Collections;
using System.Collections.Generic;
using CICDAPI.Controllers;
using CICDAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace TestsUnitaires
{
    [TestClass]
    public class Tucicd
    {

        [TestMethod]
        public void DataIsNotEmpty()
        {
            List<Game> data = JsonConvert.DeserializeObject<List<Game>>(System.IO.File.ReadAllText("Libs/data.json"));

            Assert.IsNotNull(data, "Il contient une liste de jeux !");
        }

        [TestMethod]
        public void IndexIsOk()
        {
            GameController controller = new GameController();
            var result = controller.Index();

            Assert.IsInstanceOfType(result, typeof(ViewResult), "Il doit afficher une view !");
            Assert.IsNotNull(result, "Il ne doit pas être vide !");
        }

        [TestMethod]
        public void GetViewCreateIsOk()
        {
            GameController controller = new GameController();
            var result = controller.Create();

            Assert.IsInstanceOfType(result, typeof(Microsoft.AspNetCore.Mvc.ViewResult), "Il doit afficher une view !");
        }

        [TestMethod]
        public void CreateIsOk()
        {
            var gameCreate = new Game
            {
                Id = 666,
                Name = "Doom xD",
                Genre = "DARK"
            };

            GameController controller = new GameController();
            var result = controller.Create(gameCreate);

            Assert.IsInstanceOfType(result, typeof(Microsoft.AspNetCore.Mvc.RedirectToActionResult), "Si les changements sont post, la méthode redirect !");

        }


        [TestMethod]
        public void EditErrorIsOk()
        {
            var idTyped = 0;
            GameController controller = new GameController();
            var result = controller.Edit(idTyped);

            Assert.IsInstanceOfType(result, typeof(Microsoft.AspNetCore.Mvc.RedirectToActionResult), "Puisqu'il n'y a pas d'instance similaire à l'id écrit, on trigger le redirect 404");

        }

        // Si la méthode affiche une View = OK
        [TestMethod]
        public void GetViewEditIsOk()
        {
            GameController controller = new GameController();
            var game = new Game {Id = 1, Genre = "test", Name = "test"};
            var idTyped = game.Id;

            bool testRuntime = game is Game;
            Assert.AreEqual(testRuntime, true);

            var result = controller.Edit(idTyped);
            Assert.IsNotNull(result, "Si le resultat n'est pas null alors la vue est return");


        }

        [TestMethod]
        public void EditIsOk()
        {
            var gameSelected = new Game {Id = 1, Genre = "test", Name = "test"};

            bool testRuntime = gameSelected is Game;
            Assert.AreEqual(testRuntime, true);

            gameSelected.Genre = "test Modified";
            gameSelected.Name = "name Modified";

            GameController controller = new GameController();

            var result = controller.Edit(1);

            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            Assert.AreEqual(gameSelected.Genre, "test Modified");
            Assert.AreEqual(gameSelected.Name, "name Modified");

        }

        [TestMethod]
        public void DeleteErrorIsOk()
        {
            var idTyped = 0;
            GameController controller = new GameController();
            var result = controller.Delete(idTyped);

            Assert.IsInstanceOfType(result, typeof(Microsoft.AspNetCore.Mvc.RedirectToActionResult), "Puisqu'il n'y a pas d'instance similaire à l'id écrit, on trigger le redirect 404");

        }

        [TestMethod]
        public void GetViewDeleteIsOk()
        {
            GameController controller = new GameController();
            var game = new Game {Id = 1, Genre = "test", Name = "test"};
            var idTyped = game.Id;

            bool testRuntime = game is Game;
            Assert.AreEqual(testRuntime, true);

            var result = controller.Delete(idTyped);
            Assert.IsNotNull(result, "Si le resultat n'est pas null alors la vue est return");

        }

        [TestMethod]
        public void DeleteIsOk()
        {
            var game = new Game { Id = 1, Genre = "test", Name = "test" };

            bool testRuntime = game is Game;
            Assert.AreEqual(testRuntime, true);

            GameController controller = new GameController();
            game = null;
            var result = controller.Delete(1, game);

            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult), "Si game = null alors le redirect doit se produire");
        }

    }
}
