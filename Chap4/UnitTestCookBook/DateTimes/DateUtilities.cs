using Microsoft.Extensions.Internal;

namespace Apress.UnitTests.DateTimes;

public class DateUtilities1
{
    private readonly ISystemClock _systemClock;
    public DateUtilities1(ISystemClock systemClock) 
    {
        _systemClock = systemClock;
    }

    public bool IsAfternoon()
    {
        return _systemClock.UtcNow.LocalDateTime.Hour > 12;
    }
}

public class DateUtilities2
{
    private readonly TimeProvider _timeProvider;
    public DateUtilities2(TimeProvider timeProvider)
    {
        _timeProvider = timeProvider;
    }

    public bool IsAfternoon()
    {
        return _timeProvider.GetLocalNow().Hour > 12;
    }
}
