namespace BowlingKata
{
    public class Roll
    {
        private char _value;

        public static string AllowedValues
        {
            get; set;
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
                    throw new System.ArgumentOutOfRangeException(
                        "Value",
                        value,
                        string.Format("Allowed values are: `{0}`", AllowedValues));
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

        public static explicit operator int(Roll r)
        {
            return r.ToIntValue();
        }

        public static int operator +(Roll a, Roll b)
        {
            return (int)a + (int)b;
        }
    }
}
