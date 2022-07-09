using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Camera gameCamera;
    [SerializeField] private TextMeshProUGUI description;
    
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            // ABSTRACTION
            handleSelection();
        }
    }

    void ShowDescription(BaseFigure figure)
    {
        description.text = $"Name: {figure.figureName}\nColor: {figure.color}\nWeight: ";
        description.text += (figure.weight == int.MaxValue) ? "Infinite" : $"{figure.weight}";
    }

    void handleSelection()
    {
        RaycastHit hit;
        Ray ray = gameCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit)) {
            BaseFigure figure = hit.collider.GetComponentInParent<BaseFigure>();
            ShowDescription(figure);
        }
    }
}
