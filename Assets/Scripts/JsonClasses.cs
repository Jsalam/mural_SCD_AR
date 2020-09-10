using System;
using UnityEngine;

/// <summary>
/// This script manages the clases to deserialize the case information from the json
/// to an object. Edit to add any new extra information from the json structure
/// </summary>
namespace JsonClasses{
    [Serializable]
    public class ListItem
    {
        public Case[] Cases;

    }
    [Serializable]
    public class Case{
        public string Theme;
        public string Innovation;
        public string Description;
        public string URL;
        public string[] Types;
        public float PosX;
        public float PosY;
        public float PosZ;
        public GameObject Obj{ get; set;}

        public Case(string theme, string inno, string desc, string url, string[] types, float posX, float posY, float posZ){
            this.Theme = theme;
            this.Innovation = inno;
            this.Description = desc;
            this.URL = url;
            this.Types = types;
            this.PosX = posX;
            this.PosY = posY;
            this.PosZ = posZ;
        }
    }
}