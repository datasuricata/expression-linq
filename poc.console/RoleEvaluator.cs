using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace poc.console
{
    public class RoleEvaluator
    {
        //fake context
        private IQueryable<Product> _db => Product.Collection();
        public void Invoke(IEnumerable<Role> roles)
        {
            var exp = string.Join(" ", roles.Select(Expression)).Trim();
            var args = roles.Select(Paramter).ToArray();
            var query = _db.Where(exp, args).ToList();

            var roleCounter = roles.FirstOrDefault(x => x.Condition == Condition.Count);

            if (roleCounter != null)
            {
                var number = query.Count();
                var value = int.Parse(roleCounter.Value);

                static bool IsValid(Operator @operator, int number, int value) =>
                    @operator switch
                    {
                        Operator.Equals => value == number,
                        Operator.GratherThen => value > number,
                        Operator.GratherOrEqualThen => value >= number,
                        Operator.SmallerThen => value < number,
                        Operator.SmallerOrEqualThen => value <= number,
                        Operator.NotEqual => value != number,
                        _ => throw new ArgumentException(message: "operador inválido"),
                    };

                Console.WriteLine($"Is valid: {IsValid(roleCounter.Operator, number, value)}");
            }

            query.ToList().ForEach(x => Console.WriteLine($"Product:{x.Name} - {x.Category} - Date:{x.CreatedAt:d} - {x.Value:c}"));

            //change query.Where to query.All to validate roles
        }
        private string Expression(Role role)
        {
            if (role.Condition == Condition.Count)
                return default;

            return $"{role.Condition.EnumDisplayAttribute()} {role.Property} {role.Operator.EnumDisplayAttribute()} @{role.Order}";
        }
        private object Paramter(Role role)
        {
            if (role.Condition == Condition.Count)
                return default;

            return new Product().GetType().GetProperty(role.Property).PropertyType == typeof(DateTime) ? DateTime.Parse(role.Value) : (object)role.Value;
        }
    }
}
