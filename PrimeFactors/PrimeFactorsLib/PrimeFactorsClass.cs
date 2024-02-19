namespace PrimeFactorsLib;

public class PrimeFactorsClass
{
    public static string PrimeFactors(int number)
    {
        string answer =  $"{number}: ";

        for(int i = 2; i <= number; i++)
        {
            if(number % i == 0)
            {
                answer += $"{i} X ";
                number /= i;
                i = 1;
            }
            
        }

        return answer.Substring(0, answer.Length -2);
    }
}
