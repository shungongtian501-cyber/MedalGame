using UnityEngine;

public class Hole4 : HoleBase
{
    protected override void OnCoinEntered()
    {
        Debug.Log("hole4");
        BingoManager.Instance.Fill(5);
    }
}
