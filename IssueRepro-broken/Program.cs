using System;
using System.Collections.Generic;
using System.Linq;

namespace IssueReproRepo
{
    class Program
    {
        static void Main(string[] args)
        {
            const string testMessage = "Line1|Field1|Field2\rLine2|Field3|Field4\r\r";

            var message = ParseMessage(testMessage);
            var line2 = message.FirstOrDefault(s => s[0] == "Line2");

            Console.WriteLine(line2);
        }

        public static IReadOnlyList<string[]> ParseMessage(in string message)
        {
            var lines = message.Split(new[] { "\r" }, StringSplitOptions.RemoveEmptyEntries);
            return lines.Select(ParseLine).ToList();
        }

        private static string[] ParseLine(in string segmentLine)
        {
            return segmentLine.Split(new[] { '|' }, StringSplitOptions.None);
        }
    }
}
