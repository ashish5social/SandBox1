using CRM.CreateSampleData;

namespace CreateCRMSampleData
{
	class SampleData
	{
		/// <summary>
		/// Main method to start execution
		/// </summary>
		/// <param name="args"></param>
		static void Main(string[] args)
		{
			CreateEntity entityObj = new CreateEntity();
			entityObj.ConnectServer();
            entityObj.CreateMOProfile(); 
            //entityObj.CreateIncidents();
            //entityObj.AssignRecordsToQueues();
            //entityObj.CreateContacts("TestAshish", 2);
            //entityObj.CreateAccounts("DataLoader_Accounts", 20);
            //entityObj.CreateCustomEntity("DataLoaderEntity", false, 100);
			//entityObj.CreateCustomEntity("DataLoaderActivity1", false, 100);
			//entityObj.CreateCustomEntity("DataLoaderActivity2", false, 100);
		}
	}
}
