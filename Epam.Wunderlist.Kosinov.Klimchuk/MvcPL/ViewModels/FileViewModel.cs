using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcPL.ViewModels
{
    public class FileViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual DateTime AddingDate { get; set; }
    }
}