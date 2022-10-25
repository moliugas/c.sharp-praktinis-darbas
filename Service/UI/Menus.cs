namespace C_sharp_egzaminas.Service.UI
{
    public static class Menus
    {
        public static void MainMenu()
        {
            Console.WriteLine("Please select an option:");
            Console.WriteLine("[1] add data");
            Console.WriteLine("[2] get reports");

            switch (GetChoice())
            {
                case 1:
                    AddDataMenu();
                    break;
                case 2:
                    GetReportsMenu();
                    break;
            }
        }

        public static int GetChoice()
        {
            int result;
            while (!int.TryParse(Console.ReadLine(), out result)) { }
            return result;
        }

        private static void AddDataMenu()
        {

            Console.WriteLine("Please select an option:");
            Console.WriteLine("[1] add new student");
            Console.WriteLine("[2] add new teacher");
            Console.WriteLine("[3] add new record");
            Console.WriteLine("[4] import data");
            Console.WriteLine("[5] back");

            switch (GetChoice())
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
                    ImportMenu();
                       break;
                case 5:
                    MainMenu();
                       break;

            }
        }

        private static void ImportMenu()
        {
            throw new NotImplementedException();
        }

        private static void AddRecord()
        {
            throw new NotImplementedException();
        }

        private static void AddTeacher()
        {
            throw new NotImplementedException();
        }

        private static void AddStudent()
        {
        }

        private static void GetReportsMenu() {
            Console.WriteLine("Please select an option:");
            Console.WriteLine("[1] generate html");

            switch (GetChoice())
            {
                case 1:
                    GenerateHtml();
                    break;
            }
        }

        private static void GenerateHtml()
        {
            throw new NotImplementedException();
        }
    }
}
