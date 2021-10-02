using System.Collections.Generic;

namespace SanityCheck.Model
{
    class Input
    {
        public Meta Meta { get; set; }

        public List<ulong> Set { get; set; } = new List<ulong>();
    }
}
