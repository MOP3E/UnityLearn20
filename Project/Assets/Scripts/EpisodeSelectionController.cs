using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SpaceShooter
{
    public class EpisodeSelectionController : MonoBehaviour
    {
        /// <summary>
        /// Эпизод.
        /// </summary>
        [SerializeField] private Episode _episode;

        /// <summary>
        /// Наименование эпизода.
        /// </summary>
        [SerializeField] private Text _episodeName;

        /// <summary>
        /// Картинка предпосмотра эпизода.
        /// </summary>
        [SerializeField] private Image _previewImage;

        /// <summary>
        /// Экран ввода имени игрока.
        /// </summary>
        [SerializeField] private GameObject _nameInput;

        /// <summary> 
        /// Start запускается перед первым кадром.
        /// </summary>
        private void Start()
        {
            if (_episodeName != null) _episodeName.text = _episode.Name;
            if (_previewImage != null) _previewImage.sprite = _episode.PreviewImage;
        }

        public void OnStartEpisodeButton()
        {
            _nameInput.GetComponent<InputNameController>().Episode = _episode;
            _nameInput.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
