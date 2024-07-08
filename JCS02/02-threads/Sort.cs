using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database.cs;

namespace cs202
{
    //Sort class, could be extended to support other sorting algorithms
    internal class Sort
    {
        public static void MergeSort(<T>[] array, int left, int right, int depth = 0)

        //Merge implementation 
        private static void Merge(Student[] array, int left, int mid, int right)
        {
            int i, j, k;

            int n1 = mid - left + 1;
            int n2 = right - mid;

            Student[] L = new Student[n1 + 1];
            Student[] R = new Student[n2 + 1];

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

            L[n1] = Int32.MaxValue;
            R[n2] = Int32.MaxValue;

            for (k = left; k <= right; k++)
            {
                if (L[i] <= R[j])
                {
                    array[k] = L[i];
                    i++;
                }
                else
                {
                    array[k] = R[j];
                    j++;
                }
            }
        }
        //MergeSort implementation for integers
        private static void MergeSort(int[] array, int left, int right, int column = 0, int depth = 3)
        {
            if (left < right)
            {
                int mid = (left + right) / 2;

                if (depth > 0)
                {
                    Thread leftThread = new Thread(new ThreadStart(delegate
                    {
                        MergeSort(array, left, mid, depth - 1);
                    }));
                    Thread rightThread = new Thread(new ThreadStart(delegate
                    {
                        MergeSort(array, mid + 1, right, depth - 1);
                    }));

                    leftThread.Start();
                    rightThread.Start();

                    lock (counterLock)
                    {
                        threadsCounter += 2;
                    }

                    leftThread.Join();
                    rightThread.Join();
                }
                else
                {
                    MergeSort(array, left, mid);
                    MergeSort(array, mid + 1, right);
                }

                Merge(array, left, mid, right);
            }
        }
        //MergeSort overload for easier use
        public static void MergeSort(int[] array, int depth = 0)
        {
            threadsCounter = 0;
            MergeSort(array, 0, array.Length - 1, depth);
        }
    }
}
