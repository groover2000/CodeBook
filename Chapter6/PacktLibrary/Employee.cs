namespace Packt.Shared;

class Employee : Person
{
    public string? EmployeeCode { get; set; }
    public DateTime HireDate { get; set; }


    public new void WriteToConsole()
    {
        Console.WriteLine($"{EmployeeCode}EMPLOYEE");
    }
}