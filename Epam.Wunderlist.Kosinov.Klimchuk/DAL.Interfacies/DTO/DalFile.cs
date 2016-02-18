using DAL.Interfacies.DTO;
using System;

namespace DAL.Interface.DTO
{
    public class DalFile : DalEntity
    {
        public string Name { get; set; }

        public string Path { get; set; }

        public virtual int BaseItemId { get; set; }

        public virtual int UserId { get; set; }

        public virtual DateTime AddingDate { get; set; }


    }
}
