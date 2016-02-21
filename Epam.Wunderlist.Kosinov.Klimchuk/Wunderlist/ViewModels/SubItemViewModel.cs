using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wunderlist.ViewModels
{
    public class SubItemViewModel
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public bool IsCompleted { get; set; }
    }
}