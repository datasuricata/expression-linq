using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
            var query = _db.Where(predicate: exp, args).OrderBy(x => x.CreatedAt);

            if (query.Any())
                query.ToList().ForEach(x => Console.WriteLine($"Product:{x.Name} - {x.Category} - Date:{x.CreatedAt:d} - {x.Value:c}"));

            //change query.Where to query.All to validate roles
        }
        private string Expression(Role role)
        {
            return $"{role.Condition.EnumDisplayAttribute()} {role.Property} {role.Operator.EnumDisplayAttribute()} @{role.Order}";
        }
        private object Paramter(Role role)
        {
            return new Product().GetType().GetProperty(role.Property).PropertyType == typeof(DateTime) ? DateTime.Parse(role.Value) : (object)role.Value;
        }
    }
}
