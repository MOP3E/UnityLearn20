using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter
{
    public class LevelConditionScore : MonoBehaviour, ILevelCondition
    {
        /// <summary>
        /// Очки, которых нужно достичь для выполненния условия завершени уровня.
        /// </summary>
        [SerializeField] private int _score;

        /// <summary>
        /// Условие завершения уровня выполнено.
        /// </summary>
        public bool IsCompleted => Player.Instance != null && Player.Instance.ActiveShip != null && Player.Instance.Score >= _score;
    }
}
