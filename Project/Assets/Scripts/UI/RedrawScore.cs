using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SpaceShooter
{
    public class RedrawScore : MonoBehaviour
    {
        /// <summary>
        /// Текст для времени.
        /// </summary>
        [SerializeField] Text _timeTtext;

        /// <summary>
        /// Текст для очков.
        /// </summary>
        [SerializeField] Text _scoreTtext;

        /// <summary>
        /// Текст для убийств.
        /// </summary>
        [SerializeField] Text _killsTtext;

        /// <summary>
        /// Текст для жизней.
        /// </summary>
        [SerializeField] Text _livesTtext;

        /// <summary>
        /// Предыдущее время уровня.
        /// </summary>
        private int _previousLevelTime;

        /// <summary>
        /// Start запускается перед первым кадром.
        /// </summary>
        private void Start()
        {
            if (Player.Instance != null)
            {
                Player.Instance.ScoreChanged += PlayerOnScoreChanged;
                Player.Instance.KillsChanged += PlayerOnKillsChanged;
                Player.Instance.LivesCountChanged += PlayerOnLivesChanged;
                LevelController.Instance.LevelTimeChanged += PlayerOnTimeChanged;
                if (_timeTtext != null)
                {
                    _previousLevelTime = (int)LevelController.Instance.LevelTime;
                    _timeTtext.text = $"Время: {(_previousLevelTime / 60):00}:{(_previousLevelTime % 60):00}";
                }
                if (_scoreTtext != null) _scoreTtext.text = $"Очки: {Player.Instance.Score}";
                if (_killsTtext != null) _killsTtext.text = $"Убито: {Player.Instance.Kills}";
                if (_livesTtext != null) _livesTtext.text = $"Жизни: {Player.Instance.LivesCount}";
            }
        }

        private string TimeToString(int time)
        {
            return $"{(time / 60):00}:{(time % 60):00}";
        }

        private void PlayerOnTimeChanged(object sender, EventArgs e)
        {
            if(_timeTtext == null) return;
            int time = LevelController.Instance.LevelTime > 0 ? (int)LevelController.Instance.LevelTime : 0;
            if(time == _previousLevelTime) return;
            _previousLevelTime = time;
            _timeTtext.text = $"Время: {(_previousLevelTime / 60):00}:{(_previousLevelTime % 60):00}";
        }

        private void PlayerOnScoreChanged(object sender, EventArgs e)
        {
            if (_scoreTtext != null) _scoreTtext.text = $"Очки: {Player.Instance.Score}";
        }

        private void PlayerOnKillsChanged(object sender, EventArgs e)
        {
            if (_killsTtext != null) _killsTtext.text = $"Убито: {Player.Instance.Kills}";
        }

        private void PlayerOnLivesChanged(object sender, EventArgs e)
        {
            if (_livesTtext != null) _livesTtext.text = $"Жизни: {Player.Instance.LivesCount}";
        }

        private void OnDestroy()
        {
            if(Player.Instance != null) Player.Instance.ScoreChanged -= PlayerOnScoreChanged;
            if (Player.Instance != null) Player.Instance.KillsChanged -= PlayerOnKillsChanged;
            if (Player.Instance != null) Player.Instance.LivesCountChanged -= PlayerOnLivesChanged;
        }
    }
}
