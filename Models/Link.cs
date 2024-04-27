using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Labb3.Models
{
    public class Link
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LinkId { get; set; }
        public string LinkName { get; set; }
        public string LinkUrl { get; set; }

        //public List<InterestList> InterestLists { get; }
    }
}
