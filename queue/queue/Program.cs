using System;



Console.WriteLine(Kata.QueueTime([2, 3, 10], 0));
public class Kata
{
    public static long QueueTime(int[] customers, int n)
    {
        if (n == 1)
        {
            return customers.Sum();
        }
        if (customers.Length < n)
        {
            return customers.Max();
        }
        int[]? till = new int[n];

        foreach (int waitTime in customers)
        {
            int lowestTill = Array.IndexOf(till, till.Min());
            till[lowestTill] += waitTime;
        }

        return till.Max();
        

    }
}
//Циклом for  с массивом мб? тип while массив не равен нулю в нем дальше фор по количеству касс но будет ошибку выдавать достать декуе из очереди пройтись фором по касса