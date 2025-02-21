using System;
using System.Collections;
using System.IO;  // For file handling
using UnityEngine;

public class ArrivalProcess : MonoBehaviour
{
    public GameObject customerPrefab;
    public Transform customerSpawnPlace;
    public SimulationParameters simulationParameters;
    public bool generateArrivals;

    private string filePath;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Define the path for the CSV file
        filePath = Application.dataPath + "/InterArrivalTimes.csv"; // This will create the file in the project folder
        WriteToFile("interArrivalTime"); // Write header to the file
        StartCoroutine(GenerateArrivals());
    }

    // Coroutine to generate customer arrivals based on inter-arrival time
    private IEnumerator GenerateArrivals()
    {
        while (generateArrivals)
        {
            // Instantiate a customer at the spawn location
            Instantiate(customerPrefab, customerSpawnPlace.position, Quaternion.identity);

            // Calculate inter-arrival time using exponential distribution
            float interArrivalTime = -Mathf.Log(1 - UnityEngine.Random.value) / simulationParameters.lambda;

            // Print to console (optional)
            print($"interArrivalTime = {interArrivalTime}");

            // Write interArrivalTime to the CSV file
            WriteToFile(interArrivalTime.ToString());

            // Wait for the calculated inter-arrival time before generating the next arrival
            yield return new WaitForSeconds(interArrivalTime);
        }
    }

    // Function to write data to the CSV file
    private void WriteToFile(string data)
    {
        // Open the file in append mode and write the data
        using (StreamWriter writer = new StreamWriter(filePath, true))
        {
            writer.WriteLine(data);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Can add update logic here if needed
    }
}
