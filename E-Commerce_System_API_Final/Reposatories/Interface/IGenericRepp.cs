namespace E_Commerce_System_API_Final.Reposatories.Interface
{
    public interface IGenericRepp<T> where T : class
    {
        Task<ICollection<T>> GetAll();
        Task<T> GetByID(int id);
        Task Create(T Entity);
        Task Update(int id ,T Entity);
        Task Delete(int id);
    }
}
