using System;
namespace QueerBooksAPI.Models
{
    public abstract class BaseEntity
    {
        public DateTime UpdatedDate { get; set; } = DateTime.UtcNow;
        public string UpdatedBy { get; set; } = "";
        public string AddedBy { get; set; } = "";
        public DateTime AddedDate { get; set; } = DateTime.UtcNow;
        public int Status { get; set; } = 1;
    }

}

