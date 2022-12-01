using DAL.Models;

namespace Logic.Interfaces
{
    public interface IToDoService
    {
        public Task<List<List>> GetAllLists();

        public Task<List> GetListById(int id);

        public Task AddList(List item);

        public Task EditList(List item);

        public Task DeleteList(int id);

        public Task<List<Note>> GetNotes();

        public Task AddNote(Note item);

        public Task EditNote(Note item);

        public Task DeleteNote(int id);
    }
}
