using Moq;
using NUnit.Framework;
using RestauranteDevmedia;
using RestauranteDevmedia.Models;
using RestauranteDevmedia.Models.Persistence;
using Nancy;
using Nancy.Testing;
using RestauranteDevmedia.Exceptions;
using NUnit.Framework;

namespace RestauranteDevmediaTestes.Tests
{
    [TestFixture]
    public class PratoRestaurante
    {
        [Test]
        public void QuandoPratoNaoExistirDeveDarErro()
        {
            var mockRestauranteRepository = new Mock<IRestauranteRepository>();
            mockRestauranteRepository.Setup(d => d.Get(1))
                .Throws(new RestauranteNotFoundException("O restaurante com código 1 não foi encontrado.."));
            var browser =
                new Browser(
                    c =>
                        c.Modulo<RestauranteModulo>()
                            .Dependencies<IRestauranteRepository>(mockRestauranteRepository.Object));
            var response = browser.Get("restaurante/1",)
        }
    }
}
