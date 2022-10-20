using C_sharp_egzaminas.Entity;
using C_sharp_egzaminas.Repository;

namespace C_sharp_egzaminas.Service.Generate
{
    public class ReportGenerator
    {
        StudentRepository studentRepository;
        TeacherRepository teacherRepository;
        RecordRepository recordRepository;
        ReportGenerator(StudentRepository studentRepository, TeacherRepository teacherRepository, RecordRepository recordRepository)
        {
            this.studentRepository = studentRepository;
            this.teacherRepository = teacherRepository;
            this.recordRepository = recordRepository;
        }

        public void Generate(ReportRepository reportRepository)
        {
            List<ReportItem> records = recordRepository.GetAll();

            foreach (ReportItem record in records)
            {
                reportRepository.AddItem(new ReportItem());
            }

        }
    }
}
