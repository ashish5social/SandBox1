using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArraySort
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Enter numbers with spaces");
			string s = Console.ReadLine();
			string[] sArray = s.Split(' ');
			int size = sArray.Length; 
			int[] arr = new int[sArray.Length];
			for (int i = 0; i < size; i++)
			{
				arr[i] = Int32.Parse(sArray[i]); 
			}
			int[] sortedArray = QuickSort(arr);
			Console.WriteLine("Quick Sort :"); 
			for (int j = 0; j < sortedArray.Length; j++)
			{
				Console.Write(sortedArray[j] + " "); 
			}
			Console.WriteLine();
			Console.WriteLine("Merge Sort :");
			sortedArray = MergeSort(arr);
			for (int j = 0; j < sortedArray.Length; j++)
			{
				Console.Write(sortedArray[j] + " ");
			}
			Console.WriteLine();
			Console.ReadLine(); 
		}

		public static int[] MergeSort(int[] arr)
		{
			MergeSort(arr, 0, arr.Length - 1); 
			return arr; 
		}

		public static void MergeSort(int[] arr, int low, int high)
		{
			if (low < high)
			{
				int mid = low + (high - low) / 2;
				MergeSort(arr, low, mid);
				MergeSort(arr, mid + 1, high);
				Merge(arr, low, mid, high);
			}
		}

		public static void Merge(int[] arr, int low, int mid, int high)
		{
			int lSize = mid - low + 1;
			int rSize = high - mid;

			int[] leftArray = new int[lSize];
			int[] rightArray = new int[rSize];

			for (int i = 0; i < lSize; i++)
				leftArray[i] = arr[low + i];

			for (int i = 0; i < rSize; i++)
				rightArray[i] = arr[mid + i +1];

			int i1 = 0; // Pointer in left array ; j in right array  
			int j = 0, k = low; // k will hold the actual array 
			while (i1 < lSize && j < rSize)
			{
				if (leftArray[i1] <= rightArray[j])
				{
					//If item in left array is smaller than that in right array. then move item from letr arrau to actual arry
					arr[k] = leftArray[i1];
					i1++;
				}
				else
				{
					arr[k] = rightArray[j];
					j++; 
				}
				k++; 
			}
			//Now both i1 and j will not be less than end 
			while (i1 < lSize)
			{
				arr[k] = leftArray[i1];
				i1++;
				k++; 
			}

			while (j < rSize)
			{
				arr[k] = rightArray[j];
				j++;
				k++;
			}
		}

		public static int[] QuickSort(int[] arr)
		{
			
			return QuickSort(arr, 0, arr.Length -1 ); 
			
		}

		public static int[] QuickSort(int[] arr, int l, int h) {

			if (l < h)
			{
				int p = Partition(arr, l, h);
				QuickSort(arr, l, p - 1);
				QuickSort(arr, p + 1, h);
			}
			return arr; 
		}

		public static int Partition(int[] arr, int l, int h) {
			int pivot = arr[h];
			int temp = 0; 
			int i = l - 1;  // Smaller elements index 
			for (int j = l; j < h; j++)
			{
				if (arr[j] <= pivot)
				{
					// Then send in left side, and we have index 0 created to start with
					i++;
					temp = arr[i];
					arr[i] = arr[j];
					arr[j] = arr[i];  
				}
			}
			//ith element must be lesser than pivot, so i+1th position should be swapped with pivot's position
			temp = arr[i + 1];
			arr[i + 1] = arr[h];
			arr[h] = temp;
			return i + 1;
		}
		
	}
}
