using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using HMPSW.Models;

namespace HMPSW.DAL
{
    public class HMInitializer : System.Data.Entity. DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
           
        }
    }
}