using System.ComponentModel.DataAnnotations;

namespace Domain.Common
{
    public class BaseEntity
    {
        public int Id { get; set; }
        [Required]
        public DateTime DateCreated { get; set; }
        [Required]
        public string CreatedBy { get; set; }
        [Required]
        public DateTime LastModifiedDate { get; set; }
        [Required]
        public string LastModifiedBy { get; set; }
    }
}
