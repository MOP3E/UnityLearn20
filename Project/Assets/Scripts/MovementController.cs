using System.Collections;
using System.Collections.Generic;
using SpaceShooter.UserControl;
using UnityEngine;

namespace SpaceShooter
{
    public class MovementController : ShipController
    {
        /// <summary>
        /// ��� ��������� ���������.
        /// </summary>
        [SerializeField] private ControlAxis _accelerationAxis;

        /// <summary>
        /// ��� ��������� ���������.
        /// </summary>
        public override ControlAxis AccelerationAxis => _accelerationAxis;

        /// <summary>
        /// ��� �������� ���������.
        /// </summary>
        [SerializeField] private ControlAxis _angularAccelerationAxis;

        /// <summary>
        /// ������ �������� �� ��������� ������.
        /// </summary>
        public override ControlAxis AngularAccelerationAxis => _angularAccelerationAxis;

        /// <summary>
        /// ������ �������� �� ��������� ������.
        /// </summary>
        [SerializeField] private ControlAxis _primaryFireButton;

        /// <summary>
        /// ������ �������� �� ��������� ������.
        /// </summary>
        public override ControlAxis PrimaryFireButton => _primaryFireButton;

        /// <summary>
        /// ������ �������� �� ���������� ������.
        /// </summary>
        [SerializeField] private ControlAxis _secondaryFireButton;

        /// <summary>
        /// ������ �������� �� ���������� ������.
        /// </summary>
        public override ControlAxis SecondaryFireButton => _secondaryFireButton;
    }
}
