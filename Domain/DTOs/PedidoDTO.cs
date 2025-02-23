using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs
{
    public class PedidoDTO
    {
        public string NumPedido { get; set; }
        public int CantidadPedido { get; set; }
        public string CodigoEAN { get; set; }
        public string NombreProducto { get; set; }
        public string NumDocumento { get; set; }
        public string Direccion { get; set; }
    }
}
