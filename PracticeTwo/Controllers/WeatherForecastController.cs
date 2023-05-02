using Microsoft.AspNetCore.Mvc;

namespace UPB.PracticeTwo.Controllers;

[ApiController]
[Route("[controller]")]
public class PatientController : ControllerBase
{
    public PatientController()
    {
    }

    public IEnumerable<Patient> Get()
    {
        return new List<Patient>();
    }
}
