class Teacher: Person {
    private string Position;
    private bool IsCar;
    private bool IsAdministration;
    private string CarNumber;
    private string Mail;
    private string Password;

    public Teacher(string NamePrefix, string Name, string Surname, int Age, string Allergy, string Religion, string Position, bool IsCar, string CarNumber, bool IsAdministration, string Mail, string Password): base(NamePrefix, Name, Surname, Age, Allergy, Religion) {
        this.Position = Position;
        this.IsCar = IsCar;
        this.IsAdministration = IsAdministration;
        this.CarNumber = CarNumber;
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