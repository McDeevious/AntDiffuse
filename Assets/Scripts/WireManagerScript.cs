using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class WireManagerScript : MonoBehaviour
{
    AudioManager audioManager;
    
    [SerializeField] SpriteRenderer displayNum;
    [SerializeField] List<GameObject> correctOrder;
    private List<GameObject> currentOrder;

    public int wireCount = 0;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentOrder = new List<GameObject>();
        displayNum.enabled = false;
    }

    public void WireCut(GameObject gameObject)
    {
        currentOrder.Add(gameObject);
        wireCount++;
        
        if (wireCount == 5)
        {
            CheckOrder();
        }

        audioManager.PlaySFX(audioManager.wireSnip);
    }

    private void CheckOrder()
    {
        if (currentOrder.SequenceEqual(correctOrder))
        {
            displayNum.enabled = true;
        }
        else
        {
            for (int i = 0; i < 5; i++)
            {
                currentOrder[i].GetComponent<WireScript>().ResetWire();
            }

            wireCount = 0;
            currentOrder.Clear();
        }
    }
}
