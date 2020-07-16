using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SacrementPlanner.Data;
using SacrementPlanner.Models;
using SacrementPlanner.Models.MeetingViewModels;

namespace SacrementPlanner.Controllers
{
    public class MeetingsController : Controller
    {
        private readonly SacrementPlannerContext _context;

        public MeetingsController(SacrementPlannerContext context)
        {
            _context = context;
        }

        // GET: Meetings
        public async Task<IActionResult> Index(string sortOrder, string searchString)
        {
            ViewData["ConductSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";
            ViewData["CurrentFilter"] = searchString;

            var meetings = from m in _context.Meeting
                .Include(m => m.SpeakerAssigments)
                .AsNoTracking()
                select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                meetings = meetings.Where(m => m.Conducting.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    meetings = meetings.OrderByDescending(m => m.Conducting);
                    break;
                case "Date":
                    meetings = meetings.OrderBy(m => m.MeetingDate);
                    break;
                case "date_desc":
                    meetings = meetings.OrderByDescending(m => m.MeetingDate);
                    break;
                default:
                    meetings = meetings.OrderBy(m => m.Conducting);
                    break;
            }

            //List<CountSpeakers> speakers = new List<CountSpeakers>();
            //var conn = _context.Database.GetDbConnection();
            //try
            //{
            //    await conn.OpenAsync();
            //    using (var command = conn.CreateCommand())
            //    {
            //        string query = "SELECT SpeakerCountID, COUNT(*) AS SpeakerCount "
            //            + "FROM SpeakerAssigment "
            //            + "WHERE MeetingID == Meeting.ID ";
            //        command.CommandText = query;
            //        DbDataReader reader = await command.ExecuteReaderAsync();

            //        if (reader.HasRows)
            //        {
            //            while (await reader.ReadAsync())
            //            {
            //                var row = new CountSpeakers { CountSpeakersID = reader.GetInt32(1), SpeakerCount = reader.GetInt32(1) };
            //                speakers.Add(row);
            //            }
            //        }
            //        reader.Dispose();
            //    }
            //}
            //finally
            //{
            //    conn.Close();
            //}





            return View(await meetings.AsNoTracking().ToListAsync());
        }

        // GET: Meetings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meeting = await _context.Meeting
                .Include(m => m.SpeakerAssigments)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);
            if (meeting == null)
            {
                return NotFound();
            }

            return View(meeting);
        }

        // GET: Meetings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Meetings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,MeetingDate,Presiding,Conducting,SpecialNotes,OpeningHymn,Invocation,SacamentHymn,IntermediateHymn,ClosingHymn,Benediction")] Meeting meeting)
        {
            if (ModelState.IsValid)
            {
                _context.Add(meeting);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(meeting);
        }

        // GET: Meetings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meeting = await _context.Meeting.FindAsync(id);
            if (meeting == null)
            {
                return NotFound();
            }
            return View(meeting);
        }

        // POST: Meetings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,MeetingDate,Presiding,Conducting,SpecialNotes,OpeningHymn,Invocation,SacamentHymn,IntermediateHymn,ClosingHymn,Benediction")] Meeting meeting)
        {
            if (id != meeting.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(meeting);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MeetingExists(meeting.ID))
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
            return View(meeting);
        }

        // GET: Meetings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meeting = await _context.Meeting
                .FirstOrDefaultAsync(m => m.ID == id);
            if (meeting == null)
            {
                return NotFound();
            }

            return View(meeting);
        }

        // POST: Meetings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var meeting = await _context.Meeting.FindAsync(id);
            _context.Meeting.Remove(meeting);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MeetingExists(int id)
        {
            return _context.Meeting.Any(e => e.ID == id);
        }
    }
}
