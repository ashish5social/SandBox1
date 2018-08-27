using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphTest
{
	class Program
	{
		static void Main(string[] args)
		{

			var floatNumber = 12.5523;

			var x = floatNumber - Math.Truncate(floatNumber);

			Program p = new Program();

			Graph graph = new Graph(5);
			p.addEdge(graph,1, 0);
			p.addEdge(graph,2, 1);
			p.addEdge(graph,3, 4);
			p.addEdge(graph,4, 0);

			//int V =4;
			//Graph graph = new Graph(V);
			//p.addEdge(graph,0, 1);
			//p.addEdge(graph,0, 2);
			//p.addEdge(graph,1, 2);
			//p.addEdge(graph,2, 0);
			//p.addEdge(graph,2, 3);
			//p.addEdge(graph,3, 3);

			//int V = 5;
			//Graph graph = new Graph(V);
			//p.addEdge(graph, 0, 1);
			//p.addEdge(graph, 0, 4);
			//p.addEdge(graph, 1, 2);
			//p.addEdge(graph, 1, 3);
			//p.addEdge(graph, 1, 4);
			//p.addEdge(graph, 2, 3);
			//p.addEdge(graph, 3, 4);

			// print the adjacency list representation of 
			// the above graph
			p.printGraph(graph);
			Console.WriteLine("Graph traversal : BFS");
			p.TraverseBFS(graph, 2);

			Console.WriteLine("Graph traversal : DFS");
			p.TraverseDFS(graph, 0);
			
			Console.ReadKey(); 

		}

		

		public void TraverseBFS(Graph graph, int startVertex)
		{
			if (graph.numVertices == 0)
			{
				Console.WriteLine("No vertices in graph");
				return; 
			}
			bool[] visited = new bool[graph.numVertices];
			for (int i = 0; i < graph.numVertices; i++)
			{
				visited[i] = false; 
			}
			//Mark as visited 
			visited[startVertex] = true;
			//Enque this vertex in Queue
			Queue q = new Queue(graph.numVertices);
			q.enque(startVertex);

			//No keep iterating until queue is empty 
			while (!q.IsEmpty())
			{
				int vertex = q.deque(); 
				//Print startVertex
				Console.Write(vertex);
				foreach (int item in graph.adjacenyListArray[vertex])
				{
					if (visited[item] == false)
					{
						//If current vertex is not visited, just add to the queue
						visited[item] = true;
						q.enque(item); 
					}
				}
			}
		}

		void TraverseDFS(Graph graph, int startVertex)
		{
			bool[] visited = new bool[graph.numVertices];
			// Mark all the vertices as not visited
			for (int i = 0; i < graph.numVertices; i++)
				visited[i] = false;

			for (int i = 0; i < graph.numVertices; i++)
				if (!visited[i])
					DFSUtil(graph, i, visited);
		}
		public void DFSUtil(Graph graph, int startVertex, bool[] visited)
		{
			if (graph.numVertices == 0)
			{
				Console.WriteLine("No vertices in graph");
				return;
			}
//			bool[] visited = new bool[graph.numVertices];
			//for (int i = 0; i < graph.numVertices; i++)
			//{
			//	visited[i] = false;
			//}
			//Mark as visited 
			//visited[startVertex] = true;
			//Enque this vertex in Queue
			Stack s = new Stack(graph.numVertices);
			s.push(startVertex); 

			//No keep iterating until queue is empty 
			while (!s.IsEmpty())
			{
				int vertex = s.pop();
				//Print startVertex
				if (!visited[vertex])
				{
					Console.Write(vertex);
					visited[vertex] = true; 
				}
				
				foreach (int item in graph.adjacenyListArray[vertex])
				{
					if (visited[item] == false)
					{
						//If current vertex is not visited, just add to the queue
						visited[item] = true;
						s.push(item);
					}
				}
			}
		}
		public void addEdge(Graph g, int srcVertex, int destVertex)
		{
			g.adjacenyListArray[srcVertex].AddLast(destVertex);
			//In undirected graph, opposite edge is also true, hence add 
			//g.adjacenyListArray[destVertex].AddLast(srcVertex);
		}
		public void printGraph(Graph graph)
		{
			for (int v = 0; v < graph.numVertices; v++)
			{
				Console.WriteLine("Adjacency list of vertex " + v);
				Console.Write("head");
				foreach (int pCrawl in graph.adjacenyListArray[v])
				{
					Console.Write(" -> " + pCrawl);
				}
				Console.WriteLine("\n");
			}
		}
	}

	public class Graph
	{
		//Number of vertices
		public int numVertices;
		//Array of linkedList, one linked list for each vertices. 
		public LinkedList<int>[] adjacenyListArray;

		//Constructor
		public Graph(int num)
		{
			numVertices = num;
			adjacenyListArray = new LinkedList<int>[numVertices];
			for (int i = 0; i < numVertices; i++)
			{
				//Create empty linkedlist for each vertices.
				adjacenyListArray[i] = new LinkedList<int>(); 
			}
		}
	}

	public class Stack
	{
		int top = -1;
		int[] stackData;
		int size; 
		public Stack(int size)
		{
			this.size = size;
			stackData = new int[size];
		}
		public bool IsEmpty()
		{
			return top == -1 ? true : false;
		}
		public void push(int item)
		{
			if (top == size)
			{
				Console.WriteLine("Stakc in full");
			}
			else
			{
				stackData[++top] = item;
			}
		}

		public int pop()
		{
			if (top == -1)
			{
				Console.WriteLine("Stakc in empty");
				return -1; 
			}
			else
			{
				return stackData[top--];
			}
		}

	}

	public class Queue
	{
		int front = -1;
		int back = 0;
		int count = 0; 
		int[] queueData ;
		int size;

		public Queue(int size)
		{
			this.size = size;
			queueData = new int[size]; 
		}
		public bool IsEmpty()
		{
			return count == 0 ? true : false; 
		}

		public bool IsFull()
		{
			return count == 10 ? true : false;
		}
		public void enque(int item)
		{
			if (IsFull())
			{
				Console.WriteLine("Queue is Full");
			}
			else
			{
				count++; 
				queueData[back++ % size] = item; 
			}
		}

		public int deque()
		{
			if (IsEmpty())
			{
				Console.WriteLine("Queue is empty");
				return -1;
			}
			else
			{
				count--; 
				return queueData[++front % size]; 
			}
		}
	}

}
