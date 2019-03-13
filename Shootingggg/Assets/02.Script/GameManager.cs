using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
     #region Singleton

     private static GameManager _instance;

     public static GameManager Instance => _instance;

     #endregion

     #region Public field
     
     [Header("Set Prefab")]
     public GameObject BulletPrefab;
     public Transform BulletContainer;

     [ Header ( "Set Projectile Option" ) ]
     [ Tooltip ( "Speed of Bullet" ) ] [ Range ( 0 , 10f ) ]
     public float BulletSpeed;
     [Tooltip("Between as Shoot Time")]
     public float ShootBetweenTime;
     [Tooltip("Time as bullet servive time")]
     public float BulletLifeTime;
     [ Range ( 0,45 ) ] public int SpreadDegree;
     
     #endregion

     #region GameData
     
     [HideInInspector]
     public List <GameObject> Bullets = new List < GameObject >();

     #endregion

     #region Name

     public enum TagName
     {
          Player,
          Monster
     }
     public enum ShootMode
     {
          Horizon,
          Spread
     }
     
     public enum PlayerAnimation
     {
           IsMove
     }
     
     #endregion
     
     private void Awake()
     {
          _instance = GetComponent < GameManager >();
     }
}
