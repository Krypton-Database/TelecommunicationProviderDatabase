namespace TelecommunicationProvider.Data
{
    using System;

    public class RandomGenerator 
    {
        private const string Letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";

        private static RandomGenerator instance;

        private readonly Random random;

        private RandomGenerator()
        {
            this.random = new Random();
        }

        public static RandomGenerator Instance
        {
            get
            {
                return instance ?? (instance = new RandomGenerator());
            }
        }

        public int GetRandomNumber(int min, int max)
        {
            return this.random.Next(min, max + 1);
        }

        public string GetRandomString(int length)
        {
            var chars = new char[length];

            for (int i = 0; i < length; i++)
            {
                chars[i] = Letters[this.GetRandomNumber(0, Letters.Length - 1)];
            }

            return new string(chars);
        }

        public DateTime GetRandomDate(DateTime? startDate = null, DateTime? endDate = null)
        {
            DateTime start = startDate ?? new DateTime(1995, 1, 1);
            DateTime end = endDate ?? new DateTime(2050, 12, 31);
            Random gen = new Random();

            int range = (end - start).Days;
            return start.AddDays(GetRandomNumber(0, range-1));
        }
    }
}
