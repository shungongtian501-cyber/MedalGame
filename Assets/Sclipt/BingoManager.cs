using UnityEngine;

public class BingoManager : MonoBehaviour
{
    public static BingoManager Instance;

    [SerializeField] private GameObject[] lights;

    // 点灯状態
    private bool[] opened = new bool[9];

    // ビンゴの8ライン
    private readonly int[,] bingoLines =
    {
        {0,1,2}, // 横
        {3,4,5},
        {6,7,8},

        {0,3,6}, // 縦
        {1,4,7},
        {2,5,8},

        {0,4,8}, // 斜め
        {2,4,6}
    };

    private void Awake()
    {
        Instance = this;
    }

    public void Fill(int number)
    {
        int index = number - 1;

        if (opened[index]) return;

        opened[index] = true;
        lights[index].SetActive(true);

        CheckBingo();
    }

    private void CheckBingo()
    {
        int bingoCount = 0;

        for (int i = 0; i < bingoLines.GetLength(0); i++)
        {
            if (opened[bingoLines[i, 0]] &&
                opened[bingoLines[i, 1]] &&
                opened[bingoLines[i, 2]])
            {
                bingoCount++;
            }
        }

        if (bingoCount > 0)
        {
            Debug.Log($"{bingoCount}ラインビンゴ！");
        }
    }
}