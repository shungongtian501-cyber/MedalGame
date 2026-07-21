using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BingoManager : MonoBehaviour
{
    public static BingoManager Instance;

    [SerializeField] private TMP_Text[] numbers;

    // 0～8番の点灯状態
    private bool[] opened = new bool[9];

    // 報酬を渡したラインかどうか
    private bool[] bingoCompleted = new bool[8];

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

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        ResetBingo();
    }

    // 指定した番号を点灯
    public void Fill(int number)
    {
        Debug.Log($"Fill({number}) が呼ばれた");

        int index = number - 1;

        // 既に点灯していたら何もしない
        if (opened[index])
            return;

        opened[index] = true;

        SetNumberAlpha(index, 1f);

        CheckBingo();
    }

    // ビンゴをリセット
    public void ResetBingo()
    {
        for (int i = 0; i < opened.Length; i++)
        {
            opened[i] = false;
            SetNumberAlpha(i, 0.3f);
        }

        for (int i = 0; i < bingoCompleted.Length; i++)
        {
            bingoCompleted[i] = false;
        }
    }

    // 数字の透明度を変更
    private void SetNumberAlpha(int index, float alpha)
    {
        Color color = numbers[index].color;
        color.a = alpha;
        numbers[index].color = color;
    }

    // ビンゴ判定
    private void CheckBingo()
    {
        Debug.Log(string.Join(",", opened));

        int newBingo = 0;

        for (int i = 0; i < bingoLines.GetLength(0); i++)
        {
            // 既に報酬を渡したラインなら飛ばす
            if (bingoCompleted[i])
                continue;

            if (opened[bingoLines[i, 0]] &&
                opened[bingoLines[i, 1]] &&
                opened[bingoLines[i, 2]])
            {
                bingoCompleted[i] = true;
                newBingo++;

                Debug.Log($"{i + 1}本目のライン完成！");
            }
        }

        if (newBingo > 0)
        {
            Debug.Log($"新しく {newBingo} ラインビンゴ！");
            // RewardManager.Instance.AddCoin(newBingo * 10);
        }
    }

    public void FillRandom()
    {
        List<int> candidates = new List<int>();

        for (int i = 0; i < opened.Length; i++)
        {
            if (!opened[i])
            {
                candidates.Add(i + 1);
            }
        }

        if (candidates.Count == 0)
            return;

        int randomNumber = candidates[Random.Range(0, candidates.Count)];

        Fill(randomNumber);
    }
}