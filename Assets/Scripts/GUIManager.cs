using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GUIManager : MonoBehaviour {

    public Slider healthSlider, resistanceSlider;

    public void Update () {
        healthSlider.value = GameManager.Instance.LifeManager.life;
        resistanceSlider.value = GameManager.Instance.ShieldManager.resistance;
    }
}