using System;
using System.Collections.Generic;

namespace MaxMin
{
    class TreeNode
    {
        public int data;
        public TreeNode leftNode;
        public TreeNode rightNode;
    }

    class Tree
    {
        public TreeNode rootNode; 
        public TreeNode InsertToTree(TreeNode rootNode, int data)
        {
            if (rootNode == null)
            {
                rootNode = new TreeNode();
                rootNode.data = data; 
            } else if (data < rootNode.data)
            {
                rootNode.leftNode = InsertToTree(rootNode.leftNode, data); 
            } else
            {
                rootNode.rightNode = InsertToTree(rootNode.rightNode, data); 
            }
            return rootNode; 
       }

        public void PrintTree(TreeNode rootNode)
        {
            if (rootNode == null)
            {
                return;
            }
            Console.Write(rootNode.data);
            Console.Write(" ");
            PrintTree(rootNode.leftNode);
            PrintTree(rootNode.rightNode);
        }
        public int GetMax(TreeNode rootNode)
        {
            TreeNode tempNode = rootNode;
            while (tempNode.rightNode != null)
                tempNode = tempNode.rightNode;
            return tempNode.data; 
        }
        public int GetMin(TreeNode rootNode)
        {
            TreeNode tempNode = rootNode;
            while (tempNode.leftNode != null)
                tempNode = tempNode.leftNode;
            return tempNode.data; 
         }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Tree tree = new Tree();
            TreeNode rootNode = GetInputData(tree);
            tree.rootNode = rootNode;       
            char repeat = 'n';
            do
            {
                displayOptions();
                int answer;
                bool success = Int32.TryParse(Console.ReadLine(), out answer);
                switch (answer)
                {
                    case 1:
                        Console.WriteLine("Max data in tree is " + tree.GetMax(rootNode));
                        break;
                    case 2:
                        Console.WriteLine("Min data in tree is " + tree.GetMin(rootNode));
                        break;
                    case 3:
                        rootNode = GetInputData(tree); 
                        break;
                    default:
                        Console.WriteLine("You pressed wrong key");
                        break;
                }
                Console.WriteLine("Do you want to repeat? press y to repeat, press n to exit");
                repeat = Char.Parse(Console.ReadLine()); 
            } while (repeat == 'y');
            Console.ReadLine(); 
            
        }

        public static void displayOptions()
        {
            Console.WriteLine("\nWhat do you want to do? Select the number from below options e.g Enter 1 to Return max data");
            Console.WriteLine("1. Return Max data");
            Console.WriteLine("2. Return Min data");
            Console.WriteLine("3. Add some more data to existing tree");
            Console.WriteLine("4. Exit");
        }
        public static TreeNode GetInputData(Tree tree)
        {
            Console.WriteLine("Please enter one or more numbers separated by spaces");
            //Enter data. 
            string[] inputData = (Console.ReadLine()).Split(' ');
            List<int> input = new List<int>();
            TreeNode rootNode = null;
            if (tree.rootNode != null)
                rootNode = tree.rootNode; 
            foreach (string s in inputData)
            {
                input.Add(Int32.Parse(s));
            }
            foreach (int i in input)
            {
                rootNode = tree.InsertToTree(rootNode, i);
               // Console.WriteLine("Inserted {0} in tree", i);
            }
            Console.WriteLine("Currently tree is as below : ");
            tree.PrintTree(rootNode);
            Console.WriteLine("");
            return rootNode; 
        }
    }
}
