using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TestProj.BLL.Interfaces;
using TestProj.BLL.Models;

namespace TestProj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperationController : ControllerBase
    {
        private readonly IOperationService operationService;

        public OperationController(IOperationService operationService)
        {
            this.operationService = operationService;
        }
        [HttpGet]
        //GET: api/Operation
        public IEnumerable<OperationDTO> GetOperations()
        {
            return operationService.GetAllOperations();
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
            catch
            {
                return BadRequest("This operation cannot be executed.");
            }
        }
    }
}