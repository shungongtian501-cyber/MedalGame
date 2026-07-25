using UnityEngine;

public abstract class HoleBase : MonoBehaviour
{
    [SerializeField] private GameObject floor;

    private int coinCount = 0;

    protected virtual bool CountCoin => true;

    public void CoinEntered()
    {
        if (CountCoin)
        {
            coinCount++;

            Debug.Log($"{gameObject.name} : {coinCount}");

            if (coinCount == 2)
            {
                GameManager.Instance.OpenAllFloors();
                BingoManager.Instance.ResetBingo();
            }
        }

        OnCoinEntered();
    }

    protected virtual void OnCoinEntered()
    {
        Debug.Log("通常の穴");
    }

    public void OpenFloor()
    {
        floor.SetActive(false);
    }

    public void ResetHole()
    {
        coinCount = 0;
        floor.SetActive(true);
    }
}