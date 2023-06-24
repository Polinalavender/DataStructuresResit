using System;
using System.Collections.Generic;

namespace DataStructure
{
    public class TreeNode<T>
    {
        public T Data { get; set; }
        public TreeNode<T> Left { get; set; }
        public TreeNode<T> Right { get; set; }

        public TreeNode(T data)
        {
            Data = data;
            Left = null;
            Right = null;
        }
    }

    public class BinaryTree<T>
    {
        public TreeNode<T> Root { get; set; }

        public BinaryTree()
        {
            Root = null;
        }

        public void AddLast(T value)
        {
            TreeNode<T> newNode = new TreeNode<T>(value);

            if (Root == null)
            {
                Root = newNode;
            }
            else
            {
                TreeNode<T> current = Root;
                while (current.Right != null)
                {
                    current = current.Right;
                }
                current.Right = newNode;
            }
        }

        public T[] ToArray()
        {
            List<T> list = new List<T>();
            TraverseInOrder(Root, list);
            return list.ToArray();
        }

        private void TraverseInOrder(TreeNode<T> node, List<T> list)
        {
            if (node == null)
                return;

            TraverseInOrder(node.Left, list);
            list.Add(node.Data);
            TraverseInOrder(node.Right, list);
        }


        private TreeNode<T> InsertRecursive(TreeNode<T> current, T data)
        {
            if (current == null)
            {
                return new TreeNode<T>(data);
            }

            if (Comparer<T>.Default.Compare(data, current.Data) < 0)
            {
                current.Left = InsertRecursive(current.Left, data);
            }
            else
            {
                current.Right = InsertRecursive(current.Right, data);
            }

            return current;
        }

        public void Delete(T data)
        {
            Root = DeleteRecursive(Root, data);
        }

        private TreeNode<T> DeleteRecursive(TreeNode<T> current, T data)
        {
            if (current == null)
            {
                return null;
            }

            if (Comparer<T>.Default.Compare(data, current.Data) == 0)
            {
                if (current.Left == null && current.Right == null)
                {
                    return null;
                }
                else if (current.Left == null)
                {
                    return current.Right;
                }
                else if (current.Right == null)
                {
                    return current.Left;
                }
                else
                {
                    var successor = FindMinimum(current.Right);
                    current.Data = successor.Data;
                    current.Right = DeleteRecursive(current.Right, successor.Data);
                }
            }
            else if (Comparer<T>.Default.Compare(data, current.Data) < 0)
            {
                current.Left = DeleteRecursive(current.Left, data);
            }
            else
            {
                current.Right = DeleteRecursive(current.Right, data);
            }

            return current;
        }

        private TreeNode<T> FindMinimum(TreeNode<T> current)
        {
            while (current.Left != null)
            {
                current = current.Left;
            }

            return current;
        }

        public void Clear()
        {
            Root = null;
        }
    }

    public class BubbleSort<T>
    {
        public void Sort(List<T> list)
        {
            int n = list.Count;
            bool swapped;

            for (int i = 0; i < n - 1; i++)
            {
                swapped = false;

                for (int j = 0; j < n - i - 1; j++)
                {
                    if (Comparer<T>.Default.Compare(list[j], list[j + 1]) > 0)
                    {
                        // Swap list[j] and list[j + 1]
                        T temp = list[j];
                        list[j] = list[j + 1];
                        list[j + 1] = temp;
                        swapped = true;
                    }
                }

                // If no two elements were swapped in the inner loop, then the list is already sorted
                if (!swapped)
                    break;
            }
        }
    }

    public int LinearSearch(T value)
    {
        return LinearSearchRecursive(Root, value, 0);
    }

    private int LinearSearchRecursive(TreeNode<T> node, T value, int index)
    {
        if (node == null)
            return -1;

        if (EqualityComparer<T>.Default.Equals(node.Data, value))
            return index;

        int result = LinearSearchRecursive(node.Left, value, index + 1);
        if (result == -1)
            result = LinearSearchRecursive(node.Right, value, index + 1);

        return result;
    }


    public class BucketSort<T>
    {
        public void Sort(List<T> list)
        {
            int n = list.Count;

            if (n == 0)
                return;

            // Find the minimum and maximum values in the list
            T minValue = list[0];
            T maxValue = list[0];

            for (int i = 1; i < n; i++)
            {
                if (Comparer<T>.Default.Compare(list[i], minValue) < 0)
                    minValue = list[i];

                if (Comparer<T>.Default.Compare(list[i], maxValue) > 0)
                    maxValue = list[i];
            }

            // Create buckets
            int bucketCount = Convert.ToInt32(maxValue) - Convert.ToInt32(minValue) + 1;
            List<List<T>> buckets = new List<List<T>>(bucketCount);

            for (int i = 0; i < bucketCount; i++)
                buckets.Add(new List<T>());

            // Distribute elements into buckets
            for (int i = 0; i < n; i++)
            {
                int bucketIndex = Convert.ToInt32(list[i]) - Convert.ToInt32(minValue);
                buckets[bucketIndex].Add(list[i]);
            }

            // Sort each bucket individually
            for (int i = 0; i < bucketCount; i++)
            {
                if (buckets[i].Count > 1)
                {
                    InsertionSort(buckets[i]);
                }
            }

            // Concatenate buckets
            int index = 0;
            for (int i = 0; i < bucketCount; i++)
            {
                for (int j = 0; j < buckets[i].Count; j++)
                {
                    list[index++] = buckets[i][j];
                }
            }
        }

        private void InsertionSort(List<T> list)
        {
            int n = list.Count;

            for (int i = 1; i < n; i++)
            {
                T key = list[i];
                int j = i - 1;

                while (j >= 0 && Comparer<T>.Default.Compare(list[j], key) > 0)
                {
                    list[j + 1] = list[j];
                    j = j - 1;
                }

                list[j + 1] = key;
            }
        }

    }
}
