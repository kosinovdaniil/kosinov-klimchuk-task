namespace ORM.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ORM.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(ORM.ApplicationDbContext context)
        {
            for (var i = 0; i < 10; i++)
            {
                var user = new User()
                {
                    Email = "mail" + i.ToString(),
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
                            AddingDate = DateTime.MinValue,
                            CompletionDate = null,
                            IsFavourited = false,
                            IsCompleted = false,
                            List = list
                        };
                        for (var z = 0; z < t; z++)
                        {
                            var subItem = new SubItem()
                            {
                                Text = "subText" + z.ToString(),
                                IsCompleted = false,
                                BaseItem = item
                            };
                            var file = new File()
                            {
                                Name = "file" + z.ToString(),
                                AddingDate = DateTime.MinValue,
                                Path = "path" + z.ToString(),
                                BaseItem = item
                            };
                        }
                    }
                }
            }
        }
    }
}
