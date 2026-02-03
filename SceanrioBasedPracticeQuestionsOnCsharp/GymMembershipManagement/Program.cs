// Question 8: Gym Membership Management
// Scenario: A fitness center needs to manage memberships and class schedules.
// Requirements:
// csharp
// // In class Member:
// // - int MemberId
// // - string Name
// // - string MembershipType (Basic/Premium/Platinum)
// // - DateTime JoinDate
// // - DateTime ExpiryDate

// // In class FitnessClass:
// // - string ClassName
// // - string Instructor
// // - DateTime Schedule
// // - int MaxParticipants
// // - List<string> RegisteredMembers

// // In class GymManager:
// public void AddMember(string name, string membershipType, int months)
// // Creates membership with expiry date

// public void AddClass(string className, string instructor, 
//                     DateTime schedule, int maxParticipants)

// public bool RegisterForClass(int memberId, string className)
// // Registers member if class has space

// public Dictionary<string, List<Member>> GroupMembersByMembershipType()
// // Groups members by their plan

// public List<FitnessClass> GetUpcomingClasses()
// // Returns classes scheduled for next 7 days
// Use Cases:
// •	Manage different membership tiers
// •	Schedule fitness classes
// •	Register members for classes
// •	Check membership expiry
// •	View class occupancy

public class Member{
    public int MemberId{get; set;}
    public string Name{get; set;}
    public string MembershipType{get; set;}
    public DateTime JoinDate{get; set;}
    public DateTime ExpiryDate{get; set;}
    public Member(){}
}
class FitnessClass{
    public string ClassName{get; set;}
    public string Instructor{get; set;}
    public DateTime Schedule{get; set;}
    public int MaxParticipants{get; set;}
    public List<string> RegisteredMembers{get; set;}
    public FitnessClass(){}
    public FitnessClass()
    {
        RegisteredMembers = new List<string>();
    }
}
public class GymManage
{
    public static Dictionary<int, Member> memberDetails = new Dictionary<int, Member>();
    public static List<FitnessClass> fitnessClasses = new List<FitnessClass>();
    public static int counter = 1;

    public void AddMember(string name, string membershipType, int months)
    {
        Member member = new Member()
        {
            MemberId = counter,
            Name = name,
            MembershipType = membershipType,
            JoinDate = DateTime.Now,
            ExpiryDate = DateTime.Now.AddMonths(months)
        };
        memberDetails.Add(member.MemberId, member);
        counter++;
    }
    public void AddClass(string className, string instructor, DateTime schedule, int maxParticipants)
    {
        FitnessClass Class = new FitnessClass()
        {
            ClassName = className,
            Instructor = instructor,
            Schedule = schedule,
            MaxParticipants = maxParticipants
        };
        fitnessClasses.Add(Class);
    }
    public bool RegisterForClass(int memberId, string className)
    {
        if (!memberDetails.ContainsKey(memberId))
        {
            Console.WriteLine("Member Not Exist");
            return false;
        }
        Member member = memberDetails[memberId];
        if(member.ExpiryDate < DateTime.Now)
        {
            Console.WriteLine("Membership Expired");
            return false;
        }

        FitnessClass fitnessClass = classes.Find(c => c.ClassName == className);

        if (fitnessClass == null)
        {
            Console.WriteLine("Class not found");
            return false;
        }

        if (fitnessClass.RegisteredMembers.Count >=
            fitnessClass.MaxParticipants)
        {
            Console.WriteLine("Class is full");
            return false;
        }

        if (fitnessClass.RegisteredMembers.Contains(member.Name))
        {
            Console.WriteLine("Member already registered");
            return false;
        }

        fitnessClass.RegisteredMembers.Add(member.Name);
        return true;
    }
    public Dictionary<string, List<Member>> GroupMembersByMembershipType()
    {
        Dictionary<string, List<Member>> result = new Dictionary<string, List<Member>>();

        foreach (var item in members)
        {
            Member member = item.Value;

            if (!result.ContainsKey(member.MembershipType))
            {
                result[member.MembershipType] = new List<Member>();
            }

            result[member.MembershipType].Add(member);
        }

        return result;
    }
    public List<FitnessClass> GetUpcomingClasses()
    {
        List<FitnessClass> result = new List<FitnessClass>();
        DateTime now = DateTime.Now;
        DateTime nextWeek = now.AddDays(7);

        foreach (var cls in classes)
        {
            if (cls.Schedule >= now && cls.Schedule <= nextWeek)
            {
                result.Add(cls);
            }
        }

        return result;
    }
}