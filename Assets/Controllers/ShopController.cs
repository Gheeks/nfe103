using Assets.Models.Common;
using Assets.Models.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopController : MonoBehaviour
{
    public ShopUI shop;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public ShopUI CreateGlobalShop()
    {
        shop = new ShopUI();
        shop.Items = new List<Item>();
        shop.container = GameObject.Find("UI").transform.Find("ShopSystem").transform.Find("container");
        shop.shopItemTemplate = shop.container.Find("shopItemTemplate");
        shop.container.gameObject.SetActive(false);
        return shop;
    }

    public void CreateItemButton(Item item)
    {
        // Create gameobject
        Transform shopItemTransform = Instantiate(shop.shopItemTemplate, shop.container);
        RectTransform rectTransform = shopItemTransform.GetComponent<RectTransform>();

        //Fill details
        rectTransform.Find("itemImage").GetComponent<Image>().sprite = item.Sprite;
        rectTransform.Find("itemNameText").GetComponent<Text>().text = item.Name;
        rectTransform.Find("itemDescriptionText").GetComponent<Text>().text = item.Description;
        rectTransform.Find("itemPriceText").GetComponent<Text>().text = item.Price.ToString();

        //Placement
        if (shop.Items.Count == 0)
        {
            rectTransform.anchoredPosition = new Vector2(shop.lastUIXPosition, shop.lastUIYPosition);
        }
        else
        {
            if (shop.lastUIXPosition == 75400f)
            {
                shop.lastUIXPosition = -73000f;
                shop.lastUIYPosition -= 21800f;
            }
            else
            {
                shop.lastUIXPosition += 74200;
            }
            rectTransform.anchoredPosition = new Vector2(shop.lastUIXPosition, shop.lastUIYPosition);
        }

        //Add item model
        item.FillGameObjectModel(rectTransform.GetComponent<Item>());
        rectTransform.gameObject.SetActive(true);
        rectTransform.gameObject.name = item.Name;

        rectTransform.GetComponent<Button>().onClick.AddListener(delegate () { shop.BuyItem(item); });

        //Keep in list
        shop.Items.Add(item);
    }

    public void ShowShop()
    {
        shop.container.gameObject.SetActive(true);
    }

    public void HideShop()
    {
        shop.container.gameObject.SetActive(false);
    }
}
