using UnityEngine;

public class PipeScript : MonoBehaviour
{
    AudioManager audioManager;

    float[] rotations = { 0, 90, 180, 270 };

    public float[] correctRotation;
    [SerializeField] bool isCorrect = false;

    PipeGameManager gameManager;

    private void Awake()
    {
        // Find and reference the pipe game manager script
        gameManager = GameObject.Find("PipeGameManager").GetComponent<PipeGameManager>();
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void Start()
    {
        // Give a random rotation to the pipe asset based on preset rotaion values
        int rand = Random.Range(0, rotations.Length);
        transform.eulerAngles = new Vector3(0, 0, rotations[rand]);

        // Run a check at the start as well since random rotatio happens here as well
        for (int i = 0; i < correctRotation.Length; i++)
        {
            if (transform.eulerAngles.z == correctRotation[i])
            {
                isCorrect = true;
                gameManager.CorrectlyPlaced();
                break;
            }
        }
    }

    private void OnMouseDown()
    {
        // Rotate pipe asset by 90 degrees on mouse click
        transform.Rotate(new Vector3(0, 0, 90));
        // Avoid rounding errors in computations
        transform.eulerAngles = new Vector3(0, 0, Mathf.Round(transform.eulerAngles.z));

        audioManager.PlaySFX(audioManager.pipeMove);

        for (int i = 0; i < correctRotation.Length; i++)
        {
            if(transform.eulerAngles.z == correctRotation[i] && isCorrect == false)
            {
                isCorrect = true;
                gameManager.CorrectlyPlaced();
                break;
            }
            else if(isCorrect == true)
            {
                // no longer in the correct place
                isCorrect = false;
                gameManager.WronglyPlaced();
            }
        }
    }
}
