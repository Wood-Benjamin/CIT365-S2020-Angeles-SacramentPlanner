using SacrementPlanner.Data;
using SacrementPlanner.Models;
using System;
using System.Linq;

namespace SacrementPlanner.Data
{
    public static class DbInitializer
    {
        public static void Initialize(SacrementPlannerContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Meeting.Any())
            {
                return;   // DB has been seeded
            }

            var meeting = new Meeting[]
            {
            new Meeting{MeetingDate=DateTime.Parse("2005-10-01"),Presiding="Carson",Conducting="Jeff",OpeningHymn="Carson",Invocation="Carson",SacamentHymn="Carson",ClosingHymn="Carson",Benediction="Carson"},
            new Meeting{MeetingDate=DateTime.Parse("2005-11-01"),Presiding="Carson",Conducting="Bob",OpeningHymn="Carson",Invocation="Carson",SacamentHymn="Carson",ClosingHymn="Carson",Benediction="Carson"},
            new Meeting{MeetingDate=DateTime.Parse("2005-12-01"),Presiding="Carson",Conducting="Frank",OpeningHymn="Carson",Invocation="Carson",SacamentHymn="Carson",ClosingHymn="Carson",Benediction="Carson"},
            new Meeting{MeetingDate=DateTime.Parse("2005-10-11"),Presiding="Carson",Conducting="Justin",OpeningHymn="Carson",Invocation="Carson",SacamentHymn="Carson",ClosingHymn="Carson",Benediction="Carson"}
            };
            foreach (Meeting m in meeting)
            {
                context.Meeting.Add(m);
            }
            context.SaveChanges();

            var speaker = new Speaker[]
            {
            new Speaker{SpeakerName="Ben Wood",Topic="Holy Ghost"},
            new Speaker{SpeakerName="Mason Wood",Topic="Holy Ghost"},
            new Speaker{SpeakerName="Camden Wood",Topic="Holy Ghost"},
            new Speaker{SpeakerName="Avery Wood",Topic="Holy Ghost"}
            };
            foreach (Speaker s in speaker)
            {
                context.Speaker.Add(s);
            }
            context.SaveChanges();

            var meetingSpeakers = new SpeakerAssignment[]
            {
                new SpeakerAssignment {
                    MeetingID = meeting.Single(m => m.MeetingDate == DateTime.Parse("2005-10-01")).ID,
                    SpeakerID = speaker.Single(s => s.SpeakerName == "Ben Wood").ID
                    },
                new SpeakerAssignment {
                    MeetingID = meeting.Single(m => m.MeetingDate == DateTime.Parse("2005-11-01")).ID,
                    SpeakerID = speaker.Single(s => s.SpeakerName == "Mason Wood").ID
                    },
                new SpeakerAssignment {
                    MeetingID = meeting.Single(m => m.MeetingDate == DateTime.Parse("2005-12-01")).ID,
                    SpeakerID = speaker.Single(s => s.SpeakerName == "Camden Wood").ID
                    },
                new SpeakerAssignment {
                    MeetingID = meeting.Single(m => m.MeetingDate == DateTime.Parse("2005-10-11")).ID,
                    SpeakerID = speaker.Single(s => s.SpeakerName == "Avery Wood").ID
                    }
            };

            foreach (SpeakerAssignment ms in meetingSpeakers)
            {
                context.SpeakerAssignment.Add(ms);
            }
            context.SaveChanges();
        }
    }
}