using System;
using System.Collections.Generic;
using System.Linq;
using NHibernate;
using NHibernate.Dialect.Function;
using RestauranteDevmedia.Helper;
using NHibernate.Linq;
namespace RestauranteDevmedia.Models.Persistence
{
    public class RestauranteRepository : IRestauranteRepository
    {
        public RestauranteRepository()
        {
            
        }
        public Restaurante Get(int id)
        {
            using (var session = NHibernateHelper.OpenSession())
                return session.Get<Restaurante>(id);
        }

        public IEnumerable<Restaurante> PegaTodosRegistros()
        {
            using (var session = NHibernateHelper.OpenSession())
                return session.Query<Restaurante>().ToList();
        }

        public Restaurante Adiciona(Restaurante restaurante)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTrasaction())
                {
                    session.SaveOrUpdate(restaurante);
                    transaction.Commit();
                }
                return restaurante;
            }
            
        }

        public void Delete(int id)
        {
            var restaurante = Get(id);
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.Delete(restaurante);
                    transaction.Commit();
                }
            }
        }

        public bool Atualiza(Restaurante restaurante)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.SaveOrUpdate(restaurante);
                    try
                    {
                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        
                        throw;
                    }
                }
                return true;
            }
        }
    
    }
}