using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Xml.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

namespace SpaceShooter
{
    /// <summary>
    /// Генератор космических кораблей.
    /// </summary>
    public class EntitySpawnerShips : MonoBehaviour
    {
        /// <summary>
        /// Команда кораблей, которые создаёт генератор.
        /// </summary>
        [SerializeField] private int _shipsTeam;

        /// <summary>
        /// Префабы для генерации кораблей.
        /// </summary>
        [SerializeField] private Destructible[] _shipsPrefabs;

        /// <summary>
        /// Префабы для генерации ништяков.
        /// </summary>
        [SerializeField] private Powerup[] _powerupsPrefabs;

        /// <summary>
        /// 
        /// </summary>
        [SerializeField] private CircleArea _area;

        /// <summary>
        /// Количество кораблей, которые должны быть созданы.
        /// </summary>
        [SerializeField] private int _spawnCount;

        /// <summary>
        /// Список кораблей, размещённых на игровом поле.
        /// </summary>
        private Dictionary<GameObject, PolygonCollider2D> _spawnedShips;

        /// <summary>
        /// Зона патрулирования для вновь создаваемых кораблей.
        /// </summary>
        [SerializeField] private AiPatrolZone _zone;

        private void Awake()
        {
            _spawnedShips = new Dictionary<GameObject, PolygonCollider2D>();
        }

        /// <summary>
        /// Start запускается перед первым кадром.
        /// </summary>
        private void Start()
        {
            for (int i = 0; i < _spawnCount; i++)
            {
                SpawnShip(_shipsPrefabs);
            }
        }

        /// <summary>
        /// Размещение корабля на игровом поле.
        /// </summary>
        /// <param name="shipsPrefabs">Список префабов для размещения.</param>
        private void SpawnShip(Destructible[] shipsPrefabs)
        {
            //выбрать префаб корабля и создать корабль
            int index = Random.Range(0, shipsPrefabs.Length);
            GameObject ship = Instantiate(shipsPrefabs[index].gameObject);
            //задать команду корабля
            SpaceShip spaceShip = ship.GetComponent<SpaceShip>();
            spaceShip.TeamId = _shipsTeam;
            AiController controller = ship.GetComponent<AiController>();
            controller.SetPatrolZone(_zone);

            //задать случайную позицию корабля
            ship.transform.position = _area.GetRandomInsideArea();
            //добавить обработчик события уничтожения корабля
            ship.GetComponent<Destructible>().Destruction += OnShipDestruction;

            PolygonCollider2D collider2d = ship.GetComponentInChildren<PolygonCollider2D>();
            foreach (KeyValuePair<GameObject, PolygonCollider2D> pair in _spawnedShips)
            {
                Physics2D.IgnoreCollision(pair.Value, collider2d);
            }

            _spawnedShips.Add(ship, collider2d);
        }

        /// <summary>
        /// Обработка события уничтожения корабля.
        /// </summary>
        private void OnShipDestruction(GameObject gObject)
        {
            _spawnedShips.Remove(gObject);

            //создать на месте смерти корабля бонус с вероятностью 1/3
            if(_powerupsPrefabs != null && _powerupsPrefabs.Length > 0)
            {
                if (Random.value < 0.333333f)
                {
                    int index = Random.Range(0, _powerupsPrefabs.Length);
                    GameObject powerup = Instantiate(_powerupsPrefabs[index].gameObject);
                    powerup.transform.position = gObject.transform.position;
                }
            }

            gObject.GetComponent<Destructible>().Destruction -= OnShipDestruction;
            
            //при уничтожении корабля нужно создать новый корабль
            while (_spawnedShips.Count < _spawnCount)
            {
                SpawnShip(_shipsPrefabs);
            }
        }
    }
}
