using System;
class Book : IArt
{
    public string Name { get; set; }
    public Book(string name)
    {
        Name = name;
    }
    public void PrintInfo()
    {
        Console.WriteLine("--------------------------------");
        Console.WriteLine("-> Название книги " + this.Name);
        Console.WriteLine();
    }
}