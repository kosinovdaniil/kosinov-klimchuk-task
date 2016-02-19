using BLL.Interface.Entities;
using DAL.Interface.DTO;

namespace BLL.Mappers
{
    public static class BllItemMapper
    {
        public static DalToDoItem ToDalItem(this BllToDoItem e)
        {
            return new DalToDoItem()
            {
                Id = e.Id,
                IsCompleted = e.IsCompleted,
                IsFavourited = e.IsFavourited,
                AddingDate = e.AddingDate,
                CompletionDate = e.CompletionDate,
                FilesId = e.FilesId,
                ListId = e.ListId,
                Note = e.Note,
                SubItemsId = e.SubItemsId,
                Text = e.Text
            };
        }

        public static BllToDoItem ToBllItem(this DalToDoItem e)
        {
            return new BllToDoItem()
            {
                Id = e.Id,
                IsCompleted = e.IsCompleted,
                IsFavourited = e.IsFavourited,
                AddingDate = e.AddingDate,
                CompletionDate = e.CompletionDate,
                FilesId = e.FilesId,
                ListId = e.ListId,
                Note = e.Note,
                SubItemsId = e.SubItemsId,
                Text = e.Text
            };
        }
    }
}
