using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JsonClasses;

/// <summary>
/// Activates the information pannel based on
/// the object that was activated by the user
/// </summary>
public class openInfo : MonoBehaviour {
    public GameObject InfoPanel; // Reference to the information pannel
    private Case caseInfo; // Reference to the case object with thei information to show
    private InfoManager InfoManager; // Reference to the scrpti that manages the information to show
    public string Title; // Pannel title
    private string Description; // Case description
    private string Theme; // Case theme
    private string Types; // Types of information in the case

/* The awake is called before most of the processes to find the references needed to
*  link the information to the hidden pannel 
**/
    void Awake(){

        if(InfoPanel == null){
            Object[] infoPanels = Resources.FindObjectsOfTypeAll(typeof(InfoManager));
            if(infoPanels.Length > 0){
                InfoManager = (InfoManager)infoPanels[0];
                InfoPanel = InfoManager.gameObject;
            }
        }
    }

    // Update is called once per frame
    void Update(){
        // To respond to clicks (for debugging in unity interface)
        if (Input.GetMouseButtonDown(0)){ // if left button pressed...
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit; // Object to manage the game object collisions 
        if (Physics.Raycast(ray, out hit)){
            if(hit.transform.tag == "aro") {
                string caseTitle = hit.transform.gameObject.GetComponent<openInfo>().Title;
                if(caseTitle == Title){
                    OpenInfoPanel();
                }
            }
        }
   }
        // To respond to touch interactions (in mobile)
        if (Input.touchCount >= 1) {
            // The pos of the touch on the screen
            Vector2 vTouchPos = Input.GetTouch(0).position;

            // The ray to the touched object in the world
            Ray ray = Camera.main.ScreenPointToRay(vTouchPos);
                
            // Your raycast handling
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit))
            {
                if(hit.transform.tag == "aro") {
                    string caseTitle = hit.transform.gameObject.GetComponent<openInfo>().Title;
                    if(caseTitle == Title){
                        OpenInfoPanel();
                    }                
                }
            }
        }
    }
    // Activates the info panel and uses the InfoManager to set the text for each visual element
    public void OpenInfoPanel(){

        if(InfoPanel != null){
            InfoPanel.SetActive(true);
            InfoManager.setTitle(Title);
            InfoManager.setTheme(Theme);
            InfoManager.setTypes(Types);
            InfoManager.setDescription(Description);
        }
    }
    // Sets the information for a case
    public void setInfo(string title, string theme, string types, string desc){
        this.Title = title;
        this.Theme = theme;
        this.Types = types;
        this.Description = desc;

    }
}

