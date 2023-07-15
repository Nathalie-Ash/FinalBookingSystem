using IDS.Core.Interfaces;
using IDS.Core.Models;
using IDS.Core.Repositories;
using IDS.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDS.Services
{
    public class RoomService : IRoomService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRoomRepository _roomRepository;
        public RoomService(IUnitOfWork unitOfWork, IRoomRepository roomRepository)
        {
            this._unitOfWork = unitOfWork;
            this._roomRepository = roomRepository;
        }

        public async Task<Room> CreateArtist(Room newRoom)
        {
            await _unitOfWork.Rooms
                .AddAsync(newRoom);

            return newRoom;
        }

        public async Task<Room> CreateRoom(Room newRoom)
        {
            await _unitOfWork.Rooms.AddAsync(newRoom);
            await _unitOfWork.CommitAsync();
            return newRoom;
        }


        public async Task UpdateRoom(Room room)
        {
           await _roomRepository.UpdateRoom(room);
        }

        public async Task DeleteArtist(Room room)
        {
            _unitOfWork.Rooms.Delete(room);

            await _unitOfWork.CommitAsync();
        }

        public Task DeleteRoom(Room user)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Room>> GetAllRooms()
        {
            return await _unitOfWork.Rooms.GetAllAsync();
        }

        public Task<IEnumerable<Room>> GetAllWithRoom()
        {
            throw new NotImplementedException();
        }

        public async Task<Room> GetRoomById(int id)
        {
            return await _unitOfWork.Rooms.GetByIdAsync(id);
        }

        public Task<IEnumerable<Room>> GetRoomsByRoomId(int id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateRoom(Room roomToBeUpdated, Room room)
        {
            roomToBeUpdated.Name = room.Name;

            await _unitOfWork.CommitAsync();
        }

    }
}