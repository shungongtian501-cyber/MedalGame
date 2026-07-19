using UnityEngine;

public class Hole : MonoBehaviour
{
    [SerializeField] private GameObject floor;

    private int coinCount = 0;

    public void CoinEntered()
    {
        if (coinCount >= 2) return;

        coinCount++;

        if (coinCount == 2)
        {
            GameManager.Instance.OpenAllFloors();
        }

        Debug.Log(coinCount);
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