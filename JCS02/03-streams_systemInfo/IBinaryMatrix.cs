using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace cs203
{
    internal interface IBinaryMatrix
    {
        // Length property
        int Length { get; }

        // Rows property
        int Rows { get; }

        // Columns property
        int Columns { get; }

        // Get value at given row and column (1-based indexing)
        bool? Get(int row, int col);

        // Set value at given row and column (1-based indexing)
        void Set(int row, int col, bool value);

        // Read matrix from file, return null if failed
        static abstract BinaryMatrix? ReadMatrix(string path);

        // Write matrix to file
        void WriteMatrix(string path, bool overwrite);
    }
}
