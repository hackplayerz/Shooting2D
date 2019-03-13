
using UnityEngine;

delegate void ShootMode();

public class ShootController : MonoBehaviour
{
     private float _deltaTime;
     private int _bulletIndex;
     private ShootMode _shotMode;

     #region MainProcess

     private void Start()
     {
          PushBullet ( 2 );
          _shotMode = ShootHorizon;
     }

     private void Update()
     {
          _deltaTime += Time.fixedDeltaTime;
          ModeChange();
          if ( Input.GetKey ( KeyCode.Z ) )
          {
               if ( _deltaTime > GameManager.Instance.ShootBetweenTime )
               {
                    Shot();
                    _deltaTime = 0;
               }
          }
     }
     
     // End of MainProcess
     #endregion
     
     #region SetMode
     
     /// <summary>
     /// Shot Mode Change
     /// </summary>
     void ModeChange()
     {
          if ( Input.GetKeyDown ( KeyCode.Alpha1 ) )
          {
               _shotMode = ShootHorizon;
               Debug.Log ( "Mode1" );
          }
          else if ( Input.GetKeyDown ( KeyCode.Alpha2 ) )
          {
               _shotMode = ShootSpread;
               Debug.Log ( "Mode2" );
          }
     }
     
     /// <summary>
     /// Horizon mode
     /// </summary>
     void ShootHorizon()
     {
          SetDirectionAsBullet ( GameManager.Instance.Bullets[_bulletIndex],Vector2.right );
          GameManager.Instance.Bullets[_bulletIndex].SetActive ( true );
          _bulletIndex++;
          CheckCanPooling();
     }

     /// <summary>
     /// Spread Mode
     /// </summary>
     void ShootSpread()
     {
          for ( int i = -1; i <=1 ; i++ )
          {
               // Setting Bullet's direction
               Vector2 direction = new Vector2(1,Mathf.Sin(GameManager.Instance.SpreadDegree * Mathf.Deg2Rad * i)).normalized; 
               SetDirectionAsBullet ( GameManager.Instance.Bullets[ _bulletIndex ] , direction );
               
               GameManager.Instance.Bullets[_bulletIndex].SetActive ( true );
               _bulletIndex++;
               CheckCanPooling();
          }

     }
     
     //End of SetMode
     #endregion

     #region BulletControl

     /// <summary>
     /// Push new bullet in Container as ObjectPushing
     /// </summary>
     /// <param name="count">count of new bullet</param>
     void PushBullet(int count)
     {
          for ( int i = 0; i < count; i++ )
          {
               GameObject newBullet = Instantiate ( GameManager.Instance.BulletPrefab, transform.position,Quaternion.identity );
               GameManager.Instance.Bullets.Add ( newBullet );
               newBullet.SetActive ( false );
               newBullet.transform.parent = GameManager.Instance.BulletContainer.transform;
          }
          Debug.Log ( "Push Complete" );
     }
     
     /// <summary>
     /// Shoot Bullet
     /// </summary>
     void Shot()
     {
          Debug.Log ( "Shot " + _shotMode.Method.Name );
          // Shoot
          _shotMode();
     }
     /// <summary>
     /// Set Direction of bullet to direct
     /// </summary>
     /// <param name="bullet">To change bullet object</param>
     /// <param name="direction">Direction of to move</param>
     void SetDirectionAsBullet(GameObject bullet, Vector2 direction)
     {
          bullet.GetComponent < ProjectileController >().Direction = direction * transform.localScale.x;
          bullet.transform.position = transform.position;
     }
     
     /// <summary>
     /// If no more can shooting bullet, instantiate new bullet
     /// </summary>
     void CheckCanPooling()
     {
          // Pool the Bullet at the Container
          if ( _bulletIndex >= GameManager.Instance.Bullets.Count-1 )
          {
               if ( GameManager.Instance.Bullets[ 0 ].activeInHierarchy )
               { // If First Bullet is Active, Push New Bullet
                    PushBullet ( 3 );
               }
               else
               {
                    _bulletIndex = 0;
               }
          }
     }
     
     // End of bulletControl
     #endregion
}
