using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using IssueTracker.Data;
using IssueTracker.Dtos;
using IssueTracker.Models;


namespace IssueTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiController : ControllerBase
    {
        private readonly IssueDbContext _context;

        public ApiController(IssueDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            return Ok(await _context.Users.ToListAsync());

        }
        [HttpGet("{id}")]
       

        public async Task<IActionResult> GetUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }
        [HttpPost]
        public async Task<IActionResult> AddUsers(UserModelsDto AddUserModels)
        {
            var users = new UserModels()
            {
                AssignTo = AddUserModels.AssignTo,
                userId = AddUserModels.userId,
                dueDate = AddUserModels.dueDate,
                 TaskRole= AddUserModels.TaskRole,
                TaskName = AddUserModels.TaskName,
                Description = AddUserModels.Description,
                Notes = AddUserModels.Notes,
                Priority = AddUserModels.Priority,
                isCompleted = AddUserModels.isCompleted,
             

            };
            await _context.Users.AddAsync(users);
            await _context.SaveChangesAsync();
            return Ok(users);

        }
        [HttpPut("{id}")]
        
        public async Task<IActionResult> UpdateUsers(int id, UpdateUserModelsDto updateUserModels)
        {
            var users = await _context.Users.FindAsync(id);
            if(users != null)
            {
                users.AssignTo = updateUserModels.AssignTo;
                users.userId = updateUserModels.userId;
                users.dueDate = updateUserModels.dueDate;
                users.TaskRole = updateUserModels.TaskRole;
                users.TaskName = updateUserModels.TaskName;
                users.Description = updateUserModels.Description;
                users.Notes = updateUserModels.Notes;
                users.Priority = updateUserModels.Priority;
                users.isCompleted = updateUserModels.isCompleted;
                await _context.SaveChangesAsync();
                return Ok(users);
            }
            return NotFound();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsers(int id)
        {
            var users = await _context.Users.FindAsync(id);
            if (users != null)
            {
                _context.Remove(users);
               await _context.SaveChangesAsync();
                return Ok(users);
            }
            return NotFound();
        }

    }


}
