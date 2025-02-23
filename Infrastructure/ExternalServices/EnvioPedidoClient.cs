using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Application.Interfaces;

namespace Infrastructure.ExternalServices
{
    public class EnvioPedidoClient : IEnvioPedidoClient
    {
        private readonly HttpClient _httpClient;

        public EnvioPedidoClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        //public async Task<string> EnviarPedidoAsync(string xmlPedido)
        //{
        //    var content = new StringContent(xmlPedido, Encoding.UTF8, "application/xml");
        //    var response = await _httpClient.PostAsync("https://run.mocky.io/v3/19217075-6d4e-4818-98bc-416d1feb7b84", content);
        //    return await response.Content.ReadAsStringAsync();
        //}

        public async Task<string> EnviarPedidoAsync(string xmlPedido)
        {
            // Simulación de una respuesta SOAP
            await Task.Delay(500); // Simula una espera como si fuera una petición real

            return @"<soapenv:Envelope xmlns:soapenv='http://schemas.xmlsoap.org/soap/envelope/' xmlns:env='http://WSDLs/EnvioPedidos/EnvioPedidosAcme'>
                <soapenv:Header/>
                <soapenv:Body>
                    <env:EnvioPedidoAcmeResponse>
                        <EnvioPedidoResponse>
                            <Codigo>80375472</Codigo>
                            <Mensaje>Entregado exitosamente al cliente</Mensaje>
                        </EnvioPedidoResponse>
                    </env:EnvioPedidoAcmeResponse>
                </soapenv:Body>
            </soapenv:Envelope>";
        }
    }
}

