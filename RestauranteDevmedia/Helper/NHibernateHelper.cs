using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using RestauranteDevmedia.Models;
using System.Linq;


namespace RestauranteDevmedia.Helper
{
    public class NHibernateHelper
    {
        public static ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }

        private static ISessionFactory _sessionFactory;
        /*  Nesta linha devem estar os dados de configuração 
        *   referents a base que está sendo utilizada, no caso,
         *   o nome da base, login e senha, caso necessário.
        */
        const string ConnectionString = @"nancyrestaurante source=Edson;initial catalog=restaurante;integrated security=True;";

        private static ISessionFactory SessionFactory
        {
            get
            {
                if (_sessionFactory == null)
                    CreateSessionFactory();
                return _sessionFactory;
            }
        }

        private static void CreateSessionFactory()
        {
            _sessionFactory =
                Fluently.Configure().Database(MsSqlConfiguration.MsSql2012.ConnectionString(ConnectionString).ShowSql)
                    .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Restaurante>())
                    .ExposeConfiguration(cfg => new SchemaExport(cfg).Create(false, false))
                    .BuildSessionFactory();
        }

    }
}