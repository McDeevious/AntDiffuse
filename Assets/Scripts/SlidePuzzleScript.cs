using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class SlidePuzzleScript : MonoBehaviour
{
    AudioManager audioManager;
    
    [SerializeField] Transform gameTransform;
    [SerializeField] Transform piecePrefab;
    public SpriteRenderer displayNum;

    private List<Transform> pieces;
    private int emptyLocation;
    private int size;

    private bool isShuffling = false;
    private bool isCompleted = false;
    private bool firstMoveDone = false; // Flag for audio purposes (so you do not go deaf at the start of the game)

    private void Awake()
    {
        // Enter this line in therefore do not need to drag in object to reference
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void Start()
    {
        if (displayNum != null)
        {
            Color c = displayNum.color;
            c.a = 0f; // set alpha to 0
            displayNum.color = c;
        }

        pieces = new List<Transform>();
        size = 3;
        CreateGamePieces(0.01f);

        // ✅ Shuffle only once at the start
        Shuffle();
        firstMoveDone = true;
    }

    void Update()
    {
        // ✅ Don't process input if puzzle completed
        if (isCompleted || isShuffling)
            return;

        // ✅ Check for completion only if not already completed
        if (CheckCompletion())
        {
            isCompleted = true;

            Color c = displayNum.color;
            c.a = 1f; // set alpha to 0
            displayNum.color = c;

            Debug.Log("Puzzle completed!");
            return; // ✅ do NOT reshuffle after completion
        }

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit)
            {
                for (int i = 0; i < pieces.Count; i++)
                {
                    if (pieces[i] == hit.transform)
                    {
                        if (SwapIfValid(i, -size, size)) { break; }
                        if (SwapIfValid(i, +size, size)) { break; }
                        if (SwapIfValid(i, -1, 0)) { break; }
                        if (SwapIfValid(i, +1, size - 1)) { break; }
                    }
                }
            }
        }
    }

    private bool CheckCompletion()
    {
        for (int i = 0; i < pieces.Count; i++)
        {
            if (pieces[i].name != $"{i}")
            {
                return false;
            }
        }
        return true;
    }

    private void Shuffle()
    {
        isShuffling = true;
        int count = 0;
        int last = 0;
        while (count < (size * size * size))
        {
            int rand = Random.Range(0, size * size);
            if (rand == last) { continue; }
            last = emptyLocation;

            if (SwapIfValid(rand, -size, size))
            {
                count++;
            }
            else if (SwapIfValid(rand, +size, size))
            {
                count++;
            }
            else if (SwapIfValid(rand, -1, 0))
            {
                count++;
            }
            else if (SwapIfValid(rand, +1, size - 1))
            {
                count++;
            }
        }
        isShuffling = false;
    }

    private bool SwapIfValid(int i, int offset, int colCheck)
    {
        if (((i % size) != colCheck) && ((i + offset) == emptyLocation))
        {
            // Valid move so therefore swap can occur
            (pieces[i], pieces[i + offset]) = (pieces[i + offset], pieces[i]);
            (pieces[i].localPosition, pieces[i + offset].localPosition) = (pieces[i + offset].localPosition, pieces[i].localPosition);
            emptyLocation = i;

            if (firstMoveDone)
            {
                audioManager.PlaySFX(audioManager.moveTile);
            }

            return true;
        }
        return false;
    }

    void CreateGamePieces(float gap)
    {
        float width = 1 / (float)size;
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                Transform piece = Instantiate(piecePrefab, gameTransform);
                pieces.Add(piece);

                piece.localPosition = new Vector3(-1 + (2 * width * j) + width, 1 - (2 * width * i) - width, 0);
                piece.localScale = ((2 * width) - gap) * Vector3.one;
                piece.name = $"{(i * size) + j}";

                if (i == size - 1 && j == size - 1)
                {
                    emptyLocation = (size * size) - 1;
                    piece.gameObject.SetActive(false);
                }
                else
                {
                    float thisGap = gap / 2;
                    Mesh mesh = piece.GetComponent<MeshFilter>().mesh;
                    Vector2[] uv = new Vector2[4];

                    uv[0] = new Vector2((width * j) + thisGap, 1 - ((width * (i + 1)) - thisGap));
                    uv[1] = new Vector2((width * (j + 1)) - thisGap, 1 - ((width * (i + 1)) - thisGap));
                    uv[2] = new Vector2((width * j) + thisGap, 1 - ((width * i) + thisGap));
                    uv[3] = new Vector2((width * (j + 1)) - thisGap, 1 - ((width * i) - thisGap));

                    mesh.uv = uv;
                }
            }
        }
    }
}
