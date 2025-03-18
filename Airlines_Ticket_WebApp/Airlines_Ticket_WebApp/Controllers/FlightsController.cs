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
    public class FlightsController : Controller
    {
        private readonly FlightDBContext _context;

        public FlightsController(FlightDBContext context)
        {
            _context = context;
        }

        // GET: Flights/Search
        public IActionResult Search()
        {
            return View();
        }

        // POST: Flights/Search
        [HttpPost]
        public async Task<IActionResult> Search(string departure, string destination, DateTime? departureTime)
        {
            var query = _context.Flights.Include(f => f.Origin).Include(f => f.Destination).AsQueryable();

            if (!string.IsNullOrEmpty(departure))
            {
                query = query.Where(f => f.Origin.Origin_City.Contains(departure) || f.Origin.Origin_Airport.Contains(departure));
            }

            if (!string.IsNullOrEmpty(destination))
            {
                query = query.Where(f => f.Destination.Destination_City.Contains(destination) || f.Destination.Destination_Airport.Contains(destination));
            }

            if (departureTime.HasValue)
            {
                query = query.Where(f => f.DepartureTime.Date == departureTime.Value.Date);
            }

            var flights = await query.ToListAsync();
            return View(flights);
        }
    

        // GET: Flights
        public async Task<IActionResult> Index()
        {
            var flights = await _context.Flights
                .Include(f => f.Origin)
                .Include(f => f.Destination)
                .ToListAsync();
            return View(flights);
        }

        // GET: Flights/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var flight = await _context.Flights
                .FirstOrDefaultAsync(m => m.FlightId == id);
            if (flight == null)
            {
                return NotFound();
            }

            return View(flight);
        }

        // GET: Flights/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Flights/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FlightId,Airline,Departure,DepartureTime,ArrivalTime,Status")] Flight flight)
        {
            if (ModelState.IsValid)
            {
                _context.Add(flight);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(flight);
        }

        // GET: Flights/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var flight = await _context.Flights.FindAsync(id);
            if (flight == null)
            {
                return NotFound();
            }
            return View(flight);
        }

        // POST: Flights/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FlightId,Airline,Departure,DepartureTime,ArrivalTime,Status")] Flight flight)
        {
            if (id != flight.FlightId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(flight);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FlightExists(flight.FlightId))
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
            return View(flight);
        }

        // GET: Flights/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var flight = await _context.Flights
                .FirstOrDefaultAsync(m => m.FlightId == id);
            if (flight == null)
            {
                return NotFound();
            }

            return View(flight);
        }

        // POST: Flights/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var flight = await _context.Flights.FindAsync(id);
            if (flight != null)
            {
                _context.Flights.Remove(flight);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FlightExists(int id)
        {
            return _context.Flights.Any(e => e.FlightId == id);
        }
    }
}
