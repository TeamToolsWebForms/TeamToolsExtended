using System.Data.Entity;

namespace TeamTools.Logic.Data.Contracts
{
    public interface IEntryState<T>
    {
        EntityState State { get; set; }
    }
}
