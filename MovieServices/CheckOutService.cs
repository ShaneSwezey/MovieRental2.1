using MovieData;
using MovieData.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MovieServices
{
    public class CheckOutService : ICheckOutResource
    {

        private const int DEFAULT_RENTAL_DAYS_LIMIT = 15;

        private readonly MovieDbContext _context;

        public CheckOutService(MovieDbContext context)
        {
            _context = context ?? throw new ArgumentNullException();
        }

        public void Checkin(int movieAssestId)
        {
            throw new System.NotImplementedException();
        }

        public void Checkout(int renterId, int movieAssestId)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<RentalCheckout> GetAllCheckouts()
        {
            return _context.RentalCheckouts;
        }

        public IEnumerable<RentalCheckoutHistory> GetAllRentalCheckoutHistories()
        {
            return _context.RentalCheckoutHistories;
        }

        public RentalCheckout GetCheckout(int id)
        {
            var checkout = _context.RentalCheckouts
                .FirstOrDefault(c => c.CheckoutId == id);

            return checkout;
        }

        public IEnumerable<Hold> GetCurrentHolds(int movieId)
        {
            var holdList = _context.Holds
                .Where(h => h.MovieAssest.RefMovieId == movieId);

            return holdList;
        }

        public RentalCheckout GetLatestCheckout(int renterId)
        {
            throw new System.NotImplementedException();
        }

        public int GetNumberOfCopies(int movieAssestId, string diskFormat)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<RentalCheckoutHistory> GetRentalCheckoutHistory(int userId)
        {
            var rentalHistoryList = _context.RentalCheckoutHistories
                .Where(rh => rh.RefAspNetUserId == userId);

            return rentalHistoryList;
        }

        public MovieAssest IsCheckedout(string movieTitle, MovieAssest diskType)
        {
            
        }

        public void MarkFound(int movieAssestId)
        {
            var movieAssest = _context.MovieAssests.FirstOrDefault(ma =>
                 ma.AssestId == movieAssestId);

            if (movieAssest == null) return;

            movieAssest.Active = true;

            _context.MovieAssests.Update(movieAssest);

            _context.SaveChanges();
        }

        public void MarkLost(int movieAssestId)
        {
            var movieAssest = _context.MovieAssests.FirstOrDefault(ma =>
                ma.AssestId == movieAssestId);

            if (movieAssest == null) return;

            movieAssest.Active = false;

            _context.MovieAssests.Update(movieAssest);

            _context.SaveChanges();
        }

        public void PlaceHold(int renterId, int movieAssestId)
        {

            var now = DateTime.Now;

            var newHold = new Hold()
            {
                HoldDate = now,
                RefAspNetUserId = renterId,
                RefMovieAssestId = movieAssestId
            };

            _context.Holds.Add(newHold);

            _context.SaveChanges();
        }

        private DateTime SetDefaultCheckoutTime(DateTime now)
        {
            return now.AddDays(DEFAULT_RENTAL_DAYS_LIMIT);
        }
    }
}
