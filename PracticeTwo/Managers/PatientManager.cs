using UPB.PracticeTwo;
namespace UPB.PracticeTwo.Managers;

public class PatientManager
{
    private List<Patient> _patients;
    public PatientManager()
    {
        _patients = new List<Patient>();
    }
    public List<Patient> GetAll()
    {
        return new List<Patient>();
    }

    public Patient GetById(int id)
    {
        return _patients.Find(patient => patient.CI == id);
    }
//Completar update
    public Patient Update(int id)
    {
        Patient patientFound = _patients.Find(patient => patient.CI == id);
        patientFound.Name="Name changed";
        return patientFound;
    }

    public Patient Create(string name, string lastname, int ci)
    {
        Patient createdPatient = new Patient()
        {
            Name=name, 
            LastName=lastname, 
            CI = ci, 
            BGroup="A+"
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
}