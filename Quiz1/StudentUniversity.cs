class StudentUniversity: Person {
    private string StudentID;
    private bool IsAdministration;
    private string Mail;
    private string Password;

    public StudentUniversity(string NamePrefix, string Name, string Surname, int Age, string Allergy, string Religion, string StudentID, bool IsAdministration, string Mail, string Password): base(NamePrefix, Name, Surname, Age, Allergy, Religion) {
        this.StudentID = StudentID;
        this.IsAdministration = IsAdministration;
        this.Mail = Mail;
        this.Password = Password;
    }

    public bool GetIsAdministration() {
        return this.IsAdministration;
    }
    public string GetMail() {
        return this.Mail;
    }
    public string GetPassword() {
        return this.Password;
    }
}