using System;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour {
    private static MenuManager instance;
    private Dictionary<MenuTypes, GameObject> entryMap;
    [SerializeField] menuEntry[] entries;
    [SerializeField] GameObject canvas;

    [Serializable] 
    public struct menuEntry {
        public MenuTypes type;
        public GameObject obj;
    }

    private void Awake() {
        instance = !instance? this : instance;
        entryMap = new Dictionary<MenuTypes, GameObject>();
        foreach(menuEntry e in entries) {
            entryMap.Add(e.type, e.obj);
        }
    }

    public static MenuManager getInstance() {
        return instance;
    }
    public void closeUI(MenuTypes menu) {
        entryMap[menu].SetActive(false);
    }
    private void Update() {
        if (Input.GetKeyDown("w")) {
            closeUI(MenuTypes.ADD_TOWER);
        }
    }
    public GameObject getCanvas() {
        return canvas;
    }
}

public enum MenuTypes {
    ADD_TOWER
}