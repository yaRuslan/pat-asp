using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ToDoLists.Models
{
    [Table("TodoLists")]
    public class TodoList
    {
        [Key]
        [Column("list_id")]
        public int List_id { get; set; }
        [Column("task_name")]
        [Required (ErrorMessage ="Заполните поле")]
        [StringLength (50, MinimumLength = 1,ErrorMessage = "Максимальная длина строки 50")]
        public string Task_name { get; set; }
        [Column("target_date")]
        [Required(ErrorMessage = "Заполните поле")]
        public DateTime Target_date { get; set; }
        [Column("complexity")]
        public string Complexity { get; set; }
    }
}