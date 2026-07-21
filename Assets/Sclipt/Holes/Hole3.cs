using UnityEngine;

public class Hole2 : HoleBase
{
    protected override void OnCoinEntered()
    {
        Debug.Log("hole2");
        BingoManager.Instance.Fill(3);
    }
}

