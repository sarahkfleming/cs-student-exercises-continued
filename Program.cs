using StudentExercises.Data;
using System;
using System.Collections.Generic;

namespace StudentExercises
{
    class Program
    {
        static void Main(string[] args)
        {
            Repository repository = new Repository();

            // Query the database for all the Exercises.
            List<Exercise> exercises = repository.GetAllExercises();

            foreach (Exercise exercise in exercises)
            {
                Console.WriteLine($"{exercise.ExerciseName}: {exercise.ProgrammingLanguage}");
            }
            Console.WriteLine();

            // Find all the exercises in the database where the language is JavaScript.
            exercises = repository.GetExerciseByProgLanguage("JavaScript");

            foreach (Exercise exercise in exercises)
            {
                Console.WriteLine($"{exercise.ExerciseName}: {exercise.ProgrammingLanguage}");
            }
                Console.WriteLine();

            // Insert a new exercise into the database.
            Exercise deptsAndEmployees = new Exercise
            {
                ExerciseName = "Departments and Employees",
                ProgrammingLanguage = "SQL"
            };
            repository.AddExercise(deptsAndEmployees);

            exercises = repository.GetAllExercises();

            foreach (Exercise exercise in exercises)
            {
                Console.WriteLine($"{exercise.ExerciseName}: {exercise.ProgrammingLanguage}");
            }
            Console.WriteLine();

            // Find all instructors in the database. Include each instructor's cohort.


            // Insert a new instructor into the database.Assign the instructor to an existing cohort.


            // Assign an existing exercise to an existing student.







        }
    }
}
