using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MarcoPolo : MonoBehaviour
{
    [SerializeField] private Button marcoPoloButton;
    [SerializeField] private TextMeshProUGUI textMarcoPolo;

    private void Start()
    {
        marcoPoloButton.onClick.AddListener(RunMarcoPolo);
    }

    public void RunMarcoPolo()
    {
        for (int i = 1; i <= 100; i++)
        {
            if (i % 3 == 0 && i % 5 == 0)
            {
                textMarcoPolo.text += "Marco Polo ";
            }
            else if (i % 3 == 0)
            {
                textMarcoPolo.text += "Marco ";
            }
            else if (i % 5 == 0)
            {
                textMarcoPolo.text += "Polo ";
            }
            else
            {
                textMarcoPolo.text += $"{i} ";
            }
        }
        marcoPoloButton.interactable = false;
    }
}
