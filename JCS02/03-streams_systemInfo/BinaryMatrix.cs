using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel.Design;
using System.Data;
using System.Linq;
using System.Numerics;
using System.Reflection.Metadata;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace cs203
{
    // BinaryMatrix class
    internal class BinaryMatrix : IBinaryMatrix
    {
        private (int, int) dimensions = (0, 0);
        private BitArray binMatrix = new BitArray(0);


        //************************
        //*                      *
        //*     Constructors     *
        //*                      *
        //************************

        // create empty binary matrix
        public BinaryMatrix() { }
        // create binary matrix from a 2D array of integers, 0s are treated as false, non-zero values are treated as true
        public BinaryMatrix(int[,] matrix)
        {   
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            initializeInstance(rows, cols);
            fillMatrix(matrix);
        }
        // create empty binary matrix with given dimensions
        public BinaryMatrix(int rows, int cols)
        {
            initializeInstance(rows, cols);
        }


        //************************
        //*                      *
        //*      Properties      *
        //*                      *
        //************************

        // return the number of elements
        public int Length
        {
            get => Rows * Columns;
        }
        // return the number of rows
        public int Rows
        {
            get => dimensions.Item1;
        }
        // return the number of columns
        public int Columns
        {
            get => dimensions.Item2;
        }


        //************************
        //*                      *
        //*   Matrix accessors   *
        //*                      *
        //************************

        // get the element at the given indexes
        public bool? Get(int row, int col)
        {
            try
            {
                if (!okIndex(row, col))
                {
                    throw new IndexOutOfRangeException("Index out of range.");
                }
                return binMatrix[row * Columns + col];
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An exception occured: {ex.Message}");
                return null;
            }
        }
        // set the element at the given indexes to the given value
        public void Set(int row, int col, bool value)
        {
            try
            {
                if (!okIndex(row, col))
                {
                    throw new IndexOutOfRangeException("Index out of range, value not set.");
                }
                binMatrix[row * Columns + col] = value;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An exception occured: {ex.Message}");
            }
            
        }
        // check if the given indexes are valid
        private bool okIndex(int rows, int cols)
        {
            int position = rows * Columns + cols;

            if (position < 0 || position >= Length)
            {
                return false;
            }
            return true;
        }


        //************************
        //*                      *
        //*    I/O operations    *
        //*                      *
        //************************

        // create a matrix instance from a file, return null if failed
        public static BinaryMatrix? ReadMatrix(string? path)
        {
            try
            {
                if (path == null)
                {
                    throw new ArgumentNullException("path", "Path is null.");
                }
                if (path == "")
                {
                    throw new ArgumentException("Path is empty.", "path");
                }
                if (!File.Exists(path))
                {
                    throw new FileNotFoundException($"File \'{path}\' not found.");
                }

                // open the file
                BinaryReader reader = new BinaryReader(File.Open(path, FileMode.Open), Encoding.UTF8);
                // initialize the matrix with the read dimensions
                BinaryMatrix bm = new BinaryMatrix(reader.ReadInt32(), reader.ReadInt32());
                int stop = 0;

                // count how many bytes to read
                for (int i = 0; i < Math.Ceiling((double)bm.Length / 8); i++)
                {
                    byte b = reader.ReadByte();

                    // read the bits from the current byte in reverse order
                    for (int j = 0; j < 8; j++)
                    {
                        if (stop == bm.Length)
                        {
                            break;
                        }
                        // set the bit array value
                        bm.binMatrix[i * 8 + j] = (b & 1 << (7 - j)) != 0;
                        stop++;
                    }
                }
                // close the file
                reader.Close();
                return bm;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An exception occured: {ex.Message}");
                return null;
            }
        }
        // write a matrix instance to a file at the given path, if overwrite is true, the file will be overwritten if it exists
        //
        // uses 4 + 4 + ceil((rows * columns) / 8) bytes
        public void WriteMatrix(string? path, bool overwrite = false)
        {
            try
            {
                if (path == null)
                {
                    throw new ArgumentNullException("path", "Path is null.");
                }
                if (path == "")
                {
                    throw new ArgumentException("Path is empty.", "path");
                }
                if (!overwrite && File.Exists(path))
                {
                    throw new IOException($"File \'{path}\' already exists.");
                }

                // open the file
                BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.Create), Encoding.UTF8);
                byte b = 0;
                // count the number of bits needed to align the matrix to a byte boundary
                int shiftBy = (8 - (binMatrix.Length % 8));

                writer.Write(Rows);
                writer.Write(Columns);

                // align the matrix to a byte boundary
                binMatrix.Length += shiftBy;

                // accumulate bits from the bit array into a byte
                for (int i = 0; i < binMatrix.Length; i++)
                {
                    // when 8 bits have been read, write them to the file
                    if ((i + 1) % 8 == 0)
                    {
                        writer.Write(b);
                        b = 0;
                    }
                    // set the current bit in the byte
                    b |= (byte)(binMatrix[i] ? 1 : 0);
                    b <<= 1;
                }

                // close the file
                writer.Close();
                // shift back
                binMatrix.Length -= shiftBy;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An exception occured: {ex.Message}");
            }
        }

        // return a string representation of the matrix
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            char[] row = new char[Columns];

            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    row[j] = binMatrix[i * Columns + j] ? '1' : '0';
                }
                sb.AppendLine(String.Join(" ", row));
            }
            return sb.ToString();
        }

        //************************
        //*                      *
        //*   Helper functions   *
        //*                      *
        //************************

        // initialize instance
        private void initializeInstance(int rows, int cols)
        {
            try
            {
                if (rows <= 0 || cols <= 0)
                {
                    throw new ArgumentException("Matrix dimensions have to be at least 1x1.");
                }
                dimensions = (rows, cols);
                binMatrix = new BitArray(rows * cols);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An exception occured: {ex.Message}");
            }
        }
        // fill the matrix with values from a 2D integer array
        private void fillMatrix(int[,] matrix)
        {
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    binMatrix.Set(i * Columns + j, matrix[i, j] != 0);
                }
            }
        }
    }
}
