using AutoMapper;
using TestAPI_.Entities;
using TestAPI_.Interfaces.Respositories;
using TestAPI_.Interfaces.Services;
using TestAPI_.Models;
using TestAPI_.Models.Student;

namespace TestAPI_.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;

        public StudentService(IStudentRepository studentRepository, IMapper mapper)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
        }

        public async Task<ICollection<StudentViewModel>> GetAll()
        {
            return await _studentRepository.GetAll();
        }

        public async Task<StudentViewModel> GetById(int id)
        {
            return await _studentRepository.GetById(id);
        }
        public async Task<Response> Create(StudentModel student)
        {
            return await _studentRepository.Create(_mapper.Map<Student>(student));
        }

        public async Task<Response> Update(int id, StudentModel student)
        {
            return await _studentRepository.Update(id, _mapper.Map<Student>(student));
        }

        public async Task<Response> Delete(int id)
        {
            return await _studentRepository.Delete(id);
        }

        public dynamic Filtering(string? filter)
        {
            return _studentRepository.Filtering(filter);
        }
    }
}
