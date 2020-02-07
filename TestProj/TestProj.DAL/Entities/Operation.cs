using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestProj.DAL.Entities
{
    public class Operation
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int ProductId { get; set; }
        public Product Product { get; set; }
        [Required]
        public OperationType OperationType { get; set; }
        [Required]
        public int AppUserId { get; set; }
        public AppUser appUser { get; set; }
        [Required]
        [Column(TypeName = "int")]
        public int Amount { get; set; }
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime DateTime { get; set; }
    }

    public enum OperationType
    {
        Income,
        Outcome
    }
}