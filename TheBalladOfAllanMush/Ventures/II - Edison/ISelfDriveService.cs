using TheBalladOfAllanMush.Ventures.II___Edison.Models;

namespace TheBalladOfAllanMush.Ventures.II___Edison
{
    public interface ISelfDriveService
    {
        Task AccelerateToSpeed(int targetSpeed);
        Task<Direction> EvadePedestrian(Pedestrian pedestrian);
    }
}