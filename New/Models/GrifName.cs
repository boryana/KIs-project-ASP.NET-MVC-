using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace New.Models
{
    public class GrifName
    {
        public GrifName()
        {
            var Grifs = new List<Grif>();
        }
        [Key]
        [Display(Name = "Ниво на класификация")]
        public int GrifNameId { get; set; }

        [Display(Name = "Ниво на класификация")]
        public string Name { get; set; }

        public virtual ICollection<Grif> Grifs { get; set; }
    }
}