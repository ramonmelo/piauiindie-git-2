using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject visuals;
    private CharacterController characterController;
    public float speed = 10.0f;
    public float gravity = -9.81f;
    private Vector3 velocity;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 move = transform.right * moveHorizontal + transform.forward * moveVertical;
        characterController.Move(move * speed * Time.deltaTime);

        // Apply gravity
        if (characterController.isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);

        // Rotate the visuals towards move direction
        if (move != Vector3.zero)
        {
            visuals.transform.rotation = Quaternion.Slerp(visuals.transform.rotation, Quaternion.LookRotation(move), 0.3f);
        }
    }
}
