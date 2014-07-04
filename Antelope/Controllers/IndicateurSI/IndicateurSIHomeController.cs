using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MySql.Data.MySqlClient.Properties;
using MySql.Data.MySqlClient;
using MySql.Data.Types;

namespace Antelope.Controllers.IndicateurSI
{
    public class IndicateurSIHomeController : Controller
    {
        //
        // GET: /IndicateurSIHome/
        public ActionResult Index()
        {
            MySqlConnection connection = new MySqlConnection("Database=glpi; Data Source=dlf-sk8k03; User Id=export; Password=Exp0rt;");
            connection.Open();

            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM glpi_tickets";
            MySqlDataReader reader = command.ExecuteReader();

            List<String> noms = new List<String>();
            while (reader.Read())
            {
                noms.Add(reader["name"].ToString());
            }

            string[] tab = new string[noms.Count];
            for (int i = 0; i < noms.Count; i++)
            {
                tab[i] = noms[i];
            }

            ViewBag.tabTest = tab;
            reader.Close();


            return View("~/Views/IndicateurSI/IndicateurSIHome/Index.cshtml");
        }

    }
}