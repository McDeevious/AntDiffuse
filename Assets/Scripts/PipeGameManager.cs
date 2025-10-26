using UnityEngine;

public class PipeGameManager : MonoBehaviour
{
    public GameObject PipeContainer;
    public GameObject[] Pipes;
    [SerializeField] int totalPipes = 0;

    // Number display
    public SpriteRenderer displayNum;
    int correctPipes = 0;

    void Start()
    {
        // Make number transparent
        if (displayNum != null)
        {
            Color c = displayNum.color;
            c.a = 0f; // set alpha to 0
            displayNum.color = c;
        }

        // Return int value representing number of pipes
        totalPipes = PipeContainer.transform.childCount;
        Pipes = new GameObject[totalPipes];

        for (int i = 0; i < Pipes.Length; i++)
        {
            // The array now references the pipes
            Pipes[i] = PipeContainer.transform.GetChild(i).gameObject;
        }
    }

    public void CorrectlyPlaced()
    {
        correctPipes++;
        if (correctPipes == totalPipes)
        {
            Color c = displayNum.color;
            c.a = 1f; // set alpha to 0
            displayNum.color = c;
        }
    }

    public void WronglyPlaced()
    {
        correctPipes--;
        if (correctPipes < totalPipes)
        {
            Color c = displayNum.color;
            c.a = 0f; // set alpha to 0
            displayNum.color = c;
        }
    }
}
