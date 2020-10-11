using ExServer = Exiled.API.Features.Server;
using ExPlayer = Exiled.API.Features.Player;

namespace CuffedTK
{
    public static class RoleTypeHelper
    {
        public static bool CheckCuffedCase(ExPlayer victim, ExPlayer attacker)
        {
            RoleType victimRole = victim.Role;
            RoleType killerRole = attacker.Role;

            return (victimRole == RoleType.ClassD && killerRole.IsScientistTeam()) || (victimRole == RoleType.Scientist && killerRole.IsDClassTeam());
        }
        public static bool IsSCP(this RoleType role)
            => role.ToString().ToLower().Contains("scp");
        public static bool IsNtf(this RoleType role)
            => role.ToString().ToLower().Contains("ntf");
        public static bool IsDClassTeam(this RoleType role)
            => role == RoleType.ClassD || role == RoleType.ChaosInsurgency;
        public static bool IsScientistTeam(this RoleType role)
            => IsNtf(role) || role == RoleType.FacilityGuard || role == RoleType.Scientist;
        public static bool ValidHurt(this ExPlayer player, ExPlayer attacker)
            => player.IsCuffed && attacker != player && !attacker.Role.IsSCP();
    }
}
