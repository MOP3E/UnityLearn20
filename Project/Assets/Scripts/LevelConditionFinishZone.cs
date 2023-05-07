using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter
{
    public class LevelConditionFinishZone : MonoBehaviour, ILevelCondition
    {
        /// <summary>
        /// Условие завершения уровня выполнено.
        /// </summary>
        public bool IsCompleted { get; set; }
    }
}
