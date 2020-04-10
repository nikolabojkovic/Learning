using System;

namespace RotateMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int [,] matrix = new int[4,4];
            int [][] matrixJagged = new int[4][];
            matrixJagged[0] = new int[4] { 0, 0, 0, 0};
            matrixJagged[1] = new int[4] { 1, 0, 0, 3};
            matrixJagged[2] = new int[4] { 1, 2, 0, 3};
            matrixJagged[3] = new int[4] { 1, 2, 2, 2};

            // Console.WriteLine("Matrix length: " + matrix.Length);
            // Console.WriteLine("Matrix jagged length: " + matrixJagged.Length);

            PrintMatrix(matrixJagged);
            RotateMatrix(matrixJagged);
            PrintMatrix(matrixJagged);
            // RotateMatrix(matrixJagged);
            // PrintMatrix(matrixJagged);

            matrixJagged = new int[6][];
            matrixJagged[0] = new int[6] { 0, 0, 0, 0, 0, 0};
            matrixJagged[1] = new int[6] { 1, 0, 0, 0, 0, 3};
            matrixJagged[2] = new int[6] { 1, 2, 0, 0, 0, 3};
            matrixJagged[3] = new int[6] { 1, 2, 0, 2, 0, 3};
            matrixJagged[4] = new int[6] { 1, 2, 2, 2, 0, 3};
            matrixJagged[5] = new int[6] { 1, 2, 2, 2, 2, 3};
            
            PrintMatrix(matrixJagged);
            RotateMatrix(matrixJagged);
            PrintMatrix(matrixJagged);
        }

        static void RotateMatrix(int[][] matrix)
        {
            if (matrix.Length == 0)
                return;

            for (int i = 0; i < matrix.Length; i++)
            {
                if (matrix.Length != matrix[i].Length)
                    return;
            }

            for (int layer = 0; layer < matrix.Length / 2; layer++) // O(n^2) runtime
            {
                int first = layer;
                int last = matrix.Length - 1 - layer;
                int temp = 0; // O(1) memory usage

                for (int i = first; i < last; i++)
                {
                    int offset = i - first;
                    // top -> temp
                    temp = matrix[first][i];

                    // left -> top
                    matrix[first][i] = matrix[last-offset][first];

                    // bottom -> left
                    matrix[last-offset][first] = matrix[last][last-offset];

                    // right -> bottom
                    matrix[last][last-offset] = matrix[i][last];

                    // temp -> right
                    matrix[i][last] = temp;
                }
            }
        }

        static void PrintMatrix(int[][] mattrix)
        {
            Console.WriteLine("------ Matrix -----");
            for(int i = 0; i < mattrix.Length; i++) 
            {
                for(int j = 0; j < mattrix[i].Length; j++)
                {
                    Console.Write(" " + mattrix[i][j]);
                }

                Console.WriteLine();
            }
        }
    }
}
