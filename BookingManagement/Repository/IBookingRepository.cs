using CommonService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingManagement.Repository
{
    public interface IBookingRepository
    {
        int AddBooking(BookingDetails dtls);
        IQueryable GetBookingFromPNR(string PNR);

        IQueryable GetBookingsFromEmail(string Email);

        void CancelBooking(int pnr);        
    }
}
