using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;

namespace TrainingLog2.Entities
{
    [Table("Workouts_Exercises")]
    public class Workout_Exercise
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        //References Workouts(Id)
        public int WorkoutId { get; set; }

        //References Exercises(Id)
        public int ExerciseId { get; set; }
    }
}