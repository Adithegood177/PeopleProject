namespace PeopleProject
{
    public class PersonStatistics
    {
        
        public List<Person> People { private get; set; }

        public PersonStatistics(List<Person> people)
        {
            
            if (people == null) throw new ArgumentNullException(nameof(people));
            People = people;
        }

        public double GetAverageAge()
        {
           
            return People.Count == 0 ? 0 : People.Average(p => p.Age);
        }

        public int GetNumberOfStudents()
        {
            
            return People.Count(p => p.IsStudent);
        }

        public Person GetPersonWithHighestScore()
        {
            
            return People.Count == 0 ? null : People.OrderByDescending(p => p.Score).First();
        }

        public double GetAverageScoreOfStudents()
        {
            
            var students = People.Where(p => p.IsStudent).ToList();
            return students.Count == 0 ? 0.0 : students.Average(s => s.Score);
        }

        public Person GetOldestStudent()
        {
           
            var students = People.Where(p => p.IsStudent).ToList();
            return students.Count == 0 ? null : students.OrderByDescending(s => s.Age).First();
        }

        public bool IsAnyoneFailing()
        {
            
            return People.Any(p => p.Score < 40);
        }
    }
}