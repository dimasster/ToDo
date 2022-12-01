using DAL.Interfaces;
using DAL.Models;
using Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Services
{
    public class ToDoService: IToDoService
    {
        private readonly IListRepository listRepository;
        private readonly INoteRepository noteRepository;

        public ToDoService(IListRepository lRepository, INoteRepository nRepository)
        {
            listRepository = lRepository ?? throw new ArgumentNullException();
            noteRepository = nRepository ?? throw new ArgumentNullException();
        }

        public async Task<List<List>> GetAllLists()
        {
            try
            {
                return await listRepository.Get();
            }
            catch { throw; }
        }

        public async Task<List> GetListById(int id)
        {
            if (id < 1)
            {
                throw new ArgumentOutOfRangeException();
            }

            return await listRepository.Get(id);
        }

        public async Task AddList(List item)
        {
            if (item == null)
            {
                throw new ArgumentNullException();
            }

            await listRepository.Create(item);
        }

        public async Task EditList(List item)
        {
            if (item == null)
            {
                throw new ArgumentNullException();
            }

            await listRepository.Update(item);
        }

        public async Task DeleteList(int id)
        {
            if (id < 1)
            {
                throw new ArgumentOutOfRangeException();
            }

            await noteRepository.DeleteById(id);
            await listRepository.Delete(id);
        }

        public async Task<List<Note>> GetNotes()
        {
            return await noteRepository.Get();
        }

        public async Task AddNote(Note item)
        {
            if (item == null)
            {
                throw new ArgumentNullException();
            }

            await noteRepository.Create(item);
        }

        public async Task EditNote(Note item)
        {
            if (item == null)
            {
                throw new ArgumentNullException();
            }

            await noteRepository.Update(item);
        }

        public async Task DeleteNote(int id)
        {
            if (id < 1)
            {
                throw new ArgumentOutOfRangeException();
            }

            await noteRepository.Delete(id);
        }
    }
}
