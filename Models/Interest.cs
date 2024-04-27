using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Labb3.Models
{
    public class Interest
    {
        [Key]
        public int InterestId { get; set; }
        public string InterestName { get; set; }
        public string InterestDescription { get; set; }
        //public List<InterestList> InterestLists { get;}

    }
}
