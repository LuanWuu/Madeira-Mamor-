using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class roadMap : MonoBehaviour
{
    [SerializeField] private bool BOSS;

    [SerializeField] private TextMeshProUGUI characterLines;
    // Start is called before the first frame update
    void Start()
    {
        if(BOSS == true){
            GetComponent<Renderer>().material.color =  Color.red;
        }
    }
    public void Randomized(){
        if(BOSS == false){
            int r = Random.Range(0,9);
            switch(r){
                case 0:
                    characterLines.text = "Aonde pensa que vai?";
                    break;
                case 1:
                    characterLines.text = "Prefere que eu acabe logo com isso?";
                    break;
                case 2:
                    characterLines.text = "Seu trabalho fica pro outro lado...";
                    break;
                case 3:
                    characterLines.text = "Você acha que essa ferrovia realmente vai ser tão importante?";
                    break;
                case 4:
                    characterLines.text = "Às vezes eu duvido de tudo que dizem sobre a importância do nosso trabalho...";
                    break;
                case 5:
                    characterLines.text = "Parece que estamos apenas adoecendo por nada.";
                    break;
                case 6:
                    characterLines.text = "Se quiser ser pago é melhor trabalhar direito.";
                    break;
                case 7:
                    characterLines.text = "Continue assim e nem precisa voltar amanhã.";
                    break;
                case 8:
                    characterLines.text = "Incompetência não é recompensada.";
                    break;
            }
        }else{
            characterLines.text = "Tarefa, pegar as caixa e colocar nos vagões, cada vagão aceita certos tipos de carga. Termine antes do prazo. Precione {Enter} para ir";
        }


    }
}
