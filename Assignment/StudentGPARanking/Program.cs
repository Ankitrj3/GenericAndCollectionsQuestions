public class InvalidGPAException : Exception
{
    public InvalidGPAException (string message) : base(message){}
}
public class DuplicateStudentException: Exception
{
    public DuplicateStudentException (string message) : base(message){}
}
public class StudentNotFoundException : Exception
{
    public StudentNotFoundException (string message) : base(message){}
}
public class Student
{
    public string? StudentId{get; set;}
    public string? StudentName{get; set;}
    public double GPA{get; set;}
    public Student(){}
    public Student(string StudentId,string StudentName, double GPA)
    {
        this.StudentId = StudentId;
        this.StudentName = StudentName;
        this.GPA = GPA;
    }
}
public class StudentUtility
{
    public static SortedDictionary<double, List<Student>> studentDetails = new SortedDictionary<double, List<Student>>(
        Comparer<double>.Create((a,b) => b.CompareTo(a))
    );
    public void AddStudent(Student student)
    {
        if(student.GPA < 1 || student.GPA > 10)
        {
            throw new InvalidGPAException("GPA entered is Wrong");
        }
        foreach(var i in studentDetails)
        {
            foreach(var j in i.Value)
            {
                if(j.StudentId == student.StudentId)
                {
                    throw new DuplicateStudentException("Student is Already Present");
                }
            }
        }
        if (!studentDetails.ContainsKey(student.GPA))
        {
            studentDetails[student.GPA] = new List<Student>();
        }
        studentDetails[student.GPA].Add(student);
    }
    public SortedDictionary<double, List<Student>> GetAll()
    {
        return studentDetails;
    }
    public bool UpdateGPA(string studentId, double newGPA)
    {
        Student found = null;
        double oldGPA = 0;

        foreach(var i in studentDetails)
        {
            foreach(var j in i.Value)
            {
                if(j.StudentId == studentId)
                {
                    found = j;
                    oldGPA = j.GPA;
                    break;
                }
            }
            if(found != null) break;
        }   
        if(found == null)
        {
            Console.WriteLine("Student Not Found");
            return false;
        } 
        studentDetails[oldGPA].Remove(found);
        if(studentDetails[oldGPA].Count == 0)
        {
            studentDetails.Remove(oldGPA);
        }
        found.GPA = newGPA;
        if (!studentDetails.ContainsKey(found.GPA))
        {
            studentDetails[found.GPA] = new List<Student>();
        }
        studentDetails[found.GPA].Add(found);
        return true;
    }
}
public class Program
{
    public static void Main()
    {
        while (true)
        {
            int choice = int.Parse(Console.ReadLine());
            StudentUtility utility = new StudentUtility();
            
            switch (choice)
            {
                case 1:
                    string val = Console.ReadLine();
                    string[] arr= val.Split(" ");
                    string id = arr[0];
                    string name = arr[1];
                    double gpa = double.Parse(arr[2]);

                    Student student = new Student(id,name,gpa);
                    utility.AddStudent(student);
                    break;
                case 2:
                    string val1 = Console.ReadLine();
                    string[] arr1= val1.Split(" ");
                    string id1 = arr1[0];
                    double gpa1 = double.Parse(arr1[1]);
                    utility.UpdateGPA(id1,gpa1);
                    break;
                case 3:
                    SortedDictionary<double,List<Student>> res = utility.GetAll();
                    foreach(var i in res)
                    {
                        foreach(var j in i.Value)
                        {
                            Console.WriteLine(j.StudentName +" "+j.GPA);
                        }
                    }
                    break;
                case 4:
                    return;
                default:
                    Console.WriteLine("Wrong Input");
                    break;
            }
        }
    }
}