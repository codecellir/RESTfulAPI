using Microsoft.EntityFrameworkCore;
using RESTFulAPI.Data;

namespace RESTFulAPI.Services
{
    public class StudentService : IStudentService
    {
        private readonly AppDbContext _context;

        public StudentService(AppDbContext context)
        {
            _context = context;
        }
        public async Task DeleteAsync(int id)
        {
            _context.Remove(new Student { Id = id });
            await _context.SaveChangesAsync();
        }

        public async Task<List<Student>> GetAllAsync()
        {
            return await _context.Students.ToListAsync();
        }

        public async Task<Student> GetByIdAsync(int id)
        {
            return await _context.Students.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Student> InsertStudentAsync(Student student)
        {
            await _context.AddAsync(student);
            await _context.SaveChangesAsync();
            return student;
        }

        public async Task<bool> StudentExist(int id)
        {
            return await _context.Students.AnyAsync(x => x.Id == id);
        }

        public async Task UpdateStudentAsync(Student student)
        {
            _context.Entry(student).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
