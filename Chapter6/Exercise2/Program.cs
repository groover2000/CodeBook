using Exercise2;


Shape s = new() {Height = 0.5m, Width = 1, Area = 20 }; 
Rectangle r = new() {Height = 50, Width = 20, Area = 60 }; 
Square sq = new() {Height = 100, Width = 70, Area = 34 };


Console.WriteLine($"Shape H: {s.Height} W: {s.Width} A: {s.Area}");
Console.WriteLine($"Rectangle H: {r.Height} W: {r.Width} A: {r.Area}");
Console.WriteLine($"Square H: {sq.Height} W: {sq.Width} A: {sq.Area}");