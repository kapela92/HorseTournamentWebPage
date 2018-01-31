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

        public ActionResult PreResults()
        {           
            List<ResultModel> Results = new List<ResultModel>();
            string constructor = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
            MySqlConnection connector = new MySqlConnection(constructor);
            string query = "SELECT Name,Stud,Date FROM Tournament GROUP BY Name,Stud,Date";
            MySqlCommand command = new MySqlCommand(query);
            command.Connection = connector;
            connector.Open();
            MySqlDataReader datareader = command.ExecuteReader();
            while (datareader.Read())
            {
                Results.Add(new ResultModel
                {
                    tournament = datareader["Name"].ToString(),
                    location = datareader["Stud"].ToString(),
                    date = datareader["Date"].ToString()
                });
            }
            connector.Close();           
            return View(Results);
        }

        public ActionResult Results(string tournament,string location,string date)
        {
            List<ResultModel> Results = new List<ResultModel>();
            string constructor = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
            MySqlConnection connector = new MySqlConnection(constructor);
            string query = "SELECT T.Time,T.Type,T.Position,T.Points,H.Name as Horse,P.Name as PlayerName,P.Surname as PlayerSurname FROM Tournament T, Horses H, Players P WHERE T.PlayerID=P.ID AND T.HorseID=H.ID AND T.Name='"+tournament+"' AND T.Stud='"+location+"' AND T.Date='"+date+"'";
            MySqlCommand command = new MySqlCommand(query);
            command.Connection = connector;
            connector.Open();
            MySqlDataReader datareader = command.ExecuteReader();
            while (datareader.Read())
            {
                Results.Add(new ResultModel
                {                   
                    player = datareader["PlayerName"].ToString()+" "+datareader["PlayerSurname"].ToString(),
                    horse = datareader["Horse"].ToString(),
                    type = datareader["Type"].ToString(),
                    time = datareader["Time"].ToString(),
                    points = Convert.ToInt32(datareader["Points"]),
                    position = Convert.ToInt32(datareader["Position"])
                });
            }            
            connector.Close();
            ViewBag.tournament = tournament + " " + location + " " + date;
            return View(Results);
        }

        public ActionResult Contact()
        {
            
            return View();
        }

        public ActionResult Tournament()
        {
            List<ResultModel> Results = new List<ResultModel>();
            string constructor = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
            MySqlConnection connector = new MySqlConnection(constructor);
            string query = "SELECT S.Time,S.Type,S.Points,S.Hundredth,H.Name as Horse,P.Name as PlayerName,P.Surname as PlayerSurname FROM StartList S, Horses H, Players P WHERE S.PlayerID=P.ID AND S.HorseID=H.ID";
            MySqlCommand command = new MySqlCommand(query);
            command.Connection = connector;
            connector.Open();
            MySqlDataReader datareader = command.ExecuteReader();
            while (datareader.Read())
            {
                Results.Add(new ResultModel
                {                   
                    player = datareader["PlayerName"].ToString()+" "+datareader["PlayerSurname"].ToString(),
                    horse = datareader["Horse"].ToString(),
                    type = datareader["Type"].ToString(),
                    time = datareader["Time"].ToString(),
                    points = Convert.ToInt32(datareader["Points"])
                });
            }
            datareader.Close();
            query = "SELECT Name,Pleace,Date FROM TimeLimit WHERE DATE='" + DateTime.Now.Date.ToString().Remove(10, 9) + "'";
            command = new MySqlCommand(query);
            command.Connection = connector;
            datareader = command.ExecuteReader();
            while (datareader.Read())
            ViewBag.tournament = datareader["Name"].ToString() + " " + datareader["Pleace"].ToString() + " " + datareader["Date"].ToString();
                
            connector.Close();
            return View(Results);
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

        public ActionResult PlayerResults(int id, string name)
        {

            List<ResultModel> Results = new List<ResultModel>();
            string constructor = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
            MySqlConnection connector = new MySqlConnection(constructor);
            string query = "SELECT T.Name as tournament,T.Stud,T.Date,T.Type,T.Position,H.Name FROM Tournament T, Horses H WHERE PlayerID='" + id + "' AND T.HorseID=H.ID";
            MySqlCommand command = new MySqlCommand(query);
            command.Connection = connector;
            connector.Open();
            MySqlDataReader datareader = command.ExecuteReader();
            while (datareader.Read())
            {
                Results.Add(new ResultModel
                {
                    tournament = datareader["tournament"].ToString(),
                    location = datareader["Stud"].ToString(),
                    player = datareader["Name"].ToString(),
                    date = datareader["Date"].ToString(),
                    type = datareader["Type"].ToString(),
                    position = Convert.ToInt32(datareader["Position"])
                });
            }
            connector.Close();
            ViewBag.name = name;
            return View(Results);
        }

        public ActionResult HorseResults(int id, string name )
        {
            List<ResultModel> Results = new List<ResultModel>();
            string constructor = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
            MySqlConnection connector = new MySqlConnection(constructor);
            string query = "SELECT T.Name as tournament,T.Stud,T.Date,T.Type,T.Position,P.Name,P.Surname FROM Tournament T, Players P WHERE HorseID='"+id+"' AND T.PlayerID=P.ID";
            MySqlCommand command = new MySqlCommand(query);
            command.Connection = connector;
            connector.Open();
            MySqlDataReader datareader = command.ExecuteReader();
            while (datareader.Read())
            {
                Results.Add(new ResultModel
                {
                    tournament = datareader["tournament"].ToString(),
                    location = datareader["Stud"].ToString(),
                    horse = datareader["Name"].ToString() + " " + datareader["Surname"].ToString(),
                    date = datareader["Date"].ToString(),
                    type = datareader["Type"].ToString(),
                    position = Convert.ToInt32(datareader["Position"])
                });
            }
            connector.Close();
            ViewBag.name = name;
            return View(Results);
        }
    }
}
