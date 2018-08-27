using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using Microsoft.Crm.Sdk.Messages;
using System.Net;
using System.ServiceModel.Description;
using System;

namespace ConnectToCRM
{
	class Program
	{
		public static IOrganizationService ConnecttoCRM()
		{
			//http://www.magnifez.com/console-application-to-connect-to-dynamics-365-crm-9-x-version/ This link helped. 
			IOrganizationService organizationService = null;

			String username = "admin@ashishkumarjha1.onmicrosoft.com";//eg: abc@xyz.onmicrosoft.com
			String password = "Micr0s0ft";//eg: password@123

			// Get the URL from CRM, Navigate to Settings -> Customizations -> Developer Resources
			// Copy and Paste Organization Service Endpoint Address URL
			String url = "https://ashishkumarjha1.api.crm8.dynamics.com/XRMServices/2011/Organization.svc"; //eg: https://<yourorganisationname>.api.crm8.dynamics.com/XRMServices/2011/Organization.svc
			try
			{
				ClientCredentials clientCredentials = new ClientCredentials();
				clientCredentials.UserName.UserName = username;
				clientCredentials.UserName.Password = password;

				// For Dynamics 365 Customer Engagement V9.X, set Security Protocol as TLS12
				ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

				organizationService = (IOrganizationService)new OrganizationServiceProxy(new Uri(url), null, clientCredentials, null);

				if (organizationService != null)
				{
					Guid gOrgId = ((WhoAmIResponse)organizationService.Execute(new WhoAmIRequest())).OrganizationId;
					if (gOrgId != Guid.Empty)
					{
						Console.WriteLine("Connection Established Successfully...");
					}
				}
				else
				{
					Console.WriteLine("Failed to Established Connection!!!");
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine("Exception occured - " + ex.Message);
			}
			return organizationService;

		}

		static void Main(string[] args)
		{
			//var connection = CrmConnection.Parse(ConfigurationManager.ConnectionStrings["CRMConnectionString"].ConnectionString);
			//var service = new OrganizationService(connection);

			//CrmServiceClient conn = new CrmServiceClient(ConfigurationManager.ConnectionStrings[0].ConnectionString);
			//CrmServiceClient conn = new Xrm.Tooling.Connector.CrmServiceClient(connectionString);

			// Cast the proxy client to the IOrganizationService interface.
			//IOrganizationService service = conn.OrganizationServiceProxy;

			//ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls11; 
			//ConnectionStringSettings connectionString =  new ConnectionStringSettings("CRM1", "Url=https://ashishkumarjha1.crm8.dynamics.com; Username=admin@ashishkumarjha1.onmicrosoft.com; Password=Micr0s0ft;"); 
			//CrmConnection con = new CrmConnection("CRM") ; //could have passed 
			//CrmConnection con = new CrmConnection("CRM1");
			//IOrganizationService service = new OrganizationService(con); //could have passed con here

			IOrganizationService service = ConnecttoCRM();
			var response = service.Execute(new WhoAmIRequest());
			Console.WriteLine("userID, BUID and OrgID are {0}, {1}, {2}", response["UserId"], response["BusinessUnitId"], response["OrganizationId"]); 


			Console.ReadLine(); 
		}
	}
}
