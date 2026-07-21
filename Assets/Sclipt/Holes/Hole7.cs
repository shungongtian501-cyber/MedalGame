using UnityEngine;

public class Hole6 : HoleBase
{
    protected override void OnCoinEntered()
    {
        Debug.Log("hole6");
        BingoManager.Instance.Fill(7);
    }
}
