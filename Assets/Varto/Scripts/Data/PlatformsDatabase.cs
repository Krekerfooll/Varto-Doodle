using UnityEngine;
using Varto.Examples.Platforms;

namespace Varto.Examples.Data
{
    [CreateAssetMenu(fileName = "PlatformsDatabase", menuName = "Varto/PlatformsDatabase", order = -1)]
    public class PlatformsDatabase : ScriptableObject
    {
        [SerializeField] private PlatformKeyPair[] _platforms;

        public bool TryGetPlatform(string key, out Varto_Platform platform)
        {
            for (int i = 0; i < _platforms.Length; i++)
            {
                if (_platforms[i].Key == key)
                {
                    platform = _platforms[i].Platform;
                    return true;
                }
            }

            platform = null;
            return false;
        }

        [System.Serializable]
        public struct PlatformKeyPair
        {
            public string Key;
            public Varto_Platform Platform;
        }
    }
}
