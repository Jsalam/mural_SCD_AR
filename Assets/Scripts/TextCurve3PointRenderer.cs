using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// Class to manage the text shown in the arc shape
/// </summary>

    [ExecuteInEditMode]
public class TextCurve3PointRenderer : MonoBehaviour{

    // Animator object to control the animations
    public Animator TextAnim;

    // Material that will show the word as a texture
    private Material TextMaterial;

    // The reference of the line renderer to manipulate its properties
    public LineRenderer lineRenderer;

    // Offset value to translate the text (it will be change onlw for 0 to 1 to create the illusion of continum movement)
    public float textTranslation;

    void Start(){
        // Sets a default material
        TextMaterial = Resources.Load("Materials/TechnologyM") as Material;
    }

    void Update(){
        // Updates the offset of the text to allow the text animation
        lineRenderer.material.SetTextureOffset("_MainTex", new Vector2(textTranslation, 0));
    }

    // Sets the type of link and select the text image to use as material
    public void SetType(string Type){
        Debug.Log("Setting types");
        switch (Type){
            case "Technology":
            TextMaterial = Resources.Load("Materials/TechnologyM") as Material;
            break;
            
            case "Methodology":
            TextMaterial = Resources.Load("Materials/MethodologyM") as Material;
            break;
            
            case "Process":
            TextMaterial = Resources.Load("Materials/ProcessM") as Material;
            break;

            case "Framework":
            TextMaterial = Resources.Load("Materials/FrameworkM") as Material;
            break;
      }
      // set the material in the linerenderer
      lineRenderer.material = TextMaterial;
    }

    // Starts the animation of the text
    public void startAnimation(){
        TextAnim.Play("TextMovement");
    }

}
