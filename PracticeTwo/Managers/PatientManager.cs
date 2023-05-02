using UPB.PracticeTwo;
namespace UPB.PracticeTwo.Managers;

public class PatientManager
{
    private List<Patient> _patients;
    private List<String> BloodType = new List<string> {"A", "B", "AB", "O"};
    public PatientManager()
    {
        _patients = new List<Patient>();
    }
    public List<Patient> GetAll()
    {
        return _patients;
    }

    public Patient GetById(int id)
    {
        return _patients.Find(patient => patient.CI == id);
    }
//Completar update
    public Patient Update(int id, Patient patient)
    {
        if (id<0)
        {
            throw new Exception("CI inválido");
        }
        Patient patientFound = _patients.Find(patient => patient.CI == id);
        if (patientFound==null)
        {
            throw new Exception("Patient not found");
        }
        patientFound.Name=patient.Name;
        patientFound.LastName=patient.LastName;
        return patientFound;
    }

    public Patient Create(string name, string lastname, int ci)
    {
        Patient createdPatient = new Patient()
        {
            Name=name, 
            LastName=lastname, 
            CI = ci, 
            BGroup= getRandBloodType()
        };
        _patients.Add(createdPatient);
        return createdPatient;
    }

    public Patient Delete(int id)
    {
        int patientDeletedIndex = _patients.FindIndex(patient => patient.CI == id);
        Patient patientDeleted = _patients[patientDeletedIndex];
        _patients.RemoveAt(patientDeletedIndex);
        return patientDeleted;
    }

    public String getRandBloodType()
    {
        Random rnd = new Random();
        return BloodType[rnd.Next(BloodType.Count)];
    }
}