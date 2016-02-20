using DAL.Interfacies.DTO;
using System;
using System.Collections.Generic;

namespace DAL.Interface.DTO
{
    public class DalToDoItem : DalEntity
    {
        public string Text { get; set; }

        public bool IsCompleted { get; set; }

        public bool IsFavourited { get; set; }

        public DateTime AddingDate { get; set; }

        public DateTime? CompletionDate { get; set; }

        public string Note { get; set; }

        public IList<int> SubItemsId { get; set; }

        public IList<int> FilesId { get; set; }

        public int ListId { get; set; }
    }
}
