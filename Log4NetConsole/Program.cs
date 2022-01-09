using log4net;
using log4net.Config;
using System;
using System.IO;
using System.Reflection;
using System.Security.Principal;

namespace Log4NetConsole
{
    class Program
    {
        private static log4net.ILog Log = log4net.LogManager.GetLogger(typeof(Program));
        static void Main(string[] args)
        {
            //Testing();
            Fileappender();
            //ConsoleAppender(); //This works fine for Console appender
        }

        internal static void Testing()
        {
            Console.WriteLine("hellow world!.");
            Log.Info("Main method execution started");
            try
            {
                Log.Info("Hello World!");
                Log.Info("try block executed");
            }
            catch (Exception ex)
            {

                Log.Error(ex);
            }
            finally
            {
                Log.Info("Finally block executed");
            }
            Log.Info("Test method execution completed");
        }

        internal static void Fileappender()
        {
            log4net.Config.XmlConfigurator.Configure();
            ILog logFileappender = LogManager.GetLogger(typeof(Program));
            logFileappender.Info("here we go!");
            logFileappender.Debug("debug afasf");
            logFileappender.Error("This is Error message");

            //log4net.Config.BasicConfigurator.Configure();
            //log4net.ILog log = log4net.LogManager.GetLogger(typeof(Program));
            //try
            //{
            //    string str = String.Empty;
            //    string subStr = str.Substring(0, 4);
            //}
            //catch (Exception ex)
            //{

            //    log.Error("Error Message: " + ex.Message.ToString(), ex);
            //}
        }

        private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private static void ConsoleAppender()
        {
            try
            {
                // Load configuration
                var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
                XmlConfigurator.Configure(logRepository, new FileInfo("App.config"));

                Console.WriteLine("Hello world!");

                // Log some things
                Logger.Info("Hello logging world!");
                Logger.Error("Error!");
                Logger.Warn("Warn!");
                throw new Exception();
                Console.ReadLine();
            }
            catch (Exception ex)
            {

                Logger.Error("Error message:" + ex.Message.ToString());
            }


        }
    }
}
