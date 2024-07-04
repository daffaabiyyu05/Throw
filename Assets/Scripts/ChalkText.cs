using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChalkText : MonoBehaviour
{
    [SerializeField] TMPro.TextMeshProUGUI chalkText;
    int chalkRemaining;
    // Start is called before the first frame update
    void Start()
    {
        chalkText = GetComponent<TMPro.TextMeshProUGUI>();
        if (chalkText == null)
        {
            Debug.LogError("Chalk Text not found!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        chalkRemaining = ThrowChalk.throwremaining;
        chalkText.text = "Chalk: " + chalkRemaining.ToString();
    }
}
