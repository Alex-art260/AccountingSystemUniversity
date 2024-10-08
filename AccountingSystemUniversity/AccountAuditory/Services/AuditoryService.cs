using AccountAuditory.Data;
using AccountAuditory.Interfaces;
using AccountAuditory.Models;
using AccountAuditory.Models.Dto;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace AccountAuditory.Services
{
    public class AuditoryService : IAuditoryService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public AuditoryService(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<int> Create(AuditoryDto dto)
        {
            var item = _mapper.Map<Auditory>(dto);

            _dbContext.Auditoriums.Add(item);

            await _dbContext.SaveChangesAsync();

            return item.Id;
        }

        public async Task<int> Delete(int id)
        {
            var item = await _dbContext.Auditoriums.FindAsync(id);

            if (item == null)
                throw new Exception($"Запись не найдена.");

            _dbContext.Auditoriums.Remove(item);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<List<AuditoryDto>> GetAuditoriums()
        {
            var auditoriums = await _dbContext.Auditoriums
                .Include(a => a.Buildings)
                .Include(a => a.TypeRoom)
                .ToListAsync();

            if (auditoriums != null && auditoriums.Count > 0)
            {
                var auditoriumDtos = auditoriums.Select(a => new AuditoryDto
                {
                    Id = a.Id,
                    Name = a.Name,
                    Capacity = a.Capacity,
                    Floor = a.Floor,
                    Number = a.Number,
                    BuildingId = a.BuildingId,
                    BuildingName = a.Buildings?.Name, // Получение имени из Buildings
                    TypeRoomId = a.TypeRoomId,
                    TypeRoomName = a.TypeRoom?.Name // Получение имени из TypeRoom
                }).ToList();

                return auditoriumDtos;
            }
            return null;
        }

        public async Task<int> UpdateAuditoriums(AuditoryDto dto)
        {
            var item = await _dbContext.Auditoriums.FindAsync(dto.Id);

            if (item == null)
                throw new Exception($"Запись не найдена.");

            _mapper.Map(dto, item);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<List<BuildingDto>> GetBuildings()
        {
            var items = await _dbContext.Buildings.ToListAsync();

            if (items != null || items.Count() != 0)
            {
                var mappedItems = _mapper.Map<List<BuildingDto>>(items);
                Console.WriteLine("GetBuildings: Преобразование выполнено. Количество зданий: " + mappedItems.Count);

                return mappedItems;
            }
            return null;
        }

        public async Task<List<TypeRoomDto>> GetTypeRooms()
        {
            var items = await _dbContext.TypeRooms.ToListAsync();

            if (items != null || items.Count() != 0)
            {
                var mappedItems = _mapper.Map<List<TypeRoomDto>>(items);

                return mappedItems;
            }
            return null;
        }

        public async Task<int> Create(BuildingDto dto)
        {
            var item = _mapper.Map<Buildings>(dto);

            _dbContext.Buildings.Add(item);

            await _dbContext.SaveChangesAsync();

            return item.Id;
        }

        public async Task<int> UpdateBuilding(BuildingDto dto)
        {
            var item = await _dbContext.Buildings.FindAsync(dto.Id);

            if (item == null)
                throw new Exception($"Запись не найдена.");

            _mapper.Map(dto, item);

            return await _dbContext.SaveChangesAsync();
        }

        public async Task<int> DeleteBuilding(int id)
        {
            var item = await _dbContext.Buildings.FindAsync(id);

            if (item == null)
                throw new Exception($"Запись не найдена.");

            _dbContext.Buildings.Remove(item);

            return await _dbContext.SaveChangesAsync();
        }
    }
}
