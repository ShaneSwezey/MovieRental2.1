using MovieData;
using MovieData.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MovieServices
{
    public class CheckOutService : ICheckOutResource
    {
        // Sets the standard limit of how many days a user can rent a movie  
        // before late penalties occur.
        private const int DEFAULT_RENTAL_DAYS_LIMIT = 15;

        private readonly MovieDbContext _context;

        public CheckOutService(MovieDbContext context)
        {
            _context = context ?? throw new ArgumentNullException();
        }

        // Returns a movie from a account user.
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

        /// <summary>
        /// Checks out a movie for an account user.
        /// </summary>
        /// <param name="renterId"> Renters Id </param>
        /// <param name="movieId"> Movie Id </param>
        /// <param name="diskType"> Disk type wanted </param>
        /// <returns> True: if checkout succeed False: movie is not available to rent </returns>
        public bool ProcessCheckOut(int renterId, int movieId, string diskType)
        {
            MovieAssest movie;
            if (diskType.Equals("Dvd", StringComparison.InvariantCultureIgnoreCase))
            {
                movie = IsDvdCheckedOut(movieId);
            }
            else
            {
                movie = IsBlueRayCheckedOut(movieId);
            }

            if (movie == null) return false;

            Checkout(movie, renterId);

            return true;
        }

        // Returns a list of all current movie that are checked out
        public IEnumerable<RentalCheckout> GetAllCheckouts()
        {
            return _context.RentalCheckouts;
        }

        // Returns a list of all past rental checkouts 
        public IEnumerable<RentalCheckoutHistory> GetAllRentalCheckoutHistories()
        {
            return _context.RentalCheckoutHistories;
        }

       // Returns a RentalCheckout object based on the checkout Id.
        public RentalCheckout GetCheckout(int checkoutId)
        {
            var checkout = _context.RentalCheckouts
                .FirstOrDefault(c => c.CheckoutId == checkoutId);

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

        // Returns the lastest movie check out from an account user.
        public RentalCheckout GetLatestCheckoutFromUser(int renterId)
        {
            return _context.RentalCheckouts.OrderByDescending(rc => rc.CheckoutDate)
                .FirstOrDefault(rc => rc.RefAspNetUserId == renterId);
        }

        // Returns the total number of dvd copies the company owns based on movie title
        public int GetNumberOfDvdCopies(string movieTitle)
        {
            return _context.MovieAssests.OfType<Dvd>().Count(ma =>
                ma.Movie.Title.Equals(movieTitle,
                StringComparison.InvariantCultureIgnoreCase));
        }

        // Returns the total number of blue ray copies the company owns based on movie title
        public int GetNumberofBlueRayCopies(string movieTitle)
        {
            return _context.MovieAssests.OfType<BlueRay>().Count(ma =>
                ma.Movie.Title.Equals(movieTitle,
                StringComparison.InvariantCultureIgnoreCase));
        }

        // Returns a list of past rental check outs for a particular account user.
        public IEnumerable<RentalCheckoutHistory> GetRentalCheckoutHistory(int userId)
        {
            var rentalHistoryList = _context.RentalCheckoutHistories
                .Where(rh => rh.RefAspNetUserId == userId);

            return rentalHistoryList;
        }

        // 
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

        // Places a hold on a particular movie that is currently unavailable 
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

        // Checks out an avaiable movie for an account user.
        private void Checkout(MovieAssest movieAssest, int renterId)
        {

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

        /// <summary>
        /// Checks to see if a blue ray version of the film is available
        /// </summary>
        /// <param name="movieId"> movie id from table Movies </param>
        /// <returns> 
        ///     BlueRay: If a blue Ray version of the film is available 
        ///     Null   : If a blue ray version of the fim is unavailabe
        /// </returns>
        private BlueRay IsBlueRayCheckedOut(int movieId)
        {
            return _context.BlueRays.FirstOrDefault(br =>
                br.Movie.MovieId == movieId && br.Checkedout == false);
        }

        /// <summary>
        /// Checks to see if a dvd version of the film is available
        /// </summary>
        /// <param name="movieId"> movie id from table Movies </param>
        /// <returns> 
        ///     Dvd: If a dvd version of the film is available 
        ///     Null   : If a dvd version of the fim is unavailabe
        /// </returns>
        private Dvd IsDvdCheckedOut(int movieId)
        {
            return _context.Dvds.FirstOrDefault(br =>
                br.Movie.MovieId == movieId && br.Checkedout == false);
        }

        // Sets the default check out time to the current rental Datetime
        private DateTime GetDefaultCheckoutTime(DateTime now)
        {
            return now.AddDays(DEFAULT_RENTAL_DAYS_LIMIT);
        }

        
    }
}
