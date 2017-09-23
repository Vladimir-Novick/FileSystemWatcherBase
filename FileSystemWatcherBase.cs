using System;
using System.IO;
using System.Threading;


////////////////////////////////////////////////////////////////////////////
//	Copyright 2014 : Vladimir Novick    https://www.linkedin.com/in/vladimirnovick/  
//
//         https://github.com/Vladimir-Novick/FileSystemWatcher
//
//    NO WARRANTIES ARE EXTENDED. USE AT YOUR OWN RISK. 
//
// To contact the author with suggestions or comments, use  :vlad.novick@gmail.com
//
////////////////////////////////////////////////////////////////////////////

namespace SGcombo.System
{
    /// <summary>
    ///  Using FileSystemWatcher to monitor a directory 
    /// </summary>
    public class FileSystemWatcherBase : IDisposable
    {

        private string WatchDirectory { get; set; }


        /// <summary>
        ///  Create  FileSystemWatcher to monitor a directory 
        /// </summary>
        /// <param name="watchDirectory"></param>
        public FileSystemWatcherBase(string watchDirectory)
        {

            WatchDirectory = watchDirectory;

            watcher = new FileSystemWatcher(watchDirectory);

            watcher.NotifyFilter = NotifyFilters.DirectoryName;

            watcher.Changed += new FileSystemEventHandler(OnChanged);
            watcher.Created += new FileSystemEventHandler(OnCreated);
            watcher.Deleted += new FileSystemEventHandler(OnDeleted);
            watcher.Renamed += new RenamedEventHandler(OnRenamed);

            watcher.EnableRaisingEvents = true;

        }

        ManualResetEvent oSignalEvent = new ManualResetEvent(false);

        private FileSystemWatcher watcher = null;

      

        /// <summary>
        ///  Change file
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        public virtual void OnChanged(object source, FileSystemEventArgs e)
        {

        }

        /// <summary>
        ///  Create file
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        public virtual void OnCreated(object source, FileSystemEventArgs e)
        {

        }

        /// <summary>
        ///  Delete file event
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        public virtual void OnDeleted(object source, FileSystemEventArgs e)
        {

        }
        /// <summary>
        ///  Rename file event
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        public virtual void OnRenamed(object source, RenamedEventArgs e)
        {

        }

        public void Dispose()
        {
            if (watcher != null)
            {
                watcher.Dispose();
                watcher = null;
            }
        }
    }
}
