using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LaGrandeSAS.Models
{
    public class Negocio
    {
        LagrandeBDEntities Contexto;

        public void modeloDatos()
        {
            Contexto = new LagrandeBDEntities();
        }

        public List<Inventarios> ListaInventarios()
        {
            var ConsultaI = from datos in Contexto.Inventarios select datos;
            return ConsultaI.ToList();
        }

        public List<Compras> ListaCompras()
        {
            var ConsultaI = from datos in Contexto.Compras select datos;
            return ConsultaI.ToList();
        }
    }
}