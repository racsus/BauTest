namespace BAU.Data.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BAU.Data.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }



        /// <summary>
        /// Default data
        /// </summary>
        /// <param name="context"></param>
        protected override void Seed(BAU.Data.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            // Create stored procedures for pagination
            //Engineers
            context.Database.ExecuteSqlCommand(StoredProcedures.Engineers.sp_EngineersPaginationDrop);
            context.Database.ExecuteSqlCommand(StoredProcedures.Engineers.sp_EngineersPaginationCreate);
            context.Database.ExecuteSqlCommand(StoredProcedures.Engineers.sp_EngineersPaginationCountDrop);
            context.Database.ExecuteSqlCommand(StoredProcedures.Engineers.sp_EngineersPaginationCountCreate);

            //Calendars
            context.Database.ExecuteSqlCommand(StoredProcedures.Calendars.sp_CalendarsPaginationDrop);
            context.Database.ExecuteSqlCommand(StoredProcedures.Calendars.sp_CalendarsPaginationCreate);
            context.Database.ExecuteSqlCommand(StoredProcedures.Calendars.sp_CalendarsPaginationCountDrop);
            context.Database.ExecuteSqlCommand(StoredProcedures.Calendars.sp_CalendarsPaginationCountCreate);

            List<Models.Engineer> engineers = new List<Models.Engineer>
            {
                new Models.Engineer {Id=1, Name="Oscar Rodríguez"},
                new Models.Engineer {Id=2, Name="Carlos Vila"},
                new Models.Engineer {Id=3, Name="Tommy Mannila"},
                new Models.Engineer {Id=4, Name="Pablo Picasso"},
                new Models.Engineer {Id=5, Name="Esther Plano"},
                new Models.Engineer {Id=6, Name="Sara Gonzalez"},
                new Models.Engineer {Id=7, Name="Lidia López"},
                new Models.Engineer {Id=8, Name="Abel Marti"},
                new Models.Engineer {Id=9, Name="Jorge Sanchez"},
                new Models.Engineer {Id=10, Name="Maria Planells"},
            };

            // add data into context and save to db
            foreach (Models.Engineer r in engineers)
            {
                context.Engineer.Add(r);
            }
            context.SaveChanges();
        }

    }
}
