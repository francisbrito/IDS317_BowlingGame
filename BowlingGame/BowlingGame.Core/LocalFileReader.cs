using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Permissions;
using System.Text;

namespace BowlingGame.Core
{
    public class LocalFileReader : IFileReader
    {
        private FileState _state;

        public LocalFileReader()
        {
            _state = FileState.NotLoaded;
        }

        // NOTE:
        // This method may cause a NullReferenceException in the calling method
        // if the file can't be read.
        public string ReadFile(string path)
        {
            string entries = null;

            try
            {
                entries = File.ReadAllText(path);
            }
            catch (FileNotFoundException)
            {
                _state = FileState.NotFound;
            }
            // This is the simplest way to check for read access permissions.
            catch (UnauthorizedAccessException)
            {
                _state = FileState.CantBeAccessed;
            }

            return entries;
        }

        public FileState State
        {
            get { return _state; }
        }
    }
}
