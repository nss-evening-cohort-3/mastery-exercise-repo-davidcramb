namespace RepoQuiz.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using RepoQuiz.DAL;
    using Models;
    using System.Collections.Generic;

    internal sealed class Configuration : DbMigrationsConfiguration<RepoQuiz.DAL.StudentContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(RepoQuiz.DAL.StudentContext context)
        {
            //  This method will be called after migrating to the latest version.
            NameGenerator nameGen = new NameGenerator();
            List<Student> studentSeedList = new List<Student>();
            for (int i = 0; i < 16; i++)
            {
                studentSeedList.Add(nameGen.RandomizedStudent());
            }

            foreach (var student in studentSeedList)
            {
                context.Students.AddOrUpdate(
                    s => s.StudentID,
                    student
                    );
                    
            }
            //Student Student1 = nameGen.RandomizedStudent();
            //Student Student2 = nameGen.RandomizedStudent();
            //Student Student3 = nameGen.RandomizedStudent();
            //Student Student4 = nameGen.RandomizedStudent();
            //Student Student5 = nameGen.RandomizedStudent();
            //Student Student6 = nameGen.RandomizedStudent();
            //Student Student7 = nameGen.RandomizedStudent();
            //Student Student8 = nameGen.RandomizedStudent();
            //Student Student9 = nameGen.RandomizedStudent();
            //Student Student10 = nameGen.RandomizedStudent();
            //Student Student11 = nameGen.RandomizedStudent();
            //Student Student12 = nameGen.RandomizedStudent();
            //Student Student13 = nameGen.RandomizedStudent();
            //Student Student14 = nameGen.RandomizedStudent();
            //Student Student15 = nameGen.RandomizedStudent();

           

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
