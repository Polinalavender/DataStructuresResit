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



        public void BucketSort()
        {
            // Create buckets
            int bucketCount = numberOfElements;
            LinkedList<T>[] buckets = new LinkedList<T>[bucketCount];
            for (int i = 0; i < bucketCount; i++)
            {
                buckets[i] = new LinkedList<T>();
            }

            // Determine the minimum and maximum values
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

            // Distribute elements into buckets
            current = head;
            while (current != null)
            {
                int bucketIndex = GetBucketIndex(current.Value, minValue, maxValue, bucketCount);
                buckets[bucketIndex].AddLast(current.Value);
                current = current.Next;
            }

            // Sort each bucket individually (using BubbleSort in this example)
            for (int i = 0; i < bucketCount; i++)
            {
                buckets[i].BubbleSort();
            }

            // Concatenate the sorted buckets back into the original list
            head = null;
            end = null;
            numberOfElements = 0;
            for (int i = 0; i < bucketCount; i++)
            {
                Node bucketHead = buckets[i].head;
                Node bucketEnd = buckets[i].end;
                int bucketSize = buckets[i].numberOfElements;

                if (bucketHead != null)
                {
                    if (head == null)
                    {
                        head = bucketHead;
                        end = bucketEnd;
                    }
                    else
                    {
                        end.Next = bucketHead;
                        end = bucketEnd;
                    }

                    numberOfElements += bucketSize;
                }
            }
        }


        // Bubbble sort -------------------------------------------------------//

        public void BubbleSort()
        {
            if (numberOfElements <= 1)
            {
                return;
            }

            bool swapped;
            do
            {
                swapped = false;
                Node current = head;
                Node previous = null;
                Node nextNode = current.Next;

                while (nextNode != null)
                {
                    if (Comparer<T>.Default.Compare(current.Value, nextNode.Value) > 0)
                    {
                        // Swap
                        if (previous != null)
                        {
                            previous.Next = nextNode;
                        }
                        else
                        {
                            head = nextNode;
                        }

                        current.Next = nextNode.Next;
                        nextNode.Next = current;
                        previous = nextNode;
                        nextNode = current.Next;

                        swapped = true;
                    }
                    else
                    {
                        previous = current;
                        current = nextNode;
                        nextNode = nextNode.Next;
                    }
                }
            } while (swapped);
        }
    }
}
