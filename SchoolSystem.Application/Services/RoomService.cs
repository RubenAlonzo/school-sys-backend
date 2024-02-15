namespace SchoolSystem.Application.Services
{
    using FluentValidation;
    using SchoolSystem.Application.Services.Contracts;
    using SchoolSystem.Domain.Entities;
    using SchoolSystem.Persistence.Options;
    using SchoolSystem.Persistence.Repositories.Contracts;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class RoomService : IRoomService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly  IValidator<RoomEntity> _roomValidator;
        private readonly  IValidator<GetAllRoomsOption> _optionsValidator;

        public RoomService(IUnitOfWork unitOfWork, IValidator<RoomEntity> validator, IValidator<GetAllRoomsOption> optionsValidator)
        {
            _unitOfWork = unitOfWork;
            _roomValidator = validator;
            _optionsValidator = optionsValidator;
        }

        public async Task CreateAsync(RoomEntity room, CancellationToken cancellationToken = default)
        {
            _roomValidator.ValidateAndThrow(room);
            _unitOfWork.Rooms.Add(room);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }

        public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            var room = _unitOfWork.Rooms.FirstOrDefault(x => x.Id == id);
            if (room == null) return false;
            _unitOfWork.Rooms.Remove(room);

            return (await _unitOfWork.SaveChangesAsync(cancellationToken)) > 0;
        }

        public RoomEntity? GetById(int id)
        {
            return _unitOfWork.Rooms.FirstOrDefault(x => x.Id == id);
        }

        public RoomEntity? GetByName(string name)
        {
            return _unitOfWork.Rooms.FirstOrDefault(x => x.Name == name);
        }

        public IEnumerable<RoomEntity> GetAll(GetAllRoomsOption options)
        {
            _optionsValidator.ValidateAndThrow(options);
            return _unitOfWork.Rooms.GetAll(options);
        }

        public async Task<RoomEntity?> UpdateAsync(RoomEntity room, CancellationToken cancellationToken = default)
        {
            _roomValidator.ValidateAndThrow(room);
            var currentRoom = _unitOfWork.Rooms.FirstOrDefault(x => x.Id == room.Id);
            if (currentRoom is null) return null;
            _unitOfWork.Rooms.Remove(currentRoom);
            _unitOfWork.Rooms.Add(room);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return room;
        }

        public int Count(GetAllRoomsOption options)
        {
            _optionsValidator.ValidateAndThrow(options);
            return _unitOfWork.Rooms.Count(options);
        }
    }
}
