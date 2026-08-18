using UnityEngine;

public abstract class HoleBase : MonoBehaviour
{
    [SerializeField] private GameObject floor;

    private int coinCount = 0;
    private int _RandomNumber = 200;
    protected virtual bool CountCoin => true;
    private static HoleBase Instance;

    // FeverAnimatorを記憶しておく変数
    private FeverAnimator _feverAnimator;
    // FeverAnimatorから自身を登録してもらうための関数
    public void SetFeverAnimator(FeverAnimator animator)
    {
        _feverAnimator = animator;
    }
    void Awake() 
    {
        Instance = this; 
    }
    public void CoinEntered()
    {
        int rnd = Random.Range(0, _RandomNumber);
        Debug.Log("RandomNumber:" + rnd);
        if(rnd == 1)
        {
            MoreMedal();
            if (_feverAnimator != null)
            {
                _feverAnimator.SetFeverFlag(true);
            }
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