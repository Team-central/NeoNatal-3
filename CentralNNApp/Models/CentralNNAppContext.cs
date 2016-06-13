using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CentralNNApp.Models
{
    public class CentralNNAppContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public CentralNNAppContext() : base("name=CentralNN")
        {
        }

        public System.Data.Entity.DbSet<CentralNNApp.Models.Mother> Mothers { get; set; }

        public System.Data.Entity.DbSet<CentralNNApp.Models.Survey> Surveys { get; set; }

        public System.Data.Entity.DbSet<CentralNNApp.Models.Intervention> Interventions { get; set; }

        public System.Data.Entity.DbSet<CentralNNApp.Models.AspNetUser> AspNetUsers { get; set; }
    }
}
