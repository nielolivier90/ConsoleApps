using System;
using System.Collections.Generic;
using System.Text;

namespace ConwayGame
{
    public class BaseGame
    {
        public Random _random = new Random();
        public enum SpawnType
        {
            Dead = 0,
            Alive = 1,
        }
        public int Rows { get; set; }
        public int Columns { get; set; }
        public bool IsRunning { get; set; }
        public int Sleep { get; set; }
        public int Generations { get; set; }
    }
}
