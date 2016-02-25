using DAL.Interface.DTO;
using ORM;
using System;
using System.Linq;

namespace DAL.Mappers
{
    public static class DalItemMapper
    {
        public static DalToDoItem ToDalItem(this ToDoItem e)
        {
            return new DalToDoItem()
            {
                Id = e.Id,
                IsCompleted = e.IsCompleted,
                IsFavourited = e.IsFavourited,
                AddingDate = e.AddingDate,
                CompletionDate = e.CompletionDate,
                ListId = e.List.Id,
                Note = e.Note,
                Text = e.Text
            };
        }

        public static ToDoItem ToOrmItem(this DalToDoItem e)
        {
            return new ToDoItem()
            {
                Id = e.Id,
                IsCompleted = e.IsCompleted,
                IsFavourited = e.IsFavourited,
                AddingDate = e.AddingDate,
                CompletionDate = e.CompletionDate,
                Note = e.Note,
                Text = e.Text
            };
        }

        public static void CopyFieldsTo(this DalToDoItem source, ToDoItem target)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            if (target == null)
            {
                throw new ArgumentNullException("target");
            }
            target.CompletionDate = source.CompletionDate; //TODO null
            target.Text = source.Text;
            target.Note = source.Note;
        }
    }
}
