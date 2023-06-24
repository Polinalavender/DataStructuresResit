using System;
using System.Collections.Generic;

namespace DataStructure
{
    public class Tree<T> where T : IComparable<T>
    {

        // Tree Data Structure
        private class TreeNode<T>
        {
            public T Value { get; set; }
            public TreeNode<T> Left { get; set; }
            public TreeNode<T> Right { get; set; }

            public TreeNode(T value)
            {
                Value = value;
                Left = null;
                Right = null;
            }
        }

        private string[] treeArray;

        public string[] ToArray()
        {
            return treeArray;
        }

        private TreeNode<T> root;

        public Tree()
        {
            root = null;
        }

        public void Insert(T value)
        {
            if (root == null)
            {
                root = new TreeNode<T>(value);
            }
            else
            {
                Insert(root, value);
            }
        }

        private void Insert(TreeNode<T> node, T value)
        {
            if (value.CompareTo(node.Value) < 0)
            {
                if (node.Left == null)
                {
                    node.Left = new TreeNode<T>(value);
                }
                else
                {
                    Insert(node.Left, value);
                }
            }
            else
            {
                if (node.Right == null)
                {
                    node.Right = new TreeNode<T>(value);
                }
                else
                {
                    Insert(node.Right, value);
                }
            }
        }

        // Binary Search Algorithm
        public static int BinarySearch<T>(T[] arr, T value) where T : IComparable<T>
        {
            int left = 0;
            int right = arr.Length - 1;

            while (left <= right)
            {
                int mid = (left + right) / 2;
                int cmp = value.CompareTo(arr[mid]);

                if (cmp == 0)
                {
                    return mid;
                }
                else if (cmp < 0)
                {
                    right = mid - 1;
                }
                else
                {
                    left = mid + 1;
                }
            }

            return -1;
        }

        // Bubble Sort Algorithm
        public void BubbleSort(T[] arr)
        {
            if (arr == null)
            {
                throw new ArgumentNullException(nameof(arr));
            }

            int n = arr.Length;
            bool swapped;

            for (int i = 0; i < n - 1; i++)
            {
                swapped = false;
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (arr[j].CompareTo(arr[j + 1]) > 0)
                    {
                        T temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                        swapped = true;
                    }
                }

                if (!swapped)
                {
                    break;
                }
            }
        }

        // Bucket Sort Algorithm
        public static void BucketSort(int[] arr, int maxVal)
        {
            int[] bucket = new int[maxVal + 1];

            for (int i = 0; i < arr.Length; i++)
            {
                bucket[arr[i]]++;
            }

            int k = 0;

            for (int i = 0; i < bucket.Length; i++)
            {
                for (int j = 0; j < bucket[i]; j++)
                {
                    arr[k++] = i;
                }
            }
        }

        // Linear Search Algorithm
        public static int LinearSearch<T>(T[] arr, T value) where T : IComparable<T>
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i].CompareTo(value) == 0)
                {
                    return i;
                }
            }

            return -1;
        }

        internal void BubbleSort()
        {
            throw new NotImplementedException();
        }
    }
}