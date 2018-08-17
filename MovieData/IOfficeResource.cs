using MovieData.DataModels;
using System.Collections.Generic;

namespace MovieData
{
    public interface IOfficeResource
    {
        // Returns the company from db.MovieDb table Company
        Office GetOfficeById(int id);
        // Returns the company's city from db.MovieDb table Company
        string GetCity(int id);
        // Returns the company's state from db.MovieDb table Company
        string GetState(int id);
        // Returns the companys's address from db.MovieDb table Company
        string GetAddress(int id);
        // Returns the company's local image address from db.MovieDb table Company
        string GetImageAddress(int id);
        // Returns a list of the company's email addresses from db.MovieDb 
        // table CompanyEmail
        IEnumerable<OfficeEmail> GetCompanyEmailAddresses(int id);
        // Returns a list of the company's phone numbers from db.MovieDb 
        // table CompanyPhoneNumber
        IEnumerable<OfficePhoneNumber> GetCompanyPhoneNumbers(int id);
        // Returns a list of all the companys from db.MovieDb table Company
        IEnumerable<Office> GetAll();
    }
}
