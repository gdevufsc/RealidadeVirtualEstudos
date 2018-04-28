using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///Esse script deve ser colocado em objetos que realizarão alguma ação caso sejam encarados. Deve ser configurado no editor o tipo do Interactable
///As possibilidades atuais são: TestButton. Para isso, deve ser colocado o Script CameraRaycaster na Main Camera

///Detalhes da implementação:
///
public class Interactable : MonoBehaviour {

	public string tipo; //setar para TestButton

	bool isInsideInteractable;

	//tempo para a ação acontecer
	public float timeToInteraction=1;

	public GameObject SliderImprovisado; //o vermelho feito de mesh

	//atributos para usar o SliderImprovisado
	float ContadorTempo=0;
	public Vector3 ajusteY = new Vector3 (0, 1f, 0); // o "Slider" fica deslocado por esse vetor. Ou seja, fica 1 unidade em cima (eixo y) do objeto

	//variaveis para o tipo TestButton
	bool EstahNaPosicaoOriginal = true;
	Vector3 PosicaoOriginal;

	//esse método só modifica o valor de isInsideInteractable
	public void SetIsInsideInteractable(bool visInsideInteractable){
		isInsideInteractable = visInsideInteractable;

	}

	void Start () {
		PosicaoOriginal = transform.position;
	}


	//InteractableAction verifica o tipo do Interactable, e chama as funções de acordo com isso.
	public void InteractableAction(){
		switch (tipo) {
		    case "TestButton":
			    CallTestButton ();
		    break;
            case "Sugar":
                CallSugar();
            break;
		    default:
		return;
		}
	}

	void CallTestButton (){
		//print ("TestButton worked");
		if(ContadorTempo==0)
			StartCoroutine (SelectTestButtonCoroutine ());
	}

	//corrotina para definir o tempo que se está encarando algo, e disparar uma função no final.
	IEnumerator SelectTestButtonCoroutine ()
	{

        //--------------------inicio da lógica de fazer o slider e contar o tempo
        GameObject sliderImprovisado = Instantiate(SliderImprovisado, transform.position + ajusteY, Quaternion.identity);
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

        //--------------------inicio da lógica própria do Tipo de Interactable
        if (isInsideInteractable) //Esse if é necessario, se não vai executar a qualquer momento que se pare de encarar
        { 

            if (EstahNaPosicaoOriginal) {
				gameObject.transform.position -= PosicaoOriginal - new Vector3 (PosicaoOriginal.x,
                                                        PosicaoOriginal.y, PosicaoOriginal.z - 1);
				EstahNaPosicaoOriginal = false;
			} else {
				gameObject.transform.position = PosicaoOriginal;
				EstahNaPosicaoOriginal = true;
			}

		}
        //--------------------final da lógica própria do tipo de Interactable
    }


//------------começo do código referente ao tipo CallSugar
    void CallSugar()
    {
        //print ("TestButton worked");
        if (ContadorTempo == 0)
            StartCoroutine(SugarCoroutine());
    }

    IEnumerator SugarCoroutine()
    {
        Vector3 SugarAjusteY = new Vector3(0,-.5f,0);
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

        //--------------------inicio da lógica própria do Tipo de Interactable
        if (isInsideInteractable) //Esse if é necessario, se não vai executar a qualquer momento que  pare de encarar
        {
            float minX = -2.014f, minZ = -1.743f, maxX = 2.559f, maxZ = 0.955f; //valores pegos no editor com teste

            Vector3 novaPosicao = new Vector3(  
                                                Random.Range(minX,maxX),
                                                PosicaoOriginal.y,
                                                Random.Range(minZ,maxZ)
                                             );

            gameObject.transform.parent.transform.position = novaPosicao;

        }
        //--------------------final da lógica própria do tipo de Interactable
    }
//------------final do código referente ao tipo CallSugar
}
