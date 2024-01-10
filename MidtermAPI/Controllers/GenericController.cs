using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MidtermAPI.Context;
using MidtermAPI.DataAccess;
using MidtermAPI.Entities;

namespace MidtermAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenericController<T> : ControllerBase where T : class
	{
        protected GenericRepository<T> repository;

        [HttpGet("GetByID/{id}")]
        public ActionResult GetByID(int id)
        {
            return Ok(repository.GetById(id));
        }

        [HttpGet("GetAll/{id}")]
        public ActionResult GetAll(int id)
        {
            return Ok(repository.GetAll(id));
        }

        [HttpPost("Add")]
        public ActionResult Add([FromBody] T t)
        {
            repository.Add(t);

            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Remove(T t)
        {
            repository.Remove(t);

            return Ok();
        }

        [HttpPut]
        public ActionResult Update(T t)
        {
            repository.Update(t);

            return Ok();
        }
    }
}

