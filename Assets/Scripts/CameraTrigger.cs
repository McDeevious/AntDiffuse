using UnityEngine;

public class CameraTrigger : MonoBehaviour
{
    public CameraFollowRooms camController;
    public Transform targetRoomCenter;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (camController != null)
            {
                camController.MoveToRoom(targetRoomCenter);
            }
        }
    }
}
