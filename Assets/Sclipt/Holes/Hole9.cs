using UnityEngine;

public class Hole7 : HoleBase
{
    protected override void OnCoinEntered()
    {
        Debug.Log("hole7");
        BingoManager.Instance.Fill(9);
    }
}