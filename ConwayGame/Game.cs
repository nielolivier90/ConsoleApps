using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ConwayGame
{
    public class Game : BaseGame
    {
        public Game(int _rows, int _columns, int _generations, int _sleep = 1000)
        {           
            Rows = _rows;
            Columns = _columns;
            Generations = _generations;
            Sleep = _sleep;
            if (_rows < 1 || _rows > 100 || _columns < 1 || _columns > 100 || _generations < 1 || _generations > 1000 || _sleep < 0 || _sleep > 10000)
            {
                throw new ArgumentOutOfRangeException();
            }
        }
        public void Start()
        {
            if (!IsRunning)
            {
                IsRunning = true;
                var grid = new SpawnType[Rows, Columns];
                // Random Grid
                for (var row = 0; row < Rows; row++)
                {
                    for (var column = 0; column < Columns; column++)
                    {
                        grid[row, column] = (SpawnType)_random.Next(0, 2);
                    }
                }
                // Loop Generations
                var count = 0;
                while (IsRunning && Generations > count)
                {
                    count++;
                    var result = "";
                    for (var row = 0; row < Rows; row++)
                    {
                        for (var column = 0; column < Columns; column++)
                        {
                            var cell = grid[row, column];
                            result += cell == SpawnType.Alive ? "*" : "_";
                        }
                        result += "\n";
                    }
                    Console.WriteLine(result);
                    // Get New Grid
                    grid = SpawnNew(grid);
                    Thread.Sleep(Sleep);
                }
                // Done
                if (!IsRunning)
                {
                    Console.WriteLine("Stopped by user");
                }
                else
                {
                    Console.WriteLine("Generations exhausted");
                }
                IsRunning = false;
            }
            else
            {
                throw new Exception("Can only start once the operation is done", new InvalidOperationException());
            }
        }
        public void Stop()
        {
            IsRunning = false;
        }
        public SpawnType[,] SpawnNew(SpawnType[,] grid)
        {
            if (grid == null)
            {
                throw new NullReferenceException();
            }
            var newGrid = new SpawnType[Rows, Columns];
            for (var r = 1; r < Rows - 1; r++)
                for (var c = 1; c < Columns - 1; c++)
                {
                    // Find Neighbors
                    var neighbors = 0;
                    for (var i = -1; i <= 1; i++)
                    {
                        for (var j = -1; j <= 1; j++)
                        {
                            neighbors += grid[r + i, c + j] == SpawnType.Alive ? 1 : 0;
                        }
                    }

                    var currentCell = grid[r, c];

                    // Remove cell from neighbor count
                    neighbors -= currentCell == SpawnType.Alive ? 1 : 0;

                    // Check Rules
                    switch (currentCell)
                    {
                        case SpawnType.Alive:
                            // Any live cell with fewer than two live neighbours dies, as if by underpopulation.
                            if (neighbors < 2)
                            {
                                newGrid[r, c] = SpawnType.Dead;
                            }
                            // Any live cell with two or three live neighbours lives on to the next generation.
                            else if (neighbors == 2 || neighbors == 3)
                            {
                                newGrid[r, c] = SpawnType.Alive;
                            }
                            // Any live cell with more than three live neighbours dies, as if by overpopulation
                            else if (neighbors > 3)
                            {
                                newGrid[r, c] = SpawnType.Dead;
                            }
                            break;
                        case SpawnType.Dead:
                            // Any dead cell with exactly three live neighbours becomes a live cell, as if by reproduction.
                            if (neighbors == 3)
                            {
                                newGrid[r, c] = SpawnType.Alive;
                            }
                            break;
                    }
                }
            return newGrid;
        }
    }   
}
