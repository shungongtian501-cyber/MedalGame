using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Hole[] holes;

    public static GameManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void OpenAllFloors()
    {
        foreach (Hole hole in holes)
        {
            hole.OpenFloor();
        }
    }

    public void CloseAllFloors()
    {
        foreach (Hole hole in holes)
        {
            hole.ResetHole();
        }
    }
}