namespace Lec04LibN
{
    public class Logger : ILogger
    {
        private static ILogger logger;
        private string nameSpace = "";
        private static object syncRoot = new object();
        private int count = 0;
        private string LogFileName = string.Format(@"{0}/LOG{1}.txt", Directory.GetCurrentDirectory(), DateTime.Now.ToString("yyyyMMdd-HH-mm-ss"));

        private Logger()
        {
            using (StreamWriter writer = File.AppendText(LogFileName))
            {
                writer.WriteLine(count.ToString("D6") + "-" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "-" + "INIT");
            }
        }

        public static ILogger create()
        {
            if (logger == null)
            {
                lock (syncRoot)
                {
                    if (logger == null)
                    {
                        logger = new Logger();
                    }
                }
            }
            return logger;
        }

        public void start(string title)
        {
            count++;

            nameSpace += title + ":";

            using (StreamWriter sw = File.AppendText(LogFileName))
            {
                sw.WriteLine(count.ToString("D6") + "-" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "-" + "STRT " + nameSpace);
            }
        }

        public void log(string message)
        {
            using (StreamWriter write = File.AppendText(LogFileName))
            {
                count++;
                write.WriteLine(count.ToString("D6") + "-" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "-" + "INFO " + nameSpace + " " + message);
            }
        }

        public void stop()
        {
            count++;

            if (nameSpace.Length >= 2)
            {
                nameSpace = nameSpace.Remove(nameSpace.Length - 2);
            }

            using (StreamWriter sw = File.AppendText(LogFileName))
            {
                sw.WriteLine(count.ToString("D6") + "-" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "-" + "STOP " + nameSpace);
            }
        }
    }
}