using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SpaceShooter
{
    public class PlayerShipSelectionController : MonoBehaviour
    {
        /// <summary>
        /// Панель главного меню.
        /// </summary>
        [SerializeField] private GameObject _mainMenu;

        /// <summary>
        /// Префаб космического корабля.
        /// </summary>
        [SerializeField] private SpaceShip _spaceShipPrefab;

        /// <summary>
        /// Наименование Космического корабля.
        /// </summary>
        [SerializeField] private Text _shipName;

        /// <summary>
        /// Картинка предпосмотра космического корабля.
        /// </summary>
        [SerializeField] private Image _previewImage;

        /// <summary>
        /// Наименование Космического корабля.
        /// </summary>
        [SerializeField] private Text _hitpoints;

        /// <summary>
        /// Наименование Космического корабля.
        /// </summary>
        [SerializeField] private Text _speed;

        /// <summary>
        /// Наименование Космического корабля.
        /// </summary>
        [SerializeField] private Text _agility;

        /// <summary> 
        /// Start запускается перед первым кадром.
        /// </summary>
        private void Start()
        {
            if (_spaceShipPrefab != null)
            {
                if (_previewImage != null) _previewImage.sprite = _spaceShipPrefab.PreviewImage;
                if (_shipName != null) _shipName.text = _spaceShipPrefab.Nickname;
                if (_hitpoints != null) _hitpoints.text = $"ПРОЧ: {_spaceShipPrefab.MaxHitpoints}";
                if (_speed != null) _speed.text = $"СКОР: {_spaceShipPrefab.Acceleration}";
                if (_agility != null) _agility.text = $"МНВР: {_spaceShipPrefab.AngularAcceleration}";
            }
        }

        public void OnSelectShipButton()
        {
            if(_spaceShipPrefab != null) LevelSequenceController.PlayerShip = _spaceShipPrefab;
            _mainMenu.SetActive(true);
            transform.parent.gameObject.SetActive(false);
        }
    }
}
