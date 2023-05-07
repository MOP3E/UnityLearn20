using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter
{
    public class MainMenuController : MonoSingleton<MainMenuController>
    {
        /// <summary>
        /// Экран выбора эпизода.
        /// </summary>
        [SerializeField] private GameObject _episodeSelection;

        /// <summary>
        /// Экран выбора корабля игрока.
        /// </summary>
        [SerializeField] private GameObject _shipSelection;

        /// <summary>
        /// Экран рекордов.
        /// </summary>
        [SerializeField] private GameObject _records;

        /// <summary>
        /// Корабль игрока по умолчанию.
        /// </summary>
        [SerializeField] private SpaceShip _defaultSpaceShip;

        private void Start()
        {
            LevelSequenceController.PlayerShip = _defaultSpaceShip;
        }

        /// <summary>
        /// Кнопка включение панели выбора эпизода.
        /// </summary>
        public void OnStartNewButton()
        {
            _episodeSelection.gameObject.SetActive(true);
            gameObject.SetActive(false);
        }

        /// <summary>
        /// Кнопка включение панели выбора корабля.
        /// </summary>
        public void OnShipSelectButton()
        {
            _shipSelection.SetActive(true);
            gameObject.SetActive(false);
        }

        /// <summary>
        /// Кнопка включение панели выбора корабля.
        /// </summary>
        public void OnRecordTableButton()
        {
            _records.GetComponent<RecordsPanelController>().DrawRecords(LevelSequenceController.Instance.Records);
            _records.SetActive(true);
            gameObject.SetActive(false);
        }

        public void OnExitButton()
        {
            Application.Quit();
        }
    }
}
