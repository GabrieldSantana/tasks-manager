
namespace Application.Services.Global;
public static class UtilityService
{
    public static bool GreaterThanZero(int id)
    {
        if (id > 0) { return true; } else { return false; }
    }
}
