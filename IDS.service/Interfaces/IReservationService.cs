using IDS.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDS.Services.Interfaces
{
    public interface IReservationService
    {
        Task<IEnumerable<Reservation>> GetAllReservations
            ();
        Task<Reservation> GetReservationById(int id);
        Task<IEnumerable<Reservation>> GetReservationsByReservationId(int id);
        Task<Reservation> CreateReservation(Reservation newReservation);
        
        Task DeleteReservation(Reservation reservation);
    
        Task UpdateReservation(Reservation existingReservation);
        Task<IEnumerable<Reservation>> GetAllWithReservation();
    }
}
