namespace PrimeFactorsTest;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        int input = 4;

        string expected = "4: 2 X 2 ";

        string action = PrimeFactorsClass.PrimeFactors(input);

        Assert.Equal(expected, action);
    }
    [Fact]
       public void Test2()
    {
        int input = 7;

        string expected = "7: 7 ";

        string action = PrimeFactorsClass.PrimeFactors(input);

        Assert.Equal(expected, action);
    }
     [Fact]
       public void Test3()
    {
        int input = 30;

        string expected = "30: 2 X 3 X 5 ";

        string action = PrimeFactorsClass.PrimeFactors(input);

        Assert.Equal(expected, action);
    }
}