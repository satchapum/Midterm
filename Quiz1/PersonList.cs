using System.Collections.Generic;
using System;
using System.Linq;
class PersonList {
    private List<Person> personList;

    public PersonList() {
        this.personList = new List<Person>();
    }

    public void AddNewPerson(Person person) {
        this.personList.Add(person);
    }
    
    public bool ValidateName(Person person){
        var found = personList.FirstOrDefault(n => n.GetNamePrefix().Equals(person.GetNamePrefix()) && n.GetName().Equals(person.GetName()) && n.GetSurname().Equals(person.GetSurname()));
        return found != null;
    }

    public bool ValidateMailTeacher(Teacher teacher) {
        var found = personList.Where(t=> (t is Teacher)).FirstOrDefault(t =>((Teacher) t).GetMail().Equals(teacher.GetMail()));
        return found != null || teacher.GetMail().ToLower().Equals("exit");
    }

    public bool ValidateMailStudentUniversity(StudentUniversity studentUniversity) {
        var found = personList.Where(s=>s is StudentUniversity).FirstOrDefault(s =>((StudentUniversity) s).GetMail().Equals(studentUniversity.GetMail()));
        return found != null || studentUniversity.GetMail().ToLower().Equals("exit");
    }

    public Person GetLoginPerson(string user, string password) {
        var teacher = personList.Where(t=> t is Teacher).Select(t=> (Teacher) t).FirstOrDefault(t => t.GetMail().Equals(user) && t.GetPassword().Equals(password));
        if (teacher != null)
            return teacher;
        var studentuniversity = personList.Where(s=> s is StudentUniversity).Select(s=> (StudentUniversity) s).FirstOrDefault(s => s.GetMail().Equals(user) && s.GetPassword().Equals(password));
        if (studentuniversity != null) {
            return studentuniversity;
        }
        return null;
    }
    public List<Person> ToList() {
        return personList;
    }
    
    public int TeacherCount() {
        int Count = 0;
        foreach(Person person in this.personList) {
            if(person is Teacher){
                Count++;
            }
        }
        return Count;
    }
    public int StudentUniversityCount() {
        int Count = 0;
        foreach(Person person in this.personList) {
            if(person is StudentUniversity){
                Count++;
            }
        }
        return Count;
    }
    public int StudentSchoolCount() {
        int Count = 0;
        foreach(Person person in this.personList) {
            if(person is StudentSchool){
                Count++;
            }
        }
        return Count;
    }
    public int StudentSchoolM4Count() {
        int Count = 0;
        foreach(Person person in this.personList) {
            if(person is StudentSchool studentschool){
                if(studentschool.GetLevelOfEducation() == "M.4") {
                Count++;
                }
            }
        }
        return Count;
    }
    public int StudentSchoolM5Count() {
        int Count = 0;
        foreach(Person person in this.personList) {
            if(person is StudentSchool studentschool){
                if(studentschool.GetLevelOfEducation() == "M.5") {
                Count++;
                }
            }
        }
        return Count;
    }
    public int StudentSchoolM6Count() {
        int Count = 0;
        foreach(Person person in this.personList) {
            if(person is StudentSchool studentschool){
                if(studentschool.GetLevelOfEducation() == "M.6") {
                Count++;
                }
            }
        }
        return Count;
    }

    public void ShowStudentUniversity() {
        Console.Clear();
        Console.WriteLine("List Student University");
        Console.WriteLine("*************");
        int NumberCount = 1;
        foreach(Person person in this.personList) {
            if (person is StudentUniversity) {
                Console.WriteLine("{0}:{1}", NumberCount, person.GetFullName());
                NumberCount ++;
            } 
        }
    }
    public void ShowStudentSchool() {
        Console.Clear();
        Console.WriteLine("List Student School");
        Console.WriteLine("*************");
        int NumberCount = 1;
        foreach(Person person in this.personList) {
            if (person is StudentSchool) {
                Console.WriteLine("{0}:{1}", NumberCount, person.GetFullName());
                NumberCount ++;
            } 
        }
    }
    public void ShowTeacher() {
        Console.Clear();
        Console.WriteLine("List Teacher");
        Console.WriteLine("*************");
        int NumberCount = 1;
        foreach(Person person in this.personList) {
            if (person is Teacher) {
                Console.WriteLine("{0}:{1}", NumberCount, person.GetFullName());
                NumberCount ++;
            } 
        }
    }
}