using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp9CronScheduledBackgroudService.Server.BGService.Repository;

namespace WebApp9CronScheduledBackgroudService.Server.BGService.CronExtension
{
    public enum RecurringJob
    {
        Once = 1,
        Daily,
        Weekly,
    }
    public static class CronExtension
    {
        //public static int TIME_RANGE { get; set; } = 15;

        //private static int ZERO_SECOND = 0;

        public static bool v2CompareCron(this DateTime timeNow, string cronExpression)
        {
            bool result = false;

            //      0       1     2     3           4
            //$"{minute} {hour} {day} {month} {dayOfWeek}";
            string once = timeNow.ToCron(recurringJob: RecurringJob.Once);

            string daily = timeNow.ToCron(recurringJob: RecurringJob.Daily);
            string weekly = timeNow.ToCron(recurringJob: RecurringJob.Weekly);

            if (once == cronExpression)
            {
                return !result;
            }
            if (daily == cronExpression)
            {
                return !result;
            }
            if (weekly == cronExpression)
            {
                return !result;
            }

            return result;
        }




        //public static bool CompareCron(this DateTime timeNow, string cronExpression)
        //{
        //    bool result = false;

        //    //      0       1     2     3           4
        //    //$"{minute} {hour} {day} {month} {dayOfWeek}";
        //    string[] splited = SplitToCronArray(cronExpression);

        //    int cronMinute = int.Parse(splited[0]); int cronHour = int.Parse(splited[1]);
        //    DateTime cronDateTime = new DateTime(timeNow.Year, timeNow.Month, timeNow.Day, cronHour, cronMinute, ZERO_SECOND);

        //    if (IsEveryWeek(splited[4]) && IsEveryDay(splited[2], splited[3]))
        //    {
        //        if (IsThatDayOfWeek(timeNow.DayOfWeek, splited[4]))
        //        {
        //            return Includes(timeNow, cronDateTime);
        //        }
        //    }

        //    if (IsEveryDay(splited[2], splited[3]) == IsAnyValue(splited[4]))
        //    {
        //        return Includes(timeNow, cronDateTime);
        //    }

        //    return result;
        //}

        //private static string[] SplitToCronArray(string cronExpression)
        //{
        //    return cronExpression.Split(' ');
        //}

        //private static bool IsEveryWeek(string splited)
        //{
        //    return splited != "*";
        //}

        //private static bool Includes(DateTime timeNow, DateTime startCronDateTime)
        //{
        //    //DateTime endTime = startCronDateTime.AddSeconds(TIME_RANGE);
        //    //return (startCronDateTime <= timeNow) && (timeNow <= endTime);

        //    //with status Complated
        //    DateTime endTime = startCronDateTime.AddSeconds(59);
        //    return (startCronDateTime <= timeNow) && (timeNow <= endTime);
        //}
        //private static bool IsEveryDay(string dayOfMonth, string month)
        //{
        //    return IsAnyValue(dayOfMonth) == IsAnyValue(month);
        //}

        //private static bool IsAnyValue(string splited)
        //{
        //    return splited == "*";
        //}

        public static string ToCron(this DateTime time, RecurringJob recurringJob = RecurringJob.Daily, string dayWeek = null)
        {
            int minute = time.Minute;
            int hour = time.Hour;
            string day = time.Day.ToString();
            string month = time.Month.ToString();
            string dayOfWeek = ((int)time.DayOfWeek).ToString();

            SelectedTypeOfJob(recurringJob, ref day, ref month, ref dayOfWeek);

            return $"{minute} {hour} {day} {month} {dayOfWeek}";
        }

        private static void SelectedTypeOfJob(RecurringJob recurringJob, ref string day, ref string month, ref string dayOfWeek)
        {
            switch (recurringJob)
            {
                case RecurringJob.Once:
                    break;
                case RecurringJob.Daily:
                    dayOfWeek = "*";
                    month = "*";
                    day = "*";
                    break;
                case RecurringJob.Weekly:
                    month = "*";
                    day = "*";
                    break;
                default:
                    break;
            }
        }

        //private static bool IsThatDayOfWeek(DayOfWeek dayOfWeekNow, string cronDayOfWeek)
        //{
        //    int dayOfWeek = 0;
        //    bool isDayOfWeek = int.TryParse(cronDayOfWeek, out dayOfWeek);
        //    if (isDayOfWeek && (int)dayOfWeekNow == dayOfWeek)
        //    {
        //        return true;
        //    }
        //    return false;
        //}
        public static bool v2CheckStatusCompleted(this Promotions prom, DateTime timeNow)
        {          
            //if (prom.CompletedToday == true)
            //{
            //    prom.CompletedToday = v2ChangeStatus(prom.Cron);
            //}
            if (prom.CompletedToday)
            {
                return v2CheckingStatus(timeNow, prom.Cron);
            }

            return true;
        }
        //public static bool CheckStatusComplated(this Promotions prom)
        //{
        //    if (prom.CompletedToday)
        //    {
        //        return CheckingStatus(prom.Cron);
        //    }

        //    return true;
        //}

        //public static bool CheckingStatus(string cronExpression)
        //{
        //    DateTime timeNow = DateTime.Now;
        //    //      0       1     2     3           4
        //    //$"{minute} {hour} {day} {month} {dayOfWeek}";
        //    string[] splited = SplitToCronArray(cronExpression);

        //    int cronMinute = int.Parse(splited[0]); int cronHour = int.Parse(splited[1]);
        //    DateTime cronDateTime = new DateTime(timeNow.Year, timeNow.Month, timeNow.Day, cronHour, cronMinute, ZERO_SECOND);

        //    if (IsEveryWeek(splited[4]) && IsEveryDay(splited[2], splited[3]))
        //    {
        //        if (IsThatDayOfWeek(timeNow.DayOfWeek, splited[4]))
        //        {
        //            return false;
        //        }
        //    }

        //    if (IsEveryDay(splited[2], splited[3]) == IsAnyValue(splited[4]))
        //    {
        //        if (timeNow > cronDateTime)
        //        {
        //            return false;
        //        }
        //    }
        //    return true;
        //}

        public static bool v2ChangeStatus(DateTime timeNow, string cronExpression)
        {
            string once = timeNow.ToCron(recurringJob: RecurringJob.Once);

            string daily = timeNow.ToCron(recurringJob: RecurringJob.Daily);
            string weekly = timeNow.ToCron(recurringJob: RecurringJob.Weekly);
            bool statusHasDone = true;

            //      0       1     2     3           4
            //$"{minute} {hour} {day} {month} {dayOfWeek}";

            if (once != cronExpression)
            {
                statusHasDone = false;
            }

            if (weekly != cronExpression)
            {
                statusHasDone = false;
            }
            if (daily != cronExpression)
            {
                statusHasDone = false;
            }
            return statusHasDone;
        }

        public static bool v2CheckingStatus(DateTime timeNow, string cronExpression)
        {
            var once = timeNow.ToCron(RecurringJob.Once);
            var daily = timeNow.ToCron(RecurringJob.Daily);
            var weekly = timeNow.ToCron(RecurringJob.Weekly);

            //      0       1     2     3           4
            //$"{minute} {hour} {day} {month} {dayOfWeek}";

            if (once == cronExpression)
            {
                Console.WriteLine("Once");
                return false;
            }
            
            if (daily == cronExpression)
            {
                Console.WriteLine("Daily");
                return false;
            }

            if (weekly == cronExpression)
            {
                Console.WriteLine("Weekly");
                return false;
            }
            return true;
        }

    }
}
