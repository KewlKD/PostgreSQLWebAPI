using PostgreSQLWebAPI.DataAccess;
using PostgreSQLWebAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace PostgreSQLWebAPI.DataAccess
{
    public class DataAccessProvider : IDataAccessProvider
    {
        private readonly PostgreSqlContext _context;

        public DataAccessProvider(PostgreSqlContext context)
        {
            _context = context;
        }

        public void AddStudentRecord(Student student)
        {
            _context.student.Add(student);
            _context.SaveChanges();
        }

        public void UpdateStudentRecord(Student student)
        {
            _context.student.Update(student);
            _context.SaveChanges();
        }

        public void DeleteStudentRecord(string studentid)
        {
            var entity = _context.student.FirstOrDefault(t => t.studentid == studentid);
            _context.student.Remove(entity);
            _context.SaveChanges();
        }

        public Student GetStudentSingleRecord(string studentid)
        {
            return _context.student.FirstOrDefault(t => t.studentid == studentid);
        }

        public List<Student> GetStudentRecords()
        {
            return _context.student.ToList();
        }

       
    }
}

