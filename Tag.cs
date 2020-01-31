namespace PeachFox
{
    public class Tag
    {
        public string Name;
        public string StringValue { get; private set; } = null;
        public decimal NumberValue { get; private set; } = -1;
        public enum TagType { NULL, STRING, NUMBER };
        public TagType Type = TagType.NULL;

        public Tag(string name, object value)
        {
            Name = name;
            if (value.GetType() == typeof(decimal))
            {
                NumberValue = (decimal)value;
                Type = TagType.NUMBER;
            }
            else if (value.GetType() == typeof(int))
            {
                NumberValue = (int)value;
                Type = TagType.NUMBER;
            }
            else if (value.GetType() == typeof(float))
            {
                NumberValue = (decimal)(float)value;
                Type = TagType.NUMBER;
            }
            else if (value.GetType() == typeof(double))
            {
                NumberValue = (decimal)(double)value;
                Type = TagType.NUMBER;
            }
            else if (value.GetType() == typeof(string))
            {
                StringValue = (string)value;
                Type = TagType.STRING;
            }
            else
                throw new System.InvalidCastException();
        }

        public void SetString(string str)
        {
            Type = TagType.STRING;
            StringValue = str;
        }

        public void SetNumber(decimal num)
        {
            Type = TagType.NUMBER;
            NumberValue = num;
        }

        public override string ToString()
        {
            string str = $"\"{Name}\"=";
            if (Type == TagType.STRING)
                return str +$"\"{StringValue}\"";
            else if (Type == TagType.NUMBER)
                return str + $"{NumberValue}";
            return null;
        }
    }
}
