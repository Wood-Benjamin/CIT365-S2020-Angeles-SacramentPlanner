using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SacrementPlanner.Data;
using SacrementPlanner.Models;

namespace SacrementPlanner.Controllers
{
    public class SpeakerAssignmentsController : Controller
    {
        private readonly SacrementPlannerContext _context;

        public SpeakerAssignmentsController(SacrementPlannerContext context)
        {
            _context = context;
        }

        // GET: SpeakerAssignments
        public async Task<IActionResult> Index(int? id)
        {
            var speakerAssignments = from s in _context.SpeakerAssignment select s;
            if (id != 0)
            {
                speakerAssignments = speakerAssignments.Where(s => s.MeetingID.Equals(id));
            }
            speakerAssignments = speakerAssignments.OrderBy(s => s.SpeakerName);
            if (speakerAssignments == null)
            {
                return NotFound();
            }
            ViewData["MeetingID"] = id;

            return View(await speakerAssignments.Include(s => s.Meeting).ToListAsync());

            //var sacrementPlannerContext = _context.SpeakerAssignment.Include(s => s.Meeting);
            //return View(await sacrementPlannerContext.ToListAsync());
        }

        // GET: SpeakerAssignments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var speakerAssignment = await _context.SpeakerAssignment
                .Include(s => s.Meeting)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (speakerAssignment == null)
            {
                return NotFound();
            }

            return View(speakerAssignment);
        }

        // GET: SpeakerAssignments/Create
        public IActionResult Create(int? id)
        {
            var speakerAssignment = new SpeakerAssignment();
            speakerAssignment.MeetingID = id.Value;
            ViewData["MeetingID"] = id;

            var meeting = _context.Meeting.SingleOrDefaultAsync(s => s.ID == id);
            if (meeting == null)
            {
                return NotFound();
            }

            speakerAssignment.Meeting = new Meeting();
            return View(speakerAssignment);

            //ViewData["MeetingID"] = new SelectList(_context.Meeting, "ID", "ID");
            //return View();
        }

        // POST: SpeakerAssignments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,MeetingID,SpeakerName,SpeakerTopic")] SpeakerAssignment speakerAssignment)
        {
            speakerAssignment.ID = 0;
            if (ModelState.IsValid)
            {
                _context.Add(speakerAssignment);
                await _context.SaveChangesAsync();
               //Open the meeting and update the has speaker field
                var meeting = _context.Meeting.SingleOrDefaultAsync(s => s.ID == speakerAssignment.MeetingID);
                //_context.Meeting.HasSpeakers = true; Need to add Has speakers to dbase
                return RedirectToAction(nameof(Index), new { id = speakerAssignment.MeetingID });
            }
            ViewData["MeetingID"] = speakerAssignment.MeetingID;
            //ViewData["MeetingID"] = new SelectList(_context.Meeting, "ID", "ID", speakerAssignment.MeetingID);
            return View(speakerAssignment);
        }

        // GET: SpeakerAssignments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var speakerAssignment = await _context.SpeakerAssignment.FindAsync(id);
            var speakerAssignment = await _context.SpeakerAssignment.Include(s => s.MeetingID).SingleOrDefaultAsync(m => m.ID == id);
            if (speakerAssignment == null)
            {
                return NotFound();
            }
            ViewData["MeetingID"] = new SelectList(_context.Meeting, "ID", "ID", speakerAssignment.MeetingID);
            return View(speakerAssignment);
        }

        // POST: SpeakerAssignments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,MeetingID,SpeakerName,SpeakerTopic")] SpeakerAssignment speakerAssignment)
        {
            if (id != speakerAssignment.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(speakerAssignment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SpeakerAssignmentExists(speakerAssignment.ID))
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
            ViewData["MeetingID"] = new SelectList(_context.Meeting, "ID", "ID", speakerAssignment.MeetingID);
            return View(speakerAssignment);
        }

        // GET: SpeakerAssignments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var speakerAssignment = await _context.SpeakerAssignment
                .Include(s => s.Meeting)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (speakerAssignment == null)
            {
                return NotFound();
            }

            return View(speakerAssignment);
        }

        // POST: SpeakerAssignments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var speakerAssignment = await _context.SpeakerAssignment.FindAsync(id);
            _context.SpeakerAssignment.Remove(speakerAssignment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SpeakerAssignmentExists(int id)
        {
            return _context.SpeakerAssignment.Any(e => e.ID == id);
        }
    }
}
