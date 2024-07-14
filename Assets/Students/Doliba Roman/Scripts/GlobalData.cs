using UnityEngine;

public class GlobalData
{
    public const string LAST_PLATFORM_SPAWNED_POSITION = "LAST_PLATFORM_SPAWNED_POSITION";
    public const string SPAWNED_PLATFORMS = "SPAWNED_PLATFORMS";
    public static readonly Vector2 PlatformsSpawnBounds = new Vector2(3, -3);
    public const string PLAYER_POSITION = "PLAYER_POSITION";
    public const float PlayerJumpPower = 12f;
    public const float PlayerMoveSpeed = 7f;
}
