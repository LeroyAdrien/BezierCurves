using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BezierDrawer : MonoBehaviour
{
    public int nbPoints = 50;
    private Vector3[] positions = new Vector3[50];
    public LineRenderer lineRenderer;
    public Transform position0;
    public Transform position1;
    public Transform position2;

    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = nbPoints;
        DrawLineCurve(position0.position, position1.position, position2.position);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void DrawLineCurve(Vector3 p0, Vector3 p1, Vector3 p2)
    {
        for (int i = 1; i < nbPoints + 1; i++)
        {
            float t = i / (float) nbPoints;
            print(t);
            positions[i - 1] = BezierCurve(t, p0, p1, p2);
            
        }

        lineRenderer.SetPositions(positions);
    }
    Vector3 BezierCurve(float t, Vector3 p0, Vector3 p1, Vector3 p2)
    {
        return (1 - t) * (1 - t) * p0 + 2 * p1 * t * (1 - t) + p2 * t * t;
    }
}
