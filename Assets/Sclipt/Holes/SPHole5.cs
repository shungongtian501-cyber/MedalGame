using UnityEngine;

public class SPHole5 : HoleBase
{
    protected override bool CountCoin => false;
    protected override void OnCoinEntered()
    {
        BingoManager.Instance.FillRandom();
    }
}