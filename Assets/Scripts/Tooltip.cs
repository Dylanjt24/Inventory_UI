using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tooltip : MonoBehaviour
{
    private Text tooltipText;
    
    // Start is called before the first frame update
    void Start()
    {
        tooltipText = GetComponentInChildren<Text>();
        gameObject.SetActive(false);
    }

    // Creates the tooltip depending on which item is selected
    public void GenerateTooltip(Item item)
    {
        string statText = ""; // Start statText as an empty string
        if (item.stats.Count > 0) // Make sure item has stats
        {
            foreach(var stat in item.stats)
            {
                statText += stat.Key.ToString() + ": " + stat.Value.ToString() + "\n"; // Concatenate stat key value pairs on to statText
            }
        }

        // Get the relevant tooltip information for the specific item and add it to tooltip string
        string tooltip = $"<b>{item.title}</b>\n" +
            $"{item.description}\n\n" +
            $"<b>{statText}</b>";
        tooltipText.text = tooltip;
        gameObject.SetActive(true);
    }
}
