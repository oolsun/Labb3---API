using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Labb3.Models
{
    public class InterestList
    {
        [Key]
        public int InterestListId { get; set; }

        [ForeignKey("Person")]
        public int FK_PersonId { get; set; }
        public Person? Person { get; set; }

        [ForeignKey("Interest")]
        public int FK_InterestId { get; set; }
        public Interest? Interest { get; set; }

        [ForeignKey("Link")]
        public int? FK_LinkId { get; set; }
        public Link? Link { get; set; }

    }
}
