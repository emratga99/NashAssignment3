using System;

namespace Assignment3
{
    class Program
    {
        static List<Task<int>> GetTaskList(List<int> numbers)
        {
            var taskList = new List<Task<int>>();
            foreach (var number in numbers)
            {
                taskList.Add(AsyncIsPrime(number));
            };
            return taskList;
        }
        static async Task<int> AsyncGetPrimeNumbersInRange(int min, int max)
        {
            List<int> numbers = Enumerable.Range(min, max).ToList();
            List<Task<int>> taskList = GetTaskList(numbers);
            await Task.WhenAll(taskList);

            taskList.FindAll(o => o.Result > 1).ForEach(q => Console.WriteLine(q.Result));
            return taskList.Count(o => o.Result > 1);
        }
        static async Task<int> AsyncIsPrime(int number)
        {
            return await AIsPrime(number);
        }
        static async Task<int> AIsPrime(int number)
        {
            int a = number / 2;
            for (int i = 2; i <= a; i++)
            {
                if (number % i == 0)
                {
                    return 0;
                }
            }
            return number;

        }
        #region non-async functions
        public static void GetPrimeNumbersInRange(int min, int max)
        {
            for (int i = min; i <= max; i++)
            {
                if (IsPrime(i))
                {
                    Console.WriteLine(i);
                }
            }
        }
        public static bool IsPrime(int number)
        {
            int a = number / 2;
            for (int i = 2; i <= a; i++)
            {
                if (number % i == 0)
                {
                    return false;
                }
            }
            return true;
        }
        #endregion
        public static void Main(string[] args)
        {
            Console.WriteLine("Program started");
            int min = 0;
            int max = 100;
            Task<int> a = AsyncGetPrimeNumbersInRange(min, max);
            int numberOfPrimes = a.Result;
            Console.WriteLine($"There are {numberOfPrimes} prime(s) from {min} to {max}!");
            Console.WriteLine("Program ended");

        }
    }
}