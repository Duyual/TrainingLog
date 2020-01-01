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
    [Table("Log_Cardio_Set_Entries")]
    public class Log_Cardio_Set_Entry
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public int ExerciseId { get; set; }

        public DateTime Date { get; set; }

        public decimal Distance { get; set; }

        //example: m, km, ft, mi
        public string Type { get; set; }

        public int Hours { get; set; } = 0;

        public int Minutes { get; set; } = 0;

        public int Seconds { get; set; } = 0;
    }
}