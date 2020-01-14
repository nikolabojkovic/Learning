using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace BFS_matrix_shortest_distance
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            int matrixRows = 3;
            int matrixColumns = 3;
            int [,] matrix = new int [matrixRows,matrixColumns];
            matrix[0,0] = 1; matrix[0,1] = 0; matrix[0,2] = 0;
            matrix[1,0] = 1; matrix[1,1] = 0; matrix[1,2] = 0;
            matrix[2,0] = 1; matrix[2,1] = 9; matrix[2,2] = 1;

           // PrintMatrix(matrixRows, matrixColumns, matrix);

           // Console.WriteLine($"Shortest distance is: {ShortestDistance(matrixRows, matrixColumns, matrix)}");
            Console.WriteLine();
        
            matrixRows = 5;
            matrixColumns = 4;
            // matrix = new int [matrixRows, matrixColumns];
            // matrix[0,0] = 1; matrix[0,1] = 1; matrix[0,2] = 0; matrix[0,3] = 0;
            // matrix[1,0] = 0; matrix[1,1] = 1; matrix[1,2] = 0; matrix[1,3] = 1;
            // matrix[2,0] = 1; matrix[2,1] = 1; matrix[2,2] = 1; matrix[2,3] = 9;
            // matrix[3,0] = 1; matrix[3,1] = 0; matrix[3,2] = 1; matrix[3,3] = 1;
            // matrix[4,0] = 1; matrix[4,1] = 1; matrix[4,2] = 1; matrix[4,3] = 0;

          //  Console.WriteLine($"Shortest distance is: {ShortestDistance(matrixRows, matrixColumns, matrix)}");

            var matrix2 = new int [matrixRows][];
            matrix2[0] = new int[matrixColumns];
            matrix2[1] = new int[matrixColumns];
            matrix2[2] = new int[matrixColumns];
            matrix2[3] = new int[matrixColumns];            
            matrix2[4] = new int[matrixColumns];
            
            matrix2[0][0] = 1; matrix2[0][1] = 1; matrix2[0][2] = 0; matrix2[0][3] = 0;
            matrix2[1][0] = 0; matrix2[1][1] = 1; matrix2[1][2] = 0; matrix2[1][3] = 1;
            matrix2[2][0] = 1; matrix2[2][1] = 1; matrix2[2][2] = 1; matrix2[2][3] = 9;
            matrix2[3][0] = 1; matrix2[3][1] = 0; matrix2[3][2] = 1; matrix2[3][3] = 1;
            matrix2[4][0] = 1; matrix2[4][1] = 1; matrix2[4][2] = 1; matrix2[4][3] = 0;
            Console.WriteLine($"Shortest distance path is: {FindShortestPath(matrix2)}");
            PrintMatrix2<int>(matrixRows, matrixColumns, matrix2);
        }
        static void PrintMatrix2<T>(int rows, int columns, T [][] matrix)
        {
            for(int i = 0; i < rows; i++)
            {
                for(int j = 0; j < columns; j++)
                {
                    Console.Write($"{matrix[i][j]} ");
                }

                Console.WriteLine();
            }

             Console.WriteLine();
        }

        static void PrintMatrix<T>(int rows, int columns, T [,] matrix)
        {
            for(int i = 0; i < rows; i++)
            {
                for(int j = 0; j < columns; j++)
                {
                    Console.Write($"{matrix[i,j]} ");
                }

                Console.WriteLine();
            }

             Console.WriteLine();
        }

        static int ShortestDistance(int rows, int columns, int [,] matrix)
        {
            int forbiden = 0;
            int destination = 9;
            
            // mark forbiden as visited
            bool [,] visited = new bool [rows, columns];

            for(int i = 0; i < rows; i++)
            {
                for(int j = 0; j < columns; j++)
                {
                    if (matrix[i,j] == forbiden)
                        visited[i,j] = true;
                }
            }

            // PrintMatrix(rows, columns, visited);

            Queue<Visitor> visitors = new Queue<Visitor>();
            visitors.Enqueue(new Visitor(0, 0, 1, "Start"));

            while(visitors.Count > 0)
            {
                Visitor visitor = visitors.Dequeue();

                // check destination
                if (matrix[visitor.Row, visitor.Column] == destination)
                {
                    Console.WriteLine(visitor.Path);
                    return visitor.Distance;
                }

                int up = visitor.Row - 1;    
                int down = visitor.Row + 1;
                int left = visitor.Column - 1;
                int right = visitor.Column + 1;

                // move up

                if (up > -1 && visited[up, visitor.Column] == false)
                {
                    visitors.Enqueue(new Visitor(up, visitor.Column, visitor.Distance + 1, visitor.Path + Environment.NewLine + "up"));
                    visited[up, visitor.Column] = true;
                }

                // move down
                if (down < rows && visited[down, visitor.Column] == false)
                {
                    visitors.Enqueue(new Visitor(down, visitor.Column, visitor.Distance + 1, visitor.Path + Environment.NewLine + "down"));
                    visited[down, visitor.Column] = true;
                }

                // move left
                if (left > -1 && visited[visitor.Row, left] == false)
                {
                    visitors.Enqueue(new Visitor(visitor.Row, left, visitor.Distance + 1, visitor.Path + Environment.NewLine + "left"));
                    visited[visitor.Row, left] = true;
                }

                // move right
                if (right < columns && visited[visitor.Row, right] == false)
                {
                    visitors.Enqueue(new Visitor(visitor.Row, right, visitor.Distance + 1, visitor.Path + Environment.NewLine + "right"));
                    visited[visitor.Row, right] = true;
                }
            }
            PrintMatrix(rows, columns, visited);
            return -1;
        }

        public static string FindShortestPath(int[][] matrix)
        {
            // Guard validation
            if (matrix.Length == 0)
                return "Matrix not initialized";

            for (int i = 0; i < matrix.Length; i++)
            {
                if (matrix[i].Length != matrix[0].Length)
                    return "It is not a matrix";
            }

            Queue<Visitor> visitors = new Queue<Visitor>();
            visitors.Enqueue(new Visitor(0, 0, 0, "(0, 0)"));

            bool[][] visited = FlagVisited(matrix);

            while(visitors.Any())
            {
                Visitor visitor = visitors.Dequeue();

                if (matrix[visitor.Row][visitor.Column] == 9)
                    return visitor.Path;

                // Define ways to go
                int up = visitor.Row - 1;
                int left = visitor.Column - 1;
                int right = visitor.Column + 1;
                int bottom = visitor.Row + 1;

                // Go up
                if (up >= 0 && !visited[up][visitor.Column])
                {
                    visitors.Enqueue(new Visitor(up, visitor.Column, visitor.Distance + 1, visitor.Path + $",({up},{visitor.Column})"));
                    visited[up][visitor.Column] = true;
                }

                // Go left
                if (left >= 0 && !visited[visitor.Row][left])
                {
                    visitors.Enqueue(new Visitor(visitor.Row, left, visitor.Distance + 1, visitor.Path + $",({visitor.Row},{left})"));
                    visited[visitor.Row][left] = true;
                }

                // Go right
                if (right < matrix[visitor.Row].Length && !visited[visitor.Row][right])
                {
                    visitors.Enqueue(new Visitor(visitor.Row, right, visitor.Distance + 1, visitor.Path + $",({visitor.Row},{right})"));
                    visited[visitor.Row][right] = true;
                }

                // Go down
                if (bottom < matrix.Length && !visited[bottom][visitor.Column])
                {
                    visitors.Enqueue(new Visitor(bottom, visitor.Column, visitor.Distance + 1, visitor.Path + $",({bottom},{visitor.Column})"));
                    visited[bottom][visitor.Column] = true;
                }
            }

            return "Destination not found";
        }

        public static bool[][] FlagVisited(int[][] matrix)
        {
            bool [][] visited = new bool[matrix.Length][];

                for(int i = 0; i < matrix.Length; i++)
                {
                    visited[i] = new bool[matrix[i].Length];
                    for(int j = 0; j < matrix[i].Length; j++)
                    {
                        if (matrix[i][j] == 0)
                            visited[i][j] = true;
                    }
                }
            
            return visited;
        }
    }

    public class Visitor 
    {
        public Visitor(int row, int column, int distance, string path)
        {
            Row = row;
            Column = column;
            Distance = distance;
            Path = path;
        }

        public int Row { get; private set; }
        public int Column { get; private set; }
        public int Distance { get; private set; }
        public string Path { get; set; }
    }
}


// Solution:
// This approach uses BFS - Breadth First Search algorithm to find a shortest distance.
// First mark cells which are not able to visit as visited and store results in separate matrix.
// Then queue of visitors is created and while loop will enqueue new visitors for next level if possible.
// Visitor intention is to store info about current position, traveled distance and path.
// Then while loop will do a condition for check if visitor reached the destination,
// if not then new visitor will be Enqued for next level if next level position is in matrix range
// While loop will check next levels on the same way until queue becames empty or destination has been reached
// If destination has not been found -1 will be returned.