    public static class Logger
    {
        public static void LogToDebugTraceFile(string file, string message)
        {
            try
            {
                string path = "C:\\" + "AuditRunner\\" + "log\\";
                string debugTraceFile = file + "_" + DateTime.Now.ToShortDateString().Replace("/", "_") + ".txt";
                FileInfo filepath = new FileInfo(path);
                if (filepath.Directory != null)
                    filepath.Directory.Create(); // If the directory already exists, this method does nothing.
                using (StreamWriter outputFile = new StreamWriter(path + debugTraceFile, true))
                {
                    outputFile.WriteLine(string.Format("{0} {1} : {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToLongTimeString(), message));
                }
            }
            catch (Exception e)
            {
                string ex = e.Message;
            }
        }

        public static void LogException(string file, Exception exception)
        {
            try
            {
                string path = "C:\\" + "AuditRunner\\" + "log\\";
                string debugTraceFile = file + "_" + DateTime.Now.ToShortDateString().Replace("/", "_") + ".txt";
                using (StreamWriter outputFile = new StreamWriter(path + debugTraceFile, true))
                {
                    outputFile.WriteLine(string.Format("{0} {1} : {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToLongTimeString(), exception));
                }
            }
            catch (Exception e)
            {
                string ex = e.Message;
            }
        }
    }
