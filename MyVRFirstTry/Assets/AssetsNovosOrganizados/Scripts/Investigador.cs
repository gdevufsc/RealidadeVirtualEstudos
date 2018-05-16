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
        //HeadSeN.SetActive(true);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void VcJahViu () {
        olhosDoInvestigador.PlayOneShot(audioVcJahViu);
        StartCoroutine(MostraHeadSeNAoFimDaPergunta());
    }

    //essa corrotina verifica se o audio estah sendo executado, para no fim ativar o objet HeadSeN
    IEnumerator MostraHeadSeNAoFimDaPergunta () {
        int k = 0;
        //verifica-se se jah comecou, pois tem um delay do metodo PlayOneShot ateh comecar
        while (!olhosDoInvestigador.isPlaying && k < 1200) { //se nao comecar em 20s, esquece
            k++;
            yield return null;
        }
        k = 0; //verifica se terminou. 3600 = 60*60 = 60 frames * 60 segundos = 3600 frames
        while (olhosDoInvestigador.isPlaying && k < 3600) { //se nao terminar em um minuto, aborta
            k++;
            yield return null;
        }
        HeadSeN.SetActive(true);
    }
}
