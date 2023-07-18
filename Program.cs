//#nullable enable
/*string? name = null;
PrintUpper(name!);
int? val= null;
IsNull(val);
val = 35;
IsNull(val);
PrintNullAble(null);
PrintNullAble(25);*/
/*Message mes;
Message? mes1;
Message mes2;
Message? mes3=null;
mes1 = Hello;
mes = Hello;
mes();
Console.WriteLine("*****************");
mes += Welcome.Print;
mes();
Console.WriteLine("*****************");
mes += new Hello().Display;
mes();
Console.WriteLine("*****************");
mes2 = mes + mes1;
mes2();
Console.WriteLine();
mes.Invoke();
Operation op = Add;
int n = op.Invoke(44, 99);
Console.WriteLine(n);
mes3?.Invoke();
Console.WriteLine("**********************");
DoOperation(33, 67, Add);
DoOperation(87, 35, Subtract);
DoOperation(20,44, Multiply);*/
/*Operation operation = SelectOperation(OperationType.Add);
Console.WriteLine(operation(14,8));

operation= SelectOperation(OperationType.Subtract);
Console.WriteLine(operation(14,9));

operation= SelectOperation(OperationType.Multiply);
Console.WriteLine(operation(14,10));



Operation SelectOperation(OperationType opType)
{
    switch(opType)
    {
        case OperationType.Add:return Add;
        case OperationType.Subtract:return Subtract;
        default:return Multiply;
    }
}

void Hello() => Console.WriteLine("Hello world!");
int Add(int x, int y) => x + y; 
int Subtract(int x, int y) => x - y;
int Multiply(int x, int y) => x * y;

void DoOperation(int a, int b,Operation op)
{
    Console.WriteLine(op(a, b));
}
enum OperationType
{ Add, Subtract, Multiply };
delegate void Message();
delegate int Operation(int x, int y);
/*void PrintUpper(string? text)
    
{
    if (text == null) Console.WriteLine("null");
    else Console.WriteLine(text.ToUpper());
}
void IsNull(int? obj)
{
    if (obj == null) Console.WriteLine("null");
    else Console.WriteLine(obj);
}
void PrintNullAble(int? number)
{
    if (number.HasValue)
    {
        Console.WriteLine(number.Value);
        Console.WriteLine(number);
    }
    else Console.WriteLine("null");
}*/
Account account = new Account(200);
account.RegisterHandler(PrintSimpleMessage);
account.RegisterHandler(PrintColorMessage);
account.Take(100);
account.Take(150);
account.UnregisterHandler(PrintColorMessage);
account.Take(50);

void PrintSimpleMessage(string message)=>Console.WriteLine(message);
void PrintColorMessage(string message)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine(message);
    Console.ResetColor();
}
public delegate void AccountHandler(string message);
public class Account
{
    int sum;
    AccountHandler? taken;
    public Account(int sum)=>this.sum=sum;
    public void RegisterHandler(AccountHandler handler)
    {
        taken += handler;
    }
    public void UnregisterHandler(AccountHandler handler)
    {
        taken-= handler;
    }
    public void Add(int sum) { this.sum+=sum; }
    public void Take(int sum)
    {
        if (this.sum >= sum)
        {
            this.sum -= sum;
            taken?.Invoke($"Со счета списано {sum} y.e.");
        }
        else
        {
            taken?.Invoke($"Недостаточно средств. Баланс: {this.sum} y.e.");
        }
                
    }
}
class Welcome
{
    public static void Print() => Console.WriteLine("Welcome");
}
class Hello
{
    public  void Display() => Console.WriteLine("Привет");
}