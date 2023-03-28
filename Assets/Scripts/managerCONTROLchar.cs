using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class managerCONTROLchar : MonoBehaviour
{
    private CharacterController _charControll;
    private float inputX;
    private float inputZ;
    private Vector3 v_movement;
    private float moveSpeed;

    private Animator _animator;

    private GameObject _mainCamera;


    private Transform meshPlayer;
    private void Awake()
        {
            // get a reference to our main camera
            if (_mainCamera == null)
            {
                _mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
            }
        }
    void Start()
    {
        moveSpeed = 0.06f;
        GameObject tempPlayer = GameObject.FindGameObjectWithTag("Player");
        meshPlayer = tempPlayer.transform.GetChild(0);
        _charControll = tempPlayer.GetComponent<CharacterController>();
        _animator = meshPlayer.GetComponent<Animator>();
    }

    void Update()
    {
        inputX = Input.GetAxis("Horizontal");
        inputZ = Input.GetAxis("Vertical");
        //Debug.Log(inputX + inputZ);
        
        if(inputX == 0 && inputZ == 0)
        {
            _animator.SetBool("isRUN", false);
            _animator.SetBool("isDIE", false);
            _animator.SetBool("isHURT", false);
        }
        else
        {
            _animator.SetBool("isRUN", true);
        }
    }

    private void FixedUpdate()
    {
        //movement
        v_movement = new Vector3(inputX*moveSpeed,0, inputZ*moveSpeed);
        _charControll.Move(v_movement);

        //mesh rotate
        if(inputX != 0 || inputZ != 0 )
        {
            Vector3 lookDir = new Vector3(v_movement.x,0,v_movement.z);
            meshPlayer.rotation = Quaternion.LookRotation(lookDir);
        
        }

        
    }

}
