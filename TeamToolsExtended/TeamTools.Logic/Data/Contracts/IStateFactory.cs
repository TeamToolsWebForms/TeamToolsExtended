using System.Data.Entity.Infrastructure;

namespace TeamTools.Logic.Data.Contracts
{
    public interface IStateFactory
    {
        IEntryState<T> CreateState<T>(DbEntityEntry<T> entry) where T : class;
    }
}
