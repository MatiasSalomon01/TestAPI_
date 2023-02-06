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

        public async Task<Student> GetById(int id)
        {
            return await _studentRepository.GetById(id);
        }
        public async Task<Response> Create(StudentModel student)
        {
            return await _studentRepository.Create(_mapper.Map<Student>(student));
        }

        public async Task<Response> Update(int id, StudentModel student)
        {
            var s = await _studentRepository.GetById(id);
            s.Id= id;
            s.Name= student.Name;
            s.LastName = student.LastName;
            s.Birthday= student.Birthday;
            s.PhoneNumber= student.PhoneNumber;
            s.Address= student.Address;
            s.Email= student.Email;
            s.CityId= student.CityId;

            return await _studentRepository.Update(s);
        }

        public async Task<Response> Delete(int id)
        {
            return await _studentRepository.Delete(id);
        }
    }
}
