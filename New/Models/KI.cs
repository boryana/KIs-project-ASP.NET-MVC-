using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace New.Models
{
    public class KI
    {
        private ICollection<Grif> grifs;

        public KI()
        {
            this.grifs = new HashSet<Grif>();
        }
        [Key]
        public int KIId { get; set; }

        [Display(Name ="Уникален рег. номер")]
        //[RegularExpression("^(RB303105-001-06/).*")]
        public string UniRegNum { get; set; }

        [Display(Name = "ОЕ")]
        public string OE { get; set; }

        [Display(Name = "Забележка")]
        public string Note { get; set; }

        public int GrifId { get; set; }
        [Display(Name ="Гриф за сигурност")]
        public virtual ICollection<Grif> Grifs
        {
            get { return this.grifs; }
            set { this.grifs = value; }
        }

        public virtual ApplicationUser User { get; set; }
    }


}