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

                // If no two elements were swapped in the inner loop, then the tree is already sorted
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
        public void Sort(TreeNode<T> root)
        {
            int n = root.Size();

            if (n == 0)
                return;

            // Find the minimum and maximum values in the tree
            T minValue = root.GetMinValue();
            T maxValue = root.GetMaxValue();

            // Create buckets
            int bucketCount = Convert.ToInt32(maxValue) - Convert.ToInt32(minValue) + 1;
            List<TreeNode<T>> buckets = new List<TreeNode<T>>(bucketCount);

            for (int i = 0; i < bucketCount; i++)
                buckets.Add(new TreeNode<T>());

            // Distribute elements into buckets
            for (int i = 0; i < n; i++)
            {
                int bucketIndex = Convert.ToInt32(root.GetValueAt(i)) - Convert.ToInt32(minValue);
                buckets[bucketIndex].AddValue(root.GetValueAt(i));
            }

            // Sort each bucket individually
            for (int i = 0; i < bucketCount; i++)
            {
                if (buckets[i].Size() > 1)
                {
                    BubbleSort<T> bubbleSort = new BubbleSort<T>();
                    bubbleSort.Sort(buckets[i]);
                }
            }

            // Concatenate buckets
            root.Clear();

            for (int i = 0; i < bucketCount; i++)
            {
                for (int j = 0; j < buckets[i].Size(); j++)
                {
                    root.AddValue(buckets[i].GetValueAt(j));
                }
            }
        }
    }

    public class TreeNode<T>
    {
        private List<T> values;

        public TreeNode()
        {
            values = new List<T>();
        }

        public int Size()
        {
            return values.Count;
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
            values.Add(value);
        }

        public void Clear()
        {
            values.Clear();
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

}
