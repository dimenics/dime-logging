﻿using log4net.Core;
using log4net.Layout.Pattern;
using System.IO;
using System.Web;

namespace Dime.Logging
{
    public class HttpContextUserPatternConverter : PatternLayoutConverter
    {
        protected override void Convert(TextWriter writer, LoggingEvent loggingEvent)
        {
            string name = "";
            HttpContext context = HttpContext.Current;
            if (context != null && context.User != null && context.User.Identity.IsAuthenticated)
            {
                name = context.User.Identity.Name;
            }

            writer.Write(name);
        }
    }
}