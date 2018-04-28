using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sugar : MonoBehaviour {

    bool isInsideInteractable;

    //tempo para a ação acontecer
    public float timeToInteraction = 1;

    public GameObject SliderImprovisado; //o vermelho feito de mesh

    //atributos para usar o SliderImprovisado
    float ContadorTempo = 0;
    // o "Slider" fica deslocado por esse vetor. Ou seja, fica 1 unidade em cima (eixo y) do objeto
    public Vector3 ajusteY = new Vector3(0, -1f, 0);

    Vector3 PosicaoOriginal;

    void Start()
    {
        PosicaoOriginal = transform.position;
    }

    //esses métodos só modificam o valor de isInsideInteractable
    public void IsInsideInteractable()    {   isInsideInteractable = true;   }
    public void IsNotInsideInteractable() {   isInsideInteractable = false;  }

    public void CallSugar()
    {
        //print ("TestButton worked");
        if (ContadorTempo == 0)
            StartCoroutine(SugarCoroutine());
    }

    IEnumerator SugarCoroutine()
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

        //--------------------inicio da lógica própria teleporte
        if (isInsideInteractable) //Esse if é necessario, se não vai executar a qualquer momento que  pare de encarar
        {
            float minX = -2.014f, minZ = -1.743f, maxX = 2.559f, maxZ = 0.955f; //valores pegos no editor com teste

            Vector3 novaPosicao = new Vector3(
                                                Random.Range(minX, maxX),
                                                PosicaoOriginal.y,
                                                Random.Range(minZ, maxZ)
                                             );

            gameObject.transform.parent.transform.position = novaPosicao;

        }
        //--------------------final da lógica própria do teleporte

        //para consertar o caso de quando o sugar se teleporta para onde você já estava olhando
        //porque isso não ativa o evento onPointerEnter
        yield return new WaitForSeconds(0.05f);
        if (isInsideInteractable)
        {
            CallSugar();
        }
    }
    //------------final do código referente ao tipo CallSugar

    //public void PrintOk() { print("Ok"); }

}
