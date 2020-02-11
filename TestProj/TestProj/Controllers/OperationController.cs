using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TestProj.BLL.Interfaces;
using TestProj.BLL.Models;

namespace TestProj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OperationController : ControllerBase
    {
        private readonly IOperationService operationService;

        public OperationController(IOperationService operationService)
        {
            this.operationService = operationService;
        }
        [HttpGet]
        [Route("{id}")]
        //GET: api/Operation/id
        public IEnumerable<OperationDTO> GetOperations(int id)
        {
            return operationService.GetAllOperations(id);
        }
        [HttpPost]
        //POST: api/Operation
        public IActionResult AddNewOperation(OperationDTO model)
        {
            try
            {
                var action = operationService.AddOperation(model);
                return Ok(action);
            }
            catch (ArgumentOutOfRangeException)
            {
                return BadRequest("Amount of products must be:\n - less than or equal to 1.000;\n - greater than 0.");
            }
            catch (ArgumentException)
            {
                return BadRequest("Amount of product in stock is not enough.");
            }
            catch
            {
                return BadRequest("This operation cannot be executed.");
            }
        }
    }
}