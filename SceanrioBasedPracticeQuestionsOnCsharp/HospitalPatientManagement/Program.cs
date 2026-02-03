// Question 10: Hospital Patient Management
// Scenario: A hospital needs to manage patient records and appointments.
// Requirements:
// csharp
// In class Patient:
// - int PatientId
// - string Name
// - int Age
// - string BloodGroup
// - List<string> MedicalHistory

// In class Doctor:
// - int DoctorId
// - string Name
// - string Specialization
// - List<DateTime> AvailableSlots

// In class Appointment:
// - int AppointmentId
// - int PatientId
// - int DoctorId
// - DateTime AppointmentTime
// - string Status (Scheduled/Completed/Cancelled)

// In class HospitalManager:
// public void AddPatient(string name, int age, string bloodGroup)
// public void AddDoctor(string name, string specialization)
// public bool ScheduleAppointment(int patientId, int doctorId, DateTime time)
// public Dictionary<string, List<Doctor>> GroupDoctorsBySpecialization()
// public List<Appointment> GetTodayAppointments()
// Use Cases:
// •	Register patients and doctors
// •	Schedule appointments
// •	View doctors by specialization
// •	Check daily appointments
// •	Manage medical history
public class Patient
{
    public int PatientId{get; set;}
    public string? Name{get; set;}
    public int Age{get; set;}
    public string? BloodGroup{get; set;}
    public List<string> MedicalHistory{get; set;}

    public Patient()
    {
        MedicalHistory = new List<string>();
    }
}
public class Doctor
{
    public int DoctorId{get; set;}
    public string? Name{get; set;}
    public string? Specialization{get; set;}
    public List<DateTime> AvailableSlots{get; set;}

    public Doctor()
    {
        AvailableSlots = new List<DateTime>();
    }
}
public class Appointment
{
    public int AppointmentId{get; set;}
    public int PatientId{get; set;}
    public int DoctorId{get; set;}
    public DateTime AppointmentTime{get; set;}
    public string? Status{get; set;}
    public Appointment(){}
}
public class HospitalManager
{
    public static Dictionary<int, Patient> patientDetails = new Dictionary<int, Patient>();
    public static Dictionary<int, Doctor> doctorDetails = new Dictionary<int, Doctor>();
    public static List<Appointment> appointments = new List<Appointment>();
    public static int PatientCounter = 1;
    public static int DoctorCounter = 1;
    public static int AppointmentCounter = 1;
    public void AddPatient(string name, int age, string bloodGroup)
    {
        Patient patient = new Patient()
        {
            PatientId = PatientCounter,
            Name = name,
            Age = age,
            BloodGroup = bloodGroup
        };
        patientDetails.Add(PatientCounter,patient);
        PatientCounter++;
    }
    public void AddDoctor(string name, string specialization)
    {
        Doctor doctor = new Doctor()
        {
            DoctorId = DoctorCounter,
            Name = name,
            Specialization = specialization,
        };
        doctorDetails.Add(DoctorCounter, doctor);
        DoctorCounter++;
    }
    public bool ScheduleAppointment(int patientId, int doctorId, DateTime time)
    {
        if (!patientDetails.ContainsKey(patientId))
        {
            Console.WriteLine("Patient Is Not Present");
            return false;
        }
        if (!doctorDetails.ContainsKey(doctorId))
        {
            Console.WriteLine("Docter is Not Present");
            return false;
        }
        var patient = patientDetails[patientId];
        var doctor = doctorDetails[doctorId];
        if (doctor.AvailableSlots.Contains(time))
        {
            Console.WriteLine("Docter is Busy");
            return false;
        }
        doctor.AvailableSlots.Add(time);
        Appointment appoin = new Appointment()
        {
            AppointmentId = AppointmentCounter,
            PatientId = patient.PatientId,
            DoctorId = doctor.DoctorId,
            AppointmentTime = time,
            Status = "Scheduled"
        };
        appointments.Add(appoin);
        patient.MedicalHistory.Add($"Visited {doctor.Name} ({doctor.Specialization}) on {time}");
        AppointmentCounter++;
        return true;
    }
    public Dictionary<string, List<Doctor>> GroupDoctorsBySpecialization()
    {
        Dictionary<string, List<Doctor>> result = new Dictionary<string, List<Doctor>>();
        foreach(var item in doctorDetails)
        {
            var doc = item.Value;
            if (!result.ContainsKey(doc.Specialization))
            {
                result[doc.Specialization] = new List<Doctor>();
            }
            result[doc.Specialization].Add(doc);
        }
        return result;
    }
    public List<Appointment> GetTodayAppointments()
    {
        List<Appointment> result = new List<Appointment>();
        DateTime today = DateTime.Now;
        foreach(var i in appointments)
        {
            if(i.AppointmentTime == today)
            {
                result.Add(i);
            }
        }
        return result;
    }
}