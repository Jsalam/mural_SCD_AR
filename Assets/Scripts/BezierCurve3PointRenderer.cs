using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// Class to draw the arcs
/// </summary>
    [ExecuteInEditMode]
public class BezierCurve3PointRenderer : MonoBehaviour{
    public Transform Origin;    // Reference of the origin coordinates 
    public Transform End;    // Reference of the origin coordinates 
    public LineRenderer lineRenderer;     // Reference of the line renderer which create the lines
    public int VertexCount = 19;     // Reference of the line renderer which create the lines
    public float CurveHigt = 1;     // Reference of the line renderer which create the lines
    private int Ang;     // Reference of the line renderer which create the lines
    public float AnimAng;     // Reference of the line renderer which create the lines
    public string Type;     // Reference of the line renderer which create the lines
    public Animator ArcAnim;     // Reference of the line renderer which create the lines

    void Update(){
        
        // Gets the three initial vectors to create the curve
        Vector3 pointA = Origin.position;
        Vector3 pointC = End.position;

        // The initial middle point of the arc is calculated center of the two elements
        Vector3 pointB = (pointC + pointA)/2f;

        // The base high of the arc is calculated in term of the distance between its elements
        float high = Vector3.Distance(pointA, pointC);

        // The specified hight is added to the middle point
        pointB.y = pointB.y + high - (high*AnimAng);

        // moves the middle vector to create the effect of rotation
        pointB.z = pointB.z - ((high+CurveHigt)*AnimAng);

        // Creates and calculates the position of the curve's points
        var PointList = new List<Vector3>();
        for(float ratio = 0; ratio <=1; ratio +=1.0f/VertexCount){
            var tangentLineVertexA = Vector3.Lerp(pointA, pointB, ratio);
            var tangentLineVertexB = Vector3.Lerp(pointB, pointC, ratio);
            var bezierPoint = Vector3.Lerp(tangentLineVertexA, tangentLineVertexB, ratio);
            PointList.Add(bezierPoint);
        }

        // Creates the line based on the points
        lineRenderer.positionCount = PointList.Count;
        lineRenderer.SetPositions(PointList.ToArray());
    }

    /**
    * Set the type and set the arc's angle
    */
    public void SetType(string type){

        this.Type = type;

        switch (Type){
            case "Technology":
            Ang = 2;
            break;
            
            case "Methodology":
            Ang = 3;
            break;
            
            case "Process":
            Ang = 4;
            break;

            case "Framework":
            Ang = 5;
            break;
      }
    }

    /**
    * Set the arc color based on it's type
    */
    public void ColorArc(){
        float alf = 0.7f;

        switch (Type){
            case "Technology":
            lineRenderer.SetColors(new Color(0.165f, 0.255f, 0.588f, alf),new Color(0.553f, 0.517f, 0.6f, alf));
            break;
            
            case "Methodology":
            lineRenderer.SetColors(new Color(0.776f, 0.435f, 0.588f, alf),new Color(0.757f, 0.651f, 0.447f, alf));
            break;
            
            case "Process":
            lineRenderer.SetColors(new Color(0.674f, 0.706f, 0.447f, alf),new Color(0.835f, 0.855f, 0.588f, alf));
            break;

            case "Framework":
            lineRenderer.SetColors(new Color(0.863f, 0.266f, 0.137f, alf),new Color(0.886f, 0.592f, 0.553f, alf));
            break;
      }
    }



    public void initialAnimation(){
        //ArcAnim.Play("ArcOut");
    }

}
