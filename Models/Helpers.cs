using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Configuration;

namespace EgyptExcavation.Models
{
    public class Helpers
    {
		public static string GetRDSConnectionString()
		{
			var appConfig = ConfigurationManager.AppSettings;



			string dbname = appConfig["RDS_DB_NAME"];



			//if (string.IsNullOrEmpty(dbname)) return null;


			string username = appConfig["RDS_USERNAME"];
			string password = appConfig["RDS_PASSWORD"];
			string hostname = appConfig["RDS_HOSTNAME"];
			string port = appConfig["RDS_PORT"];


			//return "Data Source=" + hostname + ";Initial Catalog=ebdb" + ";User ID=" + username + ";Password=" + password + ";";
			return "Server=aa481ifd6305dd.ccdo9rv8zndw.us-east-1.rds.amazonaws.com;User ID=admin;Password=Pleasework12;MultipleActiveResultSets=true";
			//Initial Catalog=aacm4jqc85rn9z; //Database='Dbnameplz';
		}
	}
}

