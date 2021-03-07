using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace SortingApp
{
    public class Sorting
    {
        private string sampleText;
        public Sorting(string _sampleText)
        {
            sampleText = _sampleText;
        }
        public string GenerateOutput()
        {
            //Remove Special Characters, Numbers and Spaces
            Regex rgx = new Regex(@"[^a-zA-Z]");
            var plainText = rgx.Replace(sampleText, "").ToLower();
            //Create Array
            var chars = plainText.ToCharArray();
            var max = 0;
            var result = new List<Tuple<int, char>>();
            for (int i = 0; i < chars.Length; i++)
            {
                var value = char.ToUpper(chars[i]) - 64;
                //Check if we can place at the end
                if (value >= max)
                {
                    max = value;
                    result.Add(new Tuple<int, char>(value, chars[i]));
                }
                //Find the correct position
                else
                {
                    for (int j = 0; j < result.Count(); j++)
                    {
                        if (result[j].Item1 >= value)
                        {
                            result.Insert(j, new Tuple<int, char>(value, chars[i]));
                            break;
                        }
                    }
                }
            }
            return string.Join("", result.Select(c => c.Item2));
        }
    }
}
