using UnityEngine;

namespace OIMOD.Core.Component
{
    public class OI_AddScoreAction : OI_ActionBase
    {
        [SerializeField] private int bonus;
        protected override void ExecuteInternal()
        {
            var gameData = transform.GetComponent<OI_CollectableCore>()._gameData;
            gameData.bonusScore += bonus;
        }
    }
}


