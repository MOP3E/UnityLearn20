using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter
{
    public class PowerupVelocity : Powerup
    {
        /// <summary>
        /// ����������������� ��������� ��������.
        /// </summary>
        [SerializeField] private float _velocityTime;

        /// <summary>
        /// ���� ��������� ��������.
        /// </summary>
        [SerializeField] private float _velocityPower;

        protected override void OnPickup(SpaceShip ship)
        {
            ship.VelocityPowerupTimer += _velocityTime;
            ship.VelocityPowerup = _velocityPower;
        }
    }
}
