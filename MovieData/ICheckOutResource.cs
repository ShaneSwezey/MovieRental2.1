using MovieData.DataModels;
using System.Collections.Generic;

namespace MovieData
{
    public interface ICheckOutResource
    {
        void PlaceHold(int renterId, string movieTitle, string diskType);
        void Checkin(int movieAssestId);
        bool ProcessCheckOut(int renterId, int movieId, string diskType);

        void MarkLost(int movieAssestId);
        void MarkFound(int movieAssestId);

        int GetNumberOfDvdCopies(string movieTitle);
        int GetNumberofBlueRayCopies(string movieTitle);

        RentalCheckout GetCheckout(int id);
        RentalCheckout GetLatestCheckoutFromUser(int renterId);

        IEnumerable<RentalCheckout> GetAllCheckouts();
        IEnumerable<RentalCheckoutHistory> GetAllRentalCheckoutHistories();
        IEnumerable<RentalCheckoutHistory> GetRentalCheckoutHistory(int userId);
        IEnumerable<Hold> GetCurrentHolds(string movieTitle, string diskType);

    }
}
