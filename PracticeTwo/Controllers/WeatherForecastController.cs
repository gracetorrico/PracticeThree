using Microsoft.AspNetCore.Mvc;
using UPB.PracticeTwo.Managers;

namespace UPB.PracticeTwo.Controllers;


[ApiController] // Atributes
[Route("students")]
public class PatientController : ControllerBase
{
    private PatientManager _patientManager;
    public PatientController()
    {
        _patientManager = new PatientManager(); 
    }

    [HttpGet]
    public List<Patient> Get()
    {
        return _patientManager.GetAll();
    }

    [HttpGet]
    [Route("{id}")]
    public Patient GetById([FromRoute] int id)
    {
        return _patientManager.GetById(id);
    }

    [HttpPut]
    [Route("{id}")]
    public Patient Put([FromRoute] int id)
    {
        return _patientManager.Update(id);
    }

    [HttpPost]
    public Patient Post()
    {
        return _patientManager.Create();
    }

    [HttpDelete]
    public Patient Delete()
    {
        return _patientManager.Delete();
    }
}
