using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetApplication
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            TreeNode root = new TreeNode(3);
            root.left = new TreeNode(9);
            root.right = new TreeNode(20);
            root.right.left = new TreeNode(15);
            root.right.right = new TreeNode(7);

            Console.WriteLine(String.Join(" ", AverageOfLevels(root)));
        }

        #region easy

        private static int[] TwoSum(int[] nums, int target)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                int complement = target - nums[i];
                if (dict.ContainsKey(complement))
                {
                    return new int[] { dict[complement], i };
                }

                dict[nums[i]] = i;
            }

            return new int[0];
        }

        private static bool IsPalindrome(int x)
        {
            bool isPalindrome = false;
            var charArray = x.ToString().ToCharArray();

            for (int i = 0, j = charArray.Length - 1; i < charArray.Length && j >= 0; i++, j--)
            {
                isPalindrome = charArray[i] == charArray[j];
                if (isPalindrome == false) return false;
            }

            return isPalindrome;
        }

        public static bool IsPalindrome(string s)
        {
            s = s.ToLower();
            for (int i = 0, j = s.Length - 1; i < j; i++, j--)
            {
                if (s[i] != s[j]) return false;
            }

            return true;
        }

        private static void MoveZerosToEnd(int[] nums)
        {
            nums = nums.OrderBy(n => n == 0).ToArray();
        }


        private static int[] PlusOne(int[] digits)
        {
            // https://leetcode.com/problems/plus-one/description/
            int n = digits.Length;
            for (int i = n - 1; i >= 0; i--)
            {
                if (digits[i] < 9)
                {
                    digits[i]++;
                    return digits;
                }

                digits[i] = 0;
            }

            int[] newDigits = new int[n + 1];
            newDigits[0] = 1;
            return newDigits;
        }

        // https://leetcode.com/problems/average-of-levels-in-binary-tree/solutions/ 
        private static IList<double> AverageOfLevels(TreeNode root)
        {
            List<double> averages = new List<double>();
            if (root == null) return averages;
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            while (queue.Count > 0)
            {
                int size = queue.Count;
                double sum = 0;
                for (int i = 0; i < size; i++)
                {
                    TreeNode node = queue.Dequeue();
                    sum += node.val;
                    if (node.left != null) queue.Enqueue(node.left);
                    if (node.right != null) queue.Enqueue(node.right);
                }

                double average = sum / size;
                averages.Add(average);
            }

            return averages;
        }

        #endregion

        #region Helpers

        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;

            public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }

        #endregion
    }
}