using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//para usar uma função q tu escreveu no event system faz o seguinte: põe o event trigger no objeto que vai receber o evento
//aí linka com o objeto que vai ser manipulado (ele deve ter o script que você criou). Daí pode achar pelo editor a tua função
//ali intuitivamente

public class MyScript : MonoBehaviour {

    public Slider slider;
    bool isInsideInteractable;
    float timeToFillSlider = 1f;
    public Text text;
    string textContent = "Voce encarou o verde";
	//public Canvas canvas;

    void Start () {
        isInsideInteractable = false;
        slider.value = 0;
        slider.gameObject.SetActive(false);
	}

    public void DisplaySlider()
    { 	
		//canvas.gameObject.SetActive (true);
        slider.gameObject.SetActive(true);
        isInsideInteractable = true;
        StartCoroutine(MyCoroutine());
    }

    IEnumerator MyCoroutine ()
    {
        while (isInsideInteractable && slider.value < timeToFillSlider)
        {
            slider.value += Time.deltaTime;
            yield return null;
        }
        slider.gameObject.SetActive(false);
        ModifyText();
    }

    public void HideSlider()
    {
        isInsideInteractable = false;
        slider.value = 0;
        slider.gameObject.SetActive(false);
		//canvas.gameObject.SetActive (false);
    }

    void ModifyText()
    {
        text.text = textContent;
    }
}
