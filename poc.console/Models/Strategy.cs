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
                Description = "quantidade de produtos não pode passar de 3 com categorias PP e data maior ou igual que 1910 e data menor ou igual que 1970",
                Roles = new List<Role>
                {
                    new Role
                    {
                        Id = Guid.NewGuid().ToString(),
                        Order = 0,
                        Value = "PP", 
                        Property = "Category",
                        Operator = Operator.Equals,
                        Condition = Condition.Default
                    },
                    new Role
                    {
                        Id = Guid.NewGuid().ToString(),
                        Order = 1,
                        Value = "1/1/1950",
                        Property = "CreatedAt",
                        Operator = Operator.GratherOrEqualThen,
                        Condition = Condition.And
                    },
                    new Role
                    {
                        Id = Guid.NewGuid().ToString(),
                        Order = 2,
                        Value = "1/1/1999",
                        Property = "CreatedAt",
                        Operator = Operator.SmallerOrEqualThen,
                        Condition = Condition.And
                    },
                    new Role
                    {
                        Id = Guid.NewGuid().ToString(),
                        Order = 3,
                        Value = "3",
                        Property = "Category",
                        Operator = Operator.GratherThen,
                        Condition = Condition.Count
                    }
                }
            };
        }
    }
}
