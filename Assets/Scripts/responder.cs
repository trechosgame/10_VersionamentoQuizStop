using UnityEngine;
using UnityEditor.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using Unity.VisualScripting;
using System;

public class responder : MonoBehaviour
{
    private int idTema;
    public Text pergunta;
    public Text respostaA;
    public Text respostaB;
    public Text respostaC;
    public Text respostaD;
    public Text infoRespostas;

    public string[] perguntas;  // armazena todas as perguntas
    public string[] alternativaA;  // armazena todas as alternativas A

    public string[] alternativaB;  // armazena todas as alternativas B

    public string[] alternativaC;   // armazena todas as alternativas C

    public string[] alternativaD;  // armazena todas as alternativas D


    public string[] corretas;  // armazena as alternativas corretas

    private int idPergunta;
    private float acertos;
    private float questoes;
    private float media;
    private int notaFinal;

    
    void Start()
    {
        idTema = PlayerPrefs.GetInt("idTema");
        idPergunta = 0;
        questoes = perguntas.Length;
        pergunta.text = perguntas[idPergunta];
        respostaA.text = alternativaA[idPergunta];
        respostaB.text = alternativaB[idPergunta];
        respostaC.text = alternativaC[idPergunta];
        respostaD.text = alternativaD[idPergunta];

        infoRespostas.text = "    Respondendo "+(idPergunta + 1).ToString()+ " de "+questoes.ToString() + " perguntas.";
    }

    public void resposta(string alternativa)
    {
        if (alternativa == "A")
        {
            if (alternativaA[idPergunta] == corretas[idPergunta])
            {
                acertos += 1;
            }
        }

        else if (alternativa == "B")
        {
           if (alternativaB[idPergunta] == corretas[idPergunta])
            {
                acertos += 1;
            }
        }

        else if (alternativa == "C")
        {
           if (alternativaC[idPergunta] == corretas[idPergunta])
            {
                acertos += 1;
            }
        }

        else if (alternativa == "D")
        {
           if (alternativaD[idPergunta] == corretas[idPergunta])
            {
                acertos += 1;
            }
        }
        proximaPergunta();
       
    }

    void proximaPergunta()
    {
        idPergunta += 1;

        if (idPergunta <= (questoes - 1))
        {
            pergunta.text = perguntas[idPergunta];
            respostaA.text = alternativaA[idPergunta];
            respostaB.text = alternativaB[idPergunta];
            respostaC.text = alternativaC[idPergunta];
            respostaD.text = alternativaD[idPergunta];

            infoRespostas.text = "    Respondendo " + (idPergunta + 1).ToString() + " de " + questoes.ToString() + " perguntas.";
        }
        else
        {
            // O QUE FAZER SE TERMINAR AS PERGUNTAS
            media = 10 * (acertos / questoes); // CALCULA A MEDIA COM BASE NO PERCENTUAL DE ACERTO
            notaFinal = Mathf.RoundToInt(media); // ARREDONDA A NOTA PARA O PRÓXIMO INTEIRO, SEGUNDO A REGRA DA MATEMÁTICA.

            if (notaFinal > PlayerPrefs.GetInt("notaFinal" + idTema.ToString()))
            {
                PlayerPrefs.SetInt("notaFinal"+idTema.ToString(), notaFinal);
                PlayerPrefs.SetInt("acertos"+idTema.ToString(), (int) acertos);
            }
            PlayerPrefs.SetInt("notaFinalTemp"+idTema.ToString(), notaFinal);
            PlayerPrefs.SetInt("acertosTemp"+idTema.ToString(), (int) acertos);

            SceneManager.LoadScene("notaFinal");
        }

       
    }







    // Update is called once per frame
    void Update()
    {
        
    }
}
