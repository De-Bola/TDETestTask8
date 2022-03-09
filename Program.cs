using System;
using System.Collections.Generic;

namespace TDETestTask8
{
	class Program
	{
		static void Main(string[] args)
		{
			List<int> input = new List<int>();

			input.Add(7);
			input.Add(1);
			input.Add(2);
			input.Add(3);
			input.Add(3);
			input.Add(4);
			input.Add(9);
			input.Add(8);
			input.Add(6);
			input.Add(5);

			int result = getMax(input);

			Console.WriteLine(result);


		}

		private static int getMax(List<int> input)
		{
			if (input.Count == 1)
			{
				return input[0];
			}

			if (input.Count == 2)
			{
				return input[0] + input[1];
			}

			List<int> output = getListOfAbsoluteSums(input);

			output.Sort();
			output.Reverse();

			int max = output[0];
			return max;
		}

		public static List<int> getListOfAbsoluteSums(List<int> input)
		{
			List<int> outputList = new List<int>();

			outputList.Add(getAbsoluteSum(input));

			List<int> tempList = reArrangeList(input);
			outputList.Add(getAbsoluteSum(tempList));

			tempList = reArrangeList(input, 1);
			outputList.Add(getAbsoluteSum(tempList));

			tempList = reArrangeList(input, 2);
			outputList.Add(getAbsoluteSum(tempList));

			return outputList;
		}

		public static int getAbsoluteSum(List<int> input)
		{
			int i;
			int j;
			int tempSum = 0;
			for(i = 0, j = i + 1; i < input.Count - 1; i++, j++)
			{
				tempSum += input[i] + input[j]; 
			}

			return tempSum;
		}

		public static List<int> reArrangeList(List<int> input, int flag = 0)
		{
			int length = input.Count;
			List<int> output = new List<int>(length);
			List<int> tempList = new List<int>();

			// make the output list become arrow head version of input list
			// output list:= sorted input list with reversed 2nd half of list
			/// might be worth exploring v-shaped list too
			input.Sort();

			if (flag == 0)
			{
				tempList.AddRange(input); // first do sorted list 
			}
			else if (flag == 1)
			{
				tempList = getArrowHeadList(input, length);
			}
			else
			{
				tempList = getVShapedList(input, length);
			}

			output.AddRange(tempList);

			return output;
		}

		private static List<int> getArrowHeadList(List<int> input, int length)
		{
			int middle = length / 2;
			int range = length - middle;

			List<int> tempList1 = input.GetRange(middle, range);
			tempList1.Reverse();

			List<int> tempList2 = input.GetRange(0, middle);
			tempList2.AddRange(tempList1);

			return tempList2;
		}
		private static List<int> getVShapedList(List<int> input, int length)
		{
			int middle = (length / 2) + 1;
			int range = length - middle;

			List<int> tempList1 = input.GetRange(middle, range);

			List<int> tempList2 = input.GetRange(0, middle);
			tempList2.Reverse();
			tempList2.AddRange(tempList1);

			return tempList2;
		}
	}
}
