using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// This script is used to manage the information shown in the information pannel
/// after the interaction with a case holder.
/// </summary>
public class InfoManager : MonoBehaviour{
    public TextMeshProUGUI  Title;
    public TextMeshProUGUI  Description;
    public TextMeshProUGUI  Theme;
    public TextMeshProUGUI  Types;

    public void setTitle(string title){
        Title.SetText(title);
    }
    public void setDescription(string desc){
        Description.SetText(desc);
    }    
    public void setTheme(string theme){
        Theme.SetText(theme);
    }
    public void setTypes(string types){
        Types.SetText(types);
    }
}
