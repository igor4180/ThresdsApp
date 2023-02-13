MyObject myObject = new MyObject();
myObject.Start = Int32.Parse(Console.ReadLine());
myObject.End = Int32.Parse(Console.ReadLine());
ParameterizedThreadStart parameterizedThreadStart = new ParameterizedThreadStart(ConsoleWrite);
//ThreadStart threadStart = new ThreadStart(ConsoleWrite);
Thread thread = new Thread(parameterizedThreadStart);
thread.IsBackground = true;
thread.Priority = ThreadPriority.Lowest;
thread.Start(myObject);
thread.Join();
for (int i = 0; i <= 50; i++)
{
	Console.WriteLine("из основной программы:" + i);
}
Console.ReadLine();

static void ConsoleWrite(object	 my) 
{
	int start = ((MyObject)my).Start;
	int end = ((MyObject)my).End;
	string message = ((MyObject)my).Message;
	for (int i = start; i <= end; i++)
	{
		Console.WriteLine("Из потока:" + i);
	}
	Console.WriteLine(message);
} 

class MyObject
{
	public int Start { get; set; }
	public int End { get; set; }
	public string Message { get; set; } = "Это читерство";
}
//{
	//Console.WriteLine("Введите число начала массива");
	//int istart = Int32.Parse(Console.ReadLine());
	//Console.WriteLine("Введите число конца массива");
	//for (int i = 0; i <= 50; i++)
	//{
	//	if (i == 25)
	//	{
	//		Console.ReadLine();
	//	}
	//	Console.WriteLine("из потока:" + i);
	//}
//}
