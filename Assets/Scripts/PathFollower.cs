using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;
using Unity.Mathematics;

public class PathFollower : MonoBehaviour
{
    [SerializeField] SplineContainer splineContainer;
    [SerializeField, Range(0,1)] float tdistance = 0;

    [Range(0,40)] public float speed = 1;

    //public float speed { get; set; }
    public float length { get { return splineContainer.CalculateLength(); } }
    public float distance 
    { 
        get { return tdistance * length;} 
        set { tdistance = value / length; }
    }
  

    void Update()
    {
        distance += speed * Time.deltaTime;
        UpdateTransform(math.frac(tdistance));
    }

    void UpdateTransform(float t)
    {
        Vector3 position = splineContainer.EvaluatePosition(t);
        Vector3 up = splineContainer.EvaluateUpVector(t);
        Vector3 forward = Vector3.Normalize(splineContainer.EvaluateTangent(t));
        Vector3 right = Vector3.Cross(up, forward);

        transform.position = position;
        transform.rotation = Quaternion.LookRotation(forward, up);
    }
}
