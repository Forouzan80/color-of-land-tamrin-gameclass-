using UnityEngine;

public class GreenPowerManager : MonoBehaviour
{
    public static GreenPowerManager Instance;

    private TreeColorChanger[] allTrees;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        allTrees = FindObjectsOfType<TreeColorChanger>();
    }

    public void ActivateGreenTrees()
    {
        foreach (TreeColorChanger tree in allTrees)
        {
            tree.TurnGreen();
        }
    }
}
