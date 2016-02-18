using BLL.Interface.Entities;
using DAL.Interface.DTO;
using System.Linq;

namespace BLL.Mappers
{
    public static class BllEntityMappers
    {
        public static BllUser ToBllUser(this DalUser e)
        {
            return new BllUser()
            {
                Id = e.Id,
                Name = e.Name,
                Password = e.Password,
                Email = e.Email,
                ListsId = e.ListsId,
                PhotoPath = e.PhotoPath
            };
        }
        public static DalUser ToDalUser(this BllUser e)
        {
            return new DalUser()
            {
                Id = e.Id,
                Name = e.Name,
                Password = e.Password,
                Email = e.Email,
                ListsId = e.ListsId,
                PhotoPath = e.PhotoPath
            };
        }

        public static DalToDoList ToDalList(this BllToDoList e)
        {
            return new DalToDoList()
            {
                Id = e.Id,
                IsNotified = e.IsNotified,
                ItemsId = e.ItemsId,
                Name = e.Name,
                UsersId = e.UsersId?.ToList()
            };
        }
        public static BllToDoList ToBllList(this DalToDoList e)
        {
            return new BllToDoList()
            {
                Id = e.Id,
                IsNotified = e.IsNotified,
                ItemsId = e.ItemsId,
                Name = e.Name,
                UsersId = e.UsersId?.ToList()
            };
        }

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
