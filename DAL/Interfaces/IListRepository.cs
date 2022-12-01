using DAL.Models;

namespace DAL.Interfaces
{
    public interface IListRepository
    {
        Task<List<List>> Get();

        Task<List> Get(int Id);

        Task Create(List item);

        Task Update(List updatedTodoItem);

        Task Delete(int Id);
    }
}
