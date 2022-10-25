using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ITJob.Infrastructure.Helpers
{
    public static class ModelBuilderExtension
    {
        public static void AddMappingsFromAssemblyOf(this DbModelBuilder modelBuilder, Assembly assembly)
        {
            var entityTypes = new List<Type>();

            Array.ForEach(assembly.GetTypes().Where(type => type.BaseType != null && type.BaseType.IsGenericType && (type.BaseType.GetGenericTypeDefinition() == typeof(EntityTypeConfiguration<>))).ToArray(), delegate (Type type)
            {
                entityTypes.Add(type.BaseType.GetGenericArguments()[0]);
                dynamic instance = Activator.CreateInstance(type);
                modelBuilder.Configurations.Add(instance);
            });


            Array.ForEach(assembly.GetTypes().Where(type => type.BaseType != null && type.BaseType.IsGenericType && (type.BaseType.GetGenericTypeDefinition() == typeof(ComplexTypeConfiguration<>))).ToArray(), delegate (Type type)
            {
                dynamic instance = Activator.CreateInstance(type);
                modelBuilder.Configurations.Add(instance);
            });


            Array.ForEach(entityTypes.ToArray(), modelBuilder.RegisterEntityType);
        }


        public static void AddRegisterationFromAssemblyOf(this DbModelBuilder modelBuilder, Assembly assembly, DbContext context)
        {
            //var entityMethod = typeof(DbModelBuilder).GetMethod("Entity");

            //Array.ForEach(assembly.GetTypes().Where(type => type.GetCustomAttributes(typeof(TableAttribute)).Any()).ToArray(), modelBuilder.RegisterEntityType);

            var entityTypes =
                assembly.GetTypes()
                    .Where(
                        type =>
                            !type.IsAbstract &&
                            type.BaseType == context.GetType().GenericTypeArguments[0]
                            )
                    .ToArray();

            /* foreach (var type in entityTypes)
             {
                 entityMethod.MakeGenericMethod(type)
                   .Invoke(modelBuilder, new object[] { });
             }*/

            Array.ForEach(entityTypes, modelBuilder.RegisterEntityType);
        }
    }
}
