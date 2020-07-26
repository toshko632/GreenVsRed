using System;

namespace GreenvsRed
{
    class Grid
    {
        public int width = 0;
        public int height = 0;
        public int[,] grid = new int[0, 0];         // creating an array for 0-reds and 1-green
        public int[,] secondGrid = new int[0, 0];   // creating a second array for the changes from the first array
        public int countChangesOfOne = 0;           // counts how many times the chosen cell have became 1 (green)
        public int count = 0;                       // counts how many green cell surrounding each cell

        public void createGrid()     // function that creates the grid
        {
            for (int i = 0; i < width; i++)
            {
                char[] cells = Console.ReadLine().ToCharArray();  // converting the input string in array of chars
                for (int j = 0; j < height; j++)
                {
                    grid[i, j] = Convert.ToInt32(cells[j]) - '0'; /* Converts the value of the specified Unicode 
                                                                  character to the equivalent 32-bit signed 
                                                                  integer minus unicode of 0 */
                }
            }
        }

        public void Changes(int x1, int y1, int generastions) // function for reports changes of the chosen cell
        {
            int countGenerations = 0;    // counter for Generations
            secondGrid = new int[width, height];   // set size for the second grid
            while (countGenerations < generastions)
            {
                for (int i = 0; i < height; i++)
                {
                    for (int j = 0; j < width; j++)
                    {
                        countOnes(i, j, grid);   // function that counts how many cells have 1 (green) 
                        redCell(i, j, grid);     // function for if the current cell have 0 (red) and change to 0 (red) or 1 (green)
                        greenCell(i, j, grid);   // function for if the current cell have 1 (green) and change to 0 (red) or 1 (green)
                        count = 0;
                    }
                }
                for (int i = 0; i < height; i++)
                {
                    for (int j = 0; j < width; j++)
                    {
                        grid[i, j] = secondGrid[i, j];  // assign the second grid to the first one
                    }
                }
                if (grid[x1, y1] == 1)  // check for the chson cell have 1 (green)
                {
                    Console.WriteLine();
                    countChangesOfOne++;  // аadding 1 to countChangesOfOne if there is 1 (green) in the chosen cell
                    for (int i = 0; i < height; i++)
                    {
                        for (int j = 0; j < width; j++)
                        {
                            Console.Write(grid[i, j]);    // printing the grid where the chosen cell have 1 (green)
                        }
                        Console.WriteLine();
                    }
                }
                countGenerations++;
            }
            Console.WriteLine($"Result: {countChangesOfOne}");   /*printing the result how many times there 
                                                                 where 1 (green) in hte chosen cell */
        }

        void countOnes(int x, int y, int[,] mat) // function counts 1 (green) cells surrounding the current cell
        {
            if (x == 0 && y == 0)   // count 1 (green) surrounded top left cell
            {
                if (mat[x + 1, y] == 1) // if the cells neighbour have 1 (green) count increases with 1
                {
                    count++;
                }
                if (mat[x + 1, y + 1] == 1)
                {
                    count++;
                }
                if (mat[x, y + 1] == 1)
                {
                    count++;
                }
            }
            else if (x == 0 && y == height - 1)  // count 1 (green) surrounded bottom left cell
            {
                if (mat[x, y - 1] == 1)
                {
                    count++;
                }
                if (mat[x + 1, y - 1] == 1)
                {
                    count++;
                }
                if (mat[x + 1, y] == 1)
                {
                    count++;
                }
            }
            else if (x == width - 1 && y == 0)  // count 1 (green) surrounded top right cell
            {
                if (mat[x - 1, y] == 1)
                {
                    count++;
                }
                if (mat[x - 1, y + 1] == 1)
                {
                    count++;
                }
                if (mat[x, y + 1] == 1)
                {
                    count++;
                }
            }
            else if (x == width - 1 && y == height - 1) // count 1 (green) surrounded bottom right cell
            {
                if (mat[x - 1, y] == 1)
                {
                    count++;
                }
                if (mat[x - 1, y - 1] == 1)
                {
                    count++;
                }
                if (mat[x, y - 1] == 1)
                {
                    count++;
                }
            }
            else if (y == 0)   // count 1 (green) surrounded top cell between the two corners
            {
                if (mat[x - 1, y] == 1)
                {
                    count++;
                }
                if (mat[x - 1, y + 1] == 1)
                {
                    count++;
                }
                if (mat[x, y + 1] == 1)
                {
                    count++;
                }
                if (mat[x + 1, y + 1] == 1)
                {
                    count++;
                }
                if (mat[x + 1, y] == 1)
                {
                    count++;
                }
            }
            else if (y == height - 1) // count 1 (green) surrounded bottom cell between the two corners
            {
                if (mat[x - 1, y] == 1)
                {
                    count++;
                }
                if (mat[x - 1, y - 1] == 1)
                {
                    count++;
                }
                if (mat[x, y - 1] == 1)
                {
                    count++;
                }
                if (mat[x + 1, y - 1] == 1)
                {
                    count++;
                }
                if (mat[x + 1, y] == 1)
                {
                    count++;
                }
            }
            else if (x == 0) // count 1 (green) surrounded left cell between the two corners
            {
                if (mat[x, y - 1] == 1)
                {
                    count++;
                }
                if (mat[x + 1, y - 1] == 1)
                {
                    count++;
                }
                if (mat[x + 1, y] == 1)
                {
                    count++;
                }
                if (mat[x + 1, y + 1] == 1)
                {
                    count++;
                }
                if (mat[x, y + 1] == 1)
                {
                    count++;
                }
            }
            else if (x == width - 1) // count 1 (green) surrounded right cell between the two corners
            {
                if (mat[x, y - 1] == 1)
                {
                    count++;
                }
                if (mat[x - 1, y - 1] == 1)
                {
                    count++;
                }
                if (mat[x - 1, y] == 1)
                {
                    count++;
                }
                if (mat[x - 1, y + 1] == 1)
                {
                    count++;
                }
                if (mat[x, y + 1] == 1)
                {
                    count++;
                }
            }
            else  // count 1 (green) surrounded middle cell in the grid
            {
                if (mat[x, y - 1] == 1)
                {
                    count++;
                }
                if (mat[x + 1, y - 1] == 1)
                {
                    count++;
                }
                if (mat[x + 1, y] == 1)
                {
                    count++;
                }
                if (mat[x + 1, y + 1] == 1)
                {
                    count++;
                }
                if (mat[x, y + 1] == 1)
                {
                    count++;
                }
                if (mat[x - 1, y + 1] == 1)
                {
                    count++;
                }
                if (mat[x - 1, y] == 1)
                {
                    count++;
                }
                if (mat[x - 1, y - 1] == 1)
                {
                    count++;
                }
            }
        }

        void redCell(int x, int y, int[,] mat) // function for 0 (red) cells
        {
            if (grid[x, y] == 0)  // if the current cell have 0 (red)
            {
                if (count == 3) // if the 1 (green) cells are 3
                {
                    secondGrid[x, y] = 1; // making the current cell 1 (green)
                }
                else if (count == 6) // if the 1 (green) cells are 6
                {
                    secondGrid[x, y] = 1;  // making the current cell 1 (green)
                }
                else // if 1 (green) are not 3 or 6
                {
                    secondGrid[x, y] = 0; // making the current cell 0 (red)
                }
            }
        }

        void greenCell(int x, int y, int[,] mat)  // function for 1 (green) cells
        {
            if (grid[x, y] == 1)  // if the current cell have 1 (green)
            {
                if (count == 2)  // if the 1 (green) cells are 2
                {
                    secondGrid[x, y] = 1;  // making the current cell 1 (green)
                }
                else if (count == 3) // if the 1 (green) cells are 3
                {
                    secondGrid[x, y] = 1;  // making the current cell 1 (green)
                }
                else if (count == 6)  // if the 1 (green) cells are 6
                {
                    secondGrid[x, y] = 1;  /// making the current cell 1 (green)
                }
                else // if the 1 (green) cells are not 2, 3 or 6
                {
                    secondGrid[x, y] = 0;  // making the current cell 0 (red)
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //Read line, and split it by whitespace and ' , ' into an array of strings
            string[] size = Console.ReadLine().Split(",", ' ');
            Grid newGrid = new Grid(); //create new element of Grid
            newGrid.width = int.Parse(size[0]);  //Parse element 0 of size
            newGrid.height = int.Parse(size[1]); //Parse element 1 of size
            if (newGrid.height < 1000 && newGrid.width <= newGrid.height) // if width <= height < 1000
            {
                newGrid.grid = new int[newGrid.width, newGrid.height];  // setting the grid size
                newGrid.createGrid();  // creating the grid
                //Read line, and split it by whitespace and ' , ' into an array of strings
                string[] cellCordinates = Console.ReadLine().Split(",", ' ');
                int y1 = int.Parse(cellCordinates[0]); //Parse element 0 of the first cordinate
                int x1 = int.Parse(cellCordinates[1]); //Parse element 1 of the second cordinate
                int generations = int.Parse(cellCordinates[2]);  // Parse element 2 for how many genarations
                newGrid.Changes(x1, y1, generations); // function for reports changes of the chosen cell
            }            
        }
    }
}