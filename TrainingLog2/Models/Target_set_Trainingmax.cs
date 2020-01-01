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
    [Table("Target_Sets_Trainingmax")]
    public class Target_Set_Trainingmax
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        //References Workouts_Exercises_Trainingmax(Id)
        public int Workouts_Exercises_TrainingmaxId { get; set; }

        public decimal Percent { get; set; }

        public int Min_reps { get; set; }

        public int Max_reps { get; set; }

        //Round=0 round
        //Round=1 always round down
        //Round=2 always round up
        public int Round { get; set; }
    }
}