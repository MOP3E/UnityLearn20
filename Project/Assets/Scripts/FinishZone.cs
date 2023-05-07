using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SpaceShooter
{
    public class FinishZone : MonoBehaviour
    {
        internal void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision == null) return;
            
            //получить корабль и проверить, является ли он кораблём игрока
            SpaceShip ship = collision.transform.root.GetComponentInChildren<SpaceShip>();
            if(ship == null || ship != Player.Instance.ActiveShip) return;
            
            //получить условие достижения финишной зоны и активировать его
            LevelConditionFinishZone condition = LevelController.Instance.transform.root.GetComponentInChildren<LevelConditionFinishZone>();
            if (condition != null) condition.IsCompleted = true;
        }
    }
}
