using MovieData.DataModels;
using System;
using System.Collections.Generic;

namespace MovieData
{
    public interface ICheckOutResource
    {
        IEnumerable<RentalCheckout> GetAllCheckouts();
        RentalCheckout GetCheckout(int id);

        IEnumerable<RentalCheckoutHistory> GetAllRentalCheckoutHistories();
        IEnumerable<RentalCheckoutHistory> GetRentalCheckoutHistory(int userId);

        void PlaceHold(int renterId, int movieAssestId);
        void Checkout(int renterId, int movieAssestId);
        void Checkin(int movieAssestId);

        RentalCheckout GetLatestCheckout(int renterId);

        int GetNumberOfCopies(int movieAssestId, string diskFormat);
        MovieAssest IsCheckedout(string movieTitle, MovieAssest type);

        IEnumerable<Hold> GetCurrentHolds(int movieId);

        void MarkLost(int movieAssestId);
        void MarkFound(int movieAssestId);

    }
}
