using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Button))]
public class ItemSpawner : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {
    [SerializeField] GameObject item;
    [SerializeField] GameObject realItemPrefab;
    private Vector2 mousePos;
    private GameObject theChild;

    public void OnPointerDown(PointerEventData eventData) {
        theChild = Instantiate(item, mousePos, Quaternion.identity);
        GameObject canvas = MenuManager.getInstance().getCanvas();
        theChild.transform.SetParent(canvas.transform);
    }

    public void OnPointerUp(PointerEventData eventData) {
        Destroy(theChild);
        GameObject realItem = Instantiate(realItemPrefab, (Vector2) Camera.main.ScreenToWorldPoint(mousePos), Quaternion.identity);
    }

    void Update() {
        mousePos = Input.mousePosition;
    }

    

}