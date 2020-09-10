using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using JsonClasses;
using System;
    

/// <summary>
/// Class that manage the creation of the case holders and arcs
/// from the database in json, at the begining of the app execution
/// </summary>
public class CasesManager : MonoBehaviour{


    public GameObject casePrefab;   // Prefab of the case holder (Temporaly 3d rings on the prefab folder)
    public GameObject arcPrefab;   // Prefab of the arcs
    public GameObject arcTextPrefab;   // Prefab of the arc text
    public Transform wrapper;   // Instance of the cases wrapper, currently the image target
    private Case[] Cases;   // Array of case objects (with case info)
    private List<GameObject> CaseHolders = new List<GameObject>();   // Arraylist of the case holer objects
    private List<GameObject> Arcs = new List<GameObject>();   // Arraylist of the arcs objects
    private List<GameObject> TextArcs = new List<GameObject>();   // Arraylist of the arc text objects


    const string sampleJson = "Text/cases"; // Dir of the json database relative to the Resources folder

    void Start(){

        // Load the cases from the json file
        Cases = LoadJson(sampleJson);

        // TO CREATE THE CASES HOLDERS
        for(int i=0;i<Cases.Length;i++){

            // Set the parent's position
            Vector3 pPos = wrapper.position;
            
            // Creates an instance of the prefab case holder with the positions specified in the json relative to the parent's position
            GameObject temp = Instantiate(casePrefab, new Vector3(pPos.x + Cases[i].PosX, pPos.y + Cases[i].PosY, pPos.z + Cases[i].PosZ), Quaternion.identity);
            
            // Create a string with the types of innovations
            string tempTypes = Cases[i].Types[0];
            for(int k=1;k<Cases[i].Types.Length;k++){
                tempTypes = tempTypes + ", "+ Cases[i].Types[k];
            }

            // Set the Case information in the script that opens the info panel of the case holder           
            temp.GetComponent<openInfo>().setInfo(Cases[i].Innovation, Cases[i].Theme, tempTypes, Cases[i].Description);

            // Set the case holder as a child of the wrapper
            temp.transform.parent = wrapper;

            // Stores a reference of the case holder  in the case object
            Cases[i].Obj = temp;
            
            //Deactivate the object (Comment to see the cases from the start of the application)
            temp.SetActive(false);

            //Add to the array
            CaseHolders.Add(temp);

        }
        
        // TO CREATE THE ARCS
        for(int i=0;i<Cases.Length;i++){
            for(int j=i;j<Cases.Length;j++){
                if(i!= j){
                    for(int k=0;k<Cases[i].Types.Length;k++){
                        
                        // Check for common types of innovation
                        if(Array.Exists(Cases[j].Types, Cases[i].Types[k].Contains)){
                            // Creates an arc that joins the two cases with the common type
                            GameObject temp = Instantiate(arcPrefab, new Vector3(0,0,0), Quaternion.identity);
                            GameObject tempT = Instantiate(arcTextPrefab, new Vector3(0,0,0), Quaternion.identity);
                            
                            // Set the origin and the end of the arc to the two cases with the common type
                            temp.GetComponent<BezierCurve3PointRenderer>().Origin = Cases[i].Obj.transform;
                            temp.GetComponent<BezierCurve3PointRenderer>().End = Cases[j].Obj.transform;
                            
                            tempT.GetComponent<BezierCurve3PointRenderer>().Origin = Cases[i].Obj.transform;
                            tempT.GetComponent<BezierCurve3PointRenderer>().End = Cases[j].Obj.transform;

                            // Set the type for the background arc based on the type of innovation
                            temp.GetComponent<BezierCurve3PointRenderer>().SetType(Cases[i].Types[k]);
                            temp.GetComponent<BezierCurve3PointRenderer>().ColorArc();

                            // Set the Type for the arc of words
                            tempT.GetComponent<BezierCurve3PointRenderer>().SetType(Cases[i].Types[k]);
                            tempT.GetComponent<TextCurve3PointRenderer>().SetType(Cases[i].Types[k]);



                            // Makes the arc a child of the wrapper
                            temp.transform.parent = wrapper;
                            tempT.transform.parent = wrapper;

                            //Deactivate the object (Comment to see the cases from the start of the application)
                            temp.SetActive(false);
                            tempT.SetActive(false);
                            
                            //Add to the array
                            Arcs.Add(temp);
                            TextArcs.Add(tempT);
                        }
                    }
                }

            }   
        }
        // ShowCases(); Uncomment only for testing purposes
    }

    /**
    * Activate the objects and statr the animations of the arcs
    */
    public void ShowCases(){
        foreach(GameObject ch in CaseHolders){
            ch.SetActive(true);
        }
        
        foreach(GameObject a in Arcs){
            a.SetActive(true);
            a.GetComponent<BezierCurve3PointRenderer>().initialAnimation();
        }
        foreach(GameObject ta in TextArcs){
            ta.SetActive(true);
            ta.GetComponent<BezierCurve3PointRenderer>().initialAnimation();
            ta.GetComponent<TextCurve3PointRenderer>().startAnimation();
        }
    }

    /**
    * Load a list of Case objects from a JSON
    */
    public Case[] LoadJson(string fileName){

        TextAsset targetFile = Resources.Load<TextAsset>(fileName);
        string json = targetFile.text;
        ListItem items = JsonUtility.FromJson<ListItem>(json);
        return items.Cases;
    }
}
