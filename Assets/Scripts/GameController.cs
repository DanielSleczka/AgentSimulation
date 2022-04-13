using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [Header("Time")]
    [SerializeField] private float minTimeToRespawn;
    [SerializeField] private float maxTimeToRespawn;
    private float timeToRespawn;

    [Header("Agent")]
    [SerializeField] private float maxNumberOfAgents;
    [SerializeField] private Agent agent;
    [SerializeField] private List<Agent> listOfAgents;

    [Header("Map")]
    [SerializeField] private List<Transform> spawnPoints;


    private void Start()
    {
        GenerateTimeToRespawn();
    }

    public void GenerateTimeToRespawn()
    {
        timeToRespawn = Random.Range(minTimeToRespawn, maxTimeToRespawn);
    }


    public void GenerateNewAgent()
    {
        Agent newAgent = Instantiate(agent);
        newAgent.transform.position = spawnPoints[Random.Range(0, spawnPoints.Count)].position;
        listOfAgents.Add(newAgent);
    }

}
