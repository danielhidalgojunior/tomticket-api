namespace DTExtensions
{
    public static class StringExtension
    {
        public static int ArrayLength = 0;
        public static string InBetween(this string _this, string StrSource, string StrStart, string StrEnd, ref int Starting)
        {
            int loc1 = StrSource.IndexOf(StrStart, Starting);
            int loc2;
            if (loc1 > -1)
                StrSource = StrSource.Substring(loc1 + StrStart.Length);
            loc2 = StrSource.IndexOf(StrEnd);
            if (loc2 > -1)
                StrSource = StrSource.Remove(loc2, StrSource.Length - loc2);
            if ((loc1 < 0) && (loc2 < 0))
            {
                Starting = -1;
                return "";
            }
            Starting = loc1;
            return StrSource;
        }
        public static string InBetween(this string _this, string StrSource, string StrStart, string StrEnd, int Starting = 0)
        {
            int loc1 = StrSource.IndexOf(StrStart, Starting);
            int loc2;
            if (loc1 > -1)
                StrSource = StrSource.Substring(loc1 + StrStart.Length);
            loc2 = StrSource.IndexOf(StrEnd);
            if (loc2 > -1)
                StrSource = StrSource.Remove(loc2, StrSource.Length - loc2);
            if ((loc1 < 0) && (loc2 < 0))
            {
                Starting = -1;
                return "";
            }
            return StrSource;
        }
        public static string[] GetAllBetween(this string _this, string StrSource, string StrStart, string StrEnd)
        {
            int Position = 0;
            int Count = -1;
            while (Position >= 0)
            {
                Position = StrSource.IndexOf(StrStart, Position);
                Position++;
                if (Position == 0)
                    Position = -1;
                Count++;
            }
            string[] result = new string[Count];
            Position = 0;
            for (int i = 0; i < Count; i++)
            {
                result[i] = InBetween(_this, StrSource, StrStart, StrEnd, ref Position);
                Position++;
            }
            ArrayLength = Count;
            return result;
        }
    }
}

