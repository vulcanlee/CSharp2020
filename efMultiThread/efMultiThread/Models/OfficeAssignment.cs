using System;
using System.Collections.Generic;

namespace efMultiThread.Models
{
    public partial class OfficeAssignment
    {
        public int InstructorId { get; set; }
        public string Location { get; set; }
        public byte[] Timestamp { get; set; }

        public virtual Person Instructor { get; set; }
    }
}
