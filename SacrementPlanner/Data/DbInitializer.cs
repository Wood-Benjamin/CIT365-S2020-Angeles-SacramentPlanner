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
            new Meeting{MeetingDate=DateTime.Parse("2020-08-02"),Presiding="Bishop John Smith",Conducting="Greg Brown",OpeningHymn="17. Awake, Ye Saints of God, Awake!",Invocation="Susan Wright",SacamentHymn="169. As Now We Take the Sacrament",ClosingHymn="2. The Spirit of God",Benediction="Carson Wright"},
            new Meeting{MeetingDate=DateTime.Parse("2020-08-09"),Presiding="Bishop John Smith",Conducting="John Smith",OpeningHymn="164. Great God, to Thee My Evening Song",Invocation="Todd Williams",SacamentHymn="181. Jesus of Nazareth, Savior and King",ClosingHymn="134. I Believe in Christ",Benediction="Amy Williams"},
            new Meeting{MeetingDate=DateTime.Parse("2020-08-16"),Presiding="Bishop John Smith",Conducting="Henry Johnson",OpeningHymn="211. While Shepherds Watched Their Flocks",Invocation="Mike Jones",SacamentHymn="183. In Remembrance of Thy Suffering",ClosingHymn="97. Lead, Kindly Light",Benediction="Trish Young"},
            new Meeting{MeetingDate=DateTime.Parse("2020-08-23"),Presiding="1st Counselor Greg Brown",Conducting="Greg Brown",OpeningHymn="5. High on the Mountain Top",Invocation="Jeff Miller",SacamentHymn="188. Thy Will, O Lord, Be Done",ClosingHymn="26. Joseph Smith’s First Prayer",Benediction="Beth Miller"},
            new Meeting{MeetingDate=DateTime.Parse("2020-08-30"),Presiding="Bishop John Smith",Conducting="Greg Brown",OpeningHymn="67. Glory to God on High",Invocation="Spencer Wilson",SacamentHymn="193. I Stand All Amazed",ClosingHymn="227. There Is Sunshine in My Soul Today",Benediction="Jessica Moore"},
            new Meeting{MeetingDate=DateTime.Parse("2020-09-06"),Presiding="Bishop John Smith",Conducting="John Smith",OpeningHymn="60. Battle Hymn of the Republic",Invocation="Jim Taylor",SacamentHymn="190. In Memory of the Crucified",ClosingHymn="241. Count Your Blessings",Benediction="Madison Taylor"},
            new Meeting{MeetingDate=DateTime.Parse("2020-10-04"),SpecialNotes="General Conference"}
            };
            foreach (Meeting m in meeting)
            {
                context.Meeting.Add(m);
            }
            context.SaveChanges();


            var meetingSpeakers = new SpeakerAssignment[]
            {
                new SpeakerAssignment {
                    MeetingID = meeting.Single(m => m.MeetingDate == DateTime.Parse("2020-08-02")).ID,
                    SpeakerName = "Hailey Thompson",
                    SpeakerTopic = "Holy Ghost"
                    },
                new SpeakerAssignment {
                    MeetingID = meeting.Single(m => m.MeetingDate == DateTime.Parse("2020-08-09")).ID,
                    SpeakerName = "Mark Jackson",
                    SpeakerTopic = "Repentance"
                    },
                new SpeakerAssignment {
                    MeetingID = meeting.Single(m => m.MeetingDate == DateTime.Parse("2020-08-16")).ID,
                    SpeakerName = "Janice White",
                    SpeakerTopic = "Prayer"
                    },
                new SpeakerAssignment {
                    MeetingID = meeting.Single(m => m.MeetingDate == DateTime.Parse("2020-08-23")).ID,
                    SpeakerName = "Bruce Harris",
                    SpeakerTopic = "Temples"
                    },
                new SpeakerAssignment {
                    MeetingID = meeting.Single(m => m.MeetingDate == DateTime.Parse("2020-08-30")).ID,
                    SpeakerName = "Kim Martin",
                    SpeakerTopic = "Prophets"
                    },
                new SpeakerAssignment {
                    MeetingID = meeting.Single(m => m.MeetingDate == DateTime.Parse("2020-09-06")).ID,
                    SpeakerName = "Don Clark",
                    SpeakerTopic = "Service"
                    },
                new SpeakerAssignment {
                    MeetingID = meeting.Single(m => m.MeetingDate == DateTime.Parse("2020-08-02")).ID,
                    SpeakerName = "Brenda Lewis",
                    SpeakerTopic = "Love"
                    },
                new SpeakerAssignment {
                    MeetingID = meeting.Single(m => m.MeetingDate == DateTime.Parse("2020-08-09")).ID,
                    SpeakerName = "Barbra Walker",
                    SpeakerTopic = "Forgiveness"
                    },
                new SpeakerAssignment {
                    MeetingID = meeting.Single(m => m.MeetingDate == DateTime.Parse("2020-08-16")).ID,
                    SpeakerName = "Tim Robinson",
                    SpeakerTopic = "Prayer"
                    },
                new SpeakerAssignment {
                    MeetingID = meeting.Single(m => m.MeetingDate == DateTime.Parse("2020-08-23")).ID,
                    SpeakerName = "Whittney Anderson",
                    SpeakerTopic = "Baptism"
                    },
                new SpeakerAssignment {
                    MeetingID = meeting.Single(m => m.MeetingDate == DateTime.Parse("2020-08-30")).ID,
                    SpeakerName = "Jonah Thomas",
                    SpeakerTopic = "Priesthood Keys"
                    },
                new SpeakerAssignment {
                    MeetingID = meeting.Single(m => m.MeetingDate == DateTime.Parse("2020-09-06")).ID,
                    SpeakerName = "Miranda Baker",
                    SpeakerTopic = "Plan of Salvation"
                    },
                new SpeakerAssignment {
                    MeetingID = meeting.Single(m => m.MeetingDate == DateTime.Parse("2020-08-02")).ID,
                    SpeakerName = "Tony Campbell",
                    SpeakerTopic = "Faith"
                    },
                new SpeakerAssignment {
                    MeetingID = meeting.Single(m => m.MeetingDate == DateTime.Parse("2020-08-09")).ID,
                    SpeakerName = "Kate Roberts",
                    SpeakerTopic = "Enduring to the end"
                    },
                new SpeakerAssignment {
                    MeetingID = meeting.Single(m => m.MeetingDate == DateTime.Parse("2020-08-16")).ID,
                    SpeakerName = "Mickayla Hall",
                    SpeakerTopic = "Hope"
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