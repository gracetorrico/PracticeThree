using UPB.CoreLogic.Models;
namespace UPB.CoreLogic.Managers;

public class PatientManager
{
    private List<Patient> _patients;
    private List<String> BloodType = new List<string> {"A", "B", "AB", "O"};
    private static string path = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).FullName, "test.txt");

    
    public PatientManager()
    {
        _patients = new List<Patient>();
    }

    public List<Patient> Init()
    {
        StreamReader reader = new StreamReader(path);
        while (!reader.EndOfStream)
        {
            String line = reader.ReadLine();
            Patient createdPatient = new Patient()
            {
                Name=line.Split(",")[0], 
                LastName=line.Split(",")[1], 
                CI = int.Parse(line.Split(",")[2]), 
                BGroup= line.Split(",")[3]
            };
            _patients.Add(createdPatient);
        }
        reader.Close();
        return _patients;
    }
    public List<Patient> GetAll()
    {
        return _patients;
    }

    public Patient GetById(int id)
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
        return patientFound;
    }

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
        UpdateFile();
        return patientFound;
    }

    public Patient Create(string name, string lastname, int ci)
    {
        string BloodType = getRandBloodType();
        Patient createdPatient = new Patient()
        {
            Name=name, 
            LastName=lastname, 
            CI = ci, 
            BGroup= BloodType
        };

        StreamWriter writer = new StreamWriter(path, true);
        writer.WriteLine(name +","+ lastname +","+ ci +","+ BloodType);
        _patients.Add(createdPatient);
        writer.Close();
        return createdPatient;
    }

    public Patient Delete(int id)
    {
        int patientDeletedIndex = _patients.FindIndex(patient => patient.CI == id);
        if (patientDeletedIndex==-1)
        {
            throw new Exception("CI inválido");
        }
        Patient patientDeleted = _patients[patientDeletedIndex];
        _patients.RemoveAt(patientDeletedIndex);
        UpdateFile();
        return patientDeleted;
    }

    public String getRandBloodType()
    {
        Random rnd = new Random();
        return BloodType[rnd.Next(BloodType.Count)];
    }

    public void UpdateFile()
    {
        StreamWriter writer = new StreamWriter(path);
        foreach(Patient patient in _patients)
        {
            writer.WriteLine(patient.Name +","+ patient.LastName +","+ patient.CI +","+ patient.BGroup);
        }
        writer.Close();
    }
}