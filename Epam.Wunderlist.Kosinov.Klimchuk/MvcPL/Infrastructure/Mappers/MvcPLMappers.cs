using BLL.Interface.Entities;
using MvcPL.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace MvcPL.Infrastructure.Mappers
{
    public static class MvcMappers
    {
        public static BllUser ToBllUser(this UserViewModel e)
        {
            return new BllUser()
            {
                Id = e.Id,
                Name = e.Name,
                Email = e.Email,
                PhotoPath = e.Email
            };
        }
        public static UserViewModel ToUserViewModel(this BllUser e)
        {
            return new UserViewModel()
            {
                Id = e.Id,
                Name = e.Name,
                Email=e.Email,
            };
        }

        public static ToDoListViewModel ToListViewModel(this BllToDoList e)
        {
            return new ToDoListViewModel()
            {
                Id = e.Id,
                Name = e.Name,
            };
        }
        public static BllToDoList ToBllList(this ToDoListViewModel e)
        {
            return new BllToDoList()
            {
                Id = e.Id,
                Name = e.Name,
            };
        }

        public static ToDoItemViewModel ToItemViewModel(this BllToDoItem e)
        {
            return new ToDoItemViewModel()
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
        public static BllToDoItem ToBllItem(this ToDoItemViewModel e)
        {
            return new BllToDoItem()
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

        public static FileViewModel ToFileViewModel(this BllFile e)
        {
            return new FileViewModel()
            {
                AddingDate = e.AddingDate,
                Id = e.Id,
                Name = e.Name,
            };
        }
        public static BllFile ToBllFile(this FileViewModel e)
        {
            return new BllFile()
            {
                AddingDate = e.AddingDate,
                Id = e.Id,
                Name = e.Name,
            };
        }

        public static SubItemViewModel ToSubItemViewModel(this BllSubItem e)
        {
            return new SubItemViewModel()
            {
                Id = e.Id,
                IsCompleted = e.IsCompleted,
                Text = e.Text
            };
        }
        public static BllSubItem ToBllSubItem(this SubItemViewModel e)
        {
            return new BllSubItem()
            {
                Id = e.Id,
                IsCompleted = e.IsCompleted,
                Text = e.Text
            };
        }
    }
}