using Assets.Controllers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopTriggerCollider : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        GameController.Instance.ShopController.ShowShop();
    }

    private void OnTriggerExit(Collider other)
    {
        GameController.Instance.ShopController.HideShop();
    }
}
