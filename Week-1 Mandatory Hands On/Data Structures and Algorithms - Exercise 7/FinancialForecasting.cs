using System;
using System.Collections.Generic;

namespace FinancialForecasting
{
    class Program
    {
        static double CalculateFutureValue(double initialAmount, double growthRate, int years)
        {
            if (years == 0)
                return initialAmount;
            return CalculateFutureValue(initialAmount, growthRate, years - 1) * (1 + growthRate);
        }

        static double CalculateFutureValueMemo(double initialAmount, double growthRate, int years, Dictionary<int, double> memo)
        {
            if (years == 0)
                return initialAmount;
            if (memo.ContainsKey(years))
                return memo[years];
            double result = CalculateFutureValueMemo(initialAmount, growthRate, years - 1, memo) * (1 + growthRate);
            memo[years] = result;
            return result;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Enter current value:");
            double initialAmount = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter growth rate (e.g. 0.05 for 5%):");
            double growthRate = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter number of years:");
            int years = Convert.ToInt32(Console.ReadLine());

            double futureValue = CalculateFutureValue(initialAmount, growthRate, years);
            Console.WriteLine($"Future Value (Recursive): {futureValue:F2}");

            var memo = new Dictionary<int, double>();
            double futureValueMemo = CalculateFutureValueMemo(initialAmount, growthRate, years, memo);
            Console.WriteLine($"Future value after {years} years (memoized): {futureValueMemo:F2}");
        }
    }
}
