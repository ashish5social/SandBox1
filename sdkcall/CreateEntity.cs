using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Metadata;
using System;
using System.Collections.Generic;

namespace CRM.CreateSampleData
{
	enum CasePriority
	{
		Normal,
		High,
		Low
	};

	enum CaseOrigin
	{
		Phone,
		Email,
		Web,
		Facebook,
		Twitter
	};
	class CreateEntity
	{
		#region Private members
		private List<Guid> entityIds = new List<Guid>();
		private List<Guid> caseIds = new List<Guid>();
		private List<Guid> queueIds = new List<Guid>();
		private List<Guid> accountIds = new List<Guid>();
		private List<Guid> contactIds = new List<Guid>();
		private EntityCollection entities = new EntityCollection();
		private Guid orgId;
		
		/// <summary>
		/// Function to connect to the server
		/// </summary>
		public void ConnectServer()
		{
			ConnectionToServer _conn = new ConnectionToServer();
			_conn.ConnectToServer();
			if(ConnectionToServer._service == null)
			{
				throw new OperationCanceledException("Server might be down!!");
			}
		}
		
		/// <summary>
		/// Function to create subject
		/// </summary>
		/// <returns></returns>
		public Guid CreateSubject()
		{
			// create a subject
			string subjectTitle = "DataLoader_Subject_Record " + DateTime.Now.ToString("yyyy.MM.dd.hh.mm.ss");
			Entity newSubject = new Entity("subject");
			//CrmSdk.Subject newSubject = new CrmSdk.Subject();
			newSubject["title"] = subjectTitle;
			newSubject["featuremask"] = new int?(1);
			Guid subjectId = CRM.CreateSampleData.ConnectionToServer._service.Create(newSubject);
			Console.WriteLine("\nCreated Subject :{0}", subjectId);
			return subjectId;
		}

        public Guid CreateMOProfile()
        {
            Entity mop = new Entity("mobileofflineprofile");
            string randomString = "" + DateTime.Now.Ticks;
            string mopName = "TestAshish" + randomString; 
            mop.Attributes["name"] = mopName;
            Guid mopId = CRM.CreateSampleData.ConnectionToServer._service.Create(mop);
            Console.WriteLine("\nCreated MOP :{0}", mopName);
            return mopId;
        }

		/// <summary>
		/// method to create contacts
		/// </summary>
		/// <param name="contactName"></param>
		/// <param name="numberOfRecords"></param>
		public List<Guid> CreateContacts(string contactName, int numberOfRecords)
		{
			Guid _contactId;
			entityIds.Clear();
			Entity contact = new Entity("contact");
			contact["firstname"] = contactName;
			contact["description"] = "This record is created via standalone console application.";
			contact["emailaddress1"] = "xyz@abc.com";
			contact["jobtitle"] = "Sample Automation";
			contact["fax"] = "33545";
			for (int i = 0; i < numberOfRecords; i++)
			{
				contact["lastname"] = "_DataLoader_Contact_Record_" + i;
				_contactId = CRM.CreateSampleData.ConnectionToServer._service.Create(contact);
				entityIds.Add(_contactId);
				//Console.WriteLine("\n Created Contact :{0}", _contactId);
			}
			return entityIds;
		}

		/// <summary>
		/// Function to create bunch of cases
		/// </summary>
		/// <param name="numberOfRecords"></param>
		public List<Guid> CreateAccounts(string accountName, int numberOfRecords)
		{
			Guid _accountId;
			// Instaniate an account object.
			Entity account = new Entity("account");
			account["name"] = accountName;
			account["address1_postalcode"] = "98052";
			account["address2_postalcode"] = null;
			account["revenue"] = new Money(5000000);
			account["creditonhold"] = false;
			// Create an account record named Fourth Coffee.
			for (int i = 0; i < numberOfRecords; i++)
			{
				account["name"] = "DataLoader_Account_"+ accountName + i;
				//entities.Entities.Add(account);
				_accountId = CRM.CreateSampleData.ConnectionToServer._service.Create(account);
				accountIds.Add(_accountId);
				//Console.Write("Created account: {0} ", _accountId);
			}
			return accountIds;
		}

		/// <summary>
		/// Method for creation of cases, number of cases to create can be passed in config file.
		/// </summary>
		/// <param name="numberOfRecords"></param>
		public List<Guid> CreateIncidents()
		{
			int numberOfRecords = Int32.Parse(ConnectionToServer._serverConfiguration["NumberOfCases"]);
			// create an account
			Guid accountId = CreateAccounts("Account", 1)[0];

			// create a subject
			Guid subjectId = CreateSubject();

			Console.WriteLine("Creating {0} cases.", numberOfRecords);
			// Create an incident
			Entity newIncident = new Entity("incident");
			string description = "This record is created via standalone console application.";
			newIncident["subjectid"] = new EntityReference("subject", subjectId);
			newIncident["customerid"] = new EntityReference("account", accountId);
			newIncident["description"] = description;

			for (int i = 0; i < numberOfRecords; i++)
			{
				newIncident["title"] = "DataLoader_Case_Record_" + i + DateTime.Now.ToString("yyyy.MM.dd.hh.mm.ss");
				entities.EntityName = "incidents";
				entities.Entities.Add(newIncident);
			}
			Console.WriteLine("\n Creating {0} cases...", numberOfRecords);
			ExecuteBatch();
			return caseIds;
		}

		/// <summary>
		/// Method to create queue, Number of queues to create can be passed in config file.
		/// </summary>
		/// <param name="queueName"></param>
		/// <returns></returns>
		public List<Guid> CreateQueues(string queueName)
		{
			Guid _queueId;
			int numberOfRecords = Int32.Parse(ConnectionToServer._serverConfiguration["NumberOfQueues"]);
			// Define some anonymous types to define the range of possible 
			// queue property values.
			var IncomingEmailDeliveryMethods = new
			{
				None = 0,
				EmailRouter = 2,
				ForwardMailbox = 3
			};

			var IncomingEmailFilteringMethods = new
			{
				AllEmailMessages = 0,
				EmailMessagesInResponseToCrmEmail = 1,
				EmailMessagesFromCrmLeadsContactsAndAccounts = 2
			};

			var OutgoingEmailDeliveryMethods = new
			{
				None = 0,
				EmailRouter = 2
			};

			var QueueViewType = new
			{
				Public = 0,
				Private = 1
			};
			// Create a queue instance and set its property values.
			Entity newQueue = new Entity("queue");
			newQueue["description"] = "This record is created via standalone console application.";
			newQueue["incomingemaildeliverymethod"] = new OptionSetValue(IncomingEmailDeliveryMethods.None);
			newQueue["incomingemailfilteringmethod"] = new OptionSetValue(IncomingEmailFilteringMethods.AllEmailMessages);
			newQueue["outgoingemaildeliverymethod"] = new OptionSetValue(OutgoingEmailDeliveryMethods.None);
			newQueue["queueviewtype"] = new OptionSetValue(QueueViewType.Private);
			// Create a new queue instance.
			for (int i = 0; i < numberOfRecords; i++)
			{
				newQueue["name"] = queueName + "_Queue_StandAlone_Record_" + i;
				_queueId = CRM.CreateSampleData.ConnectionToServer._service.Create(newQueue);
				queueIds.Add(_queueId);
				Console.WriteLine("Created queue: {0}", _queueId);
			}
			return queueIds;
		}
		/// <summary>
		/// Method to assign the records in Queue
		/// </summary>
		public void AssignRecordsToQueues()
		{
			Random rdn = new Random(0);
			AddToQueueRequest req = new AddToQueueRequest();
			int queueCount = queueIds.Count;
			if(queueCount <= 0)
			{
				throw new NullReferenceException("No queues are available to assign records.");
			}
			for (int j = 0; j < caseIds.Count; j++)
			{
				req.Target = new EntityReference("incident", caseIds[j]);
				req.DestinationQueueId = queueIds[rdn.Next(queueCount) % queueCount];
				AddToQueueResponse resp = (AddToQueueResponse)CRM.CreateSampleData.ConnectionToServer._service.Execute(req);
				Console.Write(".");
			}
			Console.WriteLine("Assigned cases to queues");
		}

		/// <summary>
		/// Method to enable feature in db
		/// </summary>
		/// <param name="feature"></param>
		public void EnableFeatureSet(string feature)
		{
			string featureset = "<features><feature xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\">" +
								"<name>" + feature + "</name>" +
								"<value>true</value>" +
								"<location>Organization</location>" +
								"<lastupdate>2015-05-29T08:59:47.547</lastupdate>" +
								"</feature></features>";
			Entity organization = new Entity("organization");
			organization["featureset"] = featureset;
			organization["organizationid"] = CRM.CreateSampleData.ConnectionToServer.orgId;
			CRM.CreateSampleData.ConnectionToServer._service.Update(organization);
			Console.WriteLine("Setup " + feature + " Sucessfully.");
		}

		/// <summary>
		/// Method to create custom entity
		/// </summary>
		/// <param name="Name"></param>
		public void CreateCustomEntity(string Name, bool isActivity, int NumberOfRecords)
		{
			string _primaryAttributeSchemaName = "new_name";
			string _primaryAttributeLogicalName = "name";
			if(isActivity)
			{
				_primaryAttributeSchemaName = "Subject";
				_primaryAttributeLogicalName = "subject";
			}
			// Create custom entity.
			CreateEntityRequest _entity = new CreateEntityRequest()
			{
				Entity = new EntityMetadata()
				{
					LogicalName = "new_" + Name,
					DisplayName = new Label(Name, 1033),
					DisplayCollectionName = new Label(Name, 1033),
					OwnershipType = OwnershipTypes.UserOwned,
					SchemaName = "new_" + Name,
					IsActivity = isActivity,
					IsAvailableOffline = true,
					IsAuditEnabled = new BooleanManagedProperty(true),
					IsMailMergeEnabled = new BooleanManagedProperty(false),
					IsVisibleInMobileClient = new BooleanManagedProperty(true),
					IsVisibleInMobile = new BooleanManagedProperty(true),
					IsReadOnlyInMobileClient = new BooleanManagedProperty(true),
					IsKnowledgeManagementEnabled = true,
					IsValidForQueue = new BooleanManagedProperty(true)
				},
				HasActivities = true,
				HasNotes = true,
				PrimaryAttribute = new StringAttributeMetadata()
				{
					SchemaName = _primaryAttributeSchemaName,
					LogicalName = _primaryAttributeLogicalName,
					RequiredLevel = new AttributeRequiredLevelManagedProperty(AttributeRequiredLevel.None),
					MaxLength = 100,
					DisplayName = new Label("Name", 1033)
				}
			};
			Console.WriteLine("\n Creating entity {0}", Name);
			CRM.CreateSampleData.ConnectionToServer._service.Execute(_entity);
			Console.WriteLine("\n Creating {0} records to entity {1}", NumberOfRecords, Name);
			AddRecordsToCustomEntity(Name, isActivity, NumberOfRecords);
		}

		/// <summary>
		/// Method to add records for custom entity
		/// </summary>
		/// <param name="NumberOfRecords"></param>
		public void AddRecordsToCustomEntity(string Name, bool isActivity, int NumberOfRecords)
		{
			// Instaniate an account object.
			Entity customentity = new Entity("new_"+Name.ToLower());
			
			// Create an account record named Fourth Coffee.
			for (int i = 0; i < NumberOfRecords; i++)
			{
				if (isActivity)
				{
					customentity["new_subject"] = Name + i + DateTime.Now.ToString("yyyy.MM.dd.hh.mm.ss");
				}
				else
				{
					customentity["new_name"] = Name + i + DateTime.Now.ToString("yyyy.MM.dd.hh.mm.ss");
				}
				entities.EntityName = "new_" + Name.ToLower();
				entities.Entities.Add(customentity);
			}
			ExecuteBatch();
		}

		#endregion

		#region Private Methods

		/// <summary>
		/// Method for Execute Multiple Request
		/// </summary>
		private void ExecuteBatch()
		{
			ExecuteMultipleRequest requestWithResults = null;
			requestWithResults = new ExecuteMultipleRequest()
			{
				// Assign settings that define execution behavior: continue on error, return responses. 
				Settings = new ExecuteMultipleSettings()
				{
					ContinueOnError = false,
					ReturnResponses = true
				},
				// Create an empty organization request collection.
				Requests = new OrganizationRequestCollection()
			};
			// Add a CreateRequest for each entity to the request collection.
			foreach (var entity in entities.Entities)
			{
				CreateRequest createRequest = new CreateRequest { Target = entity };
				requestWithResults.Requests.Add(createRequest);
			}

			// Execute all the requests in the request collection using a single web method call.
			ExecuteMultipleResponse responseWithResults =
				(ExecuteMultipleResponse)CRM.CreateSampleData.ConnectionToServer._service.Execute(requestWithResults);

			// Display the results returned in the responses.
			foreach (var responseItem in responseWithResults.Responses)
			{
				if (responseItem.Response != null)
					DisplayResponse(requestWithResults.Requests[responseItem.RequestIndex], responseItem.Response);

				else if (responseItem.Fault != null)
					DisplayFault(requestWithResults.Requests[responseItem.RequestIndex],
						responseItem.RequestIndex, responseItem.Fault);
			}

		}

		/// <summary>
		/// Display the response of an organization message request.
		/// </summary>
		/// <param name="organizationRequest">The organization message request.</param>
		/// <param name="organizationResponse">The organization message response.</param>
		private void DisplayResponse(OrganizationRequest organizationRequest, OrganizationResponse organizationResponse)
		{
			Console.WriteLine("Created " + 
							(organizationRequest.Parameters["Target"]).ToString() + 
							" with record id as " + 
							organizationResponse.Results["id"].ToString()
							);
		}

		/// <summary>
		/// Display the fault that resulted from processing an organization message request.
		/// </summary>
		/// <param name="organizationRequest">The organization message request.</param>
		/// <param name="count">nth request number from ExecuteMultiple request</param>
		/// <param name="organizationServiceFault">A WCF fault.</param>
		private void DisplayFault(OrganizationRequest organizationRequest, int count,
			OrganizationServiceFault organizationServiceFault)
		{
			Console.WriteLine("A fault occurred when processing {1} request, at index {0} in the request collection with a fault message: {2}", 
								count + 1, 
								organizationRequest.RequestName, 
								organizationServiceFault.Message);
		}
		#endregion
	}
}
