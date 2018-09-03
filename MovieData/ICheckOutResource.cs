using MovieData.DataModels;
using System.Collections.Generic;

namespace MovieData
{
    public interface ICheckOutResource
    {
        IEnumerable<RentalCheckout> GetAllCheckouts();
        RentalCheckout GetCheckout(int id);

        IEnumerable<RentalCheckoutHistory> GetAllRentalCheckoutHistories();
        RentalCheckoutHistory GetRentalCheckoutHistory(int id);

        void PlaceHold(int renterId, int movieAssestId);
        void Checkout(int renterId, int movieAssestId);
        void Checkin(int movieAssestId);

        RentalCheckout GetLatestCheckout(int renterId);

        int GetNumberOfCopies(int movieAssestId, string diskFormat);
        bool IsCheckout(int movieAssestId);

        IEnumerable<Hold> GetCurrentHolds(int movieAssestId);

        void MarkLost(int movieAssestId);
        void MarkFound(int movieAssestId);
    }
}
