using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriendShipManager
{
	class FriendShip
	{
		Dictionary<string, List<string>> friendsList;
		public FriendShip()
		{
			friendsList = new Dictionary<string, List<string>>();
		}
		public void MakeFriend(string nameKey, string friendName)
		{
			if (String.IsNullOrEmpty(nameKey) || String.IsNullOrEmpty(friendName))
				return;
			if (nameKey.Equals(friendName))
				return;
			if (!friendsList.ContainsKey(nameKey))
			{
				var x = new List<string>();
				x.Add(friendName);
				friendsList.Add(nameKey, x);

			}
			else if (!friendsList[nameKey].Contains(friendName))
				friendsList[nameKey].Add(friendName);
			if (!friendsList.ContainsKey(friendName))
			{
				var x = new List<string>();
				x.Add(nameKey);
				friendsList.Add(friendName, x);
			}
			else if (!friendsList[friendName].Contains(nameKey))
				friendsList[friendName].Add(nameKey);
		}

		public void UnmakeFriend(string nameKey, string friendName)
		{
			if (String.IsNullOrEmpty(nameKey) || String.IsNullOrEmpty(friendName))
				return;
			if (friendsList.ContainsKey(nameKey) && friendsList[nameKey].Contains(friendName))
			{
				friendsList[nameKey].Remove(friendName);
			}
			if (friendsList.ContainsKey(friendName) && friendsList[friendName].Contains(nameKey))
			{
				friendsList[friendName].Remove(nameKey);
			}
		}

		public List<string> GetDirectFriends(string nameKey)
		{
			if (String.IsNullOrEmpty(nameKey))
				return null;
			if (friendsList.ContainsKey(nameKey))
			{
				List<string> x = new List<string>(friendsList[nameKey]);
				if (x.Exists(a => a == nameKey))
					x.Remove(nameKey);
				return x;
			}
			return null;
		}

		public List<string> GetIndirectFriends(string nameKey)
		{
			if (String.IsNullOrEmpty(nameKey))
				return null;
			List<string> res = new List<string>();
			Dictionary<string, bool> visited = new Dictionary<string, bool>();
			visited.Add(nameKey, true);
			if (friendsList.ContainsKey(nameKey))
			{
				foreach (var x in friendsList[nameKey])
				{
					if (!visited.ContainsKey(x))
						visited.Add(x, true);
					else
						visited[x] = true;
				}
				foreach (var x in friendsList[nameKey])
				{
					if (friendsList.ContainsKey(x))
					{
						if (!visited.ContainsKey(x))
							visited.Add(x, true);
						else
							visited[x] = true;
						res.AddRange(Bfs(x, ref visited));
					}
					//if (friendsList.ContainsKey(x))
					//{
					//    foreach(var y in friendsList[x])
					//    res.AddRange(Bfs(y));
					//}
				}
			}
			List<string> y = new List<string>(GetDirectFriends(nameKey));
			foreach (var item in y)
			{
				if (res.Exists(a => a == item))
					res.Remove(item);
			}
			if (res.Exists(a => a == nameKey))
				res.Remove(nameKey);
			return res;
		}

		private List<string> Bfs(string src, ref Dictionary<string, bool> visited)
		{
			List<string> res = new List<string>();
			//Dictionary<string, bool> visited=new Dictionary<string, bool>();
			//foreach (var x in src)
			//{
			//    visited.Add(x, false);
			//}
			Queue<string> q = new Queue<string>();
			q.Enqueue(src);
			if (!visited.ContainsKey(src))
				visited.Add(src, true);
			else
				visited[src] = true;
			while (q.Count > 0)
			{
				string tmp = q.Dequeue();
				if (friendsList.ContainsKey(tmp))
				{
					foreach (var item in friendsList[tmp])
					{
						if (!visited.ContainsKey(item) || !visited[item])
						{
							res.Add(item);
							q.Enqueue(item);
							if (!visited.ContainsKey(item))
								visited.Add(item, true);
							else
								visited[item] = true;
						}
					}
				}
			}
			return res;
		}

	}
	class Program
	{
		static void Main(string[] args)
		{
			FriendShip f = new FriendShip();
			f.MakeFriend("A", "B");
			f.MakeFriend("A", "C");
			f.MakeFriend("B", "D");
			f.MakeFriend("B", "A");
			f.MakeFriend("B", "C");
			f.MakeFriend("C", "D");
			f.MakeFriend("C", "A");
			f.MakeFriend("B", "D");
			f.MakeFriend("B", "D");
			f.UnmakeFriend("A", "C");
			List<string> x = new List<string>(f.GetDirectFriends("A"));
			//foreach (var y in x)
			//	Console.WriteLine(y);
			x.Clear();
			x = f.GetIndirectFriends("A");
			foreach (var y in x)
				Console.WriteLine(y);
			Console.ReadKey(); 
		}

		/*
		 * Additional testcases
		 * MakeFriend("A","A")
         * MakeFriend("A","");
         * MakeFriend("","A");
         * MakeFriend("","");
         * 
		 * MakeFriend with an existing friend
		 * MakeFriend with a non-existing friend
		 * MakeFriend with a completely new person, not in anyone's friend list
		 * UnmakeFriend("A","A")
         * UnmakeFriend with existing friend
         * UnmakeFriend with a non-existing 
		 * 
		 *
		 */
	}
}
