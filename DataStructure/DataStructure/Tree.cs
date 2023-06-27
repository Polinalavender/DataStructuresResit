using System.Collections;
using System.Xml.Linq;

public class Tree<T> where T : IComparable<T>
{
    private T[] elements;
    private int count;

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
        count = elements.Length;
    }

    //private string[] toArray;

    private TreeNode<T> root;

    public Tree()
    {
        root = null;
        count = 0;
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
        count++;
    }

    public T[] ToArray()
    {
        List<T> result = new List<T>();
        GetElements(root, result);
        return result.ToArray();

    }

    private void GetElements(TreeNode<T> node, List<T> result)
    {
        if (node != null)
        {
            result.Add(node.Value);
            GetElements(node.Left, result);
            GetElements(node.Right, result);
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

    // Bubble Sort Algorithm

    public void BubbleSort()
    {
        T[] value = ToArray();

        for (int i = 0; i < count - 1; i++)
        {
            for (int j = 0; j < count - i - 1; j++)
            {
                if (Comparer<T>.Default.Compare(value[j], value[j + 1]) > 0)
                {
                    T temp = value[j];
                    value[j] = value[j + 1];
                    value[j + 1] = temp;
                }
            }
        }
    }

    // Bucket Sort Algorithm

    public void BucketSort()
    {
        T[] value = ToArray();

        if (count <= 1)
        {
            return;
        }

        // find the minimum and maximum values in the list
        T min = value[0];
        T max = value[0];
        for (int i = 1; i < count; i++)
        {
            if (Comparer<T>.Default.Compare(value[i], min) < 0)
                min = value[i];
            if (Comparer<T>.Default.Compare(value[i], max) > 0)
                max = value[i];
        }

        int bucketCount = count;

        // make buckets
        T[][] buckets = new T[bucketCount][];
        for (int i = 0; i < bucketCount; i++)
        {
            buckets[i] = new T[count];
        }

        int[] bucketIndexes = new int[bucketCount]; // for tracking the current index for each bucket

        // assign each element to its bucket
        for (int i = 0; i < count; i++)
        {
            int bucketIndex = GetBucketIndex(value[i], min, max, bucketCount); // calculate the bucket index
            buckets[bucketIndex][bucketIndexes[bucketIndex]++] = value[i]; // place the element in the bucket and increment the bucket index
        }

        int valueIndex = 0;
        for (int i = 0; i < bucketCount; i++)
        {
            // sort using bubble sort
            for (int j = 0; j < bucketIndexes[i]; j++)
            {
                for (int k = 0; k < bucketIndexes[i] - j - 1; k++)
                {
                    if (Comparer<T>.Default.Compare(buckets[i][k], buckets[i][k + 1]) > 0)
                    {
                        T temp = buckets[i][k];
                        buckets[i][k] = buckets[i][k + 1];
                        buckets[i][k + 1] = temp;
                    }
                }
            }

            Array.Copy(buckets[i], 0, value, valueIndex, bucketIndexes[i]); // add the sorted elements to the original list
            valueIndex += bucketIndexes[i]; // update the data index for the next bucket
        }
    }

    private int GetBucketIndex(T element, T min, T max, int bucketCount)
    {
        int index = Convert.ToInt32(Math.Floor(Convert.ToDouble(bucketCount) * (Comparer<T>.Default.Compare(element, min) - Comparer<T>.Default.Compare(max, min)) / (Comparer<T>.Default.Compare(max, min) - Comparer<T>.Default.Compare(min, max))));
        if (index >= bucketCount)
        {
            index = bucketCount - 1;
        }
        else if (index < 0)
        {
            index = 0;
        }
        return index;
    }
