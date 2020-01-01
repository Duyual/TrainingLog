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
    [Table("Exercises_Categories")]
    public class Exercise_Category
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Name { get; set; }

        //References Exercises(Id)
        public int ExerciseId { get; set; }

        //References Categories(Id)
        public int CategoryId { get; set; }
    }
}