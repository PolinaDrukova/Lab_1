using System;
using System.Collections.Generic;
using System.Linq;

namespace App
{
    internal static class Program
    {
        private static void Main()
        {
            var matrix = InputMatrix();

            var increasingLines = 0;
            var decreasingLines = 0;
            var sameLines = 0;
            var otherLines = 0;
            foreach (var line in matrix)
            {
                if (CheckSame(line))
                {
                    sameLines++;
                }
                else
                {
                    if (CheckOrdered(line))
                    {
                        increasingLines++;
                    }

                    else
                    if (CheckOrdered(line, false))
                    {
                        decreasingLines++;
                    }

                    else
                    {
                        otherLines++;
                    }
                }
            }

            Console.WriteLine("increasing lines: " + increasingLines);
            Console.WriteLine("decreasing lines: " + decreasingLines);
            Console.WriteLine("same lines: " + sameLines);
            Console.WriteLine("other lines: " + otherLines);
        }

        private static List<List<int>> InputMatrix()
        {
            Console.WriteLine("Enter a square matrix:");
            var matrix = new List<List<int>>();
            while (true)
            {
                var rawRow = Console.ReadLine();
                if (string.IsNullOrEmpty(rawRow))
                    break;

                var row = new List<int>();
                row.AddRange(rawRow.Split(" ").Select(int.Parse));
                matrix.Add(row);
            }

            return matrix;
        }

        private static bool CheckOrdered(IReadOnlyList<int> line, bool ascending = true)
        {
            var prev = line[0];
            foreach (var current in line.Skip(1))
            {
                if (ascending)
                {
                    if (current <= prev)
                        return false;
                }
                else
                {
                    if (current >= prev)
                        return false;
                }
            }

            return true;
        }

        private static bool CheckSame(IReadOnlyList<int> line)
        {
            var first = line[0];
            foreach (var value in line.Skip(1))
            {
                if (value != first)
                    return false;
            }

            return true;
        }
    }
}