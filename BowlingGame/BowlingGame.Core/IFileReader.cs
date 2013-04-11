using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BowlingGame.Core
{
    public interface IFileReader
    {
        FileState State { get; }
        string ReadFile(string path);
    }
}
