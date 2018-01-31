using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HorseTournamentWebPage.Models
{
    public class PlayerModel
    {
        public int  id { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string birth { get; set; }

    }

    public class HorseModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public string year { get; set; }
        public string mother { get; set; }
        public string father { get; set; }
    }

    public class ResultModel
    {
        public string tournament { get; set; }
        public string location { get; set; }
        public string  player { get; set; }
        public string horse { get; set; }
        public string date { get; set; }
        public string type { get; set; }
        public int position { get; set; }
        public string time { get; set; }
        public int points { get; set; }
        public int hitt { get; set; }
    }

    public class StartListModel
    {         
        public string player { get; set; }
        public string horse { get; set; }      
        public string type { get; set; }        
        public string time { get; set; }
        public int points { get; set; }
        public int hitt { get; set; }
    }
}