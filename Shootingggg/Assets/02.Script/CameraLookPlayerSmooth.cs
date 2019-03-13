using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLookPlayerSmooth : MonoBehaviour
{
    #region PublicField

    

    #endregion
    
    private Transform _playerTransform;
    
    private void Start()
    {
        _playerTransform = GameObject.FindWithTag ( nameof( GameManager.TagName.Player ) ).transform;
    }

    private void Update()
    {
        
    }
}
