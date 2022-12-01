using DAL.DataContext;
using DAL.Models;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class NoteRepository : INoteRepository
    {
        private ToDoDbContext _context;

        public NoteRepository(ToDoDbContext context)
        {
            _context = context;
        }

        public async Task<List<Note>> Get()
        {
            try
            {
                return await _context.Notes.ToListAsync();
            }
            catch { throw; }
        }

        public async Task Create(Note item)
        {
            try
            {
                await _context.Notes.AddAsync(item);
                await _context.SaveChangesAsync();
            }
            catch { throw; }
        }

        public async Task Update(Note updatedNote)
        {
            try
            {
                var currentNote = _context.Notes.First(item => item.NoteId == updatedNote.NoteId);

                if (currentNote != null)
                {
                    currentNote.ListId = updatedNote.ListId;
                    currentNote.Title = updatedNote.Title;
                    currentNote.NoteValue = updatedNote.NoteValue;
                    currentNote.NoteUnitType = updatedNote.NoteUnitType;
                    currentNote.IsDone = updatedNote.IsDone;

                    _context.Notes.Update(currentNote);
                    await _context.SaveChangesAsync();
                }
            }
            catch { throw; }
        }

        public async Task UpdateStatus(Note updatedNote)
        {
            try
            {
                var currentNote = _context.Notes.First(item => item.NoteId == updatedNote.NoteId);

                if (currentNote != null)
                {
                    currentNote.IsDone = updatedNote.IsDone;

                    _context.Notes.Update(currentNote);
                    await _context.SaveChangesAsync();
                }
            }
            catch { throw; }
        }

        public async Task Delete(int Id)
        {
            try
            {
                var currentItem = _context.Notes.First(item => item.NoteId == Id);

                if (currentItem != null)
                {
                    _context.Notes.Remove(currentItem);
                    await _context.SaveChangesAsync();
                }
            }
            catch { throw; }
        }

        public async Task DeleteById(int Id)
        {
            try 
            {
                foreach(var note in _context.Notes.Where(item => item.ListId == Id)){
                    _context.Notes.Remove(note);
                }
                await _context.SaveChangesAsync();
            }
            catch { throw; }
        }
    }
}
