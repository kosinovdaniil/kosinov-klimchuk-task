namespace Epam.Wunderlist.DataAccess.MssqlProvider.Migrations
{
    using DomainModel;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<Epam.Wunderlist.DataAccess.MssqlProvider.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Epam.Wunderlist.DataAccess.MssqlProvider.ApplicationDbContext context)
        {
            for (var i = 0; i < 10; i++)
            {
                var user = new User()
                {
                    Email = "mail" + i.ToString() + "@gmail.com",
                    Name = "user" + i.ToString(),
                    Password = "password" + i.ToString()
                };
                context.Users.Add(user);
                for (var j = 0; j < i; j++)
                {
                    var list = new ToDoList()
                    {
                        Name = "list" + i.ToString(),
                        Users = new List<User> { user }
                    };
                    context.Lists.Add(list);
                    for (var t = 0; t < j; t++)
                    {
                        var item = new ToDoItem()
                        {
                            Text = "sampleText" + t.ToString(),
                            Note = "note" + t.ToString(),
                            DateAdded = DateTime.MinValue,
                            DateCompletion = null,
                            IsFavourited = false,
                            IsCompleted = false,
                            List = list
                        };
                    }
                }
            }
        }
    }
}
