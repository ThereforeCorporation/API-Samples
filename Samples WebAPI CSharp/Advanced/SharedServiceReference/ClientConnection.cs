using Common;
using Common.CredentialsSupport;
using Common.NodeNameSupport;
using Common.TenantSupport;
using Common.TokenSupport;
using SharedServiceReference.ServiceRef_Update_it;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Windows.Forms;

namespace SharedServiceReference
{
    public static class ClientConnection
    {
        public static ThereforeServiceClient CreateClient()
        {
            ThereforeServiceClient client = null;

            LoginDialog dialog = new LoginDialog();
            DialogResult dialogResult = dialog.ShowDialog();

            if (dialogResult == System.Windows.Forms.DialogResult.OK)
            {
                switch (dialog.GetCrdentialsType())
                {
                    case CrdentialsType.Windows:
                        {
                            //return CreateClientWindowsAuthConfig();
                            client = CreateClientWindowsAuth();
                            break;
                        }
                    case CrdentialsType.UserName:
                        {
                            //return CreateClientBasicAuthConfig(dialog.GetUserName(), dialog.GetPassword());
                            client = CreateClientBasicAuth(dialog.GetUserName(), dialog.GetPassword());
                            break;
                        }
                    default:
                        throw new ApplicationException("Not supported dialog result");
                }

                string tenantName = dialog.GetTenantName();
                if (!String.IsNullOrEmpty(tenantName))
                {
                    TenantProviderBehavior tenantBehavior = new TenantProviderBehavior();
                    tenantBehavior.TenantName = tenantName;
                    client.Endpoint.Behaviors.Add(tenantBehavior);
                }

                string nodeName = dialog.GetNodeName();
                if (!String.IsNullOrEmpty(nodeName))
                {
                    NodeNameProviderBehavior nodeNameBehavior = new NodeNameProviderBehavior();
                    nodeNameBehavior.NodeName = nodeName;
                    client.Endpoint.Behaviors.Add(nodeNameBehavior);
                }
            }

            return client;
        }

        public static ThereforeServiceClient CreateClient(string userName, string token)
        {
            ThereforeServiceClient client = CreateClientBasicAuth(userName, token);
            ConnectionTokenBehavior tokenBehavior = new ConnectionTokenBehavior();
            tokenBehavior.Flag = 1;
            client.Endpoint.Behaviors.Add(tokenBehavior);

            return client;
        }

        private static ThereforeServiceClient CreateClientBasicAuth(string userName, string userPassword)
        {
            //TODO: update it with actual values
            string EndpointUriSoapun = "http://therefore-server-name:8000/theservice/v0001/soapun";

            //basic
            BasicHttpBinding binding = new BasicHttpBinding();
            EndpointAddress address = new EndpointAddress(EndpointUriSoapun);

            binding.Security.Mode = BasicHttpSecurityMode.TransportCredentialOnly;  //NOTE: use it for http protocol
            //binding.Security.Mode = BasicHttpSecurityMode.Transport;  //NOTE: use it for https protocol
            binding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Basic;
            binding.MaxReceivedMessageSize = int.MaxValue;
            binding.ReceiveTimeout = new System.TimeSpan(0, 20, 0);
            binding.SendTimeout = new System.TimeSpan(0, 20, 0);

            ThereforeServiceClient client = new ThereforeServiceClient(binding, address);
            client.ClientCredentials.UserName.UserName = userName;
            client.ClientCredentials.UserName.Password = userPassword;

            CredentialsCodePageProviderBehavior credentialsCodePageBehavior = new CredentialsCodePageProviderBehavior();
            credentialsCodePageBehavior.CodePageNumber = Encoding.Default.CodePage; //we are telling the server which charset is used for credentials
            client.Endpoint.Behaviors.Add(credentialsCodePageBehavior);

            return client;
        }

        private static ThereforeServiceClient CreateClientWindowsAuth()
        {
            //TODO: update it with actual values
            string EndpointUriSoapwin = "http://therefore-server-name:8000/theservice/v0001/soapwin";

            //win
            BasicHttpBinding binding = new BasicHttpBinding();
            EndpointAddress address = new EndpointAddress(EndpointUriSoapwin);

            //NOTE: use this endpoint constructor to define Service Principal Name (SPN) for given endpoint. SPN is needed for Kerberos protocol.
            //EndpointAddress endpoint = new EndpointAddress(new Uri(EndpointUriSoapwin), EndpointIdentity.CreateSpnIdentity("THEREFOREX/<FQDN_of_the_server>"));

            binding.Security.Mode = BasicHttpSecurityMode.TransportCredentialOnly;  //NOTE: use it for http protocol
            //binding.Security.Mode = BasicHttpSecurityMode.Transport;  //NOTE: use it for https protocol

            binding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Windows;
            binding.MaxReceivedMessageSize = int.MaxValue;
            binding.ReceiveTimeout = new System.TimeSpan(0, 20, 0);
            binding.SendTimeout = new System.TimeSpan(0, 20, 0);

            ThereforeServiceClient client = new ThereforeServiceClient(binding, address);
            return client;
        }

        /// <summary>
        /// Creates service client by using basic credentials.
        /// </summary>
        /// <returns></returns>
        private static ThereforeServiceClient CreateClientBasicAuthConfig(string userName, string userPassword)
        {
            ThereforeServiceClient client = new ThereforeServiceClient("ThereforeWS0001_SoapUserPassword");
            client.ClientCredentials.UserName.UserName = userName;
            client.ClientCredentials.UserName.Password = userPassword;

            return client;
        }

        /// <summary>
        /// Creates service client by using current windows user credentials.
        /// </summary>
        /// <returns></returns>
        private static ThereforeServiceClient CreateClientWindowsAuthConfig()
        {
            ThereforeServiceClient client = new ThereforeServiceClient("ThereforeWS0001_SoapWinCredentials");

            //NOTE: for Kerberos authentication SPN should be defined in configuration file
            //
            //<endpoint address="http://xxxxxxxxxx" />
            //  <identity>
            //      <servicePrincipalName value="HTTP/<FQDN>" />
            //  </identity>
            //</endpoint>
            //
            // where <FQDN> - fully qualified domain name of the server

            return client;
        }

    }
}
