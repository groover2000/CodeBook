namespace Packt.Shared;

public static class NumbersToWords
{

    private static string[] smallNums = [
        "Ноль", "Один", "Два", "Три", "Четыре", "Пять", "Шесть", "Семь", "Восемь", "Девять", "Десять",
        "Одиннадцать", "Двенадцать", "Тринадцать", "Четырнадцать", "Пятнадцать", "Щестнадцать", 
        "Семнадцать", "Восемнадцать", "Девятнадцать"
    ];

    private static string[] tens = [
        "","","Двадцать", "Тридцать", "Сорок", "Пятьдесят", "Шестьдесят", "Семьдесят", "Восемьдесят", "Девяносто"
    ];

    private static string[] bigNums = [
        "Сто", "Тысяча", "Миллион", "Миллиард"
    ];

    public static void ToWord(this int num)
    {
        Console.WriteLine(num);
    }
}
