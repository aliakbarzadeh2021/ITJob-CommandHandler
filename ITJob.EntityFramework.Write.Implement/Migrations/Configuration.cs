using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITJob.EntityFramework.Write.Implement.Context.Implements;

namespace ITJob.EntityFramework.Write.Implement.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<DataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;

            //ContextKey = this.GetType().Namespace;
        }

        protected override void Seed(DataContext context)
        {

        }
    }
}
