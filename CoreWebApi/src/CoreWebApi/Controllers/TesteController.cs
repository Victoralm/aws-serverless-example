using CoreWebApi.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoreWebApi.Controllers;

[Route("[controller]")] //https://localhost:58241/teste
[ApiController]
public class TesteController : ControllerBase
{
    private readonly IDol2RealRepository _dol2RealRepository;

    public TesteController(IDol2RealRepository dol2RealRepository)
    {
        _dol2RealRepository = dol2RealRepository;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var data = _dol2RealRepository.GetDol2Real();

        if (data == null)
            return BadRequest();

        return Ok(data);
    }
}
