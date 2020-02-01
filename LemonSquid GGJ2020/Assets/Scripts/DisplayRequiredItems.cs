using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayRequiredItems : MonoBehaviour
{
    [SerializeField] private TMPro.TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TMPro.TextMeshProUGUI>();


        InteractableManager.OnItemsUpdate += UpdateText;
    }

    private void OnDestroy()
    {
    InteractableManager.OnItemsUpdate -= UpdateText;        
    }


    void UpdateText()
    {
        string str = "";


        int num = InteractableManager.Instance.repairRequired.Length;


        for (int i = 0; i < num;  ++i)
        {
            str += InteractableManager.Instance.repairRequired[i].GetDescription() + "\n";
        }





        text.text = str;
    }


}
