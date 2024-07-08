using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingTracker.Models;
internal class CodingSessions
{
    internal int ID { get; set; }
    internal DateTime StartTime { get; set; }
    internal DateTime EndTime { get; set; }
    internal int Duration { get; set; }
}
