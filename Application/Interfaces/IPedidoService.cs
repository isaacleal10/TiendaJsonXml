﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Domain.DTOs;

namespace Application.Interfaces
{
    public interface IPedidoService
    {
        string ConvertirJsonAXml(PedidoDTO pedido);
        RespuestaDTO ConvertirXmlAJson(string xmlResponse);
    }
}

