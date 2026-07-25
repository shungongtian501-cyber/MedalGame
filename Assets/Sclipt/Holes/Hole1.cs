using UnityEngine;

public class Hole1 : HoleBase
{
    protected override void OnCoinEntered()
    {
        BingoManager.Instance.Fill(1);
    }
}