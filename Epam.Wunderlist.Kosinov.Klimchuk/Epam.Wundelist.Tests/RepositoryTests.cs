using System;
using Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Epam.Wunderlist.DomainModel;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using Epam.Wunderlist.DataAccess.MssqlProvider.Concrete;
using Epam.Wunderlist.DataAccess.MssqlProvider;
using Epam.Wunderlist.DataAccess.Interfaces.Repository;

namespace Epam.Wundelist.Tests
{
    [TestClass]
    public class RepositoryTests
    {
        [TestMethod]
        public void UserRepository_Update_ShouldReturnUpdatedEntity()
        {
            var userToChange = new User()
            {
                Id = 1,
                Email = "mail1",
                Lists = new List<ToDoList>(),
                Name = "name1",
                Password = "password1",
                PhotoPath = "photo1",
            };
            var dbData = new List<User>()
            {
                userToChange,
                new User()
                {
                    Id = 1,
                    Email = "mail1",
                    Lists = new List<ToDoList>(),
                    Name = "name1",
                    Password = "password1",
                    PhotoPath = "photo1",
                },
                new User()
                {
                    Id = 3,
                    Email = "mail3",
                    Lists = new List<ToDoList>(),
                    Name = "name3",
                    Password = "password3",
                    PhotoPath = "photo3",
                }
            }.AsQueryable();

            var newUser = new User()
            {
                Id = 1,
                Email = "mail2",
                Lists = new List<ToDoList>(),
                Name = "name2",
                Password = "password2",
                PhotoPath = "photo2",
            };
            var dbSetMock = new Mock<DbSet<User>>();
            dbSetMock.As<IQueryable<User>>().Setup(x => x.Provider).Returns(dbData.Provider);
            dbSetMock.As<IQueryable<User>>().Setup(x => x.Expression).Returns(dbData.Expression);
            dbSetMock.As<IQueryable<User>>().Setup(x => x.ElementType).Returns(dbData.ElementType);
            dbSetMock.As<IQueryable<User>>().Setup(x => x.GetEnumerator()).Returns(dbData.GetEnumerator());
            
            var dbContextMock = new Mock<ApplicationDbContext>();
            dbContextMock.Setup(x => x.Set<User>()).Returns(dbSetMock.Object);

            var repo = new UserRepository(dbContextMock.Object);
            var result = repo.Update(newUser);

            Assert.AreEqual(newUser.Name, result.Name);
            Assert.AreEqual(newUser.PhotoPath, result.PhotoPath);
        }
        //change list
        [TestMethod]
        public void ToDoItemRepository_Update_ShouldReturnUpdatedEntity()
        {
            var list = new ToDoList();
            var itemToChange = new ToDoItem()
            {
                Id = 1,
                DateAdded = DateTime.MinValue,
                DateCompletion = default(DateTime),
                IsCompleted = false,
                IsFavourited = false,
                List = list,
                Note = "note",
                Text = "text"
            };
            var dbData = new List<ToDoItem>()
            {
                itemToChange,
                new ToDoItem()
                {
                    Id = 2,
                    DateAdded = DateTime.MinValue,
                    DateCompletion = default(DateTime),
                    IsCompleted = false,
                    IsFavourited = false,
                    List = new ToDoList(),
                    Note = "note",
                    Text = "text"
                },
                new ToDoItem()
                {
                    Id = 3,
                    DateAdded = DateTime.MinValue,
                    DateCompletion = default(DateTime),
                    IsCompleted = false,
                    IsFavourited = false,
                    List = new ToDoList(),
                    Note = "note",
                    Text = "text"
                }
            }.AsQueryable();

            var newItem = new ToDoItem()
            {
                Id = 1,
                DateAdded = DateTime.MinValue,
                DateCompletion = default(DateTime),
                IsCompleted = false,
                IsFavourited = false,
                List = null,
                Note = "note1",
                Text = "text1"
            };
            var dbSetMock = new Mock<DbSet<ToDoItem>>();
            dbSetMock.As<IQueryable<ToDoItem>>().Setup(x => x.Provider).Returns(dbData.Provider);
            dbSetMock.As<IQueryable<ToDoItem>>().Setup(x => x.Expression).Returns(dbData.Expression);
            dbSetMock.As<IQueryable<ToDoItem>>().Setup(x => x.ElementType).Returns(dbData.ElementType);
            dbSetMock.As<IQueryable<ToDoItem>>().Setup(x => x.GetEnumerator()).Returns(dbData.GetEnumerator());
            var dbContextMock = new Mock<ApplicationDbContext>();
            dbContextMock.Setup(x => x.Set<ToDoItem>()).Returns(dbSetMock.Object);
            var repo = new ToDoItemRepository(dbContextMock.Object);
            var result = repo.Update(newItem);

            Assert.AreEqual(newItem.Text, result.Text);
            Assert.AreEqual(newItem.DateCompletion, result.DateCompletion);
            Assert.AreEqual(newItem.Note, result.Note);
            Assert.AreEqual(newItem.IsCompleted, result.IsCompleted);
            Assert.AreSame(result.List, list);
        }
        //Change items,  (users)
        [TestMethod]
        public void ToDoListRepository_Update_ShouldReturnUpdatedEntity()
        {
            var listToChange = new ToDoList()
            {
                Id = 1,
                Name = "name"
            };
            var dbData = new List<ToDoList>()
            {
                listToChange,
                new ToDoList()
                {
                    Id = 2,
                    Name ="name"
                },
                new ToDoList()
                {
                    Id = 3,
                    Name ="name"
                }
            }.AsQueryable();

            var newList = new ToDoList()
            {
                Id = 1,
                Name = "nameChanged"
            };
            var dbSetMock = new Mock<DbSet<ToDoList>>();
            dbSetMock.As<IQueryable<ToDoList>>().Setup(x => x.Provider).Returns(dbData.Provider);
            dbSetMock.As<IQueryable<ToDoList>>().Setup(x => x.Expression).Returns(dbData.Expression);
            dbSetMock.As<IQueryable<ToDoList>>().Setup(x => x.ElementType).Returns(dbData.ElementType);
            dbSetMock.As<IQueryable<ToDoList>>().Setup(x => x.GetEnumerator()).Returns(dbData.GetEnumerator());
            var dbContextMock = new Mock<ApplicationDbContext>();
            dbContextMock.Setup(x => x.Set<ToDoList>()).Returns(dbSetMock.Object);
            var repo = new ToDoListRepository(dbContextMock.Object);
            var result = repo.Update(newList);

            Assert.AreEqual(newList.Name, result.Name);
        }

    }
}
