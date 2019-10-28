namespace StudentExercises
{
    public class Instructor : NSSPerson
    {
        public string Specialty { get; set; }
       public void AssignExercise(Student student, Exercise exercise)
       {
           student.exercises.Add(exercise);
       }
    }
}