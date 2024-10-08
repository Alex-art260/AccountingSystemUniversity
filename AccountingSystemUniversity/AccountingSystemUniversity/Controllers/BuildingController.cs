using AccountingSystemUniversity.Interfaces;
using AccountingSystemUniversity.Models.Dto;
using Microsoft.AspNetCore.Mvc;

namespace AccountingSystemUniversity.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class BuildingController : ControllerBase
    {
        private readonly IBuildingService _buildingService;
        private readonly ILogger<BuildingController> _logger;

        public BuildingController(ILogger<BuildingController> logger, IBuildingService buildingService)
        {
            _logger = logger;
            _buildingService = buildingService;
        }

        /// <summary>
        /// Добавление корпуса/здания
        /// </summary>
        /// <param name="data">заполненная модель данных</param>
        /// <returns></returns>
        [HttpPost("Add")]
        public async Task<ActionResult<BuildingDto>> Add(BuildingDto data)
        {
            try
            {
                _logger.LogInformation("Запрос на добавление здания: {@data}", data); // Логирование информации
                Console.WriteLine("Controller Detected");
                var result = await _buildingService.Create(data);
                return Ok(result);
            }
            catch (Exception ex)
            {
            }
           return Ok();
        }

        /// <summary>
        /// Возвращает список корпусов/зданий
        /// </summary>
        /// <param name="data">заполненная модель данных</param>
        /// <returns></returns>
        [HttpGet("GetBuildings")]
        public async Task<ActionResult> GetBuildings()
        {
            var result = await _buildingService.GetBuildings();
            return Ok(result);
        }

        /// <summary>
        /// Удаление корпуса/здания
        /// </summary>
        /// <param name="id">id группы</param>/// 
        /// <param name="data">заполненная модель данных</param>
        /// <returns></returns>
        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _buildingService.Delete(id); 
            return Ok(result);
        }

        /// <summary>
        /// Удаление корпуса/здания
        /// </summary>
        /// <param name="id">id группы</param>/// 
        /// <param name="data">заполненная модель данных</param>
        /// <returns></returns>
        [HttpPut("Update/{id}")]
        public async Task<ActionResult> Update(BuildingDto dto)
        {
            var result = await _buildingService.UpdateBuilding(dto);
            return Ok(result);
        }
    }
}
