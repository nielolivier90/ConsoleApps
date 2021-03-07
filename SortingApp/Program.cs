using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace SortingApp
{
    class Program
    {        
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter text: ");
            Console.WriteLine(new Sorting(Console.ReadLine()).GenerateOutput());
        }       
    }   
}
