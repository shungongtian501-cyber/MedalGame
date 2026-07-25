using UnityEngine;

public class Hole6 : HoleBase
{
    protected override void OnCoinEntered()
    {
        BingoManager.Instance.Fill(7);
    }
}
