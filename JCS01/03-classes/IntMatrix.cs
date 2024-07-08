public class IntMatrix
{
    private int rows;
    private int cols;
    private int[,] values;

    public IntMatrix(int rows, int cols)
    {
        if (rows < 1 || cols < 1)
        {
            Console.WriteLine("matrix dimension cannot be lower than 1!");
            return;
        }
        this.rows = rows;
        this.cols = cols;
        values = new int[rows, cols];
    }
    //make matrix nRows * nCols full of ones
    public static IntMatrix Ones(int nRows, int nCols)
    {
        IntMatrix matrix = new IntMatrix(nRows, nCols);

        for (int i = 0; i < nRows; i++)
        {
            for (int j = 0; j < nCols; j++)
            {
                matrix.SetVal(i, j, 1);
            }
        }
        return matrix;
    }
    //return number of rows
    public int NRows()
    {
        return rows;
    }
    //return number of columns
    public int NCols()
    {
        return cols;
    }
    //return value @ x, y
    public int GetVal(int x, int y)
    {
        return values[x, y];
    }
    //set value @ x, y to val
    public void SetVal(int x, int y, int val)
    {
        values[x, y] = val;
    }
    //return number of non-zero values
    public int NonZero()
    {
        int counter = 0;

        foreach (int value in values)
        {
            if (value == 0)
            {
                counter++;
            }
        }
        return counter;
    }
    //sum all values in matrix
    public int SumOfVals()
    {
        int sum = 0;

        foreach (int value in values)
        {
            sum += value;
        }
        return sum;
    }
    //return new matrix which is the sum of original matrix and mat
    public IntMatrix AddMatrix(IntMatrix mat)
    {
        IntMatrix sum = new IntMatrix(rows, cols);

        if (mat.NRows() != rows || mat.NCols() != cols)
        {
            Console.WriteLine("both matrices have to be of m x n dimension!");
            return sum;
        }

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                sum.SetVal(i, j, GetVal(i, j) + mat.GetVal(i, j));
            }
        }
        return sum;
    }
    //return new matrix which is a multiple of original matrix and mat
    public IntMatrix MulMatrix(IntMatrix mat)
    {
        int iMultiple = 0;
        IntMatrix multiple = new IntMatrix(mat.NCols(), rows);

        if (cols != mat.NRows())
        {
            Console.WriteLine("matrices have to be of m x n and n x p dimensions!");
            return multiple;
        }

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                for (int k = 0; k < mat.NCols(); k++)
                {
                    iMultiple += GetVal(i, k) * mat.GetVal(k, j);
                }
                multiple.SetVal(i, j, iMultiple);
                iMultiple = 0;
            }
        }

        return multiple;
    }
    //print matrix to STDOUT
    public void Print()
    {
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Console.Write(GetVal(i, j) + " ");
            }
            Console.WriteLine();
        }
    }
}