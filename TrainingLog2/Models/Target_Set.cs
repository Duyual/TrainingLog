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

namespace TrainingLog2.Models
{
    [Table("Target_Sets")]
    public class Target_Set
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        //References Workouts_Exercises(Id)
        public int Workout_ExerciseId { get; set; }

        public int Min_reps { get; set; }

        public int Max_reps { get; set; }
    }
}