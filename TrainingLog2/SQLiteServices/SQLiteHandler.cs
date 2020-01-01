using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using SQLite;
using TrainingLog2.Entities;
using static TrainingLog2.DateTimeClass;

namespace TrainingLog2.SQLiteServices
{
    public class SQLiteHandler
    {
        private SQLiteConnection conn;
        private string dbPath;
        public SQLiteHandler()
        {
            dbPath = CreateDatabaseIfNotExists();
            conn = new SQLiteConnection(dbPath);
        }
        private string CreateDatabaseIfNotExists()
        {
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "traininglog.db3");
        }

        public void CreateDatabase()
        {
            DropTables();
            CreateTablesIfNotExists();
            InsertExampleDataIfNotExists();
            InsertExampleExercises();
            InsertExampleLoggedEntries();
        }

        public void InsertRoutine(string name)
        {
            Routine newRoutine = new Routine();
            newRoutine.Name = name;
            conn.Insert(newRoutine);
        }

        private void CreateTablesIfNotExists()
        {
            conn.CreateTable<Category>();
            conn.CreateTable<Exercise>();
            conn.CreateTable<Exercise_Category>();
            conn.CreateTable<Log_Cardio_Set_Entry>();
            conn.CreateTable<Log_Set_Entry>();
            conn.CreateTable<Target_Set>();
            conn.CreateTable<Target_Set_Trainingmax>();
            conn.CreateTable<Workout>();
            conn.CreateTable<Workout_Exercise>();
            conn.CreateTable<Workout_Exercise_Trainingmax>();
            conn.CreateTable<Routine>();
        }

        private void DropTables()
        {
            conn.DropTable<Exercise>();
            conn.DropTable<Workout>();
            conn.DropTable<Workout_Exercise>();
            conn.DropTable<Target_Set>();
            conn.DropTable<Log_Set_Entry>();
            conn.DropTable<Log_Cardio_Set_Entry>();
        }

        private void InsertExampleDataIfNotExists()
        {
            InsertExampleCategories();
            
        }

        private void InsertExampleExercises()
        {
            if (conn.Table<Exercise>().Count() == 0)
            {
                Exercise pushup = new Exercise();
                pushup.Name = "Push up";
                conn.Insert(pushup);
                Exercise bench_press = new Exercise();
                bench_press.Name = "Bench Press";
                conn.Insert(bench_press);
            }
        }

        private void InsertExampleLoggedEntries()
        {
            if (conn.Table<Log_Set_Entry>().Count() == 0)
            {
                Log_Set_Entry log_set = new Log_Set_Entry();
                log_set.Date = DateTime.Today;
                log_set.Reps = 8;
                log_set.Min_reps = 6;
                log_set.Max_reps = 10;
                log_set.Weight = 50;
                log_set.ExerciseId = 1;
                conn.Insert(log_set);
                log_set = new Log_Set_Entry();
                log_set.Date = DateTime.Today;
                log_set.Reps = 8;
                log_set.Min_reps = 6;
                log_set.Max_reps = 10;
                log_set.Weight = 50;
                log_set.ExerciseId = 1;
                conn.Insert(log_set);
                log_set = new Log_Set_Entry();
                log_set.Date = DateTime.Today;
                log_set.Reps = 8;
                log_set.Min_reps = 6;
                log_set.Max_reps = 10;
                log_set.Weight = 50;
                log_set.ExerciseId = 1;
                conn.Insert(log_set);
                log_set = new Log_Set_Entry();
                log_set.Date = DateTime.Today;
                log_set.Reps = 7;
                log_set.Min_reps = 6;
                log_set.Max_reps = 10;
                log_set.Weight = 60;
                log_set.ExerciseId = 2;
                conn.Insert(log_set);

            }

            if (conn.Table<Log_Cardio_Set_Entry>().Count() == 0)
            {
                Log_Cardio_Set_Entry log_set = new Log_Cardio_Set_Entry();
                log_set.Date = DateTime.Today;
                log_set.Type = "m";
                log_set.Distance = 100;
                log_set.Minutes = 10;
                log_set.Seconds = 50;
                log_set.ExerciseId = 2;
                conn.Insert(log_set);
                log_set = new Log_Cardio_Set_Entry();
                log_set.Date = DateTime.Today.AddDays(5);
                log_set.Type = "km";
                log_set.Distance = 2;
                log_set.Hours = 1;
                log_set.Minutes = 0;
                log_set.Seconds = 50;
                log_set.ExerciseId = 2;
                conn.Insert(log_set);
            }

            if (conn.Table<Workout>().Count() == 0)
            {
                Workout work = new Workout();
                work.Name = "monday";
                work.RoutinesId = 1;
                conn.Insert(work);

                Workout_Exercise exer = new Workout_Exercise();
                exer.WorkoutId = work.Id;
                exer.ExerciseId = 1;
                conn.Insert(exer);
                exer = new Workout_Exercise();
                exer.WorkoutId = work.Id;
                exer.ExerciseId = 2;
                conn.Insert(exer);
                Target_Set targ_set = new Target_Set();
                targ_set.Workout_ExerciseId = 1;
                targ_set.Min_reps = 5;
                targ_set.Max_reps = 5;
                conn.Insert(targ_set);
                targ_set = new Target_Set();
                targ_set.Workout_ExerciseId = 1;
                targ_set.Min_reps = 5;
                targ_set.Max_reps = 5;
                conn.Insert(targ_set);
                targ_set = new Target_Set();
                targ_set.Workout_ExerciseId = 1;
                targ_set.Min_reps = 5;
                targ_set.Max_reps = 5;
                conn.Insert(targ_set);
                targ_set = new Target_Set();
                targ_set.Workout_ExerciseId = 1;
                targ_set.Min_reps = 5;
                targ_set.Max_reps = 5;
                conn.Insert(targ_set);
                targ_set = new Target_Set();
                targ_set.Workout_ExerciseId = 2;
                targ_set.Min_reps = 5;
                targ_set.Max_reps = 5;
                conn.Insert(targ_set);
                targ_set = new Target_Set();
                targ_set.Workout_ExerciseId = 2;
                targ_set.Min_reps = 5;
                targ_set.Max_reps = 5;
                conn.Insert(targ_set);
                Workout_Exercise_Trainingmax exer_max = new Workout_Exercise_Trainingmax();
                exer_max.Workouts_ExercisesId = exer.Id;
                exer_max.TrainingMax = 80;
                conn.Insert(exer_max);
                Target_Set_Trainingmax set = new Target_Set_Trainingmax();
                set.Min_reps = 8;
                set.Max_reps = 8;
                set.Percent = 60;
                set.Round = 0;
                conn.Insert(set);
                Target_Set_Trainingmax set2 = new Target_Set_Trainingmax();
                set2.Min_reps = 3;
                set2.Max_reps = 3;
                set2.Percent = 90;
                set2.Round = 0;
                conn.Insert(set2);
                Log_Set_Entry log = new Log_Set_Entry();
                log.Date = DateTime.Today.AddDays(-5);
                log.Reps = set.Min_reps;
                log.Weight = exer_max.TrainingMax * (set.Percent / 100);
                conn.Insert(log);
                log = new Log_Set_Entry();
                log.Date = DateTime.Today.AddDays(-5);
                log.Reps = set2.Min_reps;
                log.Weight = exer_max.TrainingMax * (set2.Percent / 100);
                conn.Insert(log);
            }
        }

        private void InsertExampleCategories()
        {
            if (conn.Table<Category>().Count() == 0)
            {
                Category newCategory = new Category();
                newCategory.Name = "Shoulders";
                  conn.Insert(newCategory);
                newCategory = new Category();
                newCategory.Name = "Triceps";
                  conn.Insert(newCategory);
                newCategory = new Category();
                newCategory.Name = "Biceps";
                  conn.Insert(newCategory);
                newCategory = new Category();
                newCategory.Name = "Chest";
                  conn.Insert(newCategory);
                newCategory = new Category();
                newCategory.Name = "Back";
                  conn.Insert(newCategory);
                newCategory = new Category();
                newCategory.Name = "Legs";
                  conn.Insert(newCategory);
                newCategory = new Category();
                newCategory.Name = "Abs";
                  conn.Insert(newCategory);
                newCategory = new Category();
                newCategory.Name = "Arms";
                  conn.Insert(newCategory);
                newCategory = new Category();
                newCategory.Name = "Upperbody";
                  conn.Insert(newCategory);
                newCategory = new Category();
                newCategory.Name = "Lowerbody";
                  conn.Insert(newCategory);
                newCategory = new Category();
                newCategory.Name = "Cardio";
                  conn.Insert(newCategory);
            }
        }

        public void PrintCategories()
        {
            var categoryTable = conn.Table<Category>();
            foreach(var category in categoryTable)
            {
                Log.Info("category", category.Id.ToString() + category.Name);
            }
            var logsetTable = conn.Table<Log_Set_Entry>();
            foreach(var logset in logsetTable)
            {
                Log.Info("log_set", "id: " + logset.Id.ToString() + ", exerciseId: " + logset.ExerciseId + " date: " + logset.Date + " datenow: " + DateTime.Today);
            }
            var exerciseTable = conn.Table<Exercise>();
            foreach(var exercise in exerciseTable)
            {
                Log.Info("exercise", "name: " + exercise.Name);
            }
        }

        public TableQuery<Routine> GetRoutines()
        {
            var query = conn.Table<Routine>();
            return query;
        }

        public TableQuery<Workout> GetWorkoutsWithRoutine(int routineId)
        {
            var query = conn.Table<Workout>().Where(work => work.RoutinesId == routineId);
            return query;
        }

        public TableQuery<Exercise> GetExercise(int exerciseId)
        {
            var query = conn.Table<Exercise>().Where(ex => ex.Id == exerciseId);
            return query;
        }

        public TableQuery<Log_Set_Entry> GetLoggedSets(int exerciseId, DateTime date)
        {
            var query = conn.Table<Log_Set_Entry>().Where(set => set.ExerciseId == exerciseId && set.Date == date);
            return query;
        }

        public TableQuery<Log_Cardio_Set_Entry> GetLoggedCardioSets(int exerciseId, DateTime date)
        {
            var query = conn.Table<Log_Cardio_Set_Entry>().Where(set => set.ExerciseId == exerciseId && set.Date == date);
            return query;
        }

        public List<Exercise> GetLoggedExercises(DateTime date)
        {
            var query = conn.Query<Exercise>("SELECT distinct Exercises.Id, Exercises.Name FROM Exercises INNER JOIN Log_Set_Entries ON Exercises.Id = Log_Set_Entries.ExerciseId"
                + " WHERE Log_Set_Entries.Date = '" + date.Ticks + "'");
            var cardioQuery = conn.Query<Exercise>("SELECT distinct Exercises.Id, Exercises.Name FROM Exercises INNER JOIN Log_Cardio_Set_Entries ON Exercises.Id = Log_Cardio_Set_Entries.ExerciseId"
                + " WHERE Log_Cardio_Set_Entries.Date = '" + date.Ticks + "'");
            foreach (var exercise in cardioQuery)
            {
                if (!query.Any(e => e.Id == exercise.Id))
                    query.Add(exercise);
            }
            return query;
        }

        public List<ExerciseSets> GetExercisesNSetsWorkout(int workoutId)
        {
            var query = conn.Query<Exercise>("SELECT Exercises.Name, Exercises.Id from Exercises JOIN Workouts_Exercises ON Exercises.Id = Workouts_Exercises.ExerciseId"
                + " JOIN Target_Sets ON Workouts_Exercises.Id = Target_Sets.Workout_ExerciseId WHERE Workouts_Exercises.WorkoutId = " + workoutId.ToString());
            List<ExerciseSets> exercisesSets = new List<ExerciseSets>();
            foreach (var exercise in query)
            {
                //If not exists, add new ExerciseSets
                if (!exercisesSets.Any(ex => ex.Id == exercise.Id))
                {
                    ExerciseSets newExercise = new ExerciseSets();
                    newExercise.Name = exercise.Name;
                    newExercise.Count = 1;
                    newExercise.Id = exercise.Id;
                    exercisesSets.Add(newExercise);
                } //Else, add count
                else
                {
                    exercisesSets.Find(ex => ex.Id == exercise.Id).Count++;
                }
            }
            return exercisesSets;
        }

        public class ExerciseSets
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int Count { get; set; }

            public ExerciseSets()
            {

            }
        }


    }
}