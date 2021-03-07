using System;
using System.Collections.Generic;
using System.Text;

namespace ConwayGame
{
    public class BaseGame
    {
        protected Random _random = new Random();
        public enum SpawnType
        {
            Dead = 0,
            Alive = 1,
        }
        protected int Rows { get; set; }
        protected int Columns { get; set; }
        protected bool IsRunning { get; set; }
        protected int Sleep { get; set; }
        protected int Generations { get; set; }
    }
}
