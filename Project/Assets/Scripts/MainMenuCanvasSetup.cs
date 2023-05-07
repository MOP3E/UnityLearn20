using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter
{
    public class MainMenuCanvasSetup : MonoBehaviour
    {
        /// <summary>
        /// Экран главного меню.
        /// </summary>
        [SerializeField] private GameObject _mainMenu;

        /// <summary>
        /// Экран выбора эпизода.
        /// </summary>
        [SerializeField] private GameObject _episodeSelection;

        /// <summary>
        /// Экран выбора корабля игрока.
        /// </summary>
        [SerializeField] private GameObject _shipSelection;

        /// <summary>
        /// Экран результатов игры.
        /// </summary>
        [SerializeField] private GameObject _result;

        /// <summary>
        /// Экран рекордов игры.
        /// </summary>
        [SerializeField] private GameObject _records;

        /// <summary>
        /// Start запускается перед первым кадром.
        /// </summary>
        private void Start()
        {
            _mainMenu.SetActive(true);
            _episodeSelection.SetActive(false);
            _shipSelection.SetActive(false);
            _result.SetActive(false);
            _records.SetActive(false);
        }

        /// <summary>
        /// Update запускается каждый кадр.
        /// </summary>
        private void Update()
        {
        
        }
    }
}
