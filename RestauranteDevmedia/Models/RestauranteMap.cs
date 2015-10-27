using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentNHibernate.Mapping;

namespace RestauranteDevmedia.Models
{
    public class RestauranteMap : ClassMap<Restaurante>
    {
        public RestauranteMap()
        {
            Table("restaurante");
            Id(x => x.Id, "Id").GeneratedBy.Identity().UnsavedValue(0);
            Map(x => x.Titulo).Length(100);
            Map(x => x.Descricao);
            Map(x => x.Valor_prato);
            Map(x => x.Ordem_servico);
            Map(x => x.Prato_principal);
            Map(x => x.Tipo_prato).Length(1);
            Map(x => x.Identificador_chamada);
            Map(x => x.data_cadastro);

        }
    }
}