using AccountingSystemUniversity.Data;
using AccountingSystemUniversity.Interfaces;
using AccountingSystemUniversity.Models;
using AccountingSystemUniversity.Models.Dto;
using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;

namespace AccountingSystemUniversity.Services
{
    public class BuildingService : IBuildingService
    {
        private readonly IRabbitMqService _rabbitMqService;
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public BuildingService(ApplicationDbContext dbContext, IMapper mapper, IRabbitMqService rabbitMqService)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _rabbitMqService = rabbitMqService;
        }

        public async Task<int> Create(BuildingDto dto)
        {
            var item = _mapper.Map<Building>(dto);

            _dbContext.Buildings.Add(item);

            await _dbContext.SaveChangesAsync();

            var message = new
            {
                BuildingId = item.Id,
                BuildingName = item.Name,
                Action = "Create"
            };

            _rabbitMqService.PublishMessage(JsonConvert.SerializeObject(message), "auditoriesBuilding_queue");


            return item.Id;
        }

        public async Task<List<BuildingDto>> GetBuildings()
        {
            var items = await _dbContext.Buildings.ToListAsync();

            if (items != null || items.Count() != 0)
            {
                var mappedItems = _mapper.Map<List<BuildingDto>>(items);

                return mappedItems;
            }
            return null;
        }

        public async Task<int> Delete(int id)
        {
            var item = await _dbContext.Buildings.FindAsync(id);

            if (item == null)
                throw new Exception($"Запись не найдена.");

            _dbContext.Buildings.Remove(item);

            var message = new
            {
                BuildingId = id,
                Action = "Delete"
            };

            _rabbitMqService.PublishMessage(JsonConvert.SerializeObject(message), "auditoriesBuilding_queue");

            return await _dbContext.SaveChangesAsync();
        }

        public async Task<int> UpdateBuilding(BuildingDto dto)
        {

            var item = await _dbContext.Buildings.FindAsync(dto.Id);

            if (item == null)
                throw new Exception($"Запись не найдена.");

            _mapper.Map(dto, item);

            var message = new
            {
                BuildingId = item.Id,
                BuildingName = item.Name,
                Action = "Update"
            };
            _rabbitMqService.PublishMessage(JsonConvert.SerializeObject(message), "auditoriesBuilding_queue");

            return await _dbContext.SaveChangesAsync();
        }
    }

}
