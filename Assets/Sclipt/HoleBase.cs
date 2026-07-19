using UnityEditor.SearchService;
using UnityEngine;

public abstract class HoleBase : MonoBehaviour
{
    [SerializeField] private GameObject floor;

    private int coinCount = 0;

    public void CoinEntered()
    {
        OnCoinEntered();   // ← 子クラスで変更できる

        coinCount++;

        if (coinCount == 2)
        {
            GameManager.Instance.OpenAllFloors();
        }

        Debug.Log(coinCount);
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
