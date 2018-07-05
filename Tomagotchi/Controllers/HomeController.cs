using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;

using Tamagotchi.Models;

namespace Tamagotchi.Controllers
{
    public class HomeController : Controller
    {

        [HttpGet("/form")]
        public ActionResult Form()
        {
            return View();
        }

        [HttpGet("/game")]
        public ActionResult Game()
        {
            return View(Pet.myPets[0]);

        }

        [HttpPost("/game")]
        public ActionResult GamePost()
        {
            Pet myPet = new Pet(Request.Form["new-name"]);
            return View("Game", myPet);
        }

        [HttpGet("/feed")]
        public ActionResult Feed()
        {
            Pet.myPets[0].UpdateAttributes("feed");
            return View();
        }

        [HttpGet("/play")]
        public ActionResult Play()
        {
            Pet.myPets[0].UpdateAttributes("play");
            return View();
        }

        [HttpGet("/sleep")]
        public ActionResult Sleep()
        {
            Pet.myPets[0].UpdateAttributes("sleep");
            return View();
        }
    }
}