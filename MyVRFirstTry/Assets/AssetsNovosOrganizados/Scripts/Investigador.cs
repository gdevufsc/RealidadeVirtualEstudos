using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Investigador : MonoBehaviour {

    //eu poderia chamar de boca, mas no modelo dele tem os olhos que eh bem perto
    public AudioSource olhosDoInvestigador; //coloquei a audiosource nos olhos
    public AudioClip audioVcJahViu;
    public float tempoAtehFalar = 3; //em segundos
    public GameObject HeadSeN;

	void Start () {
        Invoke("VcJahViu" , tempoAtehFalar);
        HeadSeN.SetActive(true);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void VcJahViu () {
        olhosDoInvestigador.PlayOneShot(audioVcJahViu);
    }
}
