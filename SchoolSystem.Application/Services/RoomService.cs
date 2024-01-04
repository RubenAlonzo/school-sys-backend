﻿namespace SchoolSystem.Application.Services
{
    using SchoolSystem.Application.Services.Contracts;
    using SchoolSystem.Domain.Entities;
    using SchoolSystem.Persistence.Repositories.Contracts;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class RoomService : IRoomService
    {
        private readonly IUnitOfWork _unitOfWork;

        public RoomService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task CreateAsync(RoomEntity room)
        {
            _unitOfWork.Rooms.Add(room);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var room = _unitOfWork.Rooms.FirstOrDefault(x => x.Id == id);
            if (room == null) return false;
            _unitOfWork.Rooms.Remove(room);

            return (await _unitOfWork.SaveChangesAsync()) > 0;
        }

        public RoomEntity? GetById(int id)
        {
            return _unitOfWork.Rooms.FirstOrDefault(x => x.Id == id);
        }

        public RoomEntity? GetByName(string name)
        {
            return _unitOfWork.Rooms.FirstOrDefault(x => x.Name == name);
        }

        public IEnumerable<RoomEntity> GetAll()
        {
            return _unitOfWork.Rooms.GetAll();
        }

        public async Task<RoomEntity?> UpdateAsync(RoomEntity room)
        {
            var currentRoom = _unitOfWork.Rooms.FirstOrDefault(x => x.Id == room.Id);
            if (currentRoom is null) return null;
            _unitOfWork.Rooms.Remove(currentRoom);
            _unitOfWork.Rooms.Add(room);
            await _unitOfWork.SaveChangesAsync();
            return room;
        }
    }
}
