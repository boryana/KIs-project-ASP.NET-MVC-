using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace New.Models
{
    public class EditKiViewModel
    {
        [Key]
        public int EditKiViewModelId { get; set; }


        //public int Number { get; set; }

        //public string UniRegNum { get; set; }

        //public string OE { get; set; }

        //public string Note { get; set; }

        //public Grif Grifs { get; set; }

        //public int GrifId { get; set; }

        //public IEnumerable<Grif> Grifs { get; set; }
        public int GrifNameId { get; set; }

       public virtual GrifName GrifNames { get; set; }

        public int LawId { get; set; }
        public virtual Law Laws { get; set; }

        public int KiId { get; set; }
        public virtual KI KIs { get; set; }

        //[DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        //[Display(Name = "Дата на създаване")]
        //public DateTime DateCreated { get; set; }

        //[DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        //[Display(Name = "Дата на изтичане")]
        //public DateTime DateExpired { get; set; }

        public virtual ApplicationUser User { get; set; }

    }
}