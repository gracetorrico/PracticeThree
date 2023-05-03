using Microsoft.AspNetCore.Mvc;
using UPB.CoreLogic.Managers;
using UPB.CoreLogic.Models;

namespace UPB.PracticeTwo.Controllers;


[ApiController] // Atributes
[Route("students")]
public class PatientController : ControllerBase
{
    private readonly PatientManager _patientManager;
    public PatientController(PatientManager patientManager)
    {
        _patientManager = patientManager; 
        _patientManager.Init();
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
    public Patient Put([FromRoute] int id, [FromBody] Patient patientToUpdate)
    {
        return _patientManager.Update(id, patientToUpdate);
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
