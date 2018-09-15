using MovieData.DataModels;
using System.Collections.Generic;

namespace MovieData
{
    public interface ICheckOutResource
    {
        void PlaceHold(string renterId, string movieTitle, string diskType);
        void Checkin(int movieAssestId);
        bool ProcessCheckOut(string renterId, int movieId, string diskType);

        void MarkLost(int movieAssestId);
        void MarkFound(int movieAssestId);

        int GetNumberOfDvdCopies(string movieTitle);
        int GetNumberofBlueRayCopies(string movieTitle);

        Dvd IsDvdCheckedOut(int movieId);
        BlueRay IsBlueRayCheckedOut(int movieId);

        RentalCheckout GetCheckout(int id);
        RentalCheckout GetLatestCheckoutFromUser(string renterId);

        IEnumerable<RentalCheckout> GetAllCheckouts();
        IEnumerable<RentalCheckoutHistory> GetAllRentalCheckoutHistories();
        IEnumerable<RentalCheckoutHistory> GetRentalCheckoutHistory(string userId);
        IEnumerable<RentalCheckout> GetAllRentalCheckoutsByUser(string userId);
        IEnumerable<Hold> GetAllHoldsByUser(string userId);
        IEnumerable<Hold> GetCurrentHolds(string movieTitle, string diskType);

    }
}
