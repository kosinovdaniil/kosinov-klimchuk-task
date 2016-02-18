using DAL.Interface.DTO;
using ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mappers
{
    public static class DalFileMapper
    {
        public static DalFile ToDalFile(this File e)
        {
            return new DalFile()
            {
                AddingDate = e.AddingDate,
                BaseItemId = e.BaseItem.Id,
                Id = e.Id,
                Name = e.Name,
                Path = e.Path,
                UserId = e.UserId
            };
        }

        public static File ToOrmFile(this DalFile e)
        {
            return new File()
            {
                AddingDate = e.AddingDate,
                Id = e.Id,
                Name = e.Name,
                Path = e.Path,
                UserId = e.UserId
            };
        }
    }
}
