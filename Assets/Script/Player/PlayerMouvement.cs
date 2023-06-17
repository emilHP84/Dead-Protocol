using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMouvement : MonoBehaviour
{
    public PlayerManager _playerManager;
    public CharacterController controller;
    public Camera FollowCamera;
    
    [Header("saut & gravité")]
    public float _rotationSpeed = 5;
    public float jumpHeight = 2.5f;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    [Header("glissade")] 
    private bool isSlide = false;
    
    [Header("PositionChildPlayerComponent")]
    public Vector3 _velocity;
    public bool _isGrounded;
    
    private float speed;
    private Vector3 cameraRotation;

    private void Start(){
        speed = _playerManager.walk;
        isSlide = false;
    }
    
    public void Mouvement() {
        _isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (_isGrounded && _velocity.y < 0) _velocity.y = -2f;

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = Quaternion.Euler(0, FollowCamera.transform.eulerAngles.y, 0) * new Vector3(x,0,z);
        Vector3 moveDirection = move.normalized;
        
        if (moveDirection != Vector3.zero) {
            Quaternion desiredRotation = Quaternion.LookRotation(moveDirection, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, desiredRotation, _rotationSpeed * Time.deltaTime);
            
        }
        
        controller.Move(move * speed * 3 * Time.deltaTime);
    }
    
    void Update() {
        Mouvement();
        // mouvement-vitesse--------------------------------------------------------------------------------------------
        if (Input.GetButton("LeftShift")) speed = _playerManager.run;
        else if (Input.GetButton("LeftControl")) speed = _playerManager.snick;
        else speed = _playerManager.walk;
        
        // saut---------------------------------------------------------------------------------------------------------
        if (Input.GetButtonDown("Jump") && _isGrounded) _velocity.y = Mathf.Sqrt(jumpHeight * -2f * WorldManager.gravity);
        _velocity.y += WorldManager.gravity * Time.deltaTime;
        controller.Move(_velocity * Time.deltaTime);
        
        //glissade------------------------------------------------------------------------------------------------------
        if (Input.GetButton("LeftShift") && Input.GetButtonDown("LeftControl")) isSlide = true;
        else isSlide = false;
    }
}
