using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Therefore.WebAPI.Service.Contract.v0001.Services;
using System.ServiceModel;
using System.Windows.Forms;
using System.ServiceModel.Channels;
using Therefore.WebAPI.Service.Contract.Extensions;

namespace Common
{
    public static class ThereforeServiceConnection
    {
        //TODO: update it with actual values
        readonly static string EndpointUriSoapwin = "http://therefore-server-name:8000/theservice/v0001/soapwin";
        readonly static string EndpointUriSoapun = "http://therefore-server-name:8000/theservice/v0001/soapun";

        public static ChannelFactory<IThereforeService> CreateChannelFactory()
        {
            ChannelFactory<IThereforeService> channelFactory = null;

            LoginDialog dialog = new LoginDialog();
            DialogResult dialogResult = dialog.ShowDialog();
            if (dialogResult == System.Windows.Forms.DialogResult.OK)
            {
                switch (dialog.GetCrdentialsType())
                {
                    case CrdentialsType.Windows:
                        {
                            BasicHttpBinding binding = new BasicHttpBinding();
                            binding.Security.Mode = BasicHttpSecurityMode.TransportCredentialOnly;  //NOTE: use it for http protocol
                            //binding.Security.Mode = BasicHttpSecurityMode.Transport;  //NOTE: use it for https protocol
                            
                            binding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Windows;
                            binding.MaxReceivedMessageSize = int.MaxValue;
                            binding.ReceiveTimeout = new System.TimeSpan(0, 20, 0);
                            binding.SendTimeout = new System.TimeSpan(0, 20, 0);
                            EndpointAddress endpoint = new EndpointAddress(EndpointUriSoapwin);
                            
                            //NOTE: use this endpoint constructor to define Service Principal Name (SPN) for given endpoint. SPN is needed for Kerberos protocol.
                            //EndpointAddress endpoint = new EndpointAddress(new Uri(EndpointUriSoapwin), EndpointIdentity.CreateSpnIdentity("THEREFOREX/<FQDN_of_the_server>"));
                            
                            channelFactory = new ChannelFactory<IThereforeService>(binding, endpoint);
                            channelFactory.Credentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Impersonation;

                            break;
                        }
                    case CrdentialsType.UserName:
                        {
                            BasicHttpBinding binding = new BasicHttpBinding();
                            binding.Security.Mode = BasicHttpSecurityMode.TransportCredentialOnly; //NOTE: use it for http protocol
                            //binding.Security.Mode = BasicHttpSecurityMode.Transport;  //NOTE: use it for https protocol
                            binding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Basic;
                            binding.MaxReceivedMessageSize = int.MaxValue;
                            binding.ReceiveTimeout = new System.TimeSpan(0, 20, 0);
                            binding.SendTimeout = new System.TimeSpan(0, 20, 0);
                            EndpointAddress endpoint = new EndpointAddress(EndpointUriSoapun);
                            channelFactory = new ChannelFactory<IThereforeService>(binding, endpoint);
                            channelFactory.Credentials.UserName.UserName = dialog.GetUserName();
                            channelFactory.Credentials.UserName.Password = dialog.GetPassword();

                            CredentialsCodePageProviderBehavior credentialsCodePageBehavior = new CredentialsCodePageProviderBehavior();
                            credentialsCodePageBehavior.CodePageNumber = Encoding.Default.CodePage; //we are telling the server which charset is used for credentials
                            channelFactory.Endpoint.Behaviors.Add(credentialsCodePageBehavior);

                            break;
                        }
                }

                //setup tenant name behavior
                string tenantName = dialog.GetTenantName();
                if (!String.IsNullOrEmpty(tenantName))
                {
                    TenantProviderBehavior tenantBehavior = new TenantProviderBehavior();
                    tenantBehavior.TenantName = tenantName;
                    channelFactory.Endpoint.Behaviors.Add(tenantBehavior);
                }

                //setup language provider behavior
                LanguageProviderBehavior language = new LanguageProviderBehavior();
                language.LanguageCode = System.Globalization.CultureInfo.CurrentCulture.Name;
                channelFactory.Endpoint.Behaviors.Add(language);
            }

            return channelFactory;
        }
    }
}
