using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Colorfy
{
    public class ColoredString
    {
        public ConsoleColor Color;
        public String Text;

        public ColoredString(ConsoleColor color, string text)
        {
            Color = color;
            Text = text;
        }
    }
}
