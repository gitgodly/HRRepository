using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace HRRepository.App_Start
{
    public class ApplicationStartup
    {
        public static void SetConnectionString()
        {
            string strCon =
              ConfigurationManager.ConnectionStrings["HRConnection"].ConnectionString;

            DbContext.SetConnectionString(strCon);

            var val = DbContext.GetConnectionString();
        }
    }
}