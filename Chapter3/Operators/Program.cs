using static System.Console;

string s;
int a = 11;
s = a switch
{
    int some when (some > 1) => "Suck 10 dicks",
    _ => "Suck some dick"
};

WriteLine(s);