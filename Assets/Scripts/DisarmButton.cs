using UnityEngine;

public class DisarmButton : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    private bool isPressed = false;

    private void OnMouseDown()
    {
        isPressed = true;
    }

    private void OnMouseUp()
    {
        if (isPressed)
        {
            gameManager.DisarmBomb();
            isPressed = false;
        }
    }
}
