using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Camera gameCamera;
    [SerializeField] private TextMeshProUGUI description;
    [SerializeField] private GameObject redSphere;
    [SerializeField] private GameObject blueSphere;
    List<GameObject> markers;

    BaseFigure selectedFigure;
    const float cellSize = 0.6f; // TODO: compute using collider
    // we assume that board is located in (0, 0, ..)
    float offsetFromCenter = Coordinate.MaxRow / 2 * cellSize;
    
    void Start()
    {
        markers = new List<GameObject>();
        selectedFigure = GameObject.Find("Chess King White").GetComponent<King>();
        ShowDescription(selectedFigure);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
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
            if (hit.collider.gameObject.CompareTag("Figure")) {
                selectedFigure = hit.collider.GetComponentInParent<BaseFigure>();
                ShowDescription(selectedFigure);
            } else if (hit.collider.gameObject.CompareTag("Board")) {
                Vector3 worldPosition = gameCamera.ScreenToWorldPoint(Input.mousePosition);
                Coordinate coordinate = WorldPointToChessCoordinate(worldPosition);

                RemoveAllMarkers();
                List<Coordinate> moves = selectedFigure.Move(coordinate);

                // add positions only if the selected coordinate available for the selected figure
                if (moves.Count > 0)
                {
                    // add selected position
                    AddMarker(redSphere, coordinate);
                    // add possible move
                    foreach (Coordinate c in moves)
                    {
                        AddMarker(blueSphere, c);
                    }
                }
            }
        }
    }

    void AddMarker(GameObject prefab, Coordinate coordinate)
    {
        Vector3 worldPosition = ChessCoordinateToWorldPoint(coordinate);
        GameObject marker = Instantiate(prefab, worldPosition, prefab.transform.rotation);

        markers.Add(marker);
    }

    void RemoveAllMarkers()
    {
        foreach (GameObject marker in markers)
        {
            Destroy(marker);
        }
    }

    Coordinate WorldPointToChessCoordinate(Vector3 position)
    {
        int column = Mathf.FloorToInt((position.x + offsetFromCenter) / cellSize) + Coordinate.MinColumn;
        int row = Mathf.FloorToInt((position.y + offsetFromCenter) / cellSize) + Coordinate.MinRow;

        return new Coordinate(column, row);
    }

    Vector3 ChessCoordinateToWorldPoint(Coordinate coordinate)
    {
        float x = (coordinate.column - Coordinate.MinColumn) * cellSize - offsetFromCenter + cellSize / 2;
        float y = (coordinate.row - Coordinate.MinRow) * cellSize - offsetFromCenter + cellSize / 2;

        return new Vector3(x, y, -0.5f);
    }
}
