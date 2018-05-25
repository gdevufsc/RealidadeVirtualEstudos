using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

//Essa classe guarda informacao do estado do jogo.
public class Memoria : MonoBehaviour {

    public static string enderecoAtualMemoria = "";
    public static bool jahViuFlashback=false;

    public static void SetJahViuFlashback (bool jahViu) {
        jahViuFlashback = jahViu;
    }
}
