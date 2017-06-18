using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace New.Models
{
    public class Grif
    {
        
        public Grif()
        {
            
        }
        [Key]
        public int GrifId { get; set; }

        [Display(Name = "Ниво на класификация")]
        public int GrifNameId { get; set; }

        [Display(Name = "Ниво на класификация")]
        public virtual GrifName GrifNames { get; set; }

        [Display(Name = "Правно основание")]
        public int LawId { get; set; }

        [Display(Name = "Правно основание")]
        public virtual Law Laws { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true )]   /*DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]*/
        [Display(Name = "Дата на създаване")]
        public DateTime DateCreated { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Дата на изтичане")]
        public DateTime DateExpired { get; set; }

        public int KIId { get; set; }

        public virtual KI KIs { get; set; }

        public string UserId { get; set; }
        [Display(Name = "Потребител")]
        public virtual ApplicationUser User { get; set; }
        


    }
}