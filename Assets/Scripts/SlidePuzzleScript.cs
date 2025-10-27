using NUnit.Framework;
using UnityEngine;

public class SlidePuzzleScript : MonoBehaviour
{
    [SerializeField] Transform gameTransform;
    [SerializeField] Transform piecePrefab;

    private List<Transform> pieces;
    private int emptyLocation;
    private int size;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pieces = new List<Transform>();
        size = 3;
        CreateGamePieces(0.01f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CreateGamePieces(float gap)
    {
        float width = 1 / (float)size;
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                Transform piece = Instantiate(piecePrefab, gameTransform);
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
