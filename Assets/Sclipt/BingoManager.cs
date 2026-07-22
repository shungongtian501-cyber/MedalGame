using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BingoManager : MonoBehaviour
{
    public static BingoManager Instance;

    [SerializeField] private TMP_Text[] numbers;

    // 点灯状態
    private bool[] opened = new bool[9];

    // 既に報酬を渡したライン
    private bool[] bingoCompleted = new bool[8];

    // 現在のビンゴ数
    private int bingoCount = 0;

    // ビンゴ数→報酬
    [SerializeField]
    private int[] rewardTable =
    {
        0,  //0ビンゴ
        1,  //1ビンゴ
        2,  //2ビンゴ
        3,  //3ビンゴ
        5,  //4ビンゴ
        10, //5ビンゴ
        15, //6ビンゴ
        30, //7ビンゴ
        99  //8ビンゴ
    };

    // ビンゴライン
    private readonly int[,] bingoLines =
    {
        {0,1,2},
        {3,4,5},
        {6,7,8},

        {0,3,6},
        {1,4,7},
        {2,5,8},

        {0,4,8},
        {2,4,6}
    };

    public int BingoCount => bingoCount;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        ResetBingo();
    }

    //====================================================
    // 数字を点灯
    //====================================================
    public void Fill(int number)
    {
        int index = number - 1;

        if (opened[index])
            return;

        opened[index] = true;

        SetNumberAlpha(index, 1f);

        CheckBingo();
    }

    //====================================================
    // ビンゴ判定
    //====================================================
    private void CheckBingo()
    {
        int newBingo = 0;

        for (int i = 0; i < bingoLines.GetLength(0); i++)
        {
            if (bingoCompleted[i])
                continue;

            if (opened[bingoLines[i, 0]] &&
                opened[bingoLines[i, 1]] &&
                opened[bingoLines[i, 2]])
            {
                bingoCompleted[i] = true;
                newBingo++;

                Debug.Log($"{i + 1}ライン完成！");
            }
        }

        if (newBingo > 0)
        {
            bingoCount += newBingo;

            Debug.Log($"現在 {bingoCount} ビンゴ");

            // GameManagerへ現在の獲得予定枚数を渡す
            GameManager.Instance.SetEarnedCoin(rewardTable[bingoCount]);
        }
    }

    //====================================================
    // リセット
    //====================================================
    public void ResetBingo()
    {
        bingoCount = 0;

        for (int i = 0; i < opened.Length; i++)
        {
            opened[i] = false;
            SetNumberAlpha(i, 0.3f);
        }

        for (int i = 0; i < bingoCompleted.Length; i++)
        {
            bingoCompleted[i] = false;
        }

        GameManager.Instance.SetEarnedCoin(0);
    }

    //====================================================
    // 数字の透明度変更
    //====================================================
    private void SetNumberAlpha(int index, float alpha)
    {
        Color color = numbers[index].color;
        color.a = alpha;
        numbers[index].color = color;
    }
    public void FillRandom()
    {
        List<int> candidates = new List<int>();

        // 未点灯の数字を集める
        for (int i = 0; i < opened.Length; i++)
        {
            if (!opened[i])
            {
                candidates.Add(i + 1);
            }
        }

        // 全部点灯済みなら何もしない
        if (candidates.Count == 0)
            return;

        // ランダムに1つ選ぶ
        int randomNumber = candidates[Random.Range(0, candidates.Count)];

        Debug.Log($"SPで {randomNumber} が点灯");

        Fill(randomNumber);
    }
}