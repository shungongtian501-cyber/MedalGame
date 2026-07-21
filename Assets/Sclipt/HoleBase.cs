using UnityEditor.SearchService;
using UnityEngine;

public abstract class HoleBase : MonoBehaviour
{
    [SerializeField] private GameObject floor;

    private int coinCount = 0;

    //public void CoinEntered()
    //{
    //    OnCoinEntered();   // ← 子クラスで変更できる

    //    coinCount++;

    //    if (coinCount == 2)
    //    {
    //        GameManager.Instance.OpenAllFloors();
    //        BingoManager.Instance.ResetBingo();
    //    }

    //    Debug.Log(coinCount);
    //}
    public void CoinEntered()
    {
        coinCount++;

        Debug.Log($"{gameObject.name} : {coinCount}");

        OnCoinEntered();

        if (coinCount == 2)
        {
            GameManager.Instance.OpenAllFloors();
            BingoManager.Instance.ResetBingo();
        }
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
