using UnityEngine;

public class WireScript : MonoBehaviour
{
    [SerializeField] SpriteRenderer brokenWireSprite;
    [SerializeField] SpriteRenderer connectedWireSprite;

    [SerializeField] WireManagerScript gameManager;

    private bool isBroken = false;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        brokenWireSprite.enabled = false;
    }

    private void OnMouseDown()
    {
        if (!isBroken)
        {
            isBroken = true;
            brokenWireSprite.enabled = true;
            connectedWireSprite.enabled = false;

            gameManager.WireCut(gameObject);
        }
    }

    public void ResetWire()
    {
        isBroken = false;
        connectedWireSprite.enabled = true;
        brokenWireSprite.enabled= false;
    }
}
