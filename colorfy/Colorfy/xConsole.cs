using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DTExtensions;

namespace Colorfy
{
    public static class xConsole
    {
        public static char OpenChar = '{';
        public static char CloseChar = '}';

        public enum ConsoleOption
        {
            TagLexer,
            Normal,
            Rainbow,
            WordRainbow
        }

        private static ConsoleColor GetColor(string strcolor)
        {
            ConsoleColor color = Console.ForegroundColor;

            switch (strcolor.ToLower())
            {
                case "black":
                    {
                        color = ConsoleColor.Black;
                        break;
                    }
                case "blue":
                    {
                        color = ConsoleColor.Blue;
                        break;
                    }
                case "cyan":
                    {
                        color = ConsoleColor.Cyan;
                        break;
                    }
                case "darkblue":
                    {
                        color = ConsoleColor.DarkBlue;
                        break;
                    }
                case "darkcyan":
                    {
                        color = ConsoleColor.DarkCyan;
                        break;
                    }
                case "darkgrey":
                    {
                        color = ConsoleColor.DarkGray;
                        break;
                    }
                case "darkgreen":
                    {
                        color = ConsoleColor.DarkGreen;
                        break;
                    }
                case "darkmagenta":
                    {
                        color = ConsoleColor.DarkMagenta;
                        break;
                    }
                case "darkred":
                    {
                        color = ConsoleColor.DarkRed;
                        break;
                    }
                case "darkyellow":
                    {
                        color = ConsoleColor.DarkYellow;
                        break;
                    }
                case "gray":
                    {
                        color = ConsoleColor.Gray;
                        break;
                    }
                case "green":
                    {
                        color = ConsoleColor.Green;
                        break;
                    }
                case "magenta":
                    {
                        color = ConsoleColor.Magenta;
                        break;
                    }
                case "red":
                    {
                        color = ConsoleColor.Red;
                        break;
                    }
                case "white":
                    {
                        color = ConsoleColor.White;
                        break;
                    }
                case "yellow":
                    {
                        color = ConsoleColor.Yellow;
                        break;
                    }
            }

            return color;
        }

        private static ColoredString GetFirstTag(this string input, ref int starting)
        {
            int startTag = input.IndexOf(OpenChar, starting);
            int endTag = input.IndexOf(CloseChar, starting);
            int endMessage = input.IndexOf(OpenChar, endTag + 1);

            if (endMessage == -1)
                endMessage = input.Length;

            string message = input.Substring(endTag + 1, endMessage - endTag - 1);
            ConsoleColor color = GetColor(input.Substring(startTag + 1, (endTag - 1) - startTag));

            starting = endMessage;

            return new ColoredString(color, message);
        }

        private static ColoredString[] GetAllTags(this string input)
        {
            int starting = 0;
            int TagsCount = input.GetAllBetween(input, OpenChar.ToString(), CloseChar.ToString()).Count();
            ColoredString[] cs = new ColoredString[TagsCount];

            for (int i = 0; i < TagsCount; i++)
            {
                cs[i] = GetFirstTag(input, ref starting);
            }

            return cs;
        }

        public static void Write(string input, ConsoleOption option = ConsoleOption.TagLexer, int delay = 0)
        {
            switch (option)
            {
                case ConsoleOption.TagLexer:
                    {
                        WriteLexer(input, delay);
                        break;
                    }
                case ConsoleOption.Normal:
                    {
                        WriteNormal(input, delay);
                        break;
                    }
                case ConsoleOption.Rainbow:
                    {
                        WriteRainbow(input, delay);
                        break;
                    }
                case ConsoleOption.WordRainbow:
                    {
                        WriteWordRainbow(input, delay);
                        break;
                    }
            }
        }

        public static void WriteNormal(string input, int delay)
        {
            if (delay != 0) 
                Thread.Sleep(delay);
        }

        public static void Write(params ColoredString[] strings)
        {
            var originalColor = Console.ForegroundColor;
            foreach (var str in strings)
            {
                Console.ForegroundColor = str.Color;
                Console.Write(str.Text);
            }
            Console.ForegroundColor = originalColor;
        }

        public static void WriteLine(string input)
        {
            if (!input.Contains(OpenChar) && !input.Contains(CloseChar))
            {
                Console.WriteLine(input);
                return;
            }

            ConsoleColor color = Console.ForegroundColor;
            ColoredString[] cs = GetAllTags(input);

            var originalColor = Console.ForegroundColor;
            foreach (var str in cs)
            {
                Console.ForegroundColor = str.Color;
                Console.Write(str.Text);
            }
            Console.WriteLine("");
            Console.ForegroundColor = originalColor;
        }

        public static void WriteLine(params ColoredString[] strings)
        {
            var originalColor = Console.ForegroundColor;
            foreach (var str in strings)
            {
                Console.ForegroundColor = str.Color;
                Console.Write(str.Text + "\n");
            }
            Console.ForegroundColor = originalColor;
        }

        public static void WriteLexer(string input, int delay)
        {
            if (!input.Contains(OpenChar) && !input.Contains(CloseChar))
            {
                Console.Write(input);
                return;
            }

            ConsoleColor color = Console.ForegroundColor;
            ColoredString[] cs = GetAllTags(input);

            var originalColor = Console.ForegroundColor;
            foreach (var str in cs)
            {
                Console.ForegroundColor = str.Color;
                Console.Write(str.Text);
            }
            Console.ForegroundColor = originalColor;
        }

        public static void WriteRainbow(string input, int delay)
        {
            Random r = new Random(input.Length);

            ConsoleColor color;
            foreach (char c in input)
            {
                color = (ConsoleColor)r.Next(1, 15);
                Console.ForegroundColor = color;
                Console.Write(c);
            }
        }

        public static void WriteWordRainbow(string input, int delay)
        {
            Random r = new Random(input.Length);

            string[] words = input.Split(' ');

            ConsoleColor color;
            foreach (string word in words)
            {
                color = (ConsoleColor)r.Next(1, 15);
                Console.ForegroundColor = color;
                Console.Write(word + ' ');
            }
        }
    }
}
