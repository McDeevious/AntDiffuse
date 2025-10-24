using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Handle Movement
    private float speed;
    private float horizontal;
    private float vertical;

    // Handle Location
    [SerializeField] Camera cam;
    private bool inRoomA;

    Rigidbody2D rb;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        speed = 300.0f;
        rb = GetComponent<Rigidbody2D>();

        inRoomA = true;
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        PlayerMovement();
    }

    void PlayerMovement()
    {
        // Identity vector for right and up multiplied by the true direction
        Vector2 moveDirection = (Vector2.right * horizontal) + (Vector2.up * vertical);
        moveDirection *= speed * Time.deltaTime;

        rb.linearVelocity = moveDirection;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("RoomB") && inRoomA)
        {
            cam.transform.position += new Vector3(0, 10f, 0);
            inRoomA = false;
        }
        else if (collision.CompareTag("RoomA") && !inRoomA)
        {
            cam.transform.position += new Vector3(0, -10f, 0);
            inRoomA = true;
        }
    }
}
