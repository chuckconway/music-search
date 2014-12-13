using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using MusicSearch.Core.Data.Schema;
using NHibernate;
using NHibernate.Event;

namespace MusicSearch.Core.Data
{
    public class SessionFactory
    {
        /// <summary>
        /// Creates the session factory.
        /// </summary>
        /// <returns>ISessionFactory.</returns>
        public static ISessionFactory CreateSessionFactory()
        {
            return Fluently.Configure()

                .Database(MsSqlConfiguration.MsSql2012
                    .ConnectionString(c => c
                        .FromConnectionStringWithKey("SqlServer")))

                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Music>())
                .BuildConfiguration()
                .BuildSessionFactory();
        }
    }
}