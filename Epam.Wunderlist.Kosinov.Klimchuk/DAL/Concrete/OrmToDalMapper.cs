using ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface.DTO
{
    public static class OrmToDalMapper
    {
        public static User ToOrmUser(this DalUser e)
        {
            return new User()
            {
                Id = e.Id,
                Name = e.Name,
                Password = e.Password,
                Email = e.Email,
                PhotoPath = e.PhotoPath //TODO add lists if needed
            };
        }
        public static DalUser ToDalUser(this User e)
        {
            return new DalUser()
            {
                Id = e.Id,
                Name = e.Name,
                Password = e.Password,
                Email = e.Email,
                ListsId = e.Lists?.Select(x => x.Id).ToList(),
                PhotoPath = e.PhotoPath
            };
        }

        public static DalToDoList ToDalList(this ToDoList e)
        {
            return new DalToDoList()
            {
                Id = e.Id,
                IsNotified = e.IsNotified,
                Name = e.Name,
                UsersId = e.Users?.Select(x => x.Id).ToList()
            };
        }
        public static ToDoList ToOrmList(this DalToDoList e)
        {
            return new ToDoList()
            {
                Id = e.Id,
                IsNotified = e.IsNotified,
                Name = e.Name,
            };
        }

        public static DalToDoItem ToDalItem(this ToDoItem e)
        {
            return new DalToDoItem()
            {
                Id = e.Id,
                IsCompleted = e.IsCompleted,
                IsFavourited = e.IsFavourited,
                AddingDate = e.AddingDate,
                CompletionDate = e.CompletionDate,
                FilesId = e.Files?.Select(x => x.Id).ToList(),
                ListId = e.List.Id,
                Note = e.Note,
                SubItemsId = e.SubItems?.Select(x => x.Id).ToList(),
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
