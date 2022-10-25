using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITJob.EntityFramework.Write.Context.Interfaces;
using ITJob.Infrastructure.Exceptions;
using SAF.SSN.Kernel.Infrastructure.Configuration;
using ITJob.Infrastructure.Helpers;
using Configuration = ITJob.EntityFramework.Write.Implement.Migrations.Configuration;

namespace ITJob.EntityFramework.Write.Implement.Context.Implements
{
    public class DataContext : DbContext, IContext
    {

        public DataContext() : base(ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString)
        {
            Initialize();
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<PluralizingEntitySetNameConvention>();


            if (!DataProviderConfigurator.IsConfigured)
                throw new DataProviderAssembliesNotFoundException();

            //Register FluentMappings
            Array.ForEach(DataProviderConfigurator.MappingAssemblies.ToArray(), modelBuilder.AddMappingsFromAssemblyOf);

        }


        private void Initialize()
        {
            //IDataContext
            Configuration.LazyLoadingEnabled = true;
            Configuration.ProxyCreationEnabled = true;
            Configuration.ValidateOnSaveEnabled = true;
            Configuration.AutoDetectChangesEnabled = true;
            Database.CommandTimeout = 100000;

            //Database.SetInitializer(new DropCreateDatabaseAlways<DataContext>());
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<DataContext, Configuration>());
            //CompositeDatabaseInitializer<DataContext<TDataTable>> compositeDatabaseInitializer = new CompositeDatabaseInitializer<DataContext<TDataTable>>(new MigrateDatabaseToLatestVersion<DataContext<TDataTable>, Migrations.Configuration<TDataTable>>(), new IndexInitializer<DataContext<TDataTable>>());
            //Database.SetInitializer(compositeDatabaseInitializer);

        }


        public static void ExecuteMigration()
        {
            try
            {
                var dx = new DataContext();
                dx.Database.Initialize(true);
            }
            catch (Exception exception)
            {
                throw exception;
            }

        }


        public void Dispose()
        {
            // base.Dispose();
        }
    }

}
