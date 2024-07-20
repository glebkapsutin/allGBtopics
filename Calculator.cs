internal class Calculator : ICalc
{
    public event EventHandler<EventArgs> GotResult;
    public int Result = 0;

    public int Divide(int value)
    {
        Result /= value;
        RaisEvent();
        return Result;
    }

    public int Multiply(int value)
    {
        Result *= value;
        RaisEvent();
        return Result;
    }

    public int Sum(int value)
    {
        Result += value;
        RaisEvent();
        return Result;
    }

    public int Substruct(int value)
    {
        Result -= value;
        RaisEvent();
        return Result;
    }
    public void start()
    {
        while(true)
        {
            Console.WriteLine("Choose an action:");
            Console.WriteLine("1. Add");
            Console.WriteLine("2. Subtract");
            Console.WriteLine("3. Multiply");
            Console.WriteLine("4. Divide");
            Console.WriteLine("5. Exit");
            string choice = Console.ReadLine();
            if (choice =="5")
            {
                break;
            }
            if (int.TryParse(Console.ReadLine(), out int value))
            {
                switch(choice)
                {
                    case "1":
                        Sum(value);
                        break;
                    case "2":
                        Substruct(value);
                        break;
                    case "3":
                        Multiply(value);
                        break;
                    case "4":
                        Divide(value);
                        break;
                }
            }
        }
    }
    private void RaisEvent() => GotResult?.Invoke(this, EventArgs.Empty);
    
}
