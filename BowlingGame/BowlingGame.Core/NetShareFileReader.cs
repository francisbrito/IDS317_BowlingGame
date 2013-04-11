using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BowlingGame.Core
{
    public class NetShareFileReader : IFileReader
    {
        public FileState State { get; private set; }
        public string ReadFile(string path)
        {
            throw new NotImplementedException();
        }
    }
}
