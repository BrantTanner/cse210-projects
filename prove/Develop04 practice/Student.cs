public class Student : Person
{
    
    private string _id;

    public Student(string name, string id) : base(name)
    {
        _id = id;
    }

    public void Display()
    {
        string myName = GetName();
        Console.WriteLine($"Student: {myName} with id: {_id}");
    }
}