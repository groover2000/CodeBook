using static System.Console;

WriteLine($"There are {args.Length} arguments.");

ForegroundColor = (ConsoleColor) Enum.Parse(enumType: typeof(ConsoleColor), value: args[0], ignoreCase: true);

BackgroundColor = (ConsoleColor)Enum.Parse(enumType: typeof(ConsoleColor), value: args[1], ignoreCase: true);