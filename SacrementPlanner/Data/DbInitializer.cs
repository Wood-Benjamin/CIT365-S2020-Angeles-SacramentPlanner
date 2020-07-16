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
            new Meeting{MeetingDate=DateTime.Parse("2005-10-01"),Presiding="Bishop John Smith",Conducting="Brother Ben Wood",OpeningHymn="17. Awake, Ye Saints of God, Awake!",Invocation="Sister Traesa Cox",SacamentHymn="Carson",ClosingHymn="Carson",Benediction="Carson"},
            new Meeting{MeetingDate=DateTime.Parse("2005-11-01"),Presiding="Carson",Conducting="Bishop John Smith",OpeningHymn="164. Great God, to Thee My Evening Song",Invocation="Carson",SacamentHymn="Carson",ClosingHymn="Carson",Benediction="Carson"},
            new Meeting{MeetingDate=DateTime.Parse("2005-12-01"),Presiding="Carson",Conducting="Brother Aaron Wood",OpeningHymn="211. While Shepherds Watched Their Flocks",Invocation="Carson",SacamentHymn="Carson",ClosingHymn="Carson",Benediction="Carson"},
            new Meeting{MeetingDate=DateTime.Parse("2005-10-11"),Presiding="Carson",Conducting="Justin",OpeningHymn="Carson",Invocation="Carson",SacamentHymn="Carson",ClosingHymn="Carson",Benediction="Carson"}
            };
            foreach (Meeting m in meeting)
            {
                context.Meeting.Add(m);
            }
            context.SaveChanges();


            var meetingSpeakers = new SpeakerAssignment[]
            {
                new SpeakerAssignment {
                    MeetingID = meeting.Single(m => m.MeetingDate == DateTime.Parse("2005-10-01")).ID,
                    SpeakerName = "Ben Wood",
                    SpeakerTopic = "Holy Ghost"
                    },
                new SpeakerAssignment {
                    MeetingID = meeting.Single(m => m.MeetingDate == DateTime.Parse("2005-11-01")).ID,
                    SpeakerName = "Mason Wood",
                    SpeakerTopic = "Repentance"
                    },
                new SpeakerAssignment {
                    MeetingID = meeting.Single(m => m.MeetingDate == DateTime.Parse("2005-12-01")).ID,
                    SpeakerName = "Camden Wood",
                    SpeakerTopic = "Prayer"
                    },
                new SpeakerAssignment {
                    MeetingID = meeting.Single(m => m.MeetingDate == DateTime.Parse("2005-10-11")).ID,
                    SpeakerName = "Avery Wood",
                    SpeakerTopic = "Temples"
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