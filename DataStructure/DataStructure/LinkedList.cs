using System;
using System.Xml.Linq;

namespace DataStructure
{
    public class LinkedList<T>
    {
        private class Node
        {
            public T Value { get; }
            public Node Next { get; set; }

            public Node(T value)
            {
                Value = value;
                Next = null;
            }
        }

        private Node head;
        private Node end;
        public int numberOfElements { get; private set; }

        public LinkedList()
        {
            head = null;
            end = null;
            numberOfElements = 0;
        }

        public void AddFirst(T value)
        {
            Node newNode = new Node(value);

            if (head == null)
            {
                head = newNode;
                end = newNode;
            }
            else
            {
                newNode.Next = head;
                head = newNode;
            }

            numberOfElements++;
        }

        public void AddLast(T value)
        {
            Node newNode = new Node(value);

            if (end == null)
            {
                head = newNode;
                end = newNode;
            }
            else
            {
                end.Next = newNode;
                end = newNode;
            }

            numberOfElements++;
        }

        public bool Remove(T value)
        {
            if (head == null)
            {
                return false;
            }

            if (head.Value.Equals(value))
            {
                head = head.Next;
                if (head == null)
                {
                    end = null;
                }
                numberOfElements--;
                return true;
            }

            Node current = head;
            while (current.Next != null)
            {
                if (current.Next.Value.Equals(value))
                {
                    current.Next = current.Next.Next;
                    if (current.Next == null)
                    {
                        end = current;
                    }
                    numberOfElements--;
                    return true;
                }
                current = current.Next;
            }

            return false;
        }

        public bool Contains(T value)
        {
            Node current = head;
            while (current != null)
            {
                if (current.Value.Equals(value))
                {
                    return true;
                }
                current = current.Next;
            }
            return false;
        }

        public void Clear()
        {
            head = null;
            end = null;
            numberOfElements = 0;
        }

        public T[] ToArray()
        {
            T[] array = new T[numberOfElements];
            Node current = head;
            int index = 0;
            while (current != null)
            {
                array[index++] = current.Value;
                current = current.Next;
            }
            return array;
        }

        //Binary search ------------------------------------------------------//
        public int BinarySearch(T value)
        {
            T[] array = ToArray();
            int left = 0;
            int right = array.Length - 1;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;

                if (EqualityComparer<T>.Default.Equals(array[mid], value))
                {
                    return mid;
                }
                else if (Comparer<T>.Default.Compare(array[mid], value) < 0)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }
            return -1;
        }

        //Linear search ----------------------------------------------//

        public int LinearSearch(T value)
        {
            Node current = head;
            int index = 0;
            while (current != null)
            {
                if (current.Value.Equals(value))
                {
                    return index;
                }
                    current = current.Next;
                    index++;
                }
                return -1; // Value not found
        }

        //Bucket Sort -----------------------------------------------------//

        public void BucketSort()
        {
            if (numberOfElements <= 1)
            {
                return;
            }

            // min and max values 
            T minValue = head.Value;
            T maxValue = head.Value;

            Node current = head;
            while (current != null)
            {
                if (Comparer<T>.Default.Compare(current.Value, minValue) < 0)
                {
                    minValue = current.Value;
                }
                if (Comparer<T>.Default.Compare(current.Value, maxValue) > 0)
                {
                    maxValue = current.Value;
                }
                current = current.Next;
            }

           
            int bucketAmount = numberOfElements / 2;
            if (bucketAmount <= 1)
            {
                bucketAmount = 2;
            }
            List<Node>[] buckets = new List<Node>[bucketAmount];
            for (int i = 0; i < bucketAmount; i++)
            {
                buckets[i] = new List<Node>();
            }
            current = head;
            while (current != null)
            {
                int bucketIndex = GetBucketIndex(current.Value, minValue, maxValue, bucketAmount);
                buckets[bucketIndex].Add(current);
                current = current.Next;
            }

            // Sorting
            head = null;
            end = null;
            for (int i = 0; i < bucketAmount; i++)
            {
                List<Node> bucket = buckets[i];
                if (bucket.Count > 0)
                {
                    bucket.Sort((a, b) => Comparer<T>.Default.Compare(a.Value, b.Value));

                    if (head == null)
                    {
                        head = bucket[0];
                        end = bucket[bucket.Count - 1];
                    }
                    else
                    {
                        end.Next = bucket[0];
                        end = bucket[bucket.Count - 1];
                    }

                    for (int j = 0; j < bucket.Count - 1; j++)
                    {
                        bucket[j].Next = bucket[j + 1];
                    }
                }
            }

            end.Next = null;
        }

        private int GetBucketIndex(T value, T minValue, T maxValue, int bucketCount)
        {
            int index = Convert.ToInt32(Math.Floor(Convert.ToDouble(bucketCount) * (Comparer<T>.Default.Compare(value, minValue) - Comparer<T>.Default.Compare(maxValue, minValue)) / (Comparer<T>.Default.Compare(maxValue, minValue) - Comparer<T>.Default.Compare(minValue, maxValue))));
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

    }
}
