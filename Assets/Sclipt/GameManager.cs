using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private HoleBase[] holes;

    public static GameManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void OpenAllFloors()
    {
        foreach (HoleBase hole in holes)
        {
            hole.OpenFloor();
        }
    }

    public void CloseAllFloors()
    {
        foreach (HoleBase hole in holes)
        {
            hole.ResetHole();
        }
    }
}