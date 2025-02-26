using UnityEngine;

[CreateAssetMenu(fileName = "SimulationParameters", menuName = "Scriptable Objects/SimulationParameters")]
public class SimulationParameters : ScriptableObject
{
    // General simulation settings
    public string SimulationName = "";
    public float TimeScale = 1.0f;
    public float dt = 0.02f;  // Time step in seconds
    public float StartTime = 0;
    public float EndTime = 300;  // 5 minutes

    // M/M/1 Queue Parameters
    [Header("M/M/1 Queue Parameters")]
    public float lambda = 24;  // Arrival rate
    public float mu = 40;      // Service rate
}
