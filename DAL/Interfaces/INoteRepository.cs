using DAL.Models;

namespace DAL.Interfaces
{
    public interface INoteRepository
    {
        Task<List<Note>> Get();

        Task Create(Note item);

        Task Update(Note updatedTodoItem);

        Task Delete(int Id);

        Task DeleteById(int Id);
    }
}
