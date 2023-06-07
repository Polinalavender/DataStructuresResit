using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
        public class LinkedList<T>
        {

        private class Node<T>
        {
            public T Value { get; }
            public Node<T> Next { get; set; }

            public Node(T value)
            {
                Value = value;
                Next = null;
            }
        }

        private Node<T> head;
            private Node<T> end;

            public int numberOfElements { get; private set; }

            public LinkedList()
            {
                head = null;
                end = null;
                numberOfElements = 0;
            }

            public void AddFirst(T value)
            {
                Node<T> newNode = new Node<T>(value);

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

            public void AddLast(T value) //for specified value at the end 
        {
                Node<T> newNode = new Node<T>(value);

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

                Node<T> current = head;
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

            public bool isspecifiedValue(T value)
            {
                Node<T> current = head;
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

            public void Clear() //resetting
            {
                head = null;
                end = null;
                numberOfElements = 0;
            }

            public T[] ToArray()
            {
                T[] array = new T[numberOfElements];
                Node<T> current = head;
                int index = 0;
                while (current != null)
                {
                    array[index++] = current.Value;
                    current = current.Next;
                }
                return array;
            }

        }
}
