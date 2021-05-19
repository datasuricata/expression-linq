using System;

namespace poc.console
{
    class Program
    {
        static void Main(string[] args)
        {
            var strategy = Strategy.MyFirstStrategy();

            Console.WriteLine(strategy.Title);
            Console.WriteLine(strategy.Description);

            new RoleEvaluator().Invoke(strategy.Roles);
        }
    }
}