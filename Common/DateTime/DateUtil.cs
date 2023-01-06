using System.Globalization;

namespace Common.DateTime;
public static class DateUtil
{
    public static System.DateTime ShamsiToMiladi(string shamsiDate, string seperator = "/")
    {
        var parts = shamsiDate.Split(seperator);
        var year = Convert.ToInt32(parts[0]);
        var month = Convert.ToInt32(parts[1]);
        var day = Convert.ToInt32(parts[2]);
        return new System.DateTime(year, month, day, new PersianCalendar());
    }

    public static string MiladiToShamsi(this System.DateTime date, string seperator = "/")
    {
        var pc = new PersianCalendar();
        var year = pc.GetYear(date);
        var month = pc.GetMonth(date);
        var day = pc.GetDayOfMonth(date);
        var result = $"{year}{seperator}{month}{seperator}{day}";
        return result;
    }
}