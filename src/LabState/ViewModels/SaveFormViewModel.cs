using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LabState.ViewModels
{
    public class SaveFormViewModel
    {
        [Display(Name = "Value 1 - Cache")]
        public string Value1 { get; set; }

        [Display(Name = "Value 2 - Session State")]
        public string Value2 { get; set; }

        [Display(Name = "Value 3 - Cookie")]
        public string Value3 { get; set; }

    }
}
