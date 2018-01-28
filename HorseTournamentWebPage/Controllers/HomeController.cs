using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Configuration;
using MySql.Data.MySqlClient;
using HorseTournamentWebPage.Models;

namespace HorseTournamentWebPage.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Results()
        {
            ViewBag.Message = "Tu bedą wyniki";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Kontakt";

            return View();
        }

        public ActionResult Tournament()
        {

            return View();
        }

        public ActionResult Players()
        {
            List<PlayerModel> player = new List<PlayerModel>();
            string constructor = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
            MySqlConnection connector = new MySqlConnection(constructor);
            string query = "SELECT * FROM Players";
            MySqlCommand command = new MySqlCommand(query);
            command.Connection = connector;
            connector.Open();
            MySqlDataReader datareader = command.ExecuteReader();
            while (datareader.Read())
            {
                player.Add(new PlayerModel
                {
                    id = Convert.ToInt32(datareader["id"]),
                    name = datareader["name"].ToString(),
                    surname =datareader["surname"].ToString(),
                    birth=datareader["birth"].ToString()
                });
            }
            connector.Close();
            return View(player);
        }

        public ActionResult Horses()
        {
            List<HorseModel> horse = new List<HorseModel>();
            string constructor = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
            MySqlConnection connector = new MySqlConnection(constructor);
            string query = "SELECT * FROM Horses";
            MySqlCommand command = new MySqlCommand(query);
            command.Connection = connector;
            connector.Open();
            MySqlDataReader datareader = command.ExecuteReader();
            while (datareader.Read())
            {
                horse.Add(new HorseModel
                {
                    id = Convert.ToInt32(datareader["id"]),
                    name = datareader["name"].ToString(),
                    year = datareader["year"].ToString(),
                    mother = datareader["mother"].ToString(),
                    father = datareader["father"].ToString()
                });
            }
            connector.Close();
            return View(horse);
        }
    }
}