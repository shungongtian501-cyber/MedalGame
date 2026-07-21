using UnityEngine;

public class Hole5 : HoleBase
{
    protected override void OnCoinEntered()
    {
        Debug.Log("hole5");
        BingoManager.Instance.FillRandom();
    }
}