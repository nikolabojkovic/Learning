using System;

namespace ZeroMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] matrix = new int[3][];
            matrix[0] = new int[4] { 0, 1, 0, 3 };
            matrix[1] = new int[4] { 5, 1, 7, 3 };
            matrix[2] = new int[4] { 2, 1, 0, 1 };

            Print(matrix);
           // SetZerosBrute(matrix);
            SetZerosBruteOptimized(matrix);
            Print(matrix);

            // Print(matrix);
            // SetToZero(matrix);
            // Print(matrix);

            // matrix[0] = new int[4] { 0, 1, 7, 3 };
            // matrix[1] = new int[4] { 5, 1, 7, 3 };
            // matrix[2] = new int[4] { 2, 1, 0, 1 };

            // Print(matrix);
            // SetZeros(matrix);
            // Print(matrix);
        }

        static void SetZerosBruteOptimized(int[][] matrix) // O(MxN) runtime - O(1) space complexity
        {
            // Guard - return if incorect input
            for (int i = 0; i < matrix.Length; i++)
                if (matrix[i].Length != matrix[0].Length)
                    return;

            bool rowHasZero = false;
            bool columnHasZero = false;

            // check if first column has a zero
            for (int i = 0; i < matrix.Length; i++)
            {
                if (matrix[i][0] == 0)
                {
                    columnHasZero = true;
                    break;
                }
            }

            // check if first row has a zero
            for (int j = 0; j < matrix[0].Length; j++)
            {
                if (matrix[0][j] == 0)
                {
                    rowHasZero = true;
                    break;
                }
            }

            // check if rest of the matrix has zero and store results in frst row and first column
            PinFlagsTo(matrix);

            // Nullify columns if needed
            for (int j = 1; j < matrix[0].Length; j++)
            {
                if (matrix[0][j] == 0)
                    NullifyColumn(matrix, j);
            }

            // Nullify rows if needed
            for (int i = 1; i < matrix.Length; i++)
            {
                if(matrix[i][0] == 0)
                    NullifyRow(matrix, i);
            }

            // Nullify first column if needed
            if (columnHasZero)
                NullifyColumn(matrix, 0);

            // Nullify first row if needed
            if (rowHasZero)
                NullifyRow(matrix, 0);
        }

    

        static void PinFlagsTo(int[][] matrix)
        {
            for (int i = 1; i < matrix.Length; i++)
            {
                for (int j = 1; j < matrix.Length; j++)
                {
                    if (matrix[i][j] == 0)
                    {
                        matrix[0][j] = 0;
                        matrix[i][0] = 0;
                    }
                }
            }
        }

        static void NullifyRow(int[][] matrix, int row)
        {
            for (int j = 0; j < matrix[0].Length; j++)
            {
                matrix[row][j] = 0;
            }
        }

        static void NullifyColumn(int[][] matrix, int column)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                matrix[i][column] = 0;
            }
        }

        static void SetZerosBrute(int[][] matrix) // O(MxN) runtime and space complexity
        {
            bool[][] flags = PinFlags(matrix);

            for(int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if(flags[i][j])
                    {
                        // set row cells to 0
                        for (int c = 0; c < matrix[i].Length; c++)
                        {
                            matrix[i][c] = 0;
                        }

                        // set column cells to 0
                        for (int c = 0; c < matrix.Length; c++)
                        {
                            matrix[c][j] = 0;
                        }
                    }
                }
            }
        }

        static bool[][] PinFlags(int[][] matrix)
        {
            bool[][] flags = new bool[matrix.Length][];

            for (int i = 0; i < matrix.Length; i++)
            {
                flags[i] = new bool[matrix[i].Length];
                
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if(matrix[i][j] == 0)
                        flags[i][j] = true;
                }
            }

            return flags;
        }

        static void Print(int[][] matrix)
        {
            Console.WriteLine("-------- Matrix --------");
            for(int i = 0; i < matrix.Length; i++)
            {
                for(int j = 0; j < matrix[i].Length; j++)
                    Console.Write(" " + matrix[i][j]);
                
                Console.WriteLine();
            }
        }

    }
}
