using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITJob.EntityFramework.Read.Implement.Context.Implements;

namespace ITJob.EntityFramework.Read.Implement.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<ReadOnlyDataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            AutomaticMigrationDataLossAllowed = false;

            //ContextKey = this.GetType().Namespace;
        }

        protected override void Seed(ReadOnlyDataContext context)
        {

        }
    }
}
