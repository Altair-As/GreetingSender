using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreetingSender.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Ocupation { get; set; }
        [Required]
        [Column(TypeName = "Date")]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public string Sex { get; set; }
        [Required]
        [Column(TypeName = "text")]
        public string GreetingText { get; set; }
        [Required]
        public string ImagePath { get; set; }
    }
}
