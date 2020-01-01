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
    [Table("Workouts")]
    public class Workout
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        //References Routines(Id)
        public int RoutinesId { get; set; }
        public string Name { get; set; }
    }
}