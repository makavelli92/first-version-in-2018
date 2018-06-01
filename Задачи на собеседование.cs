 
 1) Что плохого в коде?
 
 static void Main()
{
	string s = "";
	for(int i = 0; i < 1000; i++)
	{
		s += i.ToString();
	}
	
	Console.WritLine(s);
}
 
2) Что выведет консоль и почему?

public enum Country
 {
     USA,
     Russia
 }
 class Person
 {
     public string Name { get; set; }
     public int Age { get; set; }
 }

 static void Modify(Person person, int y, Country country)
 {
     person.Name = "Ivan";
     person.Age = 20;
     y = 20;
     country = Country.Russia;
 }
 static void Main(string[] args)
 {
     var person = new Person();
     person.Name = "Petr";
     person.Age = 23;
     int x = 5;
     Country country = Country.USA;

     Modify(person, x, country);

     Console.WriteLine(String.Format($"{person.Name}, {person.Age}, {x}, {country}"));

     Console.ReadLine();
 }
 
 
3) Что выведет консоль и почему?

string s = "A";
Action action = () =>
{
    Console.WriteLine(s);
    s = "B";
};
s = "C";
action();
Console.WriteLine(s);


4)Что выведет консоль и почему?

class A
{
    public int x;

    public override bool Equals(object obj)
    {
        return this.x == ((A)obj).x;
    }
}
class Program
{
    static void Main(string[] args)
    {
        A a1 = new A { x = 10 };
        A a2 = new A { x = 10 };
        Console.WriteLine((Object)a1 == (Object)a2);
        Console.WriteLine(a1.Equals(a2));

        Console.ReadKey();

    }
}

5) Что выведет консоль и почему?

string s1 = "Hello";
string s2 = new String("Hello".ToCharArray());

Console.WriteLine(s1 == s2);
Console.WriteLine((object)s1 == (object)s2);
Console.WriteLine(Object.ReferenceEquals(s1, s2));

Console.ReadKey();

6) Что произойдет при выполнении кода?

List<MyDelegate> list = new List<MyDelegate>();

for (int i = 0; i < 10 ; i++)
{
    list.Add(()=>Console.WriteLine(i));
}
foreach(var i in list)
{
    i();
}

Console.ReadKey();


7) Что выведет консоль и почему?

class A
 {
     public virtual void Show()
     {
         Console.WriteLine("class A");
     }
 }

 class B : A
 {
     public virtual void Show()
     {
         Console.WriteLine("class B");
     }
 }

 class C : B
 {
     public override void Show()
     {
         Console.WriteLine("class C");
     }
 }
 static void Main(string[] args)
 {
     A ob = new C();
     ob.Show();

     Console.ReadLine();
 }
		


8) Что выведет консоль и почему?

class A
 {
     public virtual void Show()
     {
         Console.WriteLine("class A");
     }
 }

 class B : A
 {
     public override void Show()
     {
         Console.WriteLine("class B");
     }
 }

 class C : B
 {
     public new void Show()
     {
         Console.WriteLine("class C");
     }
 }
 static void Main(string[] args)
 {
     A ob = new C();
     ob.Show();

     Console.ReadLine();
 }
 
 9) Что выведет консоль и почему?
 
 static int Method(int number)
{
    if (number == 0)
        return 1;
    return number * Method(number - 1);
}
static void Main(string[] args)
{
    Console.WriteLine(Method(5));

    Console.ReadLine();
}