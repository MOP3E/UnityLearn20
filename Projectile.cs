using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter
{
    /// <summary>
    /// Управление перемещением снаряда, проверка на попадание в объекты.
    /// </summary>
    public class Projectile : MonoBehaviour
    {
        /// <summary>
        /// Скорость снаряда.
        /// </summary>
        [SerializeField] private float _velocity;

        /// <summary>
        /// Снаряд имеет ограничение по времени жизни.
        /// </summary>
        [SerializeField] private bool _hasLifetime;

        /// <summary>
        /// Время жизни снаряда.
        /// </summary>
        [SerializeField] private float _lifetime;

        /// <summary>
        /// Снаряд имеет ограничение по расстоянию полёта.
        /// </summary>
        [SerializeField] private bool _hasLifeRadius;

        /// <summary>
        /// Радиус жизни снаряда.
        /// </summary>
        [SerializeField] private float _lifeRadius;

        /// <summary>
        /// Урон снаряда.
        /// </summary>
        [SerializeField] private int _damage;

        /// <summary>
        /// Префаб взрыва.
        /// </summary>
        [SerializeField] private GameObject _explodePrefab;

        /// <summary>
        /// Таймер времени жизни снаряда.
        /// </summary>
        private float _lifeTimer = 0;

        /// <summary>
        /// Родительский корабль.
        /// </summary>
        public Destructible ParentDestructible { get; set; }

        /// <summary>
        /// Идендификатор моей команды (для того, чтобы после смерти корабля игрока начислялись очки за попадание).
        /// </summary>
        private int _myTeamId;

        /// <summary>
        /// Мой предок - игрок (для того, чтобы после смерти корабля игрока начислялись очки за попадание).
        /// </summary>
        private bool _myParentIsPlayer;

        /// <summary>
        /// Начальная позиция снаряда.
        /// </summary>
        private Vector2 _startPosition;


        private void Start()
        {
            _startPosition = transform.position;
            //для того, чтобы после смерти корабля игрока начислялись очки за попадание
            _myTeamId = ParentDestructible.TeamId;
            _myParentIsPlayer = Player.Instance != null && Player.Instance.ActiveShip != null && ParentDestructible == Player.Instance.ActiveShip;
        }

        /// <summary>
        /// FixedUpdate запускается с фиксированным периодом.
        /// </summary>
        private void FixedUpdate()
        {
            float stepLength = Time.deltaTime * _velocity;
            Vector2 step = transform.up * stepLength;

            //уничтожение снаряда при попадании
            RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, stepLength);
            if (hit)
            {
                Destructible destructible = hit.collider.transform.root.GetComponent<Destructible>();
                if (destructible != null && destructible != ParentDestructible && destructible.TeamId != _myTeamId)
                {
                    if (destructible.Hit(_damage) && _myParentIsPlayer)
                    {
                        Player.Instance.ScoreAdd(destructible.ScoreValue);
                        Player.Instance.KillAdd();
                    }
                    OnProjectileDeath();
                    return;
                }
            }

            //уничтожение снаряда по истечении заданного времени
            if (_hasLifetime)
            {
                _lifeTimer += Time.fixedDeltaTime;
                if (_lifeTimer > _lifetime)
                {
                    OnProjectileDeath();
                    return;
                }
            }

            //уничтожение снаряда по прошествии заданного расстояния
            if (_hasLifeRadius)
            {
                if (_lifeRadius <= (_startPosition - (Vector2)transform.position).magnitude)
                {
                    OnProjectileDeath();
                    return;
                }
            }

            transform.position += new Vector3(step.x, step.y, 0);
        }

        /// <summary>
        /// Завершение жизни снаряда.
        /// </summary>
        private void OnProjectileDeath()
        {
            //создать эффект взрыва
            if (_explodePrefab != null)
            {
                ParticleSystem explode = Instantiate(_explodePrefab, transform.position, Quaternion.identity).GetComponent<ParticleSystem>();
                explode.Play();
            }

            Destroy(gameObject);
        }
    }
}
