using IDS.Core.Interfaces;
using IDS.Core.Models;
using IDS.Core.Repositories;
using IDS.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IDS.Services
{
    public class ReservationService : IReservationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IReservationRepository _reservationRepository;

        public ReservationService(IUnitOfWork unitOfWork, IReservationRepository reservationRepository)
        {
            this._unitOfWork = unitOfWork;
            this._reservationRepository = reservationRepository;
        }

        public async Task<Reservation> CreateReservation(Reservation newReservation)
        {
            await _unitOfWork.Reservations.AddAsync(newReservation);
            await _unitOfWork.CommitAsync();
            return newReservation;
        }

        public async Task UpdateReservation(Reservation reservation)
        {
            await _reservationRepository.UpdateReservation(reservation);
        }

        public async Task DeleteReservation(Reservation reservation)
        {
            _unitOfWork.Reservations.Delete(reservation);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Reservation>> GetAllReservations()
        {
            return await _unitOfWork.Reservations.GetAllWithReservationsAsync();
        }

        public Task<IEnumerable<Reservation>> GetReservationsByReservationId(int id)
        {
            throw new NotImplementedException();
        }
        
        public async Task<Reservation> GetReservationById(int id)
        {
            return await _reservationRepository.GetReservationById(id);
        }

        public Task UpdateReservation(Reservation reservationToBeUpdated, Reservation reservation)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Reservation>> GetUsersByUserId(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateReservation(Reservation reservationToBeUpdated, Role reservation)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Reservation>> GetAllWithReservation()
        {
            throw new NotImplementedException();
        }

 
    }
}
