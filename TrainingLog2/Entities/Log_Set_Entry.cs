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
using Java.Sql;
using SQLite;

namespace TrainingLog2.Entities
{
    [Table("Log_Set_Entries")]
    public class Log_Set_Entry
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public int ExerciseId { get; set; }

        public DateTime Date { get; set; }

        public decimal Weight { get; set; }

        public int Reps { get; set; }

        public int Min_reps { get; set; }

        public int Max_reps { get; set; }
    }
}