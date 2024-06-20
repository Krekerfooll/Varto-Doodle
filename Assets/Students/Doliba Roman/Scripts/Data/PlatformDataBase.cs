using UnityEngine;
using RomanDoliba.Platform;

namespace RomanDoliba.Data
{
    [CreateAssetMenu(fileName = "PlatformDataBase", menuName = "MyData/PlatformsDataBase", order = 0)]
    public class PlatformDataBase : ScriptableObject
    {
        [SerializeField] private PlatformKeyPair[] _platforms;

        public bool TryGetPlatform(string key, out PlatformBase platform)
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
            public PlatformBase Platform;
        }
    }
}
