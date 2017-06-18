using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace New.Models
{
    public class CreateKiViewModel
    {
        [Key]
        public int CreateKiViewModelId { get; set; }
        [Display(Name ="Пореден номер")]
        public int Number { get; set; }

        [Display(Name = "Уникален Рег. Номер")]
        //[RegularExpression("^(RB303105-001-06/)(0-9-./)+", ErrorMessage ="Въведи коректна дата: дд.ММ.гггг ")]
        //[RegularExpression("^m", ErrorMessage = "Въведи коректна дата: дд.ММ.гггг ")]
        public string UniRegNum { get; set; }

        [Display(Name = "ОЕ")]
        public string OE { get; set; }

        [Display(Name = "Забележка")]
        public string Note { get; set; }

        [Display(Name = "Гриф за сигурност")]
        public Grif Grifs { get; set; }

        //public int GrifId { get; set; }

        [Display(Name = "Ниво на класиф.")]
        public int GrifNameId { get; set; }

        [Display(Name = "Ниво на класификация")]
        public virtual GrifName GrifNames { get; set; }

        [Display(Name = "Правно основание")]
        public int LawId { get; set; }

        [Display(Name = "Правно основание")]
        public virtual Law Laws { get; set; }

        public int KiId { get; set; }
        public virtual KI KIs { get; set; }

        //[DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        //[Display(Name = "Дата на създаване")]
        //public DateTime DateCreated { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Дата на изтичане")]
        [Required]
        public DateTime DateExpired { get; set; }

        
        public virtual ApplicationUser User { get; set; }

    }
}