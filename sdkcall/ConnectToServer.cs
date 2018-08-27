using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Sdk.Messages;
using System;
using System.Collections.Generic;
using System.IO;
using System.ServiceModel.Description;
using System.Xml;

namespace CRM.CreateSampleData
{
	class ConnectionToServer
	{
		#region Private members
		private static OrganizationServiceProxy _serviceProxy;
		private static ClientCredentials _clientCreds;
		private static OrganizationRequestCollection Requests = new OrganizationRequestCollection();
		private static ExecuteTransactionRequest request = new ExecuteTransactionRequest();
		#endregion

		#region Public members
		public static IOrganizationService _service;
		public static Dictionary<string, string> _serverConfiguration = new Dictionary<string, string>();
		public static Guid orgId;

		#endregion

		/// <summary>
		/// Function to load the local confg file
		/// </summary>
		private void InitializeKeys()
		{
			string XML_NODE_NAME_ELEMENT = "add";
			string XML_NODE_NAME_KEY = "key";
			string XML_NODE_NAME_VALUE = "value";

			XmlDocument xmldoc = new XmlDocument();

			//open the xml file and traverse till the appropriate node in it.
			FileStream fs = new FileStream("App.config", FileMode.Open, FileAccess.Read);
			xmldoc.Load(fs);
			XmlNode xmlnode = xmldoc.GetElementsByTagName("Server")[0];

			//read the key values and store them in local variable.
			using (XmlNodeReader xmlNodeReader = new XmlNodeReader(xmlnode))
			{
				if (null != xmlNodeReader)
				{
					// Move to first content node (like element node)
					xmlNodeReader.MoveToContent();
					while (xmlNodeReader.Read())
					{
						if (xmlNodeReader.Name == XML_NODE_NAME_ELEMENT)
						{
							//Read the key from the attribute
							string key = xmlNodeReader.GetAttribute(XML_NODE_NAME_KEY);
							string value = xmlNodeReader.GetAttribute(XML_NODE_NAME_VALUE);
							if (!string.IsNullOrEmpty(key))
							{
								_serverConfiguration[key] = value;
							}
						}
					}
				}
				fs.Flush();
				fs.Close();
				xmlnode = null;
			}
		}
		
		
		/// <summary>
		/// Function to make connection to specified server
		/// </summary>
		public void ConnectToServer()
		{
			string uriString;
			//Initialize the config file
			InitializeKeys();
			// Setup credential
			_clientCreds = new ClientCredentials();

			switch (_serverConfiguration["AuthenticationType"])
			{
				case "IFD":
					_clientCreds.UserName.UserName = _serverConfiguration["ServerUser"];
					_clientCreds.UserName.Password = _serverConfiguration["ServerPassword"];
					uriString = "https://" + _serverConfiguration["ServerName"] + "/XRMServices/2011/Organization.svc";
                     break;
				case "OnPrem":
				default:
					_clientCreds.Windows.ClientCredential.UserName = _serverConfiguration["ServerUser"];
					_clientCreds.Windows.ClientCredential.Password = _serverConfiguration["ServerPassword"];
					_clientCreds.Windows.ClientCredential.Domain = _serverConfiguration["ServerName"] +"dom";
					uriString = "http://" + _serverConfiguration["ServerName"] + "/" + _serverConfiguration["ServerOrgName"] + "/XRMServices/2011/Organization.svc";
					break;
			}
			
			// The DeviceIdManager class registers a computing device with Windows Live ID, through the generation of a device ID and password, 
			// and optionally stores that information in an encrypted format on the local disk for later reuse.
			// This will fail here as this vm don't have access to the Internet therefore there is no way for it to generate a device ID with login.live.com
			//_deviceCreds = DeviceIdManager.LoadOrRegisterDevice();
 
			// Connect to Crm WCF endpoint

			try
			{
				using (_serviceProxy = new OrganizationServiceProxy(new Uri(uriString),
																null,
																_clientCreds,
																null))
				{
					// require early bound type support
					_serviceProxy.ServiceConfiguration.CurrentServiceEndpoint.Behaviors.Add(new ProxyTypesBehavior());
					OrganizationServiceContext orgContext = new OrganizationServiceContext(_serviceProxy);
					_service = (IOrganizationService)_serviceProxy;
					WhoAmIRequest request = new WhoAmIRequest();

					WhoAmIResponse userResponse = (WhoAmIResponse)orgContext.Execute(request);
					Console.WriteLine("Your Crm user Guid is {0}", userResponse.UserId);

					orgId = ((WhoAmIResponse)_service.Execute(new WhoAmIRequest())).OrganizationId;
					Console.WriteLine("Your CRM Org ID is {0}:", orgId);
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex);
			}
			
		}
	}
}