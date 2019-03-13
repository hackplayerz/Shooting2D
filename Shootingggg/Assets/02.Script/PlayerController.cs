using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class PlayerController : MonoBehaviour
{
    #region PublicField

    [ SerializeField ] private float _speed;

    #endregion

    #region PrivateField

    private Rigidbody2D _rigidbody2D;
    private Animator _animator;

    #endregion

    private void Start()
    {
        _rigidbody2D = GetComponent < Rigidbody2D >();
        _animator = GetComponent < Animator >();
    }

    private void FixedUpdate()
    {
        Move();
    }
    
    /// <summary>
    /// Set Player movement
    /// </summary>
    private void Move()
    {
        float inputX = Input.GetAxis ( "Horizontal" );
        float inputY = Input.GetAxis ( "Vertical" );
        _rigidbody2D.position += new Vector2 ( inputX , inputY ) * Time.fixedDeltaTime * _speed;
        
        // Is Moving?
        if ( inputX.Equals ( 0 ) )
        {
            _animator.SetBool ( nameof(GameManager.PlayerAnimation.IsMove),false );
        }
        else
        {
            _animator.SetBool ( nameof(GameManager.PlayerAnimation.IsMove),true );
            if ( inputX < 0 )
            {
                transform.localScale = new Vector3(-1,1,1);
            }
            else if ( inputX > 0 )
            {
                transform.localScale = Vector3.one;
            }
        }
        
    }

}
