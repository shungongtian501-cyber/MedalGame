using UnityEngine;

public class Hole1 : HoleBase
{
    protected override void OnCoinEntered()
    {
        Debug.Log("hole1");
        BingoManager.Instance.Fill(1);
    }
}