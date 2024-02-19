
using static System.Console;

int some = 1;




static void TimesTable(byte number)
{

    for (int i = 1; i <= 12; i++)
    {
        WriteLine($"{i,-2} * {number,-2} = {number * i,-2}");
    }

}




static decimal CalculateTax(decimal amount, string RegCode)
{

    decimal rate = RegCode.ToUpper() switch
    {
        "CH" => 0.08M,
        "DK" or "NO" => 0.25M,
        "GB" or "FR" => 0.2M,
        "HU" => 0.27M,
        "OR" or "AK" or "MT" => 0.0M,
        "ND" or "WI" or "ME" or "VA" => 0.05M,
        "CA" => 0.0825M,
        _ => 0.06m
    };

    return amount * rate;
}



WriteLine(CalculateTax(149, "fr"));
