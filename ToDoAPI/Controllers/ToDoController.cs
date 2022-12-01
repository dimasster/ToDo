using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Logic.Interfaces;
using DAL.Models;

namespace ToDoAPI.Controllers
{
    [Route("api/todo")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        private readonly IToDoService service;

        public ToDoController(IToDoService _service)
        {
            service = _service;
        }

        [HttpGet(Name = "GetAllLists")]
        public async Task<List<List>> GetLists()
        {
            return await service.GetAllLists();
        }

        [HttpGet("{id}", Name = "GetList")]
        public async Task<List> GetList(int id)
        {
            return await service.GetListById(id);
        }

        [HttpPost]
        public async Task CreateList([FromBody] List todoItem)
        {
            await service.AddList(todoItem);
        }

        [HttpPut]
        public async Task UpdateList([FromBody] List updatedTodoItem)
        {
            await service.EditList(updatedTodoItem);
        }

        [HttpDelete("{id}")]
        public async Task DeleteList(int id)
        {
            await service.DeleteList(id);
        }

        [HttpGet("note", Name = "GetNotes")]
        public async Task<List<Note>> GetNote()
        {
            return await service.GetNotes();
        }

        [HttpPost("note")]
        public async Task CreateNote([FromBody] Note todoItem)
        {
            await service.AddNote(todoItem);
        }

        [HttpPut("note")]
        public async Task UpdateNote([FromBody] Note updatedTodoItem)
        {
            await service.EditNote(updatedTodoItem);
        }

        [HttpDelete("note/{id}")]
        public async Task DeleteNote(int id)
        {
            await service.DeleteNote(id);
        }
    }
}
