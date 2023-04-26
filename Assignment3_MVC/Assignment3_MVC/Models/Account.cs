using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Assignment3_MVC.Models
{
    public class Account
    {
        [Key]

        [DatabaseGenerated(DatabaseGeneratedOption.None)]

        public int AccountNumber { get; set; }

        public string AccountName { get; set; }

        public double CurrentBalance { get; set; }
    }
}