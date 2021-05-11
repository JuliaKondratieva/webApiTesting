using System;
using System.Collections.Generic;
using System.Text;

namespace WebAPITesting
{
    class FileClass
    {
        public string path { get; set; }
        public string mode { get; set; }
        public bool autorename { get; set; }
        public bool mute { get; set; }
        public bool strict_conflict { get; set; }

    }
}
