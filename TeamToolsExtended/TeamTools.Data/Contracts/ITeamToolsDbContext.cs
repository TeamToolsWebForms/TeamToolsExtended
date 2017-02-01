using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using TeamTools.Models;

namespace TeamTools.Data.Contracts
{
    public interface ITeamToolsDbContext : IDisposable
    {
        int SaveChanges();

        IDbSet<Organization> Organizations { get; set; }

        IDbSet<ProjectTask> ProjectTasks { get; set; }

        IDbSet<Message> Messages { get; set; }

        IDbSet<Note> Notes { get; set; }

        IDbSet<Project> Projects { get; set; }

        IDbSet<T> Set<T>() where T : class;

        DbEntityEntry<T> Entry<T>(T entity) where T : class;
    }
}
