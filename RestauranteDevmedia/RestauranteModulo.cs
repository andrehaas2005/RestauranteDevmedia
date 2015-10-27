using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Threading.Tasks;
using Nancy;
using Nancy.ModelBinding;
using RestauranteDevmedia.Models;
using RestauranteDevmedia.Models.Persistence;

namespace RestauranteDevmedia
{
    public class RestauranteModulo :NancyModule
    {
        private readonly IRestauranteRepository _restauranteRepository;

        public RestauranteModulo(IRestauranteRepository restauranteRepository) : base("/restaurante")
        {
            _restauranteRepository = restauranteRepository;
            Get["/"] = _ => Response.AsJson<object>(restauranteRepository.PegaTodosRegistro());
            Get["/{id:int}"] =
                _ =>
                    NegotiatorExtensions.WithModel(Negotiate.WithStatusCode(HttpStatusCode.OK),
                        restauranteRepository.Get(_.id));

            Post["/"] = _ =>
            {
                var nancyrestaurante = restauranteRepository.Adiciona(this.Bind<Restaurante>());
                return HttpStatusCode.OK;
            };

            Put["/{id:int}"] = _ =>
            {
                var nancyrestaurante = this.Bind<Restaurante>();
                nancyrestaurante.Id = _.id;
                restauranteRepository.Atualiza(nancyrestaurante);
                return (HttpStatusCode.OK);
            };

            Delete["/{id:int}"] = _ =>
            {
                restauranteRepository.Delete(_.id);
                return HttpStatusCode.OK;
            };
        }
    
    }
}