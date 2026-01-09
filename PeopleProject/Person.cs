namespace PeopleProject;

public class Person
{
    public int Id { get; set; } 
    public string Name { get; set; } 
    public int Age { get; set; } 
    public bool IsStudent { get; set; } 
    public int Score { get; set; } 

    public Person(int id, string name, int age, bool isStudent, int score)
    {
        Id = id;
        Name = name;
        Age = age;
        IsStudent = isStudent;
        Score = score;
    }
}