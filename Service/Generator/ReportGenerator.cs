using C_sharp_egzaminas.Entity;
using C_sharp_egzaminas.Repository;

namespace C_sharp_egzaminas.Service.Generate
{
    public class ReportGenerator
    {
        StudentRepository studentRepository;
        TeacherRepository teacherRepository;
        RecordRepository recordRepository;
        LessonRepository lessonRepository;
        public ReportGenerator(StudentRepository studentRepository, TeacherRepository teacherRepository, RecordRepository recordRepository, LessonRepository lessonRepository)
        {
            this.studentRepository = studentRepository;
            this.teacherRepository = teacherRepository;
            this.recordRepository = recordRepository;
            this.lessonRepository = lessonRepository;
        }

        public List<ReportItem> GenerateAllReportLinesByStudentId(int studentId, DateTime from, DateTime to)
        {
            List<ReportItem> results = new List<ReportItem>();
            List<Record> records = recordRepository.GetAllByStudentId(studentId);
            records = records.FindAll(x => x.Date >= from && x.Date <= to);
            int id = 0;

            foreach (Record record in records)
            {
                results.Add(new ReportItem(id++, record.Grade, 0, record.Date, record.Message, teacherRepository.GetFullName(record.TeacherId), studentRepository.GetFullName(record.StudentId), lessonRepository.GetNameById(record.LessonId), "lineItem"));
            }

            return results;
        }

        public List<ReportItem> GenerateReportLinesByStudentIdAndLessonId(int studentId, int lessonId, DateTime from, DateTime to)
        {
            List<ReportItem> results = new List<ReportItem>();
            List<Record> records = recordRepository.GetAllByStudentId(studentId);
            records = records.FindAll(x => x.LessonId == lessonId && x.Date >= from && x.Date <= to);
            int id = 0;

            foreach (Record record in records)
            {
                results.Add(new ReportItem(id++, record.Grade, 0, record.Date, record.Message, teacherRepository.GetFullName(record.TeacherId), studentRepository.GetFullName(record.StudentId), lessonRepository.GetNameById(record.LessonId), "lineItem"));
            }

            return results;
        }

        public List<ReportItem> GenerateAllReportLinesByTeacherId(int TeacherId)
        {
            List<ReportItem> results = new List<ReportItem>();
            List<Record> records = recordRepository.GetAllByTeacherId(TeacherId);
            int id = 0;

            foreach (Record record in records)
            {
                results.Add(new ReportItem(id++, record.Grade, 0, record.Date, record.Message, teacherRepository.GetFullName(record.TeacherId), studentRepository.GetFullName(record.StudentId), lessonRepository.GetNameById(record.LessonId), "lineItem"));
            }

            return results;
        }

        public ReportItem GenerateReportTitleByStudentIdAndLessonId(int studentId, int lessonId, DateTime from, DateTime to)
        {
            List<Record> records = recordRepository.GetAllByStudentId(studentId);
            records = records.FindAll(x => x.LessonId == lessonId && x.Date >= from && x.Date <= to);
            int id = 0;

            if (records.Count < 1) { return new ReportItem(); }

            return new ReportItem(id++, 0, records.Average(x => x.Grade), DateTime.Now, "", "", studentRepository.GetFullName(studentId), lessonRepository.GetNameById(lessonId), "titleItem");
        }

        public List<ReportItem> GenerateAllReportTitlesByStudent(int studentId, DateTime from, DateTime to)
        {
            List<ReportItem> results = new List<ReportItem>();
            List<Lesson> lessons = lessonRepository.GetAll();

            foreach (Lesson lesson in lessons)
            {
                results.Add(GenerateReportTitleByStudentIdAndLessonId(studentId, lesson.Id, from, to));
            }

            return results;
        }

        public List<ReportItem> GenerateFullSemesterStudentReportByStudentIdAndSemester(int studentId, int semester, int year)
        {
            DateTime[] period = GetSemesterPeriodBySchoolYear(year, semester);
            List<ReportItem> titles = GenerateAllReportTitlesByStudent(studentId, period[0], period[1]);
            List<ReportItem> lines = GenerateAllReportLinesByStudentId(studentId, period[0], period[1]);

            return titles.Concat(lines).ToList();
        }

        public List<ReportItem>[] GenerateFullYearStudentReportByStudentIdAndSemester(int studentId, int year)
        {
            List<ReportItem>[] results = new List<ReportItem>[] {
            GenerateFullSemesterStudentReportByStudentIdAndSemester(studentId, 1, year),
            GenerateFullSemesterStudentReportByStudentIdAndSemester(studentId, 2, year),
            GenerateFullSemesterStudentReportByStudentIdAndSemester(studentId, 3, year),
            };

            return results;
        }


        private DateTime[] GetSemesterPeriodBySchoolYear(int year, int semester)
        {
            DateTime from;
            DateTime to;

            switch (semester)
            {
                case 1:
                    from = DateTime.Parse($"{year}/{09}/{01}");
                    to = DateTime.Parse($"{year}/{11}/{30}");
                    break;
                case 2:
                    from = DateTime.Parse($"{year}/{12}/{01}");
                    to = DateTime.IsLeapYear(year) ? DateTime.Parse($"{year + 1}/{02}/{29}") : DateTime.Parse($"{year + 1}/{02}/{28}");
                    break;
                case 3:
                    from = DateTime.Parse($"{year + 1}/{03}/{01}");
                    to = DateTime.Parse($"{year + 1}/{06}/{15}");
                    break;
                default:
                    throw new ArgumentException();
            }

            return new[] { from, to };

        }


    }
}
