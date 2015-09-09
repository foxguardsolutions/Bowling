namespace BowlingKata
{
    public class Roll
    {
        private char _value;
        private static string _allowedValues;

        public static string AllowedValues
        {
            get { return _allowedValues; }
            set { _allowedValues = value; }
        }

        public char Value
        {
            get
            {
                return _value;
            }
            set
            {
                if (!AllowedValues.Contains(string.Empty + value))
                {
                    throw new InvalidValueException();
                }

                _value = value;
            }
        }

        public Roll(char val)
        {
            Value = val;
        }

        public Roll()
        {
            Value = AllowedValues[0];
        }

        public int ToIntValue()
        {
            return AllowedValues.IndexOf(Value);
        }

        public static implicit operator int(Roll r)
        {
            return r.ToIntValue();
        }

        public static int operator +(Roll a, Roll b)
        {
            return (int)a + (int)b;
        }
    }
}
