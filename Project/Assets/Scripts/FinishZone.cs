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
            
            //�������� ������� � ���������, �������� �� �� ������� ������
            SpaceShip ship = collision.transform.root.GetComponentInChildren<SpaceShip>();
            if(ship == null || ship != Player.Instance.ActiveShip) return;
            
            //�������� ������� ���������� �������� ���� � ������������ ���
            LevelConditionFinishZone condition = LevelController.Instance.transform.root.GetComponentInChildren<LevelConditionFinishZone>();
            if (condition != null) condition.IsCompleted = true;
        }
    }
}
