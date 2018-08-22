using Microsoft.EntityFrameworkCore;
using MovieData;
using MovieData.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MovieServices
{
    // OfficeResourceService class offers access to records contained in Office tables in MovieDB2.0
    public class OfficeResourceService : IOfficeResource
    {
        // DbContext
        private MovieDbContext _context;

        public OfficeResourceService(MovieDbContext context)
        {
            _context = context ?? throw new ArgumentException();
        }

        public string GetAddress(int id)
        {
            var address = _context.Offices
                .FirstOrDefault(c => c.OfficeId == id)
                .Address;
            return address;
        }

        public IEnumerable<Office> GetAll()
        {
            return _context.Offices
                .Include(c => c.OfficePhoneNumbers)
                .Include(c => c.OfficeEmails);
        }

        public string GetCity(int id)
        {
            var city = _context.Offices
                .FirstOrDefault(c => c.OfficeId == id)
                .City;
            return city;
        }

        public IEnumerable<OfficeEmail> GetCompanyEmailAddresses(int id)
        {
            var emailList = _context.OfficeEmails
                .Where(c => c.OfficeRefId == id);

            return emailList;
        }

        public IEnumerable<OfficePhoneNumber> GetCompanyPhoneNumbers(int id)
        {
            var phoneNumbersList = _context.OfficePhoneNumbers
                .Where(c => c.OfficeRefId == id);
            return phoneNumbersList;
        }

        public string GetImageAddress(int id)
        {
            return _context.Offices
                .FirstOrDefault(c => c.OfficeId == id)
                .ImageAddress;
        }

        public Office GetOfficeById(int id)
        {
            return _context.Offices
                .Include(c => c.OfficeEmails)
                .Include(c => c.OfficePhoneNumbers)
                .FirstOrDefault(c => c.OfficeId == id);
        }

        public string GetState(int id)
        {
            return _context.Offices
                .FirstOrDefault(c => c.OfficeId == id)
                .State;
        }
    }
}
