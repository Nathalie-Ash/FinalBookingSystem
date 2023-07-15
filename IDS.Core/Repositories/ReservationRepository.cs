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
    public class ReservationRepository : Repository<Reservation>, IReservationRepository
    {
        public ReservationRepository(IdsbookingSystemContext context)
            : base(context)
        { }

        public async Task<IEnumerable<Reservation>> GetAllWithReservationsAsync()
        {
            return await MyDbContext.Reservations

                .ToListAsync();
        }

        public async Task<Reservation> GetReservationById(int id)
        {
            return await MyDbContext.Reservations.FindAsync(id);
        }
        public Task<Reservation> GetWithReservationsByIdAsync(int id)
        {
            return MyDbContext.Reservations
                .SingleOrDefaultAsync(a => a.Id == id);
        }

        public Task<IEnumerable<Company>> GetAllWithCompaniesByCompanyIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Reservation>> GetAllWithReservationsByCompanyIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Reservation> CreateCompany(Reservation newReservation)
        {
            await MyDbContext.Reservations.AddAsync(newReservation);
            await MyDbContext.SaveChangesAsync();
            return newReservation;
        }


        public async Task UpdateReservation(Reservation reservation)
        {
            MyDbContext.Reservations.Update(reservation);
            await MyDbContext.SaveChangesAsync();
        }

        public Task DeleteReservation(Reservation reservation)
        {
            throw new NotImplementedException();
        }

        public Task Insert(Reservation newReservation)
        {
            throw new NotImplementedException();
        }

        public Task<Reservation> GetCompanyById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Reservation> CreateReservation(Reservation newReservation)
        {
            throw new NotImplementedException();
        }

    

        private IdsbookingSystemContext MyDbContext
        {
            get { return Context as IdsbookingSystemContext; }
        }
    }
}
