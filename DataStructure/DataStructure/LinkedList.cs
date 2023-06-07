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
    }
}
