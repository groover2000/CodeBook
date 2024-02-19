// See https://aka.ms/new-console-template for more information
Console.WriteLine(new string('-', 103));
Console.WriteLine($"{"Type", -8} {"Byte(s) of memory", -15} {"Min", 30} {"Max", 25}");
Console.WriteLine(new string('-', 103));



Console.WriteLine($"{"sbyte", -8} {sizeof(sbyte), -25} {sbyte.MinValue, 30} {sbyte.MaxValue, 25}");
Console.WriteLine($"{"byte", -8} {sizeof(byte), -25} {byte.MinValue, 30} {byte.MaxValue, 25}");
Console.WriteLine($"{"short", -8} {sizeof(short), -25} {short.MinValue, 30} {short.MaxValue, 25}");
Console.WriteLine($"{"ushort", -8} {sizeof(ushort), -25} {ushort.MinValue, 30} {ushort.MaxValue, 25}");
Console.WriteLine($"{"int", -8} {sizeof(int), -25} {int.MinValue, 30} {int.MaxValue, 25}");
Console.WriteLine($"{"uint", -8} {sizeof(uint), -25} {uint.MinValue, 30} {uint.MaxValue, 25}");
Console.WriteLine($"{"long", -8} {sizeof(long), -25} {long.MinValue, 30} {long.MaxValue, 25}");
Console.WriteLine($"{"ulong", -8} {sizeof(ulong), -25} {ulong.MinValue, 30} {ulong.MaxValue, 25}");
Console.WriteLine($"{"float", -8} {sizeof(float), -25} {float.MinValue, 30} {float.MaxValue, 25}");
Console.WriteLine($"{"double", -8} {sizeof(double), -25} {double.MinValue, 30} {double.MaxValue, 25}");
Console.WriteLine($"{"decimal", -8} {sizeof(decimal), -25} {decimal.MinValue, 30} {decimal.MaxValue, 25}");