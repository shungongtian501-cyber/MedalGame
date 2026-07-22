using UnityEngine.UI;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private HoleBase[] holes;

    public int playerCoin = 30;     // 所持コイン
    public int earnedCoin = 0;      // 換金予定コイン

    [SerializeField] private Text haveCoinText;
    [SerializeField] private Text earnedCoinText;

    public static GameManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        UpdateUI();
    }

    public void UpdateUI()
    {
        haveCoinText.text = "所持コイン枚数：" + playerCoin.ToString();
        earnedCoinText.text = "獲得予定コイン枚数：" + earnedCoin.ToString();
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

        UpdateUI();

        OpenAllFloors();
        BingoManager.Instance.ResetBingo();
        CloseAllFloors();
    }
    public void SetEarnedCoin(int coin)
    {
        earnedCoin = coin;
        UpdateUI();
    }
}