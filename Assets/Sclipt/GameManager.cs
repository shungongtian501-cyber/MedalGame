using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private HoleBase[] holes;

    public int playerCoin = 30;     // 所持コイン
    public int earnedCoin = 0;      // 換金予定コイン

    [SerializeField] private TMP_Text haveCoinText;
    [SerializeField] private TMP_Text earnedCoinText;

    public static GameManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        UpdateUI();
    }

    private void UpdateUI()
    {
        haveCoinText.text = playerCoin.ToString();
        earnedCoinText.text = earnedCoin.ToString();
    }

    public void OpenAllFloors()
    {
        foreach (HoleBase hole in holes)
        {
            hole.OpenFloor();
        }
    }

    public void CloseAllFloors()
    {
        foreach (HoleBase hole in holes)
        {
            hole.ResetHole();
        }
    }

    // ビンゴ報酬追加
    public void AddReward(int coin)
    {
        earnedCoin += coin;
        UpdateUI();
    }

    // 換金ボタン
    public void CashOut()
    {
        playerCoin += earnedCoin;
        earnedCoin = 0;

        UpdateUI();

        OpenAllFloors();
        BingoManager.Instance.ResetBingo();
    }
}