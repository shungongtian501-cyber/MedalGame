using UnityEngine;

public class Hole3 : HoleBase
{
    protected override void OnCoinEntered()
    {
        Debug.Log("SPhole3");
        BingoManager.Instance.FillRandom();
    }
}
