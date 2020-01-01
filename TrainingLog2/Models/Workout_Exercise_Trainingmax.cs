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
    [Table("Workouts_Exercises_Trainingmax")]
    public class Workout_Exercise_Trainingmax
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        //References Workouts_Exercises(Id)
        public int Workouts_ExercisesId { get; set; }

        public decimal TrainingMax { get; set; }
    }
}