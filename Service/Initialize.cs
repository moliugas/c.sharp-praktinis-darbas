using C_sharp_egzaminas.Repository;
using C_sharp_egzaminas.Service.Generator;
using C_sharp_egzaminas.Service.Import;
using Syncfusion.HtmlConverter;
using Syncfusion.Pdf;

namespace C_sharp_egzaminas
{
    public class Initialize
    {
        StudentRepository students = new StudentRepository();
        TeacherRepository teachers = new TeacherRepository();
        RecordRepository records = new RecordRepository();
        LessonRepository lessons = new LessonRepository();

        HtmlToPdfConverter htmlConverter = new HtmlToPdfConverter();

        ReportGenerator reportGenerator;
        public Initialize()
        {

            Import import = new Import(ref students, ref teachers, ref records, ref lessons);

            //Imports mock data.
            import.ImportAll();

            reportGenerator = new ReportGenerator(students, teachers, records, lessons);
        }

        public void Start()
        {

            while (true)
            {
                MainMenu();
            }
        }

        public void MainMenu()
        {
            Console.WriteLine("Please select an option:");
            Console.WriteLine("[1] add data");
            Console.WriteLine("[2] get reports");

            switch (GetInt())
            {
                case 1:
                    AddDataMenu();
                    break;
                case 2:
                    GetReportsMenu();
                    break;
            }
        }

        static int GetInt()
        {
            int result;
            while (!int.TryParse(Console.ReadLine(), out result)) { }
            return result;
        }

        private void AddDataMenu()
        {

            Console.WriteLine("Please select an option:");
            Console.WriteLine("[1] add new student");
            Console.WriteLine("[2] add new teacher");
            Console.WriteLine("[3] add new record");
            Console.WriteLine("[4] back");

            switch (GetInt())
            {
                case 1:
                    AddStudent();
                    break;
                case 2:
                    AddTeacher();
                    break;
                case 3:
                    AddRecord();
                    break;
                case 4:
                    MainMenu();
                    break;
            }
        }

        private void ImportMenu()
        {
            throw new NotImplementedException();
        }

        private void AddRecord()
        {
            Console.WriteLine("Enter teacher ID:");
            int teacherId = GetInt();
            Console.WriteLine("Enter student ID:");
            int studentId = GetInt();
            Console.WriteLine("Enter lesson ID:");
            int lessonId = GetInt();
            Console.WriteLine("Enter grade:");
            int grade = GetInt();
            Console.WriteLine("Enter message:");
            string message = Console.ReadLine();

            records.AddItem(new Entity.Record(records.GetNextId(), grade, teacherId, studentId, lessonId, message));
            Console.WriteLine("Added");
        }

        private void AddTeacher()
        {
            Console.WriteLine("Enter teacher first name:");
            string firstName = Console.ReadLine();
            Console.WriteLine("Enter teacher last name:");
            string lastName = Console.ReadLine();
            Console.WriteLine("Enter teacher group:");
            string group = Console.ReadLine();


            teachers.AddItem(new Entity.Teacher(teachers.GetNextId(), firstName, lastName, group));
            Console.WriteLine("Added");
        }

        private void AddStudent()
        {
            Console.WriteLine("Enter student first name:");
            string firstName = Console.ReadLine();
            Console.WriteLine("Enter student last name:");
            string lastName = Console.ReadLine();
            Console.WriteLine("Enter student group:");
            string group = Console.ReadLine();


            students.AddItem(new Entity.Student(students.GetNextId(), firstName, lastName, group));
            Console.WriteLine("Added");
        }

        private void GetReportsMenu()
        {
            Console.WriteLine("Please select an option:");
            Console.WriteLine("[1] generate student full semester report");
            Console.WriteLine("[4] back");

            switch (GetInt())
            {
                case 1:
                    GenerateSemesterReport();
                    break;
                case 4:
                    MainMenu();
                    break;
            }
        }

        private void GenerateSemesterReport()
        {
            Console.WriteLine("Enter student ID:");
            int id = GetInt();
            Console.WriteLine("Enter semester:");
            int semester = GetInt();
            Console.WriteLine("Enter year:");
            int year = GetInt();

            var report = reportGenerator.GenerateFullSemesterStudentReportByStudentIdAndSemester(id, semester, year);

            string htmlTable = HTMLGenerator.GenerateHTML(report);

            PdfDocument document = htmlConverter.Convert(htmlTable, "");

            string workingDirectory = Directory.GetCurrentDirectory();

            FileStream fileStream = new FileStream(workingDirectory + $"\\{year}Semester{semester}ReportStudentId_{id}.pdf", FileMode.Create, FileAccess.ReadWrite);

            Console.WriteLine($"File saved in {workingDirectory}");

            document.Save(fileStream);
            document.Close(true);
        }
    }
}
