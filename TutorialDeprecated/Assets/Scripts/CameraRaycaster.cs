using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///Esse script deve ser colocado na Main Camera. Filho da Main Camera, deve existir um objeto que esteja posicionado
/// em x=0, y=0, e z>0 em relação à câmera. O CameraRaycaster serve para você olhar para um objeto no VR e com isso ser disparada
/// a função dele chamada InteractableAction(), para isso, o objeto deve ter o Script Interactable Associado, e o seu tipo configurado

public class CameraRaycaster : MonoBehaviour {

	Camera cam;
	RaycastHit rch; //usado para ver onde um raio colidiu, e retornar o objeto com o qual ele colidiu
	Interactable lastInteractable=null; //isso vai fazer parte da lógica de parar de chamar InteractableAction() quando se pára de encarar o objeto
	public Transform pointer; // é o componente do objeto que deve estar em x=y y=0 e z>0 em relação à câmera

	void Start(){
		cam = GetComponent<Camera>(); //captura o componente câmera desse Game Object
	}

	void Update()
	{
		//crie um raio que saia da posição desse game object e vá na direção do Pointer
		Ray ray = new Ray(transform.position, pointer.transform.position - transform.position);

		//desenha esse raio, mas só aparece na aba scene. Não no gamee. É essa a intenção da classe Debug
		Debug.DrawRay(ray.origin, ray.direction * 10, Color.yellow);

		// se o raio colidir com algum com um collider, retorna esse objeto na variável RaycastHit chamada rch
		if (Physics.Raycast(ray, out rch))
		{
			//print(rch.collider.gameObject.name); //para fins de teste

			//acessa o componente Interactable e o armazena na variável i
			Interactable i = rch.collider.GetComponent<Interactable> ();

			//armazena o i em lastInteractable
			lastInteractable = i;

			//Se tiver sido capturado um componente Interactable, avise ele de que ele foi encontrado
			if (i != null) {
				i.SetIsInsideInteractable (true);
			}

			//execute a ação dele (no script Interactable, isso vai ter a ver com o tipo configurado nele).
			i.InteractableAction ();
		} else {
			//print ("RaycastFailed");

			//essa é a lógica de parar de executar ações do Interactable quando o player para de olhar para ele:
			//se o lastInteractable não é null, avise o último interactable que ele não está sendo encarado.
			if(lastInteractable != null){
				//print ("lastInteractable != null");
				lastInteractable.SetIsInsideInteractable(false);
			}
		}
	}

}
