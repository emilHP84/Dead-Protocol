using UnityEngine;

public class MouvementController : MonoBehaviour {
    private PlayerManager _playerManager;
    private CharacterController controller;
    
    public Camera FollowCamera;
    
    [Header("saut & gravité")]
    public float _rotationSpeed = 5;
    public float jumpHeight = 2.5f;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    
    private bool isSlide;
    private Vector3 _velocity;
    private bool _isGrounded;
    private float speed;
    private Vector3 cameraRotation;

    private void Awake()
    {
        _playerManager = GetComponent<PlayerManager>();
        controller = gameObject.GetComponent<CharacterController>();
    }

    private void Start() {
        speed = PlayerManager.walk;
        isSlide = false;
    }
    
    public void Mouvement() {
        //mouvement
        _isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (_isGrounded && _velocity.y < 0) _velocity.y = -2f;

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = Quaternion.Euler(0, FollowCamera.transform.eulerAngles.y, 0) * new Vector3(x,0,z);
        Vector3 moveDirection = move.normalized;
        
        // direction décalé par rapport a la camera
        if (moveDirection != Vector3.zero && _playerManager.boostedAIM == false) {
            Quaternion desiredRotation = Quaternion.LookRotation(moveDirection, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, desiredRotation, _rotationSpeed * Time.deltaTime);
        }
        else if (_playerManager.boostedAIM) {
            Quaternion moveAIM = Quaternion.Euler(0, FollowCamera.transform.eulerAngles.y, 0);
            transform.rotation = Quaternion.Slerp(transform.rotation, moveAIM, _rotationSpeed * Time.deltaTime);
        }
        controller.Move(move * speed * 3 * Time.deltaTime);
        
        //xp system
        if (move != Vector3.zero && Input.GetButton("LeftShift") && _playerManager.dataPlayerCompetence.basicEndurance > 0) {
            _playerManager.xpSystem.xpSpeed();
            _playerManager.xpSystem.xpEndurance();
        }
    }
    void Update() {
        if(_playerManager.boostedUI == false) Mouvement();
        if (Input.GetButton("LeftShift") && _playerManager.dataPlayerCompetence.basicEndurance > 0) speed = PlayerManager.run;
        else if (Input.GetButton("LeftControl")) speed = PlayerManager.snick;
        else speed = PlayerManager.walk;
        
        if (Input.GetButtonDown("Jump") && _isGrounded) _velocity.y = Mathf.Sqrt(jumpHeight * -2f * WorldManager.gravity);
        _velocity.y += WorldManager.gravity * Time.deltaTime;
        controller.Move(_velocity * Time.deltaTime);
        
        if (Input.GetButton("LeftShift") && Input.GetButtonDown("LeftControl")) isSlide = true;
        else isSlide = false;
    }
}
