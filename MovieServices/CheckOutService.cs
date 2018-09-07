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
            var rentalHistoryrecord = _context.RentalCheckoutHistories
                .FirstOrDefault(rh => rh.RefMovieAssestId == movieAssestId);

            if (rentalHistoryrecord == null) return;

            var returnDate = DateTime.Now;

            var rentalCheckout = _context.RentalCheckouts
                .FirstOrDefault(rc => rc.RefMovieAssestId == movieAssestId);

            rentalCheckout.MovieAssest.Checkedout = false;

            _context.Update(rentalCheckout);

            rentalHistoryrecord.ReturnDate = returnDate;

            _context.Update(rentalHistoryrecord);

            _context.SaveChanges();

        }

        public void Checkout(int renterId, int movieAssestId)
        {
            var movieAssest = _context.MovieAssests
                .FirstOrDefault(m => m.AssestId == movieAssestId);

            movieAssest.Checkedout = true;

            _context.Update(movieAssest);

            var checkoutDate = DateTime.Now;

            var newCheckout = new RentalCheckout()
            {
                CheckoutDate = checkoutDate,
                ReturnDate = GetDefaultCheckoutTime(checkoutDate),
                RefAspNetUserId = renterId,
                RefMovieAssestId = movieAssest.AssestId,
                MovieAssest = movieAssest
            };

            _context.RentalCheckouts.Add(newCheckout);

            var newRentalHistoryRecord = new RentalCheckoutHistory()
            {
                CheckoutDate = checkoutDate,
                ReturnDate = null,
                RefAspNetUserId = renterId,
                RefMovieAssestId = movieAssest.AssestId,
                MovieAssest = movieAssest
            };

            _context.RentalCheckoutHistories.Add(newRentalHistoryRecord);

            _context.SaveChanges();
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

        // Get current holds based on movie title and disktype
        // Ordered by ascending hold date
        public IEnumerable<Hold> GetCurrentHolds(string movieTitle, string diskType)
        {
            var holdList = _context.Holds
                .Where(h => h.MovieTitle == movieTitle 
                && h.DiskType.Equals(diskType, StringComparison.InvariantCultureIgnoreCase))
                .OrderBy(h => h.HoldDate);

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

        public bool IsBlueRayCheckedOut(string movieTitle)
        {
            var isCheckedOut = _context.BlueRays.Any(br => 
                br.Movie.Title.Equals(movieTitle, StringComparison.InvariantCultureIgnoreCase) 
                && br.Checkedout == false);

            return isCheckedOut;
        }

        public bool IsDvdCheckedOut(string movieTitle)
        {
            var isCheckedOut = _context.Dvds.Any(br =>
                br.Movie.Title.Equals(movieTitle, StringComparison.InvariantCultureIgnoreCase)
                && br.Checkedout == false);

            return isCheckedOut;
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

        public void PlaceHold(int renterId, string movieTitle, string diskType)
        {
            var now = DateTime.Now;

            var newHold = new Hold()
            {
                HoldDate = now,
                RefAspNetUserId = renterId,
                MovieTitle = movieTitle,
                DiskType = diskType
            };

            _context.Holds.Add(newHold);

            _context.SaveChanges();
        }

        private DateTime GetDefaultCheckoutTime(DateTime now)
        {
            return now.AddDays(DEFAULT_RENTAL_DAYS_LIMIT);
        }
    }
}
