using System;
using System.IO;
using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Conventions.Helpers;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using Wunschzettel.Core;
using Wunschzettel.mapping;

namespace Wunschzettel
{
    public class SessionFactoryBuilder : ISessionFactoryBuilder
    {
        public ISessionFactory CreateSessionFactory(Schema schema)
        {
            var config = this.GetMappedConfig(schema);

            return config.BuildSessionFactory();
        }

        private FluentConfiguration GetMappedConfig(Schema schema)
        {
            var config = GetConfig();

            if (schema == Schema.Rebuild)
            {
                config.ExposeConfiguration( BuildSchema);
            }

            this.AddMappingToConfig(config);

            return config;
        }

        private void BuildSchema(Configuration configuration)
        {
            new SchemaExport(configuration).Create(true, true);
        }

        private FluentConfiguration GetConfig()
        {
            var connectionString = MySQLConfiguration.Standard.ConnectionString( a =>
                {
                    a.Database("lunchplaner");
                    a.Password("tt6bne4v");
                    a.Server("localhost");
                    a.Username("root");
                });

            var config = Fluently.Configure().Database(connectionString);

            return config;
        }

        private void AddMappingToConfig(FluentConfiguration config)
        {
            config.Mappings(map => map.AutoMappings.Add(AutoMap.AssemblyOf<Person>(new AutomappingConfiguration()).Conventions.Add(DefaultCascade.All()))
                                                   .Add(AutoMap.AssemblyOf<Wish>(new AutomappingConfiguration()))
                                                   .Add(AutoMap.AssemblyOf<User>(new AutomappingConfiguration())));

        }
    }
}