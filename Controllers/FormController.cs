using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Model.Dto;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SparkPlug.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FormController : ControllerBase
    {
        private readonly IFormService _formService;

        public FormController(IFormService formService) //injecting Formservice
        {
            _formService = formService;
        }
        [HttpPost("add-form/{clientName}")]
        public async Task<IActionResult> AddForm([FromForm]FormToAddDto model, [FromRoute]string clientName)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var result = await _formService.AddForm(model, clientName);
            if (result == null)
            {
                ModelState.AddModelError("Add Form", "Unable to create customer form");
                return BadRequest(new ResponseDto { success = result.Item1, message = result.Item2});
            }
            return Ok(new ResponseDto { success = result.Item1, message = result.Item2});
        }
    }
}
