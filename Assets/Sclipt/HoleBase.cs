using UnityEngine;

public abstract class HoleBase : MonoBehaviour
{
    [SerializeField] private GameObject floor;

    private int coinCount = 0;
    [SerializeField] private int _RandomNumber = 10;
    protected virtual bool CountCoin => true;

    public void CoinEntered()
    {
        int rnd = Random.Range(0, _RandomNumber);
        Debug.Log(rnd);
        if(rnd == 1)
        {
            MoreMedal();
        }
        if (CountCoin)
        {
            coinCount++;

            Debug.Log($"{gameObject.name} : {coinCount}");

            if (coinCount == 2)
            {

                GameManager.Instance.OpenAllFloors();
                BingoManager.Instance.ResetBingo();
                return;
            }
        }

        OnCoinEntered();
    }

    protected virtual void OnCoinEntered()
    {
        
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
    public void MoreMedal()
    {
        Debug.Log("GOD");
    }
}