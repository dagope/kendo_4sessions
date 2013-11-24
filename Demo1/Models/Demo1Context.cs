using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;

namespace Demo1.Models
{
    public class Demo1Context : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public Demo1Context() : base("name=Demo1Context")
        {   
            Database.Log = message => Trace.WriteLine(message);            
        }

        public DbSet<Persona> Personas { get; set; }
    
    }
}
