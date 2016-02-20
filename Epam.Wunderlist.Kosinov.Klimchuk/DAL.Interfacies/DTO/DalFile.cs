using DAL.Interfacies.DTO;
using System;

namespace DAL.Interface.DTO
{
    public class DalFile : DalEntity
    {
        public string Name { get; set; }

        public string Path { get; set; }

        public int BaseItemId { get; set; }

        public int UserId { get; set; }

        public DateTime AddingDate { get; set; }


    }
}
