using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemSliderEContaTempo : MonoBehaviour {

    protected delegate void MyDelegate();
    protected MyDelegate myDelegate;

    //inicio de atributos e métodos para contar o tempo e ter slider -------------------------------------------
    bool isInsideInteractable;

    public void IsInsideInteractable() { isInsideInteractable = true; }
    public void IsNotInsideInteractable() { isInsideInteractable = false; }

    //tempo para a ação acontecer
    public float timeToInteraction = 1;

    public GameObject SliderImprovisado; //o vermelho feito de mesh

    //atributos para usar o SliderImprovisado
    float ContadorTempo = 0;
    // o "Slider" fica deslocado por esse vetor. Ou seja, fica 1 unidade em cima (eixo y) do objeto
    public Vector3 ajusteY = new Vector3(0, -1f, 0);

    Vector3 PosicaoOriginal;

    void Awake()
    {
        PosicaoOriginal = transform.position;
    }

    public void CallAction()
    {
        //print ("TestButton worked");
        if (ContadorTempo == 0)
            StartCoroutine(ActionCoroutine());
    }

    IEnumerator ActionCoroutine()
    {
        Vector3 SugarAjusteY = new Vector3(0, -.5f, 0);
        //--------------------inicio da lógica de fazer o slider e contar o tempo
        GameObject sliderImprovisado = Instantiate(SliderImprovisado, transform.position + SugarAjusteY, Quaternion.identity);
        Vector3 OriginalScale = sliderImprovisado.transform.localScale; //essas linhas instanciam o sliderImprovisado

        //Esse while vai contando o tempo e decrementando o sliderImprovisado
        while (isInsideInteractable && ContadorTempo < timeToInteraction)
        {
            ContadorTempo += Time.deltaTime;
            float relativeProgress = ContadorTempo / timeToInteraction;
            sliderImprovisado.transform.localScale = OriginalScale - new Vector3(0, 0, OriginalScale.z * relativeProgress);
            yield return null;
        }

        // note que o slider é destruído e o tempo zerado quando sai do while. Tanto faz se isInsideInteractable ou is not haha
        Destroy(sliderImprovisado);
        ContadorTempo = 0;
        //--------------------final da lógica de fazer o slider e contar o tempo

        //--------------------inicio da lógica da Action
        if(myDelegate!=null)
            myDelegate();
        //--------------------final da lógica da Action

    }
    //final dos atributose métodos para contar o tempo e ter slider -------------------------------------------
}
