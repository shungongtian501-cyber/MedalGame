using UnityEngine;

public class Hole3 : HoleBase
{
    protected override void OnCoinEntered()
    {
        BingoManager.Instance.FillRandom();
    }
}
