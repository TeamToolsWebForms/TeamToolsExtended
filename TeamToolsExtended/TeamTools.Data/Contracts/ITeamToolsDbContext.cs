using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace TeamTools.Data.Contracts
{
    public interface ITeamToolsDbContext : IDisposable
    {
        int SaveChanges();

        //IDbSet<University> Universities { get; set; }

        //IDbSet<Specialty> Specialties { get; set; }

        //IDbSet<Course> Courses { get; set; }

        //IDbSet<Student> Students { get; set; }

        IDbSet<T> Set<T>() where T : class;

        DbEntityEntry<T> Entry<T>(T entity) where T : class;
    }
}
