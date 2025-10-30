using UnityEngine;

public class DisarmButton : MonoBehaviour
{
    AudioManager audioManager;
    
    [SerializeField] GameManager gameManager;
    private bool isPressed = false;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void OnMouseDown()
    {
        isPressed = true;
        audioManager.PlaySFX(audioManager.button);
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
