public class Person {
    private string NamePrefix;
    private string Name;
    private string Surname;
    private int Age;
    private string Allergy;
    private string Religion;

    public Person(string NamePrefix, string Name, string Surname, int Age, string Allergy, string Religion) {
        this.NamePrefix = NamePrefix;
        this.Name = Name;
        this.Surname = Surname;
        this.Age = Age;
        this.Allergy = Allergy;
        this.Religion = Religion;
    }
    
    public string GetFullName() {
        return $"{NamePrefix}{Name} {Surname}";
    }
    public string GetNamePrefix() {
        return this.NamePrefix;
    }

    public string GetName() {
        return this.Name;
    }

    public string GetSurname() {
        return this.Surname;
    }

    public int GetAge() {
        return this.Age;
    }

    public string GetAllergy() {
        return this.Allergy;
    }

    public string GetReligion() {
        return this.Religion;
    }
}