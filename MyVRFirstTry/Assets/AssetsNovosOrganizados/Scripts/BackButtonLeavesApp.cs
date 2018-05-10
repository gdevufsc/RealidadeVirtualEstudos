using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Esse script tem a intencao de fazer o botao X no smartphone fechar o aplicativo
public class BackButtonLeavesApp : MonoBehaviour {

	void Start () {
        Input.backButtonLeavesApp = true;
	}

}
