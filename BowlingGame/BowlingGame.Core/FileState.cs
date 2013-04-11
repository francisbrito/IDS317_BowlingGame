using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BowlingGame.Core
{
    public enum FileState
    {
        NotLoaded,
        Loaded,
        NotFound,
        CantBeAccessed,
        InvalidFormat,
    }
}
