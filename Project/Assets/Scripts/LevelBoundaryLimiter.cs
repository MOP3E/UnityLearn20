using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter
{
    public class LevelBoundaryLimiter : MonoBehaviour
    {
        //кэшированные параметры границы уровня
        private Vector2 _boundaryPosition;
        private float _boundaryRadius;
        private BoundaryMode _boundaryMode;

        private void Start()
        {
            if (LevelBoundary.Instance == null) return;
            _boundaryPosition = LevelBoundary.Instance.transform.position;
            _boundaryRadius = LevelBoundary.Instance.Radius;
            _boundaryMode = LevelBoundary.Instance.Mode;
        }

        /// <summary>
        /// Update запускается каждый кадр.
        /// </summary>
        private void Update()
        {
            if(LevelBoundary.Instance == null) return;
            
            Vector2 shipPosition = transform.position;
            Vector2 localShipPosition = shipPosition - _boundaryPosition;


            if (localShipPosition.magnitude > _boundaryRadius)
            {
                switch (_boundaryMode)
                {
                    case BoundaryMode.Wall:
                        transform.position = (localShipPosition.normalized * _boundaryRadius) + _boundaryPosition;
                        break;
                    case BoundaryMode.Teleport:
                        transform.position = (-localShipPosition.normalized * _boundaryRadius) + _boundaryPosition;
                        break;
                }
            }
        }
    }
}
