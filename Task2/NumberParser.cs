using System;

namespace Task2
{
    public class NumberParser : INumberParser
    {
        public int Parse(string stringValue)
        {
            if (stringValue == null)
                throw new ArgumentNullException(nameof(stringValue));

            if (stringValue == "")
                throw new FormatException();

            var isNegative = false;
            var isPositiv = false;
            long num = 0;
            switch (stringValue[0])
            {
                case '-':
                    isNegative = true;
                    break;
                case '+':
                    isPositiv = true;
                    break;
                default:
                    break;
            }

            int i = isNegative || isPositiv ? 1 : 0;
            for (; i < stringValue.Length; i++)
            {
                if (i != 0 && (int)stringValue[i] == 32)
                    continue;

                if (((int)stringValue[i] >= 48) && ((int)stringValue[i] <= 57))
                {
                    num = num * 10 + ((int)stringValue[i] - 48);
                }
                else
                {
                    throw new FormatException();
                }

            }

            if (isNegative)
                num = 0 - num;

            if (num > int.MaxValue || num < int.MinValue)
                throw new OverflowException();

            return (int)num;
        }
    }
}