using UnityEngine;

public class BoardGenerator : MonoBehaviour {

    [Header("Board Dimensions")]
    [SerializeField]
    private int widht;
    [SerializeField]
    private int height;

    [Header("Prefabs")]
    [SerializeField]
    private GameObject cellBlack;
    [SerializeField]
    private GameObject cellWhite;
    [SerializeField]
    private GameObject enemyGO;

    private GameObject[,] board;
    private Vector2 playerTile;

    void Start()
    {
        board = new GameObject[widht, height];

        //var player = FindObjectOfType<PlayerController>();
        //player.OnMoved += PlayerMoved;
        playerTile = new Vector2(0f, 0f);

        Draw();
    }

    void Draw()
    {
        for (int i = 0; i < widht; i++)
            for (int j = 0; j <= height; j++)
            {
                if (board[i % widht, j % height] == null)
                {
                    Vector3 pos = new Vector3(i - widht / 2, 0f, j - height / 2);
                    GameObject cell = ((i + j) % 2) == 0 ? cellBlack : cellWhite;
                    cell = Instantiate(cell, pos, cell.transform.rotation, transform);
                    //cell.transform.RotateAround(transform.position, Vector3.up, 45f);
                    board[i % widht, j % height] = cell;
                }
            }

        int x = Random.Range(0, widht);
        int y = Random.Range(0, height);

        GameObject enemy = Instantiate(enemyGO, new Vector3(x - widht / 2, 0.375f, y - height / 2), enemyGO.transform.rotation, transform);
        FindObjectOfType<GameManager>().GetComponent<GameManager>().Subscribe(enemy.GetComponent<Enemy>());

    }


    void PlayerMoved(DIRECTION dir)
    {
        switch (dir)
        {
            case DIRECTION.UP:
                playerTile.y++;
                break;
            case DIRECTION.DOWN:
                playerTile.y--;
                break;
            case DIRECTION.LEFT:
                playerTile.x--;
                break;
            case DIRECTION.RIGHT:
                playerTile.x++;
                break;
        }
    }
}
