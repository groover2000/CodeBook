string name = "Samanta Jones";
int lengthOfFirst = name.IndexOf(' ');
int lengthOfLast = name.Length - lengthOfFirst - 1;

string firstName = name.Substring(0, lengthOfFirst);
string lastName = name.Substring(name.Length - lengthOfLast, lengthOfLast);

Console.WriteLine($"FirstName: {firstName} LastName: {lastName}");

ReadOnlySpan<char> nameAsSpan = name.AsSpan();
ReadOnlySpan<char> firstNameSpan = nameAsSpan[..lengthOfFirst];
ReadOnlySpan<char> lastNameSpan = nameAsSpan[^lengthOfLast..];

Console.WriteLine($"FirstName: {firstNameSpan} LastName: {lastNameSpan}");