using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Airlines_Ticket_WebApp.Models;
using Booking_Airline.Models;

namespace Airlines_Ticket_WebApp.Controllers
{
    public class TicketsController : Controller
    {
        private readonly FlightDBContext _context;

        public TicketsController(FlightDBContext context)
        {
            _context = context;
        }   

        // GET: Tickets/Booking
        public IActionResult Booking()
        {
            ViewData["Flights"] = new SelectList(_context.Flights, "FlightId", "Airline");
            ViewData["Customers"] = new SelectList(_context.Customers, "Id", "Customer_Name");
            ViewData["SeatClasses"] = new SelectList(_context.SeatClasses, "Id", "ClassName");
            return View();
        }

        // POST: Tickets/Booking
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Booking([Bind("FlightId,CustomerId,SeatClassId,SeatNumber")] Booking booking)
        {
            if (ModelState.IsValid)
            {
                _context.Add(booking);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Payment));
            }
            ViewData["Flights"] = new SelectList(_context.Flights, "FlightId", "Airline", booking.Flight.FlightId);
            ViewData["Customers"] = new SelectList(_context.Customers, "Id", "Customer_Name", booking.Customer.Id);
            ViewData["SeatClasses"] = new SelectList(_context.SeatClasses, "Id", "ClassName", booking.SeatClass.Id);
            return View(booking);
        }

        // GET: Tickets/Payment
        public IActionResult Payment()
        {
            return View();
        }

        // POST: Tickets/Payment
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Payment(Payment payment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(payment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(GetEticket));
            }
            return View(payment);
        }

        // GET: Tickets/GetEticket
        public IActionResult GetEticket()
        {
            // Trong thực tế, bạn sẽ lấy thông tin đặt vé từ database
            // Ví dụ: var booking = _context.Bookings.Include(...).FirstOrDefault(b => b.Id == id);
            return View();
        }

        // GET: Tickets/BookingConfirmation/5
        public async Task<IActionResult> BookingConfirmation(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booking = await _context.Bookings
                .Include(b => b.Flight)
                .Include(b => b.Customer)
                .Include(b => b.SeatClass)
                .FirstOrDefaultAsync(m => m.BookingId == id);
            if (booking == null)
            {
                return NotFound();
            }

            return View(booking);
        }

        // GET: Bookings
        public async Task<IActionResult> Index()
        {
            return View(await _context.Bookings.ToListAsync());
        }

        // GET: Bookings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booking = await _context.Bookings
                .FirstOrDefaultAsync(m => m.BookingId == id);
            if (booking == null)
            {
                return NotFound();
            }

            return View(booking);
        }

        // GET: Bookings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Bookings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BookingId,SeatNumber")] Booking booking)
        {
            if (ModelState.IsValid)
            {
                _context.Add(booking);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(booking);
        }

        // GET: Bookings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booking = await _context.Bookings.FindAsync(id);
            if (booking == null)
            {
                return NotFound();
            }
            return View(booking);
        }

        // POST: Bookings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BookingId,SeatNumber")] Booking booking)
        {
            if (id != booking.BookingId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(booking);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookingExists(booking.BookingId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(booking);
        }

        // GET: Bookings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booking = await _context.Bookings
                .FirstOrDefaultAsync(m => m.BookingId == id);
            if (booking == null)
            {
                return NotFound();
            }

            return View(booking);
        }

        // POST: Bookings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var booking = await _context.Bookings.FindAsync(id);
            if (booking != null)
            {
                _context.Bookings.Remove(booking);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookingExists(int id)
        {
            return _context.Bookings.Any(e => e.BookingId == id);
        }
    }
}
