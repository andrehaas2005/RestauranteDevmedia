using System.Collections.Generic;

namespace RestauranteDevmedia.Models.Persistence
{
    public interface IRestauranteRepository
    {
        Restaurante Get(int id);
        IEnumerable<Restaurante> PegaTodosRegistro();
        Restaurante Adiciona(Restaurante cardapioRestaurante);
        void Delete(int id);
        bool Atualiza(Restaurante cardapioRestaurante);
    }
}