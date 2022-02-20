using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersimosMVC.Services.Utility
{
    public class MyLogger : ILogger
    {

        //singleton pattern example. Only one instance of this class can be instanciated 

        private static MyLogger instance;//singleton desing pattern.single instance of this class

        private static Logger logger;//static variable  to hold a single instance of the nLog logger.

        //single desing pattern - private contructor 
        private MyLogger()
        {
            

        }

        public static MyLogger GetInstance()
        {
            if (instance == null)
                instance = new MyLogger();
            return instance;
        }

        private Logger GetLogger (string theLogger)
        {
            if (MyLogger.logger == null)
                MyLogger.logger = LogManager.GetLogger(theLogger);
            return MyLogger.logger;
        }


        public void Debug(string message, string arg = null)
        {
            if (arg == null)
                GetLogger("myAppLoggersRules").Debug(message);
            else
                GetLogger("myAppLoggersRules").Debug(message, arg);
        }

        public void Error(string message, string arg = null)
        {
            if (arg == null)
                GetLogger("myAppLoggersRules").Error(message);
            else
                GetLogger("myAppLoggersRules").Error(message, arg);
        }

        public void Info(string message, string arg = null)
        {
            if (arg == null)
                GetLogger("myAppLoggersRules").Info(message);
            else
                GetLogger("myAppLoggersRules").Info(message, arg);
        }

        public void Warning(string message, string arg = null)
        {
            if (arg == null)
                GetLogger("myAppLoggersRules").Warn(message);
            else
                GetLogger("myAppLoggersRules").Warn(message, arg);
        }
    }
}