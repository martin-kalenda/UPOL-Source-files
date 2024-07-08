namespace cs205
{
    internal class Sort
    {
        // helper method for MergeSort
        private static void Merge<T>(T[] array, int left, int mid, int right, Comparer<T> comparer)
        {
            int i, j, k;

            // calculate sizes of two subarrays and create them
            int n1 = mid - left + 1;
            int n2 = right - mid;
            T[] L = new T[n1];
            T[] R = new T[n2];

            // copy data to subarrays
            for (i = 0; i < n1; i++)
            {
                L[i] = array[left + i];
            }
            for (j = 0; j < n2; j++)
            {
                R[j] = array[mid + 1 + j];
            }

            i = 0;
            j = 0;

            // merge the subarrays back into the original array
            for (k = left; k <= right; k++)
            {
                // check if one of the subarrays is empty or if the element from the left subarray is smaller
                if (j >= n2 || (i < n1 && comparer.Compare(L[i], R[j]) <= 0))
                {
                    // copy the element from the left subarray
                    array[k] = L[i];
                    i++;
                }
                else
                {
                    // copy the element from the right subarray
                    array[k] = R[j];
                    j++;
                }
            }
        }
        // generic MergeSort implementation, comparer and depth can be specified in the public overload bellow
        private static void MergeSort<T>(T[] array, int left, int right, Comparer<T> comparer, int depth)
        {
            // check if there is more than 1 element in the array
            if (left < right)
            {
                // calculate the middle index
                int mid = (left + right) / 2;

                // recursively call MergeSort on the two halves of the array
                // if depth is greater than 0, use multi-threading
                if (depth > 0)
                {
                    Thread leftThread = new Thread(new ThreadStart(delegate
                    {
                        MergeSort(array, left, mid, comparer, depth - 1);
                    }));
                    Thread rightThread = new Thread(new ThreadStart(delegate
                    {
                        MergeSort(array, mid + 1, right, comparer, depth - 1);
                    }));

                    leftThread.Start();
                    rightThread.Start();

                    leftThread.Join();
                    rightThread.Join();
                }
                else
                {
                    MergeSort(array, left, mid, comparer, depth);
                    MergeSort(array, mid + 1, right, comparer, depth);
                }
                // merge the two halves
                Merge(array, left, mid, right, comparer);
            }
        }
        //MergeSort overload for easier use
        public static void MergeSort<T>(T[] array, Comparer<T>? comparer = null, int depth = 3)
        {
            // use default comparer if none is provided
            if (comparer == null)
            {
                comparer = Comparer<T>.Default;
            }

            MergeSort(array, 0, array.Length - 1, comparer, depth);
        }
    }
}
