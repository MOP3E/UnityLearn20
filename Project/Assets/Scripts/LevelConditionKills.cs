using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter
{
    public class LevelConditionKills : MonoBehaviour, ILevelCondition
    {
        /// <summary>
        /// Очки, которых нужно достичь для выполненния условия завершени уровня.
        /// </summary>
        [SerializeField] private int _kills;

        /// <summary>
        /// Условие завершения уровня выполнено.
        /// </summary>
        public bool IsCompleted => Player.Instance != null && Player.Instance.ActiveShip != null && Player.Instance.Kills >= _kills;
    }
}
