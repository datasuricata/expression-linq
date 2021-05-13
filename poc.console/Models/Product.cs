using System;
using System.Linq;

namespace poc.console
{
    public class Product
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public double Value { get; set; }
        public DateTime CreatedAt { get; set; }

        public static IQueryable<Product> Collection() => Enumerable.Range(1, 10000).Select(x =>
        new Product
        {
            Id = Guid.NewGuid().ToString(),
            Name = RandomText(10),
            Category = RandomText(2),
            CreatedAt = new DateTime(new Random().Next(1900, 2020), new Random().Next(1, 12), new Random().Next(1, 25)),
            Value = new Random().Next(500)
        }).AsQueryable();

        private static string RandomText(int length)
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
