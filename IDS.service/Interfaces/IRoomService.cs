using IDS.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDS.Services.Interfaces
{
    public interface IRoomService
    {
        Task<IEnumerable<Room>> GetAllRooms
            ();
        Task<Room> GetRoomById(int id);
        Task<IEnumerable<Room>> GetRoomsByRoomId(int id);
        Task<Room> CreateRoom(Room newRoom);
        Task UpdateRoom(Room existingRoom);
        Task DeleteRoom(Room user);
        Task<IEnumerable<Room>> GetAllWithRoom();
    }
}
