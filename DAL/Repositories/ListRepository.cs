using DAL.DataContext;
using DAL.Interfaces;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class ListRepository : IListRepository
    {
        
        private ToDoDbContext _context;

        public ListRepository(ToDoDbContext context)
        {
            _context = context;
        }

        public async Task<List<List>> Get()
        {
            try {
                return await _context.Lists.ToListAsync();
            }
            catch { throw; }
        }

        public async Task<List> Get(int Id)
        {
            try
            {
                return await _context.Lists.FindAsync(Id);
            }
            catch { throw; }
        }

        public async Task Create(List item)
        {
            try
            {
                await _context.Lists.AddAsync(item);
                await _context.SaveChangesAsync();
            }
            catch { throw; }
        }

        public async Task Update(List updatedTodoItem)
        {
            try
            {
                var currentItem = _context.Lists.First(item => item.ListId == updatedTodoItem.ListId);

                if (currentItem != null)
                {
                    currentItem.Title = updatedTodoItem.Title;

                    _context.Lists.Update(currentItem);
                    await _context.SaveChangesAsync();
                }
            }
            catch { throw; }        
        }

        public async Task Delete(int Id)
        {
            try
            {
                var currentItem = _context.Lists.First(item => item.ListId == Id);

                if (currentItem != null)
                {
                    _context.Lists.Remove(currentItem);
                    await _context.SaveChangesAsync();
                }
            }
            catch { throw; }
        }
    }
}
