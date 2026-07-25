using UnityEngine;

public class Hole7 : HoleBase
{
    protected override void OnCoinEntered()
    {
        BingoManager.Instance.Fill(9);
    }
}