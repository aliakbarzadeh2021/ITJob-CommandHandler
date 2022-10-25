using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITJob.Infrastructure.Exceptions;
using SAF.SSN.Kernel.Infrastructure.Configuration;
using ITJob.Infrastructure.Helpers;

namespace ITJob.EntityFramework.Read.Implement.Context.Implements
{
    internal class ReadOnlyDataContext : DbContext
    {
        //ApplicationSettingsFactory.GetApplicationSettings().SqlConnectionString
        public ReadOnlyDataContext() : base(ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString)
        {
            Initialize();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<PluralizingEntitySetNameConvention>();


            if (!DataProviderConfigurator.IsConfigured)
                throw new DataProviderAssembliesNotFoundException();

            //Register FluentMappings
            Array.ForEach(DataProviderConfigurator.MappingAssemblies.ToArray(), modelBuilder.AddMappingsFromAssemblyOf);


        }

        private void Initialize()
        {
            //IReadOnlyContext
            Configuration.LazyLoadingEnabled = true;
            Configuration.ProxyCreationEnabled = true;
            Configuration.ValidateOnSaveEnabled = false;
            Configuration.AutoDetectChangesEnabled = false;

            Database.SetInitializer(new NullDatabaseInitializer<ReadOnlyDataContext>());
        }

        public IQueryable<TDto> SqlQuery<TDto>(string storedProcedure, Dictionary<string, object> parameteres) where TDto : class
        {
            if (parameteres != null && parameteres.Count > 0)
            {
                object[] sqlParameters = new SqlParameter[parameteres.Count];
                int index = 0;
                foreach (var parametere in parameteres)
                {
                    SqlParameter sqlParameter = new SqlParameter(parametere.Key, parametere.Value);
                    sqlParameters[index] = sqlParameter;
                    index++;
                }
                return Database.SqlQuery<TDto>(storedProcedure, sqlParameters).AsQueryable();
            }

            return Database.SqlQuery<TDto>(storedProcedure).AsQueryable();
        }



        public static void ExecuteMigration()
        {
            try
            {
                ReadOnlyDataContext dx = new ReadOnlyDataContext();
                dx.Database.Initialize(true);
            }
            catch (Exception exception)
            {
                throw exception;
            }

        }
    }


}
