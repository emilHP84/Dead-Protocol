using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMouvement : PlayerManager
{
    public CharacterController controller;
    
    [Header("saut & gravité")]
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
    private void Start() {
        speed = walk;
        isSlide = false;
    }
    
    public void Mouvement() {
        _isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (_isGrounded && _velocity.y < 0) _velocity.y = -2f;

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);
    }
    
    void Update() {
        Mouvement();
        // mouvement-vitesse--------------------------------------------------------------------------------------------
        if (Input.GetButton("LeftShift")) speed = run;
        else if (Input.GetButton("LeftControl")) speed = snick;
        else speed = walk;
        
        // saut---------------------------------------------------------------------------------------------------------
        if (Input.GetButtonDown("Jump") && _isGrounded) _velocity.y = Mathf.Sqrt(jumpHeight * -2f * WorldManager.gravity);
        _velocity.y += WorldManager.gravity * Time.deltaTime;
        controller.Move(_velocity * Time.deltaTime);
        
        //glissade------------------------------------------------------------------------------------------------------
        if (Input.GetButton("LeftShift") && Input.GetButtonDown("LeftControl")) isSlide = true;
        else isSlide = false;
    }
}
