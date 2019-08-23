using System;
using Hiring.Domain.Entities;
using Hiring.Service.Services;
using Hiring.Service.Validator;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hiring.Application.Controllers
{
    [Produces("application/json")]
    [Route("api/")]
    public class UserController : Controller
    {
        private VagaService service = new VagaService();

        [HttpPost]
        [AllowAnonymous]
        [Route("vaga")]
        public IActionResult Post([FromBody] Vaga item)
        {
            try
            {
                service.Post<VagaValidator>(item);

                return new ObjectResult(item.Id);
            }
            catch(ArgumentNullException ex)
            {
                return NotFound(ex);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut]
        [AllowAnonymous]
        [Route("vaga")]
        public IActionResult Put([FromBody] Vaga item)
        {
            try
            {
                service.Put<VagaValidator>(item);

                return new ObjectResult(item);
            }
            catch(ArgumentNullException ex)
            {
                return NotFound(ex);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete]
        [AllowAnonymous]
        [Route("vaga")]
        public IActionResult Delete(int id)
        {
            try
            {
                service.Delete(id);

                return new NoContentResult();
            }
            catch(ArgumentException ex)
            {
                return NotFound(ex);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("vaga")]
        public IActionResult Get()
        {
            try
            {
                return new ObjectResult(service.Get());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("vaga/{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                return new ObjectResult(service.Get(id));
            }
            catch(ArgumentException ex)
            {
                return NotFound(ex);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}