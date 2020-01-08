namespace ProductsServer
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    using System.ServiceModel;

    //// Define the data contract for the service
    //[DataContract]
    //// Declare the serializable properties.
    //public class ProductData
    //{
    //    [DataMember]
    //    public string Id { get; set; }
    //    [DataMember]
    //    public string Name { get; set; }
    //    [DataMember]
    //    public string Quantity { get; set; }
    //}
    //// Define the service contract.
    //[ServiceContract]
    //interface IProducts
    //{
    //    [OperationContract]
    //    IList<ProductData> GetProducts();

    //}

    //interface IProductsChannel : IProducts, IClientChannel
    //{
    //}

    [DataContract]
    public class ClientData
    {
        [DataMember]
        public string Action { get; set; }
        [DataMember]
        public string ClientCode { get; set; }
        [DataMember]
        public string OrgCode { get; set; }
        [DataMember]
        public string ClientName { get; set; }
        [DataMember]
        public string ClientOffice { get; set; }
        [DataMember]
        public string CountryCode { get; set; }
        [DataMember]
        public string FileSource { get; set; }
        [DataMember]
        public string FileDestination{ get; set; }
    }
    [ServiceContract]
    interface IClients
    {
        [OperationContract]
        IList<ClientData> GetClients(ClientData _model);
        [OperationContract]
        bool FileManager(ClientData _model);

    }

    interface IClientsChannel : IClients, IClientChannel
    {
    }

}