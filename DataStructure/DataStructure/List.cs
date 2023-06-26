namespace DataStructure
{
    public class List<T>
    {
        private T[] data;
        public T element { get; set; }
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
                Array.Resize(ref data, count * 2);
            }

            data[count++] = element;
        }

        public bool Remove(T element)
        {
            int elementIndex = Array.IndexOf(data, element); // find the index of the inputted element

            if (elementIndex >= 0)
            {
                for (int i = elementIndex + 1; i < count; i++) // loop starting from the elements after elementIndex and move them one postion
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

        //Linear search ----------------------------------------------//

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

        //Bubble Sort ----------------------------------------------//

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

        //Binary search ----------------------------------------------//

        public int BinarySearch(T element)
        {
            if (Comparer<T>.Default.Compare(data[0], data[count - 1]) > 0) // check if list is sorted
            {
                BubbleSort(); // if its not then sort it using bubble sort
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

        //Bucket Sort ----------------------------------------------//

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
                int bucketIndex = GetBucketIndex(data[i], min, max, bucketCount); // calculate the bucket index
                buckets[bucketIndex][bucketIndexes[bucketIndex]++] = data[i]; // place the element in the bucket and increment the bucket index
            }

            int dataIndex = 0;
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

                Array.Copy(buckets[i], 0, data, dataIndex, bucketIndexes[i]); // add the sorted elements to the original list
                dataIndex += bucketIndexes[i]; // update the data index for the next bucket
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
    }
}