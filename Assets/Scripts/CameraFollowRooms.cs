using UnityEngine;

public class CameraFollowRooms : MonoBehaviour
{
    Transform targetPosition;
    public float moveSpeed = 5.0f;
    private bool isMoving = false;

    void Update()
    {
        if (isMoving && targetPosition != null)
        {
            transform.position = Vector3.Lerp(transform.position, targetPosition.position, Time.deltaTime * moveSpeed);

            // clamp value if it is close enough to target
            if (Vector3.Distance(transform.position, targetPosition.position) < 0.05f)
            {
                transform.position = targetPosition.position;
                isMoving = false;
            }
        }
    }

    public void MoveToRoom(Transform newTarget)
    {
        targetPosition = newTarget;
        isMoving = true;
    }
}
