using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineDraw : MonoBehaviour
{
    public GameObject linePrefab;
    public GameObject currentLine;
    public LineRenderer lineRenderer;
    public EdgeCollider2D edgeCollider;
    public List<Vector2> mousePositions;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("mouse button is down...");
            CreateLine();
        }

        if (Input.GetMouseButton(0))
        {
            Vector2 tempMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if(Vector2.Distance(tempMousePos, mousePositions[mousePositions.Count - 1]) > .1f)
            {
                UpdateLine(tempMousePos);
            }    
        }
    }

    void CreateLine()
    {
        Debug.Log("create line is called...");
        currentLine = Instantiate(linePrefab, Vector3.zero, Quaternion.identity);
        Destroy(currentLine, 1f);
        lineRenderer = currentLine.GetComponent<LineRenderer>();
        edgeCollider = currentLine.GetComponent<EdgeCollider2D>();
        mousePositions.Clear();
        mousePositions.Add(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        mousePositions.Add(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        lineRenderer.SetPosition(0, mousePositions[0]);
        lineRenderer.SetPosition(1, mousePositions[1]);
        edgeCollider.points = mousePositions.ToArray();
    }

    void UpdateLine(Vector2 newMousePos)
    {
        Debug.Log("update line is called...");
        mousePositions.Add(newMousePos);
        lineRenderer.positionCount++;
        lineRenderer.SetPosition(lineRenderer.positionCount - 1, newMousePos);
        edgeCollider.points = mousePositions.ToArray();
    }
}
