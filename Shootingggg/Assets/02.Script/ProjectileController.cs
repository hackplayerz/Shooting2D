using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ProjectileController : MonoBehaviour
{
     private Rigidbody2D _rigidbody2D;
     [ HideInInspector ] public Vector2 Direction;
     private float _speed;
     private float _lifeTime;
     private Vector2 _playerVelocity;
     
     private void OnEnable()
     {
          _speed = GameManager.Instance.BulletSpeed;
          _rigidbody2D = GetComponent < Rigidbody2D >();
          StartCoroutine ( Move() );
     }

     IEnumerator Move()
     {
          while ( enabled )
          {
               _lifeTime += Time.fixedDeltaTime;
               _rigidbody2D.position += Direction * _speed * Time.fixedDeltaTime;
               yield return new WaitForEndOfFrame();
               if ( _lifeTime > GameManager.Instance.BulletLifeTime )
               {
                    gameObject.SetActive ( false );
                    _lifeTime = 0;
               }
          }
     }
}
