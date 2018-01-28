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
}