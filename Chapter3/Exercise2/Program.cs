using static System.Console;

checked {



try {
int max = 500;
for (byte i = 0; i < max; i++)
{
 WriteLine(i);
}

}
catch(OverflowException e)
{
    WriteLine(e.Message);
}
}