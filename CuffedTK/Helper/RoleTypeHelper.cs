using ExServer = Exiled.API.Features.Server;
using ExPlayer = Exiled.API.Features.Player;

namespace CuffedTK
{
    internal static class RoleTypeHelper
    {
        internal static bool CheckCuffedCase(ExPlayer victim, ExPlayer attacker)
        {
            RoleType victimRole = victim.Role;
            RoleType killerRole = attacker.Role;

            return (victimRole == RoleType.ClassD && killerRole.IsScientistTeam()) || (victimRole == RoleType.Scientist && killerRole.IsDClassTeam());
        }
        internal static bool IsSCP(this RoleType role)
            => role.ToString().ToLower().Contains("scp");
        internal static bool IsNtf(this RoleType role)
            => role.ToString().ToLower().Contains("ntf");
        internal static bool IsDClassTeam(this RoleType role)
            => role == RoleType.ClassD || role == RoleType.ChaosInsurgency;
        internal static bool IsScientistTeam(this RoleType role)
            => IsNtf(role) || role == RoleType.FacilityGuard || role == RoleType.Scientist;
        internal static bool ValidHurt(this ExPlayer player, ExPlayer attacker)
            => player.IsCuffed && attacker != player && !attacker.Role.IsSCP();
    }
}
