using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace A3IanMartin
{
	public class Data
	{
		public static string GetConnectionString(string csName)
		{
			return ConfigurationManager.ConnectionStrings[csName].ConnectionString;
		}
	}
}