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
        public string Task_name { get; set; }
        [Column("target_date")]
        public string Target_date { get; set; }
        [Column("complexity")]
        public string Complexity { get; set; }
    }
}