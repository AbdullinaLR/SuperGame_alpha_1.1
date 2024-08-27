using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractableItem : MonoBehaviour
{
    [SerializeField]
    private GameObject pickUpUI;

    [SerializeField]
    private Sprite pickUpSprite; 

    private bool pickUpAllowed;

    private void Start() 
    {
        pickUpUI.SetActive(false);
    }

    private void Update()
    {
        if (pickUpAllowed && Input.GetKeyDown(KeyCode.E))
        {
            PickUp();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Hero"))
        {
            pickUpUI.SetActive(true);
            pickUpAllowed = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Hero"))
        {
            pickUpUI.SetActive(false);
            pickUpAllowed = false;
        }
    }

    private void PickUp()
    {
        Destroy(gameObject);
        pickUpUI.SetActive(false);
        ShowPickUpImage(); 
    }

    private void ShowPickUpImage()
    {
        GameObject pickUpImageUI = new GameObject("PickUpImage");
        pickUpImageUI.transform.SetParent(GameObject.Find("UI Elements (Canvas)").transform, false);

        Image imageComponent = pickUpImageUI.AddComponent<Image>();
        imageComponent.sprite = pickUpSprite;

        RectTransform rectTransform = pickUpImageUI.GetComponent<RectTransform>();
        rectTransform.sizeDelta = new Vector2(600, 400); // меняем туда сюда подгоняем для красот
        rectTransform.anchorMin = new Vector2(0.5f, 0.5f); 
        rectTransform.anchorMax = new Vector2(0.5f, 0.5f); 
        rectTransform.anchoredPosition = Vector2.zero; 

        Destroy(pickUpImageUI, 5f);
    }
}
