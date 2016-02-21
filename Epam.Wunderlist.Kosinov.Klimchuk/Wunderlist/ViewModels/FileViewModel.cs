using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Wunderlist.ViewModels
{
    public class FileViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Field can't be empty!")]
        public string Name { get; set; }

        public DateTime AddingDate { get; set; }
    }
}