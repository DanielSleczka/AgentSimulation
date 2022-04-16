using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [Header("Time")]
    [SerializeField] private float minTimeToRespawn;
    [SerializeField] private float maxTimeToRespawn;
    private float getTimeToRespawn;
    private float currentTime;

    [Header("Agent")]
    [SerializeField] private float maxNumberOfAgents;
    [SerializeField] private Agent agent;
    [SerializeField] private List<Agent> currentAgents;
    private int numberOfAgent;

    [Header("Map")]
    [SerializeField] private List<Transform> spawnPoints;


    private void Start()
    {
        SetTimeToRespawn();
        numberOfAgent = 1;
    }

    private void Update()
    {
        if (currentAgents.Count <= maxNumberOfAgents)
        {
            CheckRespawnCondition();
        }
        if (currentAgents.Count > 0)
        {
            currentAgents.RemoveAll(Agent => Agent == null);
        }
    }

    public void CheckRespawnCondition()
    {
        if (currentTime >= getTimeToRespawn)
        {
            GenerateNewAgent();
            SetTimeToRespawn();
        }
        currentTime += Time.deltaTime;
    }
    public void GenerateNewAgent()
    {
        Agent newAgent = Instantiate(agent);
        newAgent.transform.position = spawnPoints[Random.Range(0, spawnPoints.Count)].position;
        newAgent.transform.Rotate(0, 0, Random.Range(0, 360));
        newAgent.name = $"Agent {numberOfAgent}";
        numberOfAgent++;
        currentAgents.Add(newAgent);
    }
    public void SetTimeToRespawn()
    {
        getTimeToRespawn = Random.Range(minTimeToRespawn, maxTimeToRespawn);
        currentTime = 0f;
    }
}
