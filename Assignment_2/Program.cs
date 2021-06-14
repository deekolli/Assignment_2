using System;
using System.Collections.Generic;
using System.Linq;

namespace Assignment_2
{
	class Program
	{
		static void Main(string[] args)
		{
			//Question1:
			Console.WriteLine("Question 1");
			int[] nums1 = { 4, 9, 5 };
			int[] nums2 = { 9, 4, 9, 8, 4 };
			Intersection(nums1, nums2);
			Console.WriteLine("");
			//Question 2 
			Console.WriteLine("Question 2");
			int[] nums = { 0, 1, 0, 3, 12 };
			Console.WriteLine("Enter the target number:");
			int target = Int32.Parse(Console.ReadLine());
			int pos = SearchInsert(nums, target);
			Console.WriteLine("Insert Position of the target is : {0}", pos);
			Console.WriteLine("");
			//Question3
			Console.WriteLine("Question 3");
			int[] ar3 = { 1, 2, 3, 1, 1, 3 };
			int Lnum = LuckyNumber(ar3);
			if (Lnum == -1)
				Console.WriteLine("Given Array doesn't have any lucky Integer");
			else
				Console.WriteLine("Lucky Integer for given array {0}", Lnum);

			Console.WriteLine();
			//Question 4
			Console.WriteLine("Question 4");
			Console.WriteLine("Enter the value for n:");
			int n = Int32.Parse(Console.ReadLine());
			int Ma = GenerateNums(n);
			Console.WriteLine("Maximun Element in the Generated Array is {0}", Ma);
			Console.WriteLine();

			//Question 5

			Console.WriteLine("Question 5");
			List<List<string>> cities = new List<List<string>>();
			cities.Add(new List<string>() { "London", "New York" });
			cities.Add(new List<string>() { "New York", "Tampa" });
			cities.Add(new List<string>() { "Delhi", "London" });
			string Dcity = DestCity(cities);
			Console.WriteLine("Destination City for Given Route is : {0}", Dcity);

			Console.WriteLine();
			//Question 6
			Console.WriteLine("Question 6");
			int[] Nums = { 2, 7, 11, 15 };
			int target_sum = 9;
			targetSum(Nums, target_sum);
			Console.WriteLine();

			//Question 7
			Console.WriteLine("Question 7");
			int[,] scores = { { 1, 91 }, { 1, 92 }, { 2, 93 }, { 2, 97 }, { 1, 60 }, { 2, 77 }, { 1, 65 }, { 1, 87 }, { 1, 100 }, { 2, 100 }, { 2, 76 } };
			HighFive(scores);
			Console.WriteLine();
			//Question 8
			Console.WriteLine("Question 8");
			int[] arr = { 1, 2, 3, 4 };
			int K = 2;
			RotateArray(arr, K);

			Console.WriteLine();
			//Question 9
			Console.WriteLine("Question 9");
			int[] arr9 = { 5, 4, -1, 7, 8 };
			int Ms = MaximumSum(arr9);
			Console.WriteLine("Maximun Sum contiguous subarray {0}", Ms);
			Console.WriteLine();
			//Question 10
			Console.WriteLine("Question 10");
			int[] costs = { 1, 100, 1, 1, 1, 100, 1, 1, 100, 1 };
			int minCost = MinCostToClimb(costs);
			Console.WriteLine("Minimum cost to climb the top stair {0}", minCost);
			Console.WriteLine();




		}
		public static void Intersection(int[] nums1, int[] nums2)
		{
			try
			{
				//Intialize two sets
				HashSet<int> set1 = new HashSet<int>();
				HashSet<int> set2 = new HashSet<int>();
				//Add the integers in array 1 to set 1
				for (int i = 0; i < nums1.Length; i++)
				{
					set1.Add(nums1[i]);
				}
				for (int i = 0; (i < nums2.Length); i++)
				{
					//If the number is in set1 and does not contain in set2 then add the number to set2 
					if ((set1.Contains(nums2[i])
								&& !set2.Contains(nums2[i])))
					{
						set2.Add(nums2[i]);
					}

				}
				//set2 contains a intersection of array 1 and array 2 with unique elements
				int c = set2.Count;
				//Intialize an array with the size of the hash set
				int[] arr = new int[c];
				int counter = 0;
				foreach (int curr in set2)
				{
					arr[counter++] = curr;

				}
				foreach (int a in arr)
				{
					//print 
					Console.Write("{0} ", a);
				}
			}
			catch (Exception)
			{

				throw;
			}
		}
		public static int SearchInsert(int[] nums, int target)
		{
			try
			{

				int first = 0;
				int last = nums.Length - 1;
				//Binary search 
				while (first <= last)
				{

					int middle = (first + last) / 2;
					//as the array is sorted check whether the target is in the middle of the array
					if (nums[middle] == target)
						return middle;
					//else if  the target is greater than the middle element then x can only lie in
					//the right half subarray after the mid element.
					else if (nums[middle] < target)
						first = middle + 1;
					//else the x lies in left half subarray before mid element
					else
						last = middle - 1;
				}

				return last + 1;
			}
			catch (Exception)
			{
				throw;
			}
		}
		private static int LuckyNumber(int[] nums)
		{
			try
			{
				//initialize a dictionary
				var d = new Dictionary<int, int>();
				//looping through the array
				foreach (int x in nums)
					//check the frequency
					if (d.ContainsKey(x))
						d[x] += 1;
					else
						d.Add(x, 1);

				int max = -1;
				//for each value in the dictionary d if key is equal value then return the max number
				foreach (var kv in d)
					if (kv.Key == kv.Value)
						max = Math.Max(max, kv.Key);

				return max;
			}
			catch (Exception)
			{

				throw;
			}
		}
		private static int GenerateNums(int n)
		{
			try
			{
				//if the array length is less than 2 then return the length 
				if (n < 2)
					return n;
				int[] arr = new int[n + 1];
				arr[0] = 0;
				arr[1] = 1;
				for (int i = 2; i <= n; i++)
				{
					//if  the length is multiple of 2
					if (i % 2 == 0)
					{
						arr[i] = arr[i / 2];
					}
					else
					{
						int val = (i - 1) / 2;
						arr[i] = arr[val] + arr[val + 1];
					}
				}
				//return the max integer
				return arr.ToList().Max();
			}
			catch (Exception)
			{

				throw;
			}

		}
		public static string DestCity(List<List<string>> paths)
		{
			try
			{
				//initialize a list
				List<string> list = new List<string>();
				//add the destination cities into list
				foreach (var path in paths)
				{
					list.Add(path[1]);
				}

				foreach (var path in paths)
				{
					//if the city in the list contatins in the start city remove it from the list
					if (list.Contains(path[0]))
					{
						list.Remove(path[0]);
					}

				}
				//return the destination city
				return list.Last();
			}
			catch (Exception)
			{

				throw;
			}
		}
		private static void targetSum(int[] nums, int target)
		{
			try
			{

				int i = 0, j = nums.Length - 1;

				while (i < j)
				{
					//if the sum off index i and index j is equal to target
					if (nums[i] + nums[j] == target)
					{
						Console.WriteLine("[" + (i + 1) + "," + (j + 1) + "]");
						break;
					}
					//if the sum is greater than the target 
					else if (nums[i] + nums[j] > target)
						j--;
					else
						i++;
				}



			}
			catch (Exception)
			{

				throw;
			}
		}
		private static void HighFive(int[,] items)
		{
			try
			{
				List<int[]> list = new List<int[]>();
				List<int[,]> list1 = new List<int[,]>();
				//converting to list 
				for (int i = 0; i < items.GetLength(0); i++)
				{
					list.Add(new int[] { items[i, 0], items[i, 1] });
				}
				// sorting the list
				list.Sort((p, q) => { return (p[0] < q[0]) ? -1 : ((p[0] == q[0]) ? ((p[1] <= q[1]) ? 1 : -1) : 1); });
				int a = list[0][0];
				int count = 1;
				int sum = list[0][1];

				// taking the top 5 entries of every id and computing its sum
				for (int i = 1; i < list.Count; i++)
				{
					if (list[i][0] == a && count < 5)
					{
						sum += list[i][1];
						count += 1;
					}
					else if (list[i][0] != a)
					{
						list1.Add(new int[,] { { a, sum / 5 } });

						Console.Write("[[" + a + "," + sum / 5 + "]" + ",");
						a = list[i][0];
						count = 1;
						sum = list[i][1];
					}
				}
				list1.Add(new int[,] { { a, sum / 5 } });
				Console.Write("[" + a + "," + sum / 5 + "]]");
				Console.Write("\n");

			}
			catch (Exception)
			{

				throw;
			}
		}

		private static void RotateArray(int[] arr, int n)
		{
			try
			{
				
				var index1 = 0;
				var currentIndex = 0;
				var current = arr[currentIndex];

				for (int i = 0; i < arr.Length; i++)
				{
					//the  index should be swapped to index+n,and as the length should not exceed the length of the array we are using %
					currentIndex = (currentIndex + n) % arr.Length;

					// swap current index with next index
					var temp = arr[currentIndex];
					arr[currentIndex] = current;
					current = temp;

					if (currentIndex == index1)
					{

						currentIndex = (++index1) % arr.Length;
						current = arr[currentIndex];
					}
				}
				Console.WriteLine(String.Join(",", arr));

			}
			catch (Exception)
			{

				throw;
			}
		}

		private static int MaximumSum(int[] arr)
		{
			try
			{
				
				var max1 = arr[0];
				var max2= arr[0];

				for (var i = 1; i < arr.Length; i++)
				{
					//use max method to get the max sum
					max2 = Math.Max(arr[i], max2 + arr[i]);
					max1 = Math.Max(max1, max2);
				}

				return max1;
			
			}
			catch (Exception)
			{

				throw;
			}
		}
		private static int MinCostToClimb(int[] costs)
		{
			try
			{
				int min1 = 0;
				int min2 = 0;

				for (int i = 2; i <= costs.Length; i++)
				{
					int temp = min2;
					//skip one step or two steps
					min2 = Math.Min(min1 + costs[i - 2], min2 + costs[i - 1]);
					min1 = temp;
				}

				return min2;
			
			}
			catch (Exception)
			{

				throw;
			}
		}

	}
	
}