using UnityEngine;

public class YellowPowerManager : MonoBehaviour
{
    public static YellowPowerManager Instance;

    private LightChanger[] allLights;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        allLights = FindObjectsOfType<LightChanger>();
    }

    public void ActivateYellowLights()
    {
        foreach (LightChanger light in allLights)
        {
            light.TurnOn();
        }
    }
}

