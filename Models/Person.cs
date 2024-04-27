using System.ComponentModel.DataAnnotations;

namespace Labb3.Models
{
    public class Person
    {
        [Key]
        public int PersonId { get; set; }
        public string PersonName { get; set; }
        public int PhoneNumber { get; set; }
        //public List<InterestList> InterestLists { get; set; }
    }
}
