using System;
using System.Collections.Generic;

namespace DataStructure
{
    public class TreeNode<T>
    {
        public T Data { get; set; }
        public TreeNode<T> Left { get; set; }
        public TreeNode<T> Right { get; set; }

        private T[] values;

        public TreeNode(T data)
        {
            Data = data;
            Left = null;
            Right = null;
            values = new T[8];
        }

        public int Size()
        {
            return values.Length;
        }

        public T GetValueAt(int index)
        {
            return values[index];
        }

        public void SetValueAt(int index, T value)
        {
            values[index] = value;
        }

        public void AddValue(T value)
        {

        }

        public void Clear()
        {

        }

        public T GetMinValue()
        {
            return values.Min();
        }

        public T GetMaxValue()
        {
            return values.Max();
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
        public void Sort(TreeNode<T> root)
        {
            int n = root.Size();
            bool swapped;

            for (int i = 0; i < n - 1; i++)
            {
                swapped = false;

                for (int j = 0; j < n - i - 1; j++)
                {
                    if (Comparer<T>.Default.Compare(root.GetValueAt(j), root.GetValueAt(j + 1)) > 0)
                    {
                        // Swap values in tree nodes
                        T temp = root.GetValueAt(j);
                        root.SetValueAt(j, root.GetValueAt(j + 1));
                        root.SetValueAt(j + 1, temp);
                        swapped = true;
                    }
                }

                if (!swapped)
                    break;
            }
        }
    }

    public class LinearSearch<T>
    {
        public int Search(TreeNode<T> root, T value)
        {
            for (int i = 0; i < root.Size(); i++)
            {
                if (EqualityComparer<T>.Default.Equals(root.GetValueAt(i), value))
                    return i;
            }

            return -1;
        }
    }

    public class BucketSort<T>
    {
        public void Sort(BinaryTree<T> tree)
        {
            List<T> bucket = new List<T>();
            InorderTraversal(tree.Root, bucket);

            int index = 0;
            UpdateTree(tree.Root, bucket, ref index);
        }


        private int UpdateTree(TreeNode<T> node, List<T> bucket, ref int index)
        {
            if (node == null)
                return index;

            index = UpdateTree(node.Left, bucket, ref index);
            index = UpdateTree(node.Right, bucket, ref index);

            return index;
        }

        private void InorderTraversal(TreeNode<T> node, List<T> bucket)
        {
            if (node == null)
                return;

            InorderTraversal(node.Left, bucket);

            // Add all the values from the node's array to the bucket
            for (int i = 0; i < node.Size(); i++)
            {
                T value = node.GetValueAt(i);
                if (value != null)
                    bucket.Add(value);
            }

            InorderTraversal(node.Right, bucket);
        }

        // Example usage
        static void Main(string[] args)
        {
            BinaryTree<int> tree = new BinaryTree<int>();
            tree.AddLast(8);
            tree.AddLast(4);
            tree.AddLast(12);
            tree.AddLast(2);
            tree.AddLast(6);
            tree.AddLast(10);
            tree.AddLast(14);

            Console.WriteLine("Before sorting:");
            Console.WriteLine(string.Join(", ", tree.ToArray()));
            Console.WriteLine();

            // Perform BucketSort on the tree
            BucketSort<int> sorter = new BucketSort<int>();
            sorter.Sort(tree);

            Console.WriteLine("After sorting:");
            Console.WriteLine(string.Join(", ", tree.ToArray()));
        }
    }



}
