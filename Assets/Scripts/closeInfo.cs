using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script to hide the information panel after tab close
/// This also resets the scroll position
/// </summary>
public class closeInfo : MonoBehaviour
{
    public GameObject InfoPanel;

    public void CloseInfoPanel(){
        if(InfoPanel != null){

            GameObject content = GameObject.Find("Content");
            content.transform.position = new Vector3(content.transform.position.x, -1000, content.transform.position.z);
            InfoPanel.SetActive(false);
        }
    }
}
