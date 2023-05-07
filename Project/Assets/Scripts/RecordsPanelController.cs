using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SpaceShooter
{
    public class RecordsPanelController : MonoBehaviour
    {
        /// <summary>
        /// Окно главного меню.
        /// </summary>
        [SerializeField] private GameObject _mainMenu;

        /// <summary>
        /// Поле имени игрока окна рекордов.
        /// </summary>
        [SerializeField] private Text _name1;
        [SerializeField] private Text _name2;
        [SerializeField] private Text _name3;

        /// <summary>
        /// Поле очков окна рекордов.
        /// </summary>
        [SerializeField] private Text _score1;
        [SerializeField] private Text _score2;
        [SerializeField] private Text _score3;

        /// <summary>
        /// Поле времени окна результатов.
        /// </summary>
        [SerializeField] private Text _time1;
        [SerializeField] private Text _time2;
        [SerializeField] private Text _time3;

        /// <summary>
        /// Поле числа убийств окна результатов.
        /// </summary>
        [SerializeField] private Text _numKills1;
        [SerializeField] private Text _numKills2;
        [SerializeField] private Text _numKills3;

        /// <summary>
        /// Кнопка возврата в главное меню.
        /// </summary>
        public void OnReturnButton()
        {
            _mainMenu.gameObject.SetActive(true);
            gameObject.SetActive(false);
        }

        /// <summary>
        /// Вывод рекордов на экран.
        /// </summary>
        public void DrawRecords(List<PlayerStatistics> records)
        {
            if (records.Count > 0)
            {
                _name1.text = records[0].PlayerName;
                _score1.text = records[0].Score.ToString();
                _time1.text = TimeFormat(records[0].Time);
                _numKills1.text = records[0].Kills.ToString();
            }
            else
            {
                _name1.text = string.Empty;
                _score1.text = string.Empty;
                _time1.text = string.Empty;
                _numKills1.text = string.Empty;
            }

            if (records.Count > 1)
            {
                _name2.text = records[1].PlayerName;
                _score2.text = records[1].Score.ToString();
                _time2.text = TimeFormat(records[1].Time);
                _numKills2.text = records[1].Kills.ToString();
            }
            else
            {
                _name2.text = string.Empty;
                _score2.text = string.Empty;
                _time2.text = string.Empty;
                _numKills2.text = string.Empty;
            }

            if (records.Count > 2)
            {
                _name3.text = records[2].PlayerName;
                _score3.text = records[2].Score.ToString();
                _time3.text = TimeFormat(records[2].Time);
                _numKills3.text = records[2].Kills.ToString();
            }
            else
            {
                _name3.text = string.Empty;
                _score3.text = string.Empty;
                _time3.text = string.Empty;
                _numKills3.text = string.Empty;
            }
        }

        /// <summary>
        /// Форматирование времени прохождения игрока.
        /// </summary>
        private string TimeFormat(float timeFloat)
        {
            int time = (int)timeFloat;
            int seconds = time % 60;
            int minutes = (time / 60) % 60;
            int hours = time / 3600;
            return $"{hours:00}:{minutes:00}:{seconds:00}";
        }
    }
}
