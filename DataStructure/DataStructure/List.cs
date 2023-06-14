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

        private List()
        {
            data = new T[8];
            count = 0;
        }

        public void Add(T element)
        {
            if (count == data.Length)
            {
                Array.Resize(ref data, data.Length * 2);
            }

            data[count++] = element;
        }

        public bool Remove(T element) 
        {
            int elementIndex = Array.IndexOf(data, element);

            if (elementIndex > 0) 
            {
                for (int i = elementIndex; i < count - 1; i++)
                {
                    data[i] = data[i + 1];
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
        //public void Clear() { }
    }
}
