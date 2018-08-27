using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Solution
{

	/*
     * Complete the demandingMoney function below.
     */
	static int[] demandingMoney(int[] money, int[][] roads)
	{
		/*
         * Write your code here.
         */
		int[] result = new int[2]; 
		List<Node> graphAllNodes = new List<Node>();

		for (int i = 0; i < money.Length; i++)
		{
			//Create all nodes. 
			Node n = new Node();
			n.data = money[i];
			n.connectedNodes = null;
			graphAllNodes.Add(n); 
		}

		
		//matrix.GetLength(0)
		for (int row = 0; row < roads.GetLength(0); row++)
		{
			//Each row is connected to two nodes. Add connected nodes
			int firstHouse = roads[row][0];
			int secondHouse = roads[row][1];
			graphAllNodes[firstHouse - 1].connectedNodes = new List<Node>();
			graphAllNodes[secondHouse - 1].connectedNodes = new List<Node>(); 
			graphAllNodes[firstHouse-1].connectedNodes.Add(graphAllNodes[secondHouse-1]);
			graphAllNodes[secondHouse-1].connectedNodes.Add(graphAllNodes[firstHouse-1]);
		}

		Queue<Node> q = new Queue<Node>();
		//Lets say we start from node0. 
		int MoneyCollected = 0;
		//Read node0
		Node startNode = graphAllNodes[0];
		MoneyCollected = MoneyCollected + startNode.data;
		startNode.visited = true;
		startNode.MarkAllDirectFriendsToVisited(); 
		//Now get all Indirect friends node in a list 
		List<Node> indirectFriends = new List<Node>();
		indirectFriends = startNode.GetIndirectUnvisitedFriends(graphAllNodes);
		indirectFriends.Sort(); 
		foreach (Node node in indirectFriends)
		{
			q.Enqueue(node); 
		}
		while (q.Count > 0)
		{
			Node tempNode = q.Dequeue();
			if (tempNode.visited !=true)
			{
				MoneyCollected = MoneyCollected + tempNode.data;
				tempNode.visited = true;
				tempNode.MarkAllDirectFriendsToVisited();
				indirectFriends = tempNode.GetIndirectUnvisitedFriends(graphAllNodes);
				//foreach (Node node in indirectFriends)
				//{
				//	q.Enqueue(node);
				//}
			}
		}

		return result; 
	}

	
	class Graph {
			List<Node> allNodes = new List<Node>(); 
	}

	class Node : IComparable
	{
		public int data;
		public bool visited; 
		public List<Node> connectedNodes = new List<Node>();
		public void MarkAllDirectFriendsToVisited()
		{
			foreach (Node node in connectedNodes)
			{
				if(node.visited == false)
					node.visited = true; 
			}
		}

		public List<Node> GetIndirectUnvisitedFriends(List<Node> graphAllNodes)
		{
			List<Node> nodeList = new List<Node>();
			foreach (Node node in graphAllNodes)
			{
				if (!node.Equals(this) && !this.connectedNodes.Contains(node) && node.visited != true)
				{
					nodeList.Add(node);
				}
			}
			return nodeList;
		}

		public int CompareTo(object obj)
		{
			Node nodeToCompare = obj as Node;
			if (nodeToCompare.data < data)
			{
				return 1;
			}
			if (nodeToCompare.data > data)
			{
				return -1;
			}
			// The orders are equivalent.
			return 0;
		}
	}

	static void Main(string[] args)
	{
		//TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

		string[] nm = Console.ReadLine().Split(' ');

		int n = Convert.ToInt32(nm[0]);

		int m = Convert.ToInt32(nm[1]);

		int[] money = Array.ConvertAll(Console.ReadLine().Split(' '), moneyTemp => Convert.ToInt32(moneyTemp))
		;

		int[][] roads = new int[m][];

		for (int roadsRowItr = 0; roadsRowItr < m; roadsRowItr++)
		{
			roads[roadsRowItr] = Array.ConvertAll(Console.ReadLine().Split(' '), roadsTemp => Convert.ToInt32(roadsTemp));
		}

		int[] result = demandingMoney(money, roads);

		Console.WriteLine(string.Join(" ", result));

		//textWriter.Flush();
		//textWriter.Close();
	}
}
