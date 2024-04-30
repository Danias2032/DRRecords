using Microsoft.AspNetCore.Mvc;
using DRrecords.Repositories;
using DRrecords.Models;

namespace DRrecords.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecordController : ControllerBase
    {
        private readonly RecordsRepository _recordsRepository = new();

        // GET: api/<RecordController>
        [HttpGet]
        public IEnumerable<Record> Get()
        {
            return _recordsRepository.GetAll();
        }

        // GET api/<RecordController>/5
        [HttpGet("{id}")]
        public Record GetBy(int id)
        {
            return _recordsRepository.GetById(id);
        }

        // POST api/<RecordController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Record> Post([FromBody] Record record)
        {
            try
            {
                Record createdRecord = _recordsRepository.AddRecord(record);
                return Created("/" + createdRecord.Id, createdRecord);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            } 
        }

        // PUT api/<RecordController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<RecordController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Record> Delete(int id)
        {
            Record deletedRecord = _recordsRepository.DeleteRecord(id);
            if (deletedRecord == null)
            {
                return NotFound();
            }
            return Ok(deletedRecord);
        }
    }
}
