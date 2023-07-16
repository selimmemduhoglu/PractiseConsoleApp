new MyClass3d();
MyClass3d _myClass3d = new();




class MyClass
{
    public int? Age { get; set; } 
    public string? Name { get; set; }
    public MyClass() => Console.WriteLine("boş cons.");
    public MyClass(int a) : this() => Console.WriteLine($"b parametreli constructor");
    public MyClass(int a, string b) :this(a) => Console.WriteLine("a parametreli cons.");
    
}
class MyClass2 :MyClass
{
    public string Agency { get; set; }
    public string Surname { get; set; }
    public MyClass2() :base(3 , "selim")
    {
        Console.WriteLine("MyClass2 cons.");
    }
}

class MyClass3d : MyClass2
{
    readonly object x = 15;  //bunun default erişimi belirleyicisi private'tır.
    //readonly'de ister cosnt ta olduğu gibi tanımlama noktasında değer verilebilir istenirse de const içerisinde değer verilebilir.
    
    const int y=3; //const ta yani sabitlerde direkt tanımlama noktasında değer assign edilmelidir const'ta değer atanamaz direkt verilmelidir.

    static int z = 4;
    public MyClass3d() : base()
    {
        x = 16; // Readonly ile tanımlandığı esnadan assign edilen değeri burada ezdim
        z= 5;  // static olduğu için değiştirmek mümkün
        /*y= 6;*/ //cons olduğu için tanımlandığı esnada assign edilen değer değiştirilemez.
        base.Agency = "asdasd";
        Console.WriteLine("MyClass3d cons.");
    }
}

//static ve cons(constunt) arasındaki fark cons yapıları özünde static tir ve tanımlandıktan sonra değiştirilemez
//fakat static tanımlandıktan sonra da değiştirilebilir
///readonly ise hem tanımlandığı yerde hem de constructor içersinde tanımlanabilir.
// readonly aynı zamanda static ti atandıktan sonra değiştirilemez ( ek bilgi adından da anlaşılacağı üzere)