using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Sponsorship_advertising
{
    class Program
    {
        static void Main(string[] args)
        {
            var keywords = new List<string>();
            var url = new List<string>();
            var describe = new List<string>();
            using (var rd = new StreamReader("data.csv"))
            {
                while (!rd.EndOfStream)
                {
                    var splits = rd.ReadLine().Split(';');
                    keywords.Add(splits[0]);
                    url.Add(splits[1]);
                    describe.Add(splits[2]);
                }
            }

            File.Copy("index.html", "newindex.html", true);

            string[] lines = File.ReadAllLines("newindex.html");
            for (int i = 1; i < keywords.Count; i++)
            {
                for (int j = 0; j < lines.Length; j++)
                {
                    if (lines[j].Contains(keywords[i]))
                    {
                        lines[j] = $"<li> <a href = \"{url[i]}\" onMouseOver = \"setStatus('{describe[i]}');\" onMouseOut = \"setStatus('');\" > {keywords[i]} </a></li></li>";
                    }
                }
            }
            File.WriteAllLines("newindex.html", lines);
        }
    }
}
