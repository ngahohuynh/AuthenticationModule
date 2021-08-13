using System;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models
{
    public class IdBase
    {
        [Key]
        public int Id { get; set; }
    }

    public class Trackable : IdBase
    {
        public DateTime CreatedDate { get; set; }

        public DateTime ModifiedDate { get; set; }

        public bool Valid { get; set; }
    }
}
