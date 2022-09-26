namespace Deliveriamo.DTOs.Enums
{
    public enum OrderStatus
    {
        WaitingForApproval,
        Accepted,
        Rejected,
        Completed,
        Canceled
    }

    public static class Converter
    {
        public static T ToEnum<T>(this string value)
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }
    }
}
