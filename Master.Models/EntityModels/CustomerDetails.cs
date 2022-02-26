using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Master.Models.EntityModels
{
    [Table("customers")]
    public class CustomerDetails
    {
        [Key]
        [Column("customer_id")]
        public int customerId { get; set; }
        [Column("first_name")]
        public string firstName { get; set; }
        [Column("last_name")]
        public string lastName { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string street  { get; set; }
        public string city  { get; set; }
        public string state  { get; set; }
        [Column("zip_code")]
        public string zipCode  { get; set; }
    }
}
