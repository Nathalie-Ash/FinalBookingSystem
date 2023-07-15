using IDS.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDS.Core.Interfaces
{
    public interface IReservationRepository : IRepository<Reservation>
    {

        Task<IEnumerable<Reservation>> GetAllWithReservationsAsync();
        Task<Reservation> GetReservationById(int id);
        Task<Reservation> GetWithReservationsByIdAsync(int id);
        Task<IEnumerable<Reservation>> GetAllWithReservationsByCompanyIdAsync(int id);
        Task<Reservation> CreateReservation(Reservation newReservation);
        Task UpdateReservation (Reservation newReservation);

        Task DeleteReservation(Reservation reservation);
        Task Insert(Reservation newReservation);
      
    }
}
