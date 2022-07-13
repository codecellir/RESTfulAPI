using RESTFulAPI.Data;

namespace RESTFulAPI.Services
{
    public interface IStudentService
    {
        Task<List<Student>> GetAllAsync();

        Task<Student> GetByIdAsync(int id);

        Task<Student> InsertStudentAsync(Student student);

        Task UpdateStudentAsync(Student student);   

        Task DeleteAsync(int id);

        Task<bool> StudentExist(int id);
    }
}
