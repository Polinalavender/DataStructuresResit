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
                return false;
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
                data[i] = default;
            }
            count = 0;
            Array.Resize(ref data, 8);
        }

        public int LinearSearch(T element)
        {
            for (int i = 0; i < count; i++)
            {
                if (data[i].Equals(element))
                {
                    return i;
                }
            }
            return -1;
        }

        public void BubbleSort()
        {
            for (int i = 0; i < count - 1; i++)
            {
                for (int j = 0; j < count - i - 1; j++)
                {
                    if (Comparer<T>.Default.Compare(data[j], data[j + 1]) > 0)
                    {
                        T temp = data[j];
                        data[j] = data[j + 1];
                        data[j + 1] = temp;
                    }
                }
            }
        }

        public int BinarySearch(T element)
        {
            if (Comparer<T>.Default.Compare(data[0], data[count - 1]) > 0) // check if list is sorted
            {
                BubbleSort(); // if its not the bubble sort it
            }

            int left = 0;
            int right = count - 1;

            while (left <= right)
            {
                int middle = left + (right - left) / 2;
                int comparison = Comparer<T>.Default.Compare(data[middle], element);

                if (comparison == 0)
                {
                    return middle; // return the element at the middle index of the array
                }
                else if (comparison < 0)
                {
                    left = middle + 1; // search in the right half
                }
                else
                {
                    right = middle - 1; // search in the left half
                }
            }
            return -1;
        }

        public void BucketSort()
        {
            if (count <= 1)
            {
                return;
            }

            // find the minimum and maximum values in the list
            T min = data[0];
            T max = data[0];
            for (int i = 1; i < count; i++)
            {
                if (Comparer<T>.Default.Compare(data[i], min) < 0)
                    min = data[i];
                if (Comparer<T>.Default.Compare(data[i], max) > 0)
                    max = data[i];
            }

            // calculate the range of each bucket
            int bucketCount = count / 4;
            int range = Comparer<T>.Default.Compare(max, min) == 0 ? default : Comparer<T>.Default.Compare(max, min);

            // create and initialize the buckets
            int[] bucketSizes = new int[bucketCount];
            T[][] buckets = new T[bucketCount][];
            for (int i = 0; i < bucketCount; i++)
            {
                bucketSizes[i] = 0;
                buckets[i] = new T[count]; // initialize each bucket with the maximum possible size
            }

            // assign each element to its respective bucket
            for (int i = 0; i < count; i++)
            {
                int bucketIndex = (int)(((Convert.ToDouble(data[i]) - Convert.ToDouble(min)) / range) * (bucketCount - 1)); // calculate the bucket index for the current element


                // resize if necessary
                if (bucketSizes[bucketIndex] == buckets[bucketIndex].Length)
                {
                    Array.Resize(ref buckets[bucketIndex], bucketSizes[bucketIndex] + 1);
                }

                int bucketSize = bucketSizes[bucketIndex]; // get the current size of the bucket
                T[] currentBucket = buckets[bucketIndex]; // get the current bucket
                bucketSizes[bucketIndex] = bucketSize + 1; // increase the bucket size by 1
                currentBucket[bucketSize] = data[i]; // assign the element to the current bucket

            }

            // sort each bucket individually 
            for (int i = 0; i < bucketCount; i++)
            {
                Array.Resize(ref buckets[i], bucketSizes[i]); // trim the bucket size to the actual number of elements
                Array.Sort(buckets[i], 0, bucketSizes[i]);
            }

            // merge the sorted buckets back into the original list
            int currentIndex = 0;
            for (int i = 0; i < bucketCount; i++)
            {
                for (int j = 0; j < bucketSizes[i]; j++)
                {
                    data[currentIndex++] = buckets[i][j]; // add sorted element to the original list
                }
            }
        }
    }
}