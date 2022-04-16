using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Pointer : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private GameView gameView;

    private Transform selectObject;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Raycast();
        }
    }

    private void Raycast()
    {
        var layerMask = 1 << 6;
        RaycastHit2D hit = Physics2D.Raycast(mainCamera.ScreenToWorldPoint(Input.mousePosition), -Vector2.up, 100, layerMask);
        if (hit)
        {
            DeselectObject();
            selectObject = hit.transform;
            gameView.ShowAgentInfo(selectObject.gameObject.name, selectObject.gameObject.GetComponent<Agent>().HealtPoint);
            selectObject.gameObject.GetComponentInChildren<SpriteRenderer>().color = Color.red;
        }
    }
    private void DeselectObject()
    {
        if (selectObject != null)
        {
            selectObject.gameObject.GetComponentInChildren<SpriteRenderer>().color = Color.white;
        }
    }


}
