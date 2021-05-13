using System;
using System.Collections.Generic;

namespace poc.console
{
    public class Strategy
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public IEnumerable<Role> Roles { get; set; } = new List<Role>();

        public static Strategy MyFirstStrategy()
        {
            return new Strategy
            {
                Id = Guid.NewGuid().ToString(),
                Title = "Primeira estratégia",
                Description = "Apenas produtos com categorias PA e data maior que 1970",
                Roles = new List<Role>
                {
                    new Role
                    {
                        Id = Guid.NewGuid().ToString(),
                        Order = 0,
                        Value = "PA",
                        Property = "Category",
                        Operator = Operator.Equals,
                        Condition = Condition.Default
                    },
                    new Role
                    {
                        Id = Guid.NewGuid().ToString(),
                        Order = 1,
                        Value = "1/1/1970",
                        Property = "CreatedAt",
                        Operator = Operator.GratherThen,
                        Condition = Condition.And
                    }
                }
            };
        }
    }
}
