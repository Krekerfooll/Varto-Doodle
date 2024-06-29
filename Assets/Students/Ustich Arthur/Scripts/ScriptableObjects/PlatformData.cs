using UnityEngine;

namespace Ustich.Arthur.DoodleJump
{
    [CreateAssetMenu(fileName = "PlatformType", menuName = "Ustich/PlatformType", order = 1)]
    public class PlatformData : ScriptableObject
    {
        [SerializeField] private GameObject _objectPrefab;
        [SerializeField] private PlatformType _platformType;
        [SerializeField] private ExecutorBaseSO _executorBaseSO;
    }
}