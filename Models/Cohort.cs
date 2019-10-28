using System.Collections.Generic;


namespace StudentExercises
{
    public class Cohort
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Student> students = new List<Student>();
        
        public List<Instructor> instructors = new List<Instructor>();
    }
}