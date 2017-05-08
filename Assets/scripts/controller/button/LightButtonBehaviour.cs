using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LightButtonBehaviour : MonoBehaviour {

    [SerializeField]
    private List<Light> lightList;

    [SerializeField]
    private Text text;

    private const string LIGHTS_TURN_ON = "Encender Luces";
    private const string LIGHTS_TURN_OFF = "Apagar Luces";

    void Start()
    {
        Button btn = gameObject.GetComponent<Button>();
        btn.onClick.AddListener(OnLightClick);
    }

    void OnLightClick()
    {
        if (lightList != null && lightList.Count > 0)
        {
            bool actualState = false;
            foreach (Light light in lightList) {
                actualState = light.enabled;
                light.enabled = !light.enabled;
            }

            if (actualState) {
                text.text = LIGHTS_TURN_ON;
            } else {
                text.text = LIGHTS_TURN_OFF;
            }
        }
        
        //Debug.Log("You have clicked the button!");
    }
}
