using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class KeypadScript : MonoBehaviour
{
    // Audio
    AudioManager audioManager;
    
    // Buttons and input
    public TMP_InputField charHolder;
    public GameObject button1;
    public GameObject button2;
    public GameObject button3;
    public GameObject button4;
    public GameObject button5;
    public GameObject button6;
    public GameObject button7;
    public GameObject button8;
    public GameObject button9;
    public GameObject clearButton;
    public GameObject enterButton;
    private bool isSolved = false;

    // Door Control
    [SerializeField] BoxCollider2D doorCollider;
    [SerializeField] SpriteRenderer doorSprite;

    // Flash settings
    [SerializeField] private Color successColor = Color.green;
    [SerializeField] private Color failColor = Color.red;
    [SerializeField] private float flashDuration = 0.3f;

    private Image inputBackground;
    private Color originalColor;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void Start()
    {
        // Get the TMP_InputField background image
        inputBackground = charHolder.GetComponentInChildren<Image>();
        if (inputBackground != null)
        {
            originalColor = inputBackground.color;
        }
    }

    public void b1()
    {
        if (charHolder.text.Length < 3 && !isSolved)
        {
            charHolder.text += "1";
            audioManager.PlaySFX(audioManager.keypad);
        }
    }

    public void b2()
    {
        if (charHolder.text.Length < 3 && !isSolved)
        {
            charHolder.text += "2";
            audioManager.PlaySFX(audioManager.keypad);
        }
    }

    public void b3()
    {
        if (charHolder.text.Length < 3 && !isSolved)
        {
            charHolder.text += "3";
            audioManager.PlaySFX(audioManager.keypad);
        }
    }

    public void b4()
    {
        if (charHolder.text.Length < 3 && !isSolved)
        {
            charHolder.text += "4";
            audioManager.PlaySFX(audioManager.keypad);
        }
    }

    public void b5()
    {
        if (charHolder.text.Length < 3 && !isSolved)
        {
            charHolder.text += "5";
            audioManager.PlaySFX(audioManager.keypad);
        }
    }

    public void b6()
    {
        if (charHolder.text.Length < 3 && !isSolved)
        {
            charHolder.text += "6";
            audioManager.PlaySFX(audioManager.keypad);
        }
    }

    public void b7()
    {
        if (charHolder.text.Length < 3 && !isSolved)
        {
            charHolder.text += "7";
            audioManager.PlaySFX(audioManager.keypad);
        }
    }

    public void b8()
    {
        if (charHolder.text.Length < 3 && !isSolved)
        {
            charHolder.text += "8";
            audioManager.PlaySFX(audioManager.keypad);
        }
    }

    public void b9()
    {
        if (charHolder.text.Length < 3 && !isSolved)
        {
            charHolder.text += "9";
            audioManager.PlaySFX(audioManager.keypad);
        }
    }

    public void b0()
    {
        if (charHolder.text.Length < 3 && !isSolved)
        {
            charHolder.text += "0";
            audioManager.PlaySFX(audioManager.keypad);
        }
    }

    public void clearEvent()
    {
        if (!isSolved)
        {
            charHolder.text = "";
            audioManager.PlaySFX(audioManager.keypad);
        }
    }

    public void enterEvent()
    {
        if (charHolder.text == "548")
        {
            StartCoroutine(FlashColor(successColor));
            doorCollider.enabled = false;
            doorSprite.enabled = false;
            isSolved = true;
            audioManager.PlaySFX(audioManager.keypad);
        }
        else
        {
            StartCoroutine(FlashColor(failColor));
            clearEvent();
        }
    }

    private IEnumerator FlashColor(Color targetColor)
    {
        if (inputBackground == null)
            yield break;

        inputBackground.color = targetColor;
        yield return new WaitForSeconds(flashDuration);
        inputBackground.color = originalColor;
    }
}
