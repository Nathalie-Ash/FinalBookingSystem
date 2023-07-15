using IDS.Core.Interfaces;
using IDS.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDS.Core.Repositories
{
    public class RoomRepository : Repository<Room>, IRoomRepository
    {
        public RoomRepository(IdsbookingSystemContext room)
            : base(room)
        { }
        public async Task<Room> GetRoomById(int id)
        {
            return await MyDbContext.Rooms.FindAsync(id);
        }
        public async Task<IEnumerable<Room>> GetAllWithRoomAsync()
        {
            return await MyDbContext.Rooms

                .ToListAsync();
        }

        public Task<Room> GetWithRoomsByIdAsync(int id)
        {
            return MyDbContext.Rooms
                .SingleOrDefaultAsync(a => a.Id == id);
        }

        public Task<IEnumerable<Room>> GetAllWithRoomsByRoomIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Role> GetWithRoomByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Room> CreateRoom(Room newRoom)
        {
            await MyDbContext.Rooms.AddAsync(newRoom);
            await MyDbContext.SaveChangesAsync();
            return newRoom;
        }



        public Task DeleteRoom(Room room)
        {
            throw new NotImplementedException();
        }

        public Task Insert(Room room)
        {
            throw new NotImplementedException();
        }

        Task<Room> IRoomRepository.GetWithRoomByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateRoom(Room room)
        {
            MyDbContext.Rooms.Update(room);
            await MyDbContext.SaveChangesAsync();
        }


        private IdsbookingSystemContext MyDbContext
        {
            get { return Context as IdsbookingSystemContext; }
        }
    }
}
