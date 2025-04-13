namespace application.Repositories.Generic
{
    public interface IRepoGeneric<T>
    {
        int Create(T dto);
        T GetById(Guid id);
        int Update(T dto);
        int Delete(Guid id);
    }
}
