using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace JayMayNN3.Models
{
    public class JayMayNN3Context : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public JayMayNN3Context() : base("name=Client")
        {
        }

        public System.Data.Entity.DbSet<JayMayNN3.Models.Client> Clients { get; set; }

        public System.Data.Entity.DbSet<JayMayNN3.Models.Mother> Mothers { get; set; }

        public System.Data.Entity.DbSet<JayMayNN3.Models.Survey> Surveys { get; set; }

        public System.Data.Entity.DbSet<JayMayNN3.Models.Intervention> Interventions { get; set; }
    }
}
