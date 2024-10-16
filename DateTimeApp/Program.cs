namespace DateTimeApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите дату и время.");

            int day = ReadInt("День (1-31):", 1, 31);
            int month = ReadInt("Месяц (1-12):", 1, 12);
            int year = ReadInt("Год (1900-2100):", 1900, 2100);
            int hour = ReadInt("Час (0-23):", 0, 23);
            int minute = ReadInt("Минута (0-59):", 0, 59);

            try
            {
                DateTime dateTime = new DateTime(year, month, day, hour, minute, 0);
                Console.WriteLine($"Введенная дата и время: {dateTime}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }
        public static int ReadInt(string prompt, int minValue, int maxValue, Func<string> reader = null)
        {
            Console.Write(prompt);
            string input = reader != null ? reader() : Console.ReadLine();

            if (!int.TryParse(input, out int value))
            {
                throw new FormatException("Введенное значение имеет неверный формат.");
            }

            if (value < minValue || value > maxValue)
            {
                throw new ArgumentOutOfRangeException($"Значение должно быть между {minValue} и {maxValue}.");
            }

            return value;
        }
    }
}
