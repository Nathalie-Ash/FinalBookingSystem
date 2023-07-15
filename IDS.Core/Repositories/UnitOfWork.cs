using IDS.Core.Interfaces;
using IDS.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDS.Core.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IdsbookingSystemContext _context;
        private CompanyRepository _companyRepository;
        private ReservationRepository _reservationRepository;
        private RoomRepository _roomRepository;
        private UserRepository _userRepository;
        private RoleRepository _roleRepository;
     
        public UnitOfWork(IdsbookingSystemContext context)
        {
            this._context = context;
        }

       public ICompanyRepository Companies => _companyRepository = _companyRepository ?? new CompanyRepository(_context);
        public IReservationRepository Reservations => _reservationRepository = _reservationRepository ?? new ReservationRepository(_context);
        public IUserRepository Users => _userRepository = _userRepository ?? new UserRepository(_context);
        public IRoomRepository Rooms => _roomRepository = _roomRepository ?? new RoomRepository(_context);
        public IRoleRepository Roles => _roleRepository = _roleRepository ?? new RoleRepository(_context);


    

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}