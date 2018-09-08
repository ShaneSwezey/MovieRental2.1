using MovieData.DataModels;
using System.Collections.Generic;

namespace MovieData
{
    public interface ICheckOutResource
    {
        IEnumerable<RentalCheckout> GetAllCheckouts();
        RentalCheckout GetCheckout(int id);

        IEnumerable<RentalCheckoutHistory> GetAllRentalCheckoutHistories();
        IEnumerable<RentalCheckoutHistory> GetRentalCheckoutHistory(int userId);

        void PlaceHold(int renterId, string movieTitle, string diskType);
        bool IsDvdCheckedOut(string movieTitle);
        bool IsBlueRayCheckedOut(string movieTitle);
        void Checkin(int movieAssestId);

        RentalCheckout GetLatestCheckoutFromUser(int renterId);

        int GetNumberOfDvdCopies(string movieTitle);
        int GetNumberofBlueRayCopies(string movieTitle);

        IEnumerable<Hold> GetCurrentHolds(string movieTitle, string diskType);

        void MarkLost(int movieAssestId);
        void MarkFound(int movieAssestId);

    }
}
