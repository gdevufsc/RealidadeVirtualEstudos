using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///Esse script simula o funcionamento do script GvrEditorEmulator do pacote GoogleVR
///O objetivo é fazer testes de VR no editor da Unity sem precisar de um headset devidamente configurado
///Ou seja, aperte espaço e mova o mouse para rodar a câmera
///Esse script deve ser colocado em um game object pai da câmera, e esse game object deve ter um pai também
///na mesma posição e rotação

public class MyGvrEditorEmulator : MonoBehaviour {
    
	void Update () {
#if UNITY_EDITOR //se está no editor da Unity
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(MouseCoroutine());
        }
#endif
    }

    IEnumerator MouseCoroutine()
    {
        // vamos incrementar a cada frame, então precisamos de uma variável que guarde a posição no último frame.
        Vector3 LastMousePosition = Input.mousePosition; 
        while (Input.GetKey(KeyCode.Space))
        {
            ///Minha primeira tentativa foi dar um transform.Rotate() nesse objeto, mas não funcionou.
            ///Isso porque quando a câmera rodava em um eixo, ela deslocava os outros eixos. O transform.Rotate()
            ///Usa os eixos locais.. aí no primeiro movimento funcionava, depois começava a entortar.
            ///A solução foi separar o giro em um eixo pro pai e um eixo pra esse objeto. Aí deu.

                transform.Rotate(LastMousePosition.y - Input.mousePosition.y,
                                 0,
                                 0
                                );

                transform.parent.transform.Rotate(0,
                                 Input.mousePosition.x - LastMousePosition.x,
                                 0
                                );

            LastMousePosition = Input.mousePosition;
            
            yield return null;
        }

    }
}
