using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Crm.Sdk;

using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Client;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Discovery;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Sdk.Client;
using System.ServiceModel.Description;
using System.ServiceModel;
using System.IdentityModel;





namespace sdkcall
{
	class Program
	{
		private static OrganizationServiceProxy _serviceProxy;
		private static ClientCredentials _clientCreds;
		//private static ClientCredentials _deviceCreds;
 
		static void Main(string[] args)
		{
			// Setup credential
			_clientCreds = new ClientCredentials();
			_clientCreds.Windows.ClientCredential.UserName = "Administrator";
			_clientCreds.Windows.ClientCredential.Password = "T!T@n1130";
			_clientCreds.Windows.ClientCredential.Domain = "atagar5dom";
			// The DeviceIdManager class registers a computing device with Windows Live ID, through the generation of a device ID and password, 
			// and optionally stores that information in an encrypted format on the local disk for later reuse.
			// This will fail here as this vm don't have access to the Internet therefore there is no way for it to generate a device ID with login.live.com
			//_deviceCreds = DeviceIdManager.LoadOrRegisterDevice();
 
			// Connect to Crm WCF endpoint
			using (_serviceProxy = new OrganizationServiceProxy(new Uri("http://atagar5/test/XRMServices/2011/Organization.svc"),
																null,
																_clientCreds,
																null))
			{
				// require early bound type support
				_serviceProxy.ServiceConfiguration.CurrentServiceEndpoint.Behaviors.Add(new ProxyTypesBehavior());
				OrganizationServiceContext orgContext = new OrganizationServiceContext(_serviceProxy);
				IOrganizationService _service = (IOrganizationService)_serviceProxy;
				WhoAmIRequest request = new WhoAmIRequest();

				WhoAmIResponse userResponse = (WhoAmIResponse)orgContext.Execute(request); 
				Console.WriteLine("Your Crm user Guid is {0}", userResponse.UserId);

				// Create the ActivityParty instance.
				//ActivityParty party = new ActivityParty
				//{
				//	PartyId = new EntityReference(SystemUser.EntityLogicalName, userResponse.UserId)
				//};

				//// Create the appointment instance.
				//Appointment  appointment = new Appointment
				//{
				//	Subject = "Test Appointment",
				//	Description = "Test Appointment created using the BookRequest Message.",
				//	ScheduledStart = DateTime.Now.AddHours(1),
				//	ScheduledEnd = DateTime.Now.AddHours(2),
				//	Location = "Office",
				//	RequiredAttendees = new ActivityParty[] { party },
				//	Organizer = new ActivityParty[] { party }
				//};

				//// Use the Book request message.
				//BookRequest book = new BookRequest
				//{
				//	Target = appointment
				//};
				//BookResponse booked = (BookResponse)_serviceProxy.Execute(book);
				//Guid _appointmentId = booked.ValidationResult.ActivityId;

				Entity en = new Entity("appointment");
				en["subject"] = "testSDk";
				en["scheduledstart"] = DateTime.Now.AddHours(5);
				en["scheduledend"] = DateTime.Now.AddHours(6);
				
				Guid appId = _service.Create(en);
				Console.WriteLine("Your Appointment Guid is {0}", appId);
				
			}
 
			Console.Read();
		}

	}
}