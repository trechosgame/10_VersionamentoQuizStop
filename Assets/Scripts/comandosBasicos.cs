using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class comandosBasicos : MonoBehaviour
{
    public void carregaCena(string nomeCena)
    {
        SceneManager.LoadScene(nomeCena);
    }

    public void resetarPontuacoes()
    {
        PlayerPrefs.DeleteAll();
    }
    
    
}
