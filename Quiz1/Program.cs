enum MenuNonRegister {
    RegisterToCampaign = 1,
    ShowExhibitorStatistics,
    ShowLogin,

}
enum MenuRegister {
    RegisterToCampaign = 1,
    ShowStudentUniversityData,
    ShowStudentSchoolData,
    ShowTeacherData,
    ShowLogout,

}

class Program {

    static PersonList personList = new PersonList();
    
    public static void Main(string[] args) {
        bool IsRegister = false;
    
        PreparePersonListWhenProgramIsLoad();
        SelectPrintMenu(IsRegister);

    }  
    public static void SelectPrintMenu(bool IsRegister, Person login = null) {
        if(IsRegister == false) {
            PrintMenuNonRegister(IsRegister);

        }
        else if(IsRegister == true) {
            PrintMenuRegister(IsRegister, login);
        }
    }

    static void PreparePersonListWhenProgramIsLoad() {
        Program.personList = new PersonList();
    }

    public static void PrintMenuNonRegister(bool IsRegister) {
        Console.Clear();

        Console.WriteLine("***********************");
        Console.WriteLine("1 : Register");
        Console.WriteLine("2 : GuestData");
        Console.WriteLine("3 : Login");
        Console.WriteLine("***********************");

        InputMenuNumberFromKeyboard(IsRegister, null);
    }

    public static void PrintMenuRegister(bool IsRegister, Person login) {
        Console.Clear();

        Console.WriteLine ($"Welcome : {login.GetFullName()}");
        Console.WriteLine("***********************");
        Console.WriteLine("1 : Register");
        Console.WriteLine("2 : Show StudentUniversity Infomation");
        Console.WriteLine("3 : Show StudentSchool Infomation");
        Console.WriteLine("4 : Show Teacher Infomation");
        Console.WriteLine("5 : Logout");
        Console.WriteLine("***********************");

        InputMenuNumberFromKeyboard(IsRegister, login);
    }

    public static void InputMenuNumberFromKeyboard(bool IsRegister, Person login) {
        Console.Write("Please input Menu : ");
        int Type = 0;
        if(IsRegister == false) {
            MenuNonRegister menunonregister = (MenuNonRegister)(int.Parse(Console.ReadLine()));
            
            PresentMenuNonRegister(menunonregister, Type); 
        }
        else {
            MenuRegister menuregister = (MenuRegister)(int.Parse(Console.ReadLine()));

            PresentMenuRegister(menuregister, Type, login);
        }

        
    }

    public static void PresentMenuNonRegister(MenuNonRegister menunonregister, int Type) {
        if(menunonregister == MenuNonRegister.RegisterToCampaign) {
            Console.Write("Input Type (1: Student University,2: Student School ,3: Teacher) : ");
            Type = int.Parse(Console.ReadLine());

            ShowInputRegisterToCampaign(Type);
            SelectPrintMenu(false);
        }
        else if(menunonregister == MenuNonRegister.ShowExhibitorStatistics) {
            ShowAmountOfData();
            Console.Write("Please Enter to go next");
            Console.ReadLine();
            SelectPrintMenu(false);
        }
        else if(menunonregister == MenuNonRegister.ShowLogin) {
            ShowInputLogin();
        }
    }

    public static void PresentMenuRegister(MenuRegister menuregister, int Type, Person login) {
        if(menuregister == MenuRegister.RegisterToCampaign) {
            Console.Write("Input Type (1: Student University,2: Student School ,3: Teacher) : ");
            Type = int.Parse(Console.ReadLine());

            ShowInputRegisterToCampaign(Type);
            SelectPrintMenu(true, login);
        }
        else if(menuregister == MenuRegister.ShowStudentUniversityData) {
            personList.ShowStudentUniversity();
            Console.Write("Please Enter to go next");
            Console.ReadLine();
            SelectPrintMenu(true, login);
        }
        else if(menuregister == MenuRegister.ShowStudentSchoolData) {
            personList.ShowStudentSchool();
            Console.Write("Please Enter to go next");
            Console.ReadLine();
            SelectPrintMenu(true, login);
        }
        else if(menuregister == MenuRegister.ShowTeacherData) {
            personList.ShowTeacher();
            Console.Write("Please Enter to go next");
            Console.ReadLine();
            SelectPrintMenu(true, login);
        }
        else if(menuregister == MenuRegister.ShowLogout) {
            SelectPrintMenu(false);
        }
    }

    public static void ShowAmountOfData() {
        Console.Clear();

        Console.WriteLine("Amount Of Data");
        Console.WriteLine("**********************");
        Console.WriteLine("Amount of Teacher : {0}", personList.TeacherCount());
        Console.WriteLine("Amount of Student School : {0}", personList.StudentSchoolCount());
        Console.WriteLine("Amount of Student University : {0}", personList.StudentUniversityCount());
        Console.WriteLine("Amount of Student School M.4 : {0}", personList.StudentSchoolM4Count());
        Console.WriteLine("Amount of Student School M.5 : {0}", personList.StudentSchoolM5Count());
        Console.WriteLine("Amount of Student School M.6 : {0}", personList.StudentSchoolM6Count());
        Console.WriteLine("**********************");

    }
    public static void ShowInputLogin() {
        string User = "";
        string Password = "";

        Console.Clear();

        Console.WriteLine("******************");
        Console.Write("Input User Name : ");
        User = Console.ReadLine();

        if(User.ToLower().Equals("exit")) {
            Console.Clear();
            Console.Write("Please Enter to go next");
            SelectPrintMenu(false);
        }
        else if(User == "" && Password == "") {
            Console.WriteLine("Incorrect email or password. Please try again.");
            Console.ReadLine();
            ShowInputLogin();
        }
        else  {
            Console.Write("Input Password : ");
            Password = Console.ReadLine();
            var login = personList.GetLoginPerson(User, Password);
            if(login != null) {
                SelectPrintMenu(true, login);
            }
            else {
                Console.WriteLine("Incorrect email or password. Please try again.");
                Console.ReadLine();
                ShowInputLogin();
            }
        }
    }

    public static void ShowInputRegisterToCampaign(int Type) {
        Console.Clear();

        InputRegisterToCampaign(Type);
    }

    public static void PrintHeaderRegisterToCampaign(int Type) {
        if(Type == 1) {
            Console.WriteLine("Register New Student University");
            Console.WriteLine("**********************");
        }
        else if(Type == 2) {
            Console.WriteLine("Register New Student School");
            Console.WriteLine("**********************");
        }
        else {
            Console.WriteLine("Register New Teacher");
            Console.WriteLine("**********************");
        }
    }

    public static void InputRegisterToCampaign(int Type) {
        if(Type == 1) {
            Console.Clear();
            PrintHeaderRegisterToCampaign(Type);
            bool AdministrationStudent;

            StudentUniversity studentuniversity = new StudentUniversity(InputNamePrefix(), InputName(), InputSurname(), InputAge(), InputAllergy(), InputReligion(), InputStudentID(), AdministrationStudent = IsAdministration(), 
            InputMailStudent(AdministrationStudent), InputPassWordStudent(AdministrationStudent));

            if (personList.ValidateName(studentuniversity))
            {
                Console.Clear();
                printError("User is already registered. Please try again.",Type); 
                InputRegisterToCampaign(Type);
                return;
            }
            if(personList.ValidateMailStudentUniversity(studentuniversity)) {
                Console.Clear();
                printError("Invalid email. Please try again.",Type);
                InputRegisterToCampaign(Type);
                return;
            }
            Program.personList.AddNewPerson(studentuniversity);
            
        }
        else if(Type == 2) {
            Console.Clear();
            PrintHeaderRegisterToCampaign(Type);
            StudentSchool studentschool = new StudentSchool(InputNamePrefix(), InputName(), InputSurname(), InputAge(), InputAllergy(), InputReligion(), InputLevelOfEducation(), InputSchoolName());

            if (personList.ValidateName(studentschool))
            {
                Console.Clear();
                printError("User is already registered. Please try again.",Type);
                InputRegisterToCampaign(Type);
                return;
            }

            Program.personList.AddNewPerson(studentschool);
        }
        else {
            Console.Clear();
            PrintHeaderRegisterToCampaign(Type);
            bool AdministrationTeacher;
            bool Car;
            Teacher teacher = new Teacher(InputNamePrefix(), InputName(), InputSurname(), InputAge(), InputAllergy(), InputReligion(), Position(), Car = IsCar(), InputCarNumber(Car), AdministrationTeacher = IsAdministration(), 
            InputMailTeacher(AdministrationTeacher), InputPassWordTeacher(AdministrationTeacher));

            if (personList.ValidateName(teacher))
            {
                Console.Clear();
                printError("User is already registered. Please try again.",Type);
                InputRegisterToCampaign(Type);
                return;
            }
            if(personList.ValidateMailTeacher(teacher)) {
                Console.Clear();
                printError("Invalid email. Please try again.",Type);
                InputRegisterToCampaign(Type);
                return;
            }

            Program.personList.AddNewPerson(teacher);
        }
    }
    
    static void printError(string errMsg, int Type)
    {
        Console.WriteLine(errMsg);
        Console.Write("Please Enter to retry");
        Console.ReadLine();
        PrintHeaderRegisterToCampaign(Type);
    }

    static bool IsAdministration() {
        Console.WriteLine("-----------------");
        Console.Write("Are you Administration(Yes/No) : ");
        string InputFromKeyboard = Console.ReadLine();

        if(InputFromKeyboard == "Yes" || InputFromKeyboard == "yes") {
            return true;
        }
        else {
            return false;
        }
    }

    static string InputMailStudent(bool AdministrationStudent) {
        if(AdministrationStudent == true) {
            Console.WriteLine("-----------------");
            Console.Write("Input email : ");
            return Console.ReadLine();
        }
        return "";
    }

    static string InputPassWordStudent(bool AdministrationStudent) {
        if(AdministrationStudent == true) {
            Console.WriteLine("-----------------");
            Console.Write("Input Password : ");
            return Console.ReadLine();
        }
        return "";
    }

    static string InputMailTeacher(bool AdministrationTeacher) {
        if(AdministrationTeacher == true) {
            Console.WriteLine("-----------------");
            Console.Write("Input email : ");
            return Console.ReadLine();
        }
        return "";
    }

    static string InputPassWordTeacher(bool AdministrationTeacher) {
        if(AdministrationTeacher == true) {
            Console.WriteLine("-----------------");
            Console.Write("Input Password : ");
            return Console.ReadLine();
        }
        return "";
    }
    
    static string InputCarNumber(bool Car) {
        if(Car == true) {
            Console.WriteLine("-----------------");
            Console.Write("Input Car number : ");
            return Console.ReadLine();
        }
        return "";
    }

    static string InputNamePrefix() {
        Console.WriteLine("-----------------");
        Console.WriteLine("Select Name Prefix");
        Console.WriteLine("1. Mr. ");
        Console.WriteLine("2. Mrs. ");
        Console.WriteLine("3. Ms. ");
        Console.Write("Input SelectNumber : ");

        string NumberSelect = Console.ReadLine();

        if(NumberSelect == "1") {
            return "Mr.";
        }
        else if(NumberSelect == "2") {
            return "Mrs.";
        }
        else{
            return "Ms.";
        }
    }

    static string InputName() {
        Console.WriteLine("-----------------");
        Console.Write("Name : ");

        return Console.ReadLine();
    }

        static string InputSurname() {
        Console.WriteLine("-----------------");
        Console.Write("Surname : ");



        return Console.ReadLine();
    }

    static string InputStudentID() {
        Console.WriteLine("-----------------");
        Console.Write("StudentID : ");

        return Console.ReadLine();
    }

    static int InputAge() {
        Console.WriteLine("-----------------");
        Console.Write("Age : ");

        return int.Parse(Console.ReadLine());
    }

    static string InputAllergy() {
        Console.WriteLine("-----------------");
        Console.Write("Allergy : ");

        return Console.ReadLine();
    }

    static string InputSchoolName() {
        Console.WriteLine("-----------------");
        Console.Write("SchoolName : ");

        return Console.ReadLine();
    }


    static string InputLevelOfEducation() {
        Console.WriteLine("-----------------");
        Console.WriteLine("Select Level Of Education");
        Console.WriteLine("1. M.4 ");
        Console.WriteLine("2. M.5");
        Console.WriteLine("3. M.6");
        Console.Write("Input SelectNumber : ");

        string NumberSelect = Console.ReadLine();

        if(NumberSelect == "1") {
            return "M.4";
        }
        else if(NumberSelect == "2") {
            return "M.5";
        }
        else{
            return "M.6";
        }
    }
    
    static string InputReligion() {
        Console.WriteLine("-----------------");
        Console.WriteLine("Select Religion");
        Console.WriteLine("1. Buddhist ");
        Console.WriteLine("2. Christ ");
        Console.WriteLine("3. Islam ");
        Console.WriteLine("4. Other ");
        Console.Write("Input SelectNumber : ");

        string NumberSelect = Console.ReadLine();

        if(NumberSelect == "1") {
            return "Buddhist";
        }
        else if(NumberSelect == "2") {
            return "Christ";
        }
        else if(NumberSelect == "3") {
            return "Islam";
        }
        else {
            Console.Write("Input Religion : ");

            return Console.ReadLine();
        }
    }

    static string Position() { 
        Console.WriteLine("-----------------");
        Console.WriteLine("Select Position");
        Console.WriteLine("1. Dean ");
        Console.WriteLine("2. Head of department ");
        Console.WriteLine("3. Full-time teacher ");
        Console.Write("Input SelectNumber : ");

        string NumberSelect = Console.ReadLine();

        if(NumberSelect == "1") {
            return "Dean";
        }
        else if(NumberSelect == "2") {
            return "Head of department";
        }
        else {
            return "Full-time teacher";
        }
    } 

    static bool IsCar() {
        Console.WriteLine("-----------------");
        Console.Write("Do you have Car? (Yes/No) : ");
        string InputFromKeyboard = Console.ReadLine();

        if(InputFromKeyboard == "Yes" || InputFromKeyboard == "yes") {
            return true;
        }
        else {
            return false;
        }
    }
}