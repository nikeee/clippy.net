using System;
using System.Collections.Generic;
using System.Linq;

namespace Clippy
{
    static class AsciiClippy
    {
        internal readonly static string[] Clippy = {
            "╭──╮ ",
            "│  │ ",
            "@  @ ",
            "││ ││",
            "││ ││",
            "│╰─╯│",
            "╰───╯",
        };
        internal readonly static string[] Arm = {
            "   ",
            "   ",
            " ╭ ",
            " │ ",
            " ╯ ",
            "   ",
            "   ",
        };

        internal const string Padding = "        ";
        internal const char VerticalLine = '│';
        internal const char HorizonalLine = '─';
        internal const char TopLeft = '╭';
        internal const char TopRight = '╮';
        internal const char BottomLeft = '╰';
        internal const char BottomRight = '╯';
    }

    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.In.ReadToEnd();

            var lines = new List<string>(input.GetLines());
            if (lines.Count > 0 && lines[^1] == "")
                lines.RemoveAt(lines.Count - 1); // Trimm off ending new line

            if (lines.Count == 0)
                return;

            var maxLength = lines.Max(l => l.GetLengthIgnoringVTEscapeCodes());
            var lineCount = lines.Count;

            for (int lineIndex = 0; lineIndex < Math.Max(AsciiClippy.Clippy.Length, lineCount + 2); ++lineIndex)
            {
                if (lineIndex < AsciiClippy.Clippy.Length)
                {
                    // Draw part of clippy
                    Console.Write(AsciiClippy.Clippy[lineIndex]);
                    Console.Write(AsciiClippy.Arm[lineIndex]);
                }
                else
                {
                    // Draw placeholder, since the speec bubble is larger than clippy
                    Console.Write(AsciiClippy.Padding);
                }

                if (lineIndex == 0)
                {
                    // Draw top border
                    Console.Write(AsciiClippy.TopLeft);
                    Console.Write(AsciiClippy.HorizonalLine.Repeat(maxLength + 2));
                    Console.Write(AsciiClippy.TopRight);
                    Console.Write('\n');
                }
                else if (lineIndex == lineCount + 1)
                {
                    // Draw bottom border
                    Console.Write(AsciiClippy.BottomLeft);
                    Console.Write(AsciiClippy.HorizonalLine.Repeat(maxLength + 2));
                    Console.Write(AsciiClippy.BottomRight);
                    Console.Write('\n');
                }
                else if (lineIndex > lineCount + 1)
                {
                    // Ensure we are at the next line if we a border
                    // This is the case if the lines are shorter than clippy
                    Console.Write('\n');
                }
                else if (lineIndex - 1 < lineCount)
                {
                    // Actual text drawing
                    var value = lines[lineIndex - 1];
                    Console.Write(AsciiClippy.VerticalLine);
                    Console.Write(' ');
                    Console.Write(value.PadRight(maxLength + 1, ' '));
                    Console.Write(AsciiClippy.VerticalLine);
                    Console.Write('\n');
                }
            }
        }
    }

    public static class StringExtensions
    {
        public static string[] GetLines(this string value) => value.Split("\n");

        private const char EscapeChar = '\x1B';
        public static int GetLengthIgnoringVTEscapeCodes(this string value)
        {
            // TODO: Parse only chars that are printed to screen.
            // This way, colored text does not mess with the speech bubble
            return value.Length;
        }

    }
    public static class CharExtensions
    {
        public static string Repeat(this char value, int times)
        {
            return string.Create(times, value, (c, state) =>
            {
                for (int i = 0; i < times; ++i)
                    c[i] = state;
            });
        }
    }
}
