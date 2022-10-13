class StudentSchool: Person {
    private string LevelOfEducation;
    private string SchoolName;

    public StudentSchool(string NamePrefix, string Name, string Surname, int Age, string Allergy, string Religion, string LevelOfEducation, string SchoolName): base(NamePrefix, Name, Surname, Age, Allergy, Religion) {
        this.LevelOfEducation = LevelOfEducation;
        this.SchoolName = SchoolName;
    }

    public string GetLevelOfEducation() {
        return this.LevelOfEducation;
    }
}