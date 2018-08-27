using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;



namespace test
{
	class Program
	{
		static void Main(string[] args)
		{
			using (WebClient webClient = new System.Net.WebClient())
			{
				string s = "spiderman"; 
				//WebClient n = new WebClient();
				var result = webClient.DownloadString("https://jsonmock.hackerrank.com/api/movies/search/?Title="+s);

				string regex = "\"page\":(\\d+),\"per_page\":(\\d+),\"total\":(\\d+),\"total_pages\":(\\d+)";
				 


					//string regex = @"\.\.\.\. (\d+) ::::: (\w+)";
				Match m = Regex.Match(result, regex);

				if (m.Success)
				{
					int v1 = int.Parse(m.Groups[1].Value);
					int v2 = int.Parse(m.Groups[2].Value);
					int v3 = int.Parse(m.Groups[3].Value);
					int v4 = int.Parse(m.Groups[4].Value);
					
					// ... Do something with these values
				}

				string regex1 = "\"Title\":\"(.*?)\",\"Type\":\"";
				MatchCollection mc = Regex.Matches(result, regex1);
				int i = 1;
				List<string> slist = new List<string>(); 
				foreach (Match match in mc)
				{
					string s1 = match.Groups[i++].Value;
					slist.Add(s1); 
				}

				foreach (string s2 in slist)
				{
					Console.WriteLine(s2); 
				}

			}
			
		}


	}
}
