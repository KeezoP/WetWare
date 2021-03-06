using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    public static Inventory instance;

    void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        Inventory.instance.Add(GameObject.Find("Icebreaker_Field").GetComponent<ItemPickup>().Item);
    }


    public delegate void onItemChanged();
    public onItemChanged onItemChangedCallback;

    public List<Item> items = new List<Item>();

    public void Add(Item item)
    {
        items.Add(item);

        if(onItemChangedCallback != null)
            onItemChangedCallback.Invoke();
    }

    public void Remove(Item item)
    {
        items.Remove(item);
        if (onItemChangedCallback != null)
            onItemChangedCallback.Invoke();
    }



}
