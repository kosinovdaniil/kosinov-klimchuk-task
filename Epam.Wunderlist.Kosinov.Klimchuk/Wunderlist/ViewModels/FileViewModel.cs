using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wunderlist.ViewModels
{
    public class FileViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime AddingDate { get; set; }
    }
}