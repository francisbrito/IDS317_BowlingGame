using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BowlingGame.Core
{
    public interface IFileValidator
    {
        bool IsValid(string[] entries);
    }
}
