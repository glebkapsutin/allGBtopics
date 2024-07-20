internal interface ICalc
{
    event EventHandler<EventArgs> GotResult;

    int Sum(int value);
    int Substruct(int value);
    int Multiply(int value);
    int Divide(int value);

}
