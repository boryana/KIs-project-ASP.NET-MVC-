using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace New.Models
{
    public class Law
    {
        public Law()
        {
            var Grifs = new List<Grif>();
        }
        [Key]
        [Display(Name = "Правно основание")]
        public int LawId { get; set; }

        [Display(Name = "Правно основание")]
        public string LawName { get; set; }
        public virtual ICollection<Grif> Grifs { get; set; }
    }
}