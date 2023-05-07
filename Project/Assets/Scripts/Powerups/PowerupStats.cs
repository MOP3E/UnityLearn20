using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter
{
    /// <summary>
    /// ������� �������� �������.
    /// </summary>
    public enum PowerupEffect
    {
        AddAmmo,
        AddEnergy
    }

    public class PowerupStats : Powerup
    {
        /// <summary>
        /// ������, ������������� �� ������ ��� �������.
        /// </summary>
        [SerializeField] private PowerupEffect _effect;

        /// <summary>
        /// ���� �������.
        /// </summary>
        [SerializeField] private float _value;

        protected override void OnPickup(SpaceShip ship)
        {
            switch (_effect)
            {
                case PowerupEffect.AddAmmo:
                    ship.AddAmmo((int)_value);
                    break;
                case PowerupEffect.AddEnergy:
                    ship.AddEnergy((int)_value);
                    break;
            }
        }
    }
}
