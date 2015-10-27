using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestauranteDevmedia.Models
{
    public class Restaurante
    {
        public virtual int Id { get; set; }
        public virtual string Titulo { get; set; }
        public virtual string Descricao { get; set; }
        public virtual string Valor_prato{ get; set; }
        public virtual int Ordem_servico { get; set; }
        public virtual bool Prato_principal { get; set; }
        public virtual int Tipo_prato { get; set; }
        public virtual int Identificador_chamada { get; set; }
        public virtual DateTime data_cadastro { get; set; }

    }
}