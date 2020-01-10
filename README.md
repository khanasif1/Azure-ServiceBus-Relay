<p align="center">
  <img width="400" height="300" src="https://raw.githubusercontent.com/Azure/azure-relay/master/relay.png">
</p>

# Azure-ServiceBus-Relay
The Azure Relay service enables you to securely expose services that run in your corporate network to the public cloud.
WCF Relay works with the full .NET Framework and for WCF. You create a connection between your on-premises service and 
the relay service using a suite of WCF "relay" bindings. The relay bindings map to new transport binding elements designed to
create WCF channel components that integrate with Service Bus in the cloud. For more information, see getting started with WCF Relay.

<h3>PaaS Usage in Enterprises</h3>
<p align="center">
  <img  src="https://raw.githubusercontent.com/khanasif1/Azure-ServiceBus-Relay/master/ServiceBuse.Relay/Images/R1.PNG">
  <img src="https://raw.githubusercontent.com/khanasif1/Azure-ServiceBus-Relay/master/ServiceBuse.Relay/Images/R2.PNG">
  <ul>
  <li>PaaS is deployed on open internet enterprises do not allow such resources to access enterprise contents</li>
  <li>All the benefits are missed due to accessibility</li>  
</ul>

</p>
<h2>Soluition Azure  Service Bus WCF Relay</h3>
<p align="center">
  <img  src="https://raw.githubusercontent.com/khanasif1/Azure-ServiceBus-Relay/master/ServiceBuse.Relay/Images/R3.PNG">
  <ul>
  <li>Deploy WCF with relay binding in your enterprise network</li>
  <li>No enterprise security changes required eg: firewall, IP whitelisting</li>
  <li>Only Outbound channel to internet is required opened in enterrpise network</li>
</ul>
</p>
<h2>How Service Bus WCF Relay works?</h3>
<p align="center">
  <img src="https://raw.githubusercontent.com/khanasif1/Azure-ServiceBus-Relay/master/ServiceBuse.Relay/Images/R4.PNG">
  <ul>
  <li>PaaS/ Internet resource connect to Azure Service Bus Relay</li>
  <li>Azure Service Bus relay is connected to WCF relay listener inside the enterprise network</li>
  <li>WCF relay listener connects to enterprise resources, pulls data and pass it back to Azure Service bus relay which pass it back to colling resource</li>
</ul>
</p>
<h2>Azure resources you need to test solution?</h3>
<p align="center">
  <img width="400" height="300" src="https://raw.githubusercontent.com/khanasif1/Azure-ServiceBus-Relay/master/ServiceBuse.Relay/Images/Azure%20Resources.PNG">
  <ul>
  <li>Azure Virtual Network</li>
  <li>Azure SQL Database enabled with above vNet</li>
  <li>VM setup on same vNet as above</li>
  <li>Azure Service Bus Relay Service</li>
</ul>
</p>
<h3>Please check below youtube video, I have discussed in detail about the solution and how to setup the solution.</h3>

[![IMAGE ALT TEXT HERE](https://img.youtube.com/vi/xrUkdxY5jro/0.jpg)](https://www.youtube.com/watch?v=xrUkdxY5jro)

