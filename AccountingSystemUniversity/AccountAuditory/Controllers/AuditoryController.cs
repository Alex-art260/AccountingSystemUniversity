using AccountAuditory.Interfaces;
using AccountAuditory.Models.Dto;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace AccountAuditory.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuditoryController : ControllerBase
    {
        private readonly IAuditoryService _auditoryService;

        public AuditoryController(IAuditoryService auditoryService)
        {
            _auditoryService = auditoryService;
        }

        /// <summary>
        /// Добавление аудитории
        /// </summary>
        /// <param name="data">заполненная модель данных</param>
        /// <returns></returns>
        [HttpPost("Add")]
        public async Task<ActionResult<AuditoryDto>> Add(AuditoryDto data)
        {
            var result = await _auditoryService.Create(data);
            return Ok(result);

        }

        /// <summary>
        /// Возвращает список корпусов/зданий
        /// </summary>
        /// <param name="data">заполненная модель данных</param>
        /// <returns></returns>
        [HttpGet("GetAll")]
        public async Task<ActionResult> GetAuditoriums()
        {
            var result = await _auditoryService.GetAuditoriums();

            return Ok(result);
        }

        [HttpGet("GetBuildings")]
        public async Task<ActionResult> GetBuildings()
        {
            var result = await _auditoryService.GetBuildings();

            return Ok(result);
        }


        [HttpGet("GetTypeRooms")]
        public async Task<ActionResult> GetTypeRooms()
        {
            var result = await _auditoryService.GetTypeRooms();

            return Ok(result);
        }

        /// <summary>
        /// Удаление аудитории
        /// </summary>
        /// <param name="id">id группы</param>/// 
        /// <param name="data">заполненная модель данных</param>
        /// <returns></returns>
        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _auditoryService.Delete(id);
            return Ok(result);
        }

        /// <summary>
        /// Удаление корпуса/здания
        /// </summary>
        /// <param name="id">id группы</param>/// 
        /// <param name="data">заполненная модель данных</param>
        /// <returns></returns>
        [HttpPut("Update/{id}")]
        public async Task<ActionResult> Update(AuditoryDto dto)
        {
            var result = await _auditoryService.UpdateAuditoriums(dto);
            return Ok(result);
        }
    }
}
