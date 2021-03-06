﻿namespace Dime.Logging.Log4net
{
    using log4net;
    using log4net.Appender;
    using log4net.Layout;
    using log4net.Repository.Hierarchy;

    public class LogFactory
    {
        // Set the level for a named logger
        public static void SetLevel(string loggerName, string levelName)
        {
            ILog log = LogManager.GetLogger(loggerName);
            Logger l = (Logger)log.Logger;

            l.Level = l.Hierarchy.LevelMap[levelName];
        }

        // Add an appender to a logger
        public static void AddAppender(string loggerName, IAppender appender)
        {
            ILog log = LogManager.GetLogger(loggerName);
            Logger l = (Logger)log.Logger;

            l.AddAppender(appender);
        }

        // Create a new file appender
        public static IAppender CreateFileAppender(string name, string fileName)
        {
            FileAppender appender = new FileAppender { Name = name, File = fileName, AppendToFile = true };
            PatternLayout layout = new PatternLayout { ConversionPattern = "%d [%t] %-5p %c [%x] - %m%n" };
            layout.ActivateOptions();

            appender.Layout = layout;
            appender.ActivateOptions();

            return appender;
        }

        // Create a new file appender
        public static IAppender CreateAdoNetAppender()
        {
            AdoNetAppender appender = new AdoNetAppender();
            PatternLayout layout = new PatternLayout { ConversionPattern = "%d [%t] %-5p %c [%x] - %m%n" };
            layout.ActivateOptions();

            appender.Layout = layout;
            appender.ActivateOptions();

            return appender;
        }
    }
}