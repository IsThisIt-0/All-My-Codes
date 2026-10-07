using UnityEngine;

public class Movement : MonoBehaviour
{
 [SerializeField] private float moveSpeed = 5f;

 private PlayerControls playerControls;
 private Vector2 movement;

 private Rigidbody2D rigidBody;


 private void Awake()
 {
    playerControls = new PlayerControls();
    rigidBody = GetComponent<Rigidbody2D>();
 }

 private void OnEnable() 
 {
       playerControls.Enable();
 }

 private void OnDisable() 
 {
    playerControls.Disable();   
 }

 private void PlayerInput()
    {
         movement = playerControls.Movement.Move.ReadValue<Vector2>();
    }

private void Move()
    {
        rigidBody.MovePosition(rigidBody.position + movement * moveSpeed * Time.fixedDeltaTime);

    }

 private void Update() 
 {
   PlayerInput();
 }

private void FixedUpdate() 
{
    Move();
}

}
