using PostgreSQLWebAPI.Models;


namespace PostgreSQLWebAPI.DataAccess
{
    public interface IDataAccessProvider
    {
        void AddStudentRecord(Student student);
        void UpdateStudentRecord(Student student);
        void DeleteStudentRecord(string studentid);
        Student GetStudentSingleRecord(string studentid);
        List<Student> GetStudentRecords();
    }
}
