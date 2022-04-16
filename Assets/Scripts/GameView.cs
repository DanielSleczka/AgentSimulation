using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI agentName;
    [SerializeField] private TextMeshProUGUI agentHP;

    private void Start()
    {
        AgentInfoDefaultValue();
    }

    public void ShowAgentInfo(string name, int HP)
    {
        agentName.text = $"Name: {name}";
        agentHP.text = $"HP: {HP}";
    }

    public void AgentInfoDefaultValue()
    {
        agentName.text = $"Name: ";
        agentHP.text = $"HP: ";
    }
}
