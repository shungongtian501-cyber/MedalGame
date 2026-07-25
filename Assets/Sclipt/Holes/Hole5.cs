using UnityEngine;

public class Hole4 : HoleBase
{
    protected override void OnCoinEntered()
    {
        BingoManager.Instance.Fill(5);
    }
}
