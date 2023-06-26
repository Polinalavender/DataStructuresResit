using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace DataStructure
{
    public class Tree<T> where T : IComparable<T>
    {
        private T[] elements;

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

        public Tree(T[] data)
        {
            elements = data;
        }

        private string[] treeArray;

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
                InsertRecursive(value, root);
            }
        }

        private void InsertRecursive(T value, TreeNode<T> node)
        {
            if (value.CompareTo(node.Value) < 0)
            {
                if (node.Left == null)
                {
                    node.Left = new TreeNode<T>(value);
                }
                else
                {
                    InsertRecursive(value, node.Left);
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
                    InsertRecursive(value, node.Right);
                }
            }
        }

        public T[] ToArray()
        {
            List<T> result = new List<T>();
            TraverseInOrder(root, result);
            return result.ToArray();
        }

        private void TraverseInOrder(TreeNode<T> node, List<T> result)
        {
            if (node != null)
            {
                TraverseInOrder(node.Left, result);
                result.Add(node.Value);
                TraverseInOrder(node.Right, result);
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

        // Bucket Sort Algorithm
        public void BucketSort()
        {
            if (root == null)
            {
                throw new InvalidOperationException("Cannot perform Bucket Sort on an empty tree.");
            }

            // Create a new tree to hold the sorted elements
            Tree<T> sortedTree = new Tree<T>();

            // Traverse the original tree and insert elements into the sorted tree
            TraverseAndInsert(root, sortedTree);

            // Convert the sorted tree to an array
            elements = sortedTree.ToArray();
        }

        // Traverse the original tree and insert elements into the sorted tree
        private void TraverseAndInsert(TreeNode<T> node, Tree<T> sortedTree)
        {
            if (node != null)
            {
                // Recursively traverse the left subtree
                TraverseAndInsert(node.Left, sortedTree);

                // Insert the current node's value into the sorted tree
                sortedTree.Insert(node.Value);

                // Recursively traverse the right subtree
                TraverseAndInsert(node.Right, sortedTree);
            }
        }



        // Linear Search Algorithm
        public int LinearSearch(T value)
        {
            return LinearSearch(root, value);
        }

        private int LinearSearch(TreeNode<T> node, T value)
        {
            if (node != null)
            {
                if (value.Equals(node.Value))
                {
                    return GetIndex(node); // Return the index directly
                }

                int leftResult = LinearSearch(node.Left, value);
                if (leftResult >= 0)
                {
                    return leftResult;
                }

                int rightResult = LinearSearch(node.Right, value);
                if (rightResult >= 0)
                {
                    return rightResult;
                }
            }

            return -1;
        }

        private int GetIndex(TreeNode<T> node)
        {
            // Traverse the tree to find the index of the node
            T[] values = ToArray();
            for (int i = 0; i < values.Length; i++)
            {
                if (values[i].Equals(node.Value))
                {
                    return i;
                }
            }

            return -1;
        }

        public void BubbleSort()
        {
            if (elements == null)
            {
                throw new ArgumentNullException(nameof(elements));
            }

            int n = elements.Length;
            bool swapped;

            for (int i = 0; i < n - 1; i++)
            {
                swapped = false;
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (elements[j].CompareTo(elements[j + 1]) > 0)
                    {
                        T temp = elements[j];
                        elements[j] = elements[j + 1];
                        elements[j + 1] = temp;
                        swapped = true;
                    }
                }

                if (!swapped)
                {
                    break;
                }
            }
        }
    }
}
