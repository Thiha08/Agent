using System;
using System.Collections.Generic;
using System.Text;

namespace Agent.Core.Args
{
    public class EmailArgs
    {
        public string From { get; set; }

        public string To { get; set; }

        public string Subject { get; set; }

        public string Body { get; set; }
    }
}
