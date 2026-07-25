using UnityEngine;

public class Hole2 : HoleBase
{
    protected override void OnCoinEntered()
    {
        BingoManager.Instance.Fill(3);
    }
}

