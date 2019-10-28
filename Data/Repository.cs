using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;


namespace StudentExercises.Data
{
    class Repository
    {
        public SqlConnection Connection
        {
            get
            {
                // This is "address" of the database
                string _connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=StudentExercises;Integrated Security=True";
                return new SqlConnection(_connectionString);
            }
        }

        public List<Exercise> GetAllExercises()
        {
            // We must "use" the database connection.
            using (SqlConnection conn = Connection)
            {
                // Note, we must Open() the connection, the "using" block doesn't do that for us.
                conn.Open();

                // We must "use" commands too.
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    // Here we setup the command with the SQL we want to execute before we execute it.
                    cmd.CommandText = "SELECT Id, ExerciseName, ProgrammingLanguage FROM Exercise";

                    // Execute the SQL in the database and get a "reader" that will give us access to the data.
                    SqlDataReader reader = cmd.ExecuteReader();

                    // A list to hold the exercises we retrieve from the database.
                    List<Exercise> exercises = new List<Exercise>();

                    // Read() will return true if there's more data to read
                    while (reader.Read())
                    {
                        Exercise exercise = new Exercise
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            ExerciseName = reader.GetString(reader.GetOrdinal("ExerciseName")),
                            ProgrammingLanguage = reader.GetString(reader.GetOrdinal("ProgrammingLanguage"))
                        };

                        // ...and add that exercise object to our list.
                        exercises.Add(exercise);
                    }

                    // We should Close() the reader. Unfortunately, a "using" block won't work here.
                    reader.Close();

                    // Return the list of exercises.
                    return exercises;
                }
            }

        }

        public List<Exercise> GetExerciseByProgLanguage(string ProgrammingLanguage)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT Id, ExerciseName, ProgrammingLanguage FROM Exercise WHERE ProgrammingLanguage = @ProgrammingLanguage";
                    cmd.Parameters.Add(new SqlParameter("@ProgrammingLanguage", ProgrammingLanguage));
                    SqlDataReader reader = cmd.ExecuteReader();

                    List<Exercise> exercises = new List<Exercise>();

                    while (reader.Read())
                    {
                       Exercise exercise = new Exercise
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            ExerciseName = reader.GetString(reader.GetOrdinal("ExerciseName")),
                            ProgrammingLanguage = reader.GetString(reader.GetOrdinal("ProgrammingLanguage"))
                        };

                        exercises.Add(exercise);
                    }
                        reader.Close();
                        return exercises;
                }

            }
        }

        public void AddExercise(Exercise exercise)
        {
            /*
             * TODO: DONE Complete this method by using an INSERT statement with SQL
             *  Remember to use SqlParameters!
             */
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO Exercise (ExerciseName, ProgrammingLanguage) Values (@ExerciseName, @ProgrammingLanguage)";
                    cmd.Parameters.Add(new SqlParameter("@ExerciseName", exercise.ExerciseName));
                    cmd.Parameters.Add(new SqlParameter("@ProgrammingLanguage", exercise.ProgrammingLanguage));
                    cmd.ExecuteNonQuery();
                }
            }
        }




    }
}
