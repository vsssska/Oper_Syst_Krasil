<<<<<<< HEAD
﻿using System;
using System.Diagnostics;
using System.Diagnostics.EventLog;

class Program
{
    static void Main(string[] args)
    {
        // Create an EventLog object for the specified event log
        EventLog log = new EventLog("Application");

        // Write each event to a text file
        foreach (EventLogEntry entry in log.Entries)
        {
            // Write the event details to a text file
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\\log.txt", true))
            {
                file.WriteLine("Event ID: " + entry.EventID.ToString());
                file.WriteLine("Event Source: " + entry.Source.ToString());
                file.WriteLine("Event Type: " + entry.EntryType.ToString());
                file.WriteLine("Event Time: " + entry.TimeGenerated.ToString());
                file.WriteLine("Event Message: " + entry.Message.ToString());
                file.WriteLine();
            }
        }
    }
}
=======
﻿using System;
using System.Diagnostics;
using System.Diagnostics.EventLog;

class Program
{
    static void Main(string[] args)
    {
        // Create an EventLog object for the specified event log
        EventLog log = new EventLog("Application");

        // Write each event to a text file
        foreach (EventLogEntry entry in log.Entries)
        {
            // Write the event details to a text file
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\\log.txt", true))
            {
                file.WriteLine("Event ID: " + entry.EventID.ToString());
                file.WriteLine("Event Source: " + entry.Source.ToString());
                file.WriteLine("Event Type: " + entry.EntryType.ToString());
                file.WriteLine("Event Time: " + entry.TimeGenerated.ToString());
                file.WriteLine("Event Message: " + entry.Message.ToString());
                file.WriteLine();
            }
        }
    }
}
>>>>>>> 6cf045d1ffb005712723aa4054b441865808ce0e
