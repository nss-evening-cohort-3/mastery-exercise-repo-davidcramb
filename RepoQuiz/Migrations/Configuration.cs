namespace RepoQuiz.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using RepoQuiz.DAL;
    using Models;

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
            Student Student1 = nameGen.RandomizedStudent();
            Student Student2 = nameGen.RandomizedStudent();
            Student Student3 = nameGen.RandomizedStudent();
            Student Student4 = nameGen.RandomizedStudent();
            Student Student5 = nameGen.RandomizedStudent();
            Student Student6 = nameGen.RandomizedStudent();
            Student Student7 = nameGen.RandomizedStudent();
            Student Student8 = nameGen.RandomizedStudent();
            Student Student9 = nameGen.RandomizedStudent();
            Student Student10 = nameGen.RandomizedStudent();
            Student Student11 = nameGen.RandomizedStudent();
            Student Student12 = nameGen.RandomizedStudent();
            Student Student13 = nameGen.RandomizedStudent();
            Student Student14 = nameGen.RandomizedStudent();
            Student Student15 = nameGen.RandomizedStudent();



            context.Students.AddOrUpdate(
                s => s.LastName,
                Student1,
                Student2,
                Student3,
                Student4,
                Student5,
                Student6,
                Student7,
                Student8,
                Student9,
                Student10,
                Student11,
                Student12,
                Student13,
                Student14,
                Student15
                );

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
