using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDS.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ICompanyRepository Companies { get; }
        IReservationRepository Reservations { get; }
        IRoleRepository Roles { get; }
        IRoomRepository Rooms { get; }
        IUserRepository Users { get; }


        Task<int> CommitAsync();
    }
}
