using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPath : MonoBehaviour
{
    public Transform position0;
    public Transform position1;
    public Transform position2;
    int speed = 1;
    int nbPoints=100;
    public Vector3[] positions = new Vector3[1];
    Coroutine MoveIE;

    


    // Start is called before the first frame update
    void Start()
    {
        positions = new Vector3[nbPoints];
        transform.position=position0.position;
        DrawLineCurve(position0.position, position1.position, position2.position);
        StartCoroutine(moveObject());
    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator moveObject()
    {
        for (int i = 0; i < positions.Length; i++)
        {
            MoveIE = StartCoroutine(Moving(i));
            yield return MoveIE;
        }
    }

    IEnumerator Moving(int currentPosition)
    {
        while (transform.position != positions[currentPosition])
        {
            transform.position = Vector3.MoveTowards(transform.position, positions[currentPosition], speed * Time.deltaTime);
            yield return null;
        }
    }

    Vector3 BezierCurve(float t, Vector3 p0, Vector3 p1, Vector3 p2)
    {
        return (1 - t) * (1 - t) * p0 + 2 * p1 * t * (1 - t) + p2 * t * t;
    }

        void DrawLineCurve(Vector3 p0, Vector3 p1, Vector3 p2)
    {
        for (int i = 1; i < nbPoints + 1; i++)
        {
            float t = i / (float) nbPoints;
            print(t);
            positions[i - 1] = BezierCurve(t, p0, p1, p2);
            
        }
    }
}   
