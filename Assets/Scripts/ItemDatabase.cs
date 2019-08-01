using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{
    public List<Item> items = new List<Item>();

    private void Awake()
    {
        BuildDatabase();
    }

    // Finds an item by id
    public Item GetItem(int id)
    {
        return items.Find(item => item.id == id);
    }

    // Finds an item by name
    public Item GetItem(string itemName)
    {
        return items.Find(item => item.title == itemName);
    }

    // Creates the database with the defined items
    private void BuildDatabase()
    {
        items = new List<Item>()
        {
            new Item(0, "Diamond Sword", "A sword made of diamond.",
            new Dictionary<string, int>{
                { "Power", 15 },
                { "Defense", 10 }
            }),
            new Item(1, "Diamond Ore", "A pretty diamond.",
            new Dictionary<string, int>{
                { "Value", 300 }
            }),
            new Item(2, "Silver Pick", "A pickaxe made of silver. A vampire's nightmare.",
            new Dictionary<string, int>{
                { "Power", 5 },
                { "Mining", 20 }
            }),
        };
    }
}
