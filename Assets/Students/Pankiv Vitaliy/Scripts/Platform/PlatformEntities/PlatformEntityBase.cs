using PVitaliy.Factory;
using UnityEngine;

namespace PVitaliy.Platform.Entities
{
    public class PlatformEntityBase : FactoryObject<PlatformEntityType>
    {
        [SerializeField] private PlatformEntityType type;

        public override PlatformEntityType Type()
        {
            return type;
        }
    }
}