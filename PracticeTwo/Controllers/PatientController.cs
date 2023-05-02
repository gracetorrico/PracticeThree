using Microsoft.AspNetCore.Mvc;
using UPB.PracticeTwo.Managers;

namespace UPB.PracticeTwo.Controllers;


[ApiController] // Atributes
[Route("students")]
public class PatientController : ControllerBase
{
    private readonly PatientManager _patientManager;
    public PatientController(PatientManager patientManager)
    {
        _patientManager = patientManager; 
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
    public Patient Post([FromBody] Patient patientToCreate)
    {
        return _patientManager.Create(patientToCreate.Name, patientToCreate.LastName,patientToCreate.CI);
    }

    [HttpDelete]
    [Route("{id}")]
    public Patient Delete([FromRoute] int id)
    {
        return _patientManager.Delete(id);
    }
}
