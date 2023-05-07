using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SpaceShooter
{
    public class InputNameController : MonoBehaviour
    {
        /// <summary>
        /// Поле ввода имени.
        /// </summary>
        [SerializeField] private InputField _inputNameField;

        /// <summary>
        /// Эпизод, с которого нужно начинать игру.
        /// </summary>
        public Episode Episode { get; set; }

        /// <summary>
        /// Start запускается перед первым кадром.
        /// </summary>
        private void Start()
        {
            _inputNameField.text = "Пилот";
        }

        /// <summary>
        /// Нажатие на кнопку "Далее".
        /// </summary>
        public void OnButtonPressed()
        {
            if(string.IsNullOrEmpty(_inputNameField.text)) return;

            //передать имя игрока в контроллер эпизода
            LevelSequenceController.Instance.PlayerName = _inputNameField.text;
            //запустить эпизод
            LevelSequenceController.Instance.EpisodeStart(Episode);
        }
    }
}
