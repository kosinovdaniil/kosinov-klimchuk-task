using DAL.Interface.DTO;
using ORM;

namespace DAL.Mappers
{
    public static class DalSubItemMapper
    {
        public static DalSubItem ToDalSubItem(this SubItem e)
        {
            return new DalSubItem()
            {
                BaseItemId = e.BaseItem.Id,
                Id = e.Id,
                IsCompleted = e.IsCompleted,
                Text = e.Text
            };
        }

        public static SubItem ToOrmSubItem(this DalSubItem e)
        {
            return new SubItem()
            {
                Id = e.Id,
                IsCompleted = e.IsCompleted,
                Text = e.Text
            };
        }
    }
}
