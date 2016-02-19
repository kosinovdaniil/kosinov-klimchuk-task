using BLL.Interface.Entities;
using DAL.Interface.DTO;

namespace BLL.Mappers
{
    public static class BllSubItemMapper
    {        
        public static DalSubItem ToDalSubItem(this BllSubItem e)
        {
            return new DalSubItem()
            {
                BaseItemId = e.BaseItemId,
                Id = e.Id,
                IsCompleted = e.IsCompleted,
                Text = e.Text
            };
        }

        public static BllSubItem ToBllSubItem(this DalSubItem e)
        {
            return new BllSubItem()
            {
                BaseItemId = e.BaseItemId,
                Id = e.Id,
                IsCompleted = e.IsCompleted,
                Text = e.Text
            };
        }


    }
}
