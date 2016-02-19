using BLL.Interface.Entities;
using DAL.Interface.DTO;

namespace BLL.Mappers
{
    public static class BllFileMapper
    {
        public static DalFile ToDalFile(this BllFile e)
        {
            return new DalFile()
            {
                AddingDate = e.AddingDate,
                BaseItemId = e.BaseItemId,
                Id = e.Id,
                Name = e.Name,
                Path = e.Path,
                UserId = e.UserId
            };
        }

        public static BllFile ToBllFile(this DalFile e)
        {
            return new BllFile()
            {
                AddingDate = e.AddingDate,
                BaseItemId = e.BaseItemId,
                Id = e.Id,
                Name = e.Name,
                Path = e.Path,
                UserId = e.UserId
            };
        }

    }
}
