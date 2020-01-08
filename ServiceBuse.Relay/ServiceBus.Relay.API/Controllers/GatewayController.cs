using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.ServiceModel;
using Microsoft.ServiceBus;
using ProductsServer;
using Client.Models;

namespace ServiceBus.Relay.API.Controllers
{
    public class GatewayController : ApiController
    {
        static ChannelFactory<IClientsChannel> channelFactory;

        public GatewayController()
        {
            channelFactory = new ChannelFactory<IClientsChannel>(new NetTcpRelayBinding(),
                "sb://{service bus relay name}.servicebus.windows.net/clients");
            channelFactory.Endpoint.Behaviors.Add(new TransportClientEndpointBehavior
            {
                TokenProvider = TokenProvider.CreateSharedAccessSignatureTokenProvider(
                    "RootManageSharedAccessKey", "{Service Bus Relay Key}")
            });
        }
        // GET: api/Gateway
        [Route("GetClient")]
        public IEnumerable<Client.Models.Client> GetClient()
        {
            IEnumerable<Client.Models.Client> lstClients = null;
            using (IClientsChannel channel = channelFactory.CreateChannel())
            {
                try
                {

                    lstClients = from client in channel.GetClients(new ClientData { Action = "R" })
                                 select
                                    new Client.Models.Client
                                    {
                                        ClientCode = client.ClientCode,
                                        ClientName = client.ClientName,
                                        ClientOffice = client.ClientOffice,
                                        CountryCode = client.CountryCode,
                                        OrgCode = client.OrgCode
                                    };

                }
                catch (System.Exception ex)
                {
                    throw ex;
                }
            }
            return lstClients;
        }
        [Route("ManageFile")]
        public bool ManageFile()
        {
            using (IClientsChannel channel = channelFactory.CreateChannel())
            {
                try
                {

                    return channel.FileManager(new ClientData { Action = "C", ClientCode = "0001", ClientName = "A0001", ClientOffice = "O0001", CountryCode = "C0001", OrgCode = "OR0001", });

                }
                catch (System.Exception ex)
                {
                    throw ex;

                }
            }
        }
        [Route("MoveFile")]
        public bool MoveFile(ClientData _model)
        {
            using (IClientsChannel channel = channelFactory.CreateChannel())
            {
                try
                {

                    return channel.FileManager(_model);

                }
                catch (System.Exception ex)
                {
                    throw ex;

                }
            }
        }
    }
}
