using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SpaceShooter
{
    public class PauseMenuController : MonoBehaviour
    {
        /// <summary>
        /// Start запускается перед первым кадром.
        /// </summary>
        private void Start()
        {
            gameObject.SetActive(false);
        }

        /// <summary>
        /// Нажатие на кнопку паузы.
        /// </summary>
        public void OnPauseButtonPressed()
        {
            Time.timeScale = 0;
            gameObject.SetActive(true);
        }

        /// <summary>
        /// Нажатие на кнопку продолжения игры.
        /// </summary>
        public void OnContinueButtonPressed()
        {
            gameObject.SetActive(false);
            Time.timeScale = 1;
        }

        /// <summary>
        /// Нажатие на кнопку главного меню.
        /// </summary>
        public void OnMainMenuButtonPressed()
        {
            gameObject.SetActive(false);
            Time.timeScale = 1;
            SceneManager.LoadScene(LevelSequenceController.MainMenuSceneName);
        }
    }
}
