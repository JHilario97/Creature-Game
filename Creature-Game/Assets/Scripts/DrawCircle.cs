using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawCircle : MonoBehaviour
{
    private List<Vector2> points = new List<Vector2>();
    private LineRenderer lineRenderer;
    private bool isDrawing = false;
    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.positionCount = 0;
        lineRenderer.widthMultiplier = 0.1f;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                StartDrawing(touch.position);
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                ContinueDrawing(touch.position);
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                EndDrawing();
            }
        }
    }

    void StartDrawing(Vector2 startPosition)
    {
        points.Clear();
        lineRenderer.positionCount = 0;
        isDrawing = true;
        AddPoint(startPosition);
    }
    void ContinueDrawing(Vector2 Position)
    {
        if (isDrawing)
        {
            AddPoint(Position);
        }
    }
    void EndDrawing()
    {
        isDrawing = false;
        if(IsCircleClosed())
        {
            Debug.Log("Circle is Closed");
        }
    }
    void AddPoint(Vector2 point)
    {
        points.Add(Camera.main.ScreenToWorldPoint(point));
        lineRenderer.positionCount = points.Count;
        lineRenderer.SetPosition(points.Count - 1, points[points.Count - 1]);
    }
    bool IsCircleClosed()
    {
        if(points.Count < 3)
            return false;
        float distance = Vector2.Distance(points[0], points[points.Count - 1]);
        return distance > 0.1f;
    }

}
