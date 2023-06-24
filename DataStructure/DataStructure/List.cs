using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    public class List<T>
    {
        private T[] data;
        public T element { get; }
        private int count;

        public List()
        {
            data = new T[8];
            count = 0;
        }

        public void Add(T element)
        {
            if (count == data.Length)
            {
                Array.Resize(ref data, count + 1); 
            }

            data[count++] = element;
        }

        public bool Remove(T element) 
        {
            int elementIndex = Array.IndexOf(data, element); // find the index of the inputted element

            if (elementIndex >= 0) 
            {
                for (int i = elementIndex + 1; i < count; i++) // loop starting from the elements after elementIndex and move them one postion to the 'left'
                {
                    data[i - 1] = data[i];
                }
                count--;
                return true;
            } 
            else
            {
                throw new IndexOutOfRangeException("Invalid index");
            }
        }

        public T[] ToArray()
        {
            T[] array = new T[count];
            
            for (int i = 0; i < count; i++)
            {
                array[i] = data[i];
            }

            return array;
        }

        public void Clear()
        {
            for (int i = 0; i < count; i++)
            {
                data[i] = default; // set each element to its default value
            }

            count = 0; 
        }

        public int LinearSearch(T element)
        {
            for (int i = 0; i < count; i++)
            {
                if (data[i].Equals(element)) {
                    return i;
                }
            }   
            return -1;
        }

        public void BubbleSort()
        {
            bool swapped;

            for (int i = 0; i < count - 1; i++)
            {
                swapped = false;

                for (int j = 0; j < count - i - 1; j++)
                {
                    if (Comparer<T>.Default.Compare(data[j], data[j + 1]) > 0)
                    {
                        // swap data[j] and data[j + 1]
                        T temp = data[j];
                        data[j] = data[j + 1];
                        data[j + 1] = temp;
                        swapped = true;
                    }
                }

                // if no two elements were swapped in the inner loop, then the list is already sorted
                if (!swapped)
                    break;
            }
        }
    }
}
