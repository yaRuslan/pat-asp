using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebBook.Models
{
    [Table("patient")]
    public class Patient
    {
        [Key]
        [Column("patient_id")]
        public int Patient_id { get; set; }
        [Column("surname")]
        public string Surname { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("patronymic")]
        public string Patronymic { get; set; }
        [Column("date_of_visit")]
        public DateTime Date_of_visit { get; set; }
        [Column("time_of_visit")]
        public DateTime Time_of_visit { get; set; }
        [Column("specialty")]
        public string Specialty { get; set; }
    }
}