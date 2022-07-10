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
            handleSelection(0);
        } else if (Input.GetMouseButton(1)) {
            // ABSTRACTION
            handleSelection(1);
        }
    }

    void ShowDescription(BaseFigure figure)
    {
        description.text = $"Name: {figure.figureName}\nColor: {figure.color}\nWeight: ";
        description.text += (figure.weight == int.MaxValue) ? "Infinite" : $"{figure.weight}";
    }

    void handleSelection(int button)
    {
        RaycastHit hit;
        Ray ray = gameCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit)) {
            if (hit.collider.gameObject.CompareTag("Figure") && button == 0) {
                BaseFigure figure = hit.collider.GetComponentInParent<BaseFigure>();
                ShowDescription(figure);
            } else if (hit.collider.gameObject.CompareTag("Board") && button == 1) {
                Debug.Log(gameCamera.ScreenToWorldPoint(Input.mousePosition));
            }
        }
    }
}
