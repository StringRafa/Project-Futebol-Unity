using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CompraBola : MonoBehaviour
{

    public int bolasIDe;
    public Text btnText;
    private GameObject txtMoedas;
    private Animator falido;

    public void ComprarBolaBtn()
    {
        for (int i = 0; i < BolasShop.instance.bolasList.Count;i++)
        {
            if (BolasShop.instance.bolasList[i].bolasID == bolasIDe && !BolasShop.instance.bolasList[i].bolascomprou && PlayerPrefs.GetInt("moedasSave") >= BolasShop.instance.bolasList[i].bolasPreco)
            {
                BolasShop.instance.bolasList [i].bolascomprou = true;
                UpdateCompraBtn();
                ScoreManager.instance.PerdeMoedas(BolasShop.instance.bolasList[i].bolasPreco);
                GameObject.Find("PontosUI").GetComponent<Text>().text = PlayerPrefs.GetInt("moedasSave").ToString();

            }
            else if (BolasShop.instance.bolasList[i].bolasID == bolasIDe && !BolasShop.instance.bolasList[i].bolascomprou && PlayerPrefs.GetInt("moedasSave") <= BolasShop.instance.bolasList[i].bolasPreco)
            {
                falido = GameObject.FindGameObjectWithTag("falido").GetComponent<Animator>();
                falido.Play ("Falido");
            }
            
            
            
            
            else if (BolasShop.instance.bolasList[i].bolasID == bolasIDe && BolasShop.instance.bolasList[i].bolascomprou)
            {
                UpdateCompraBtn();
            }
        }

        BolasShop.instance.UpdateSprite(bolasIDe);

    }

    void UpdateCompraBtn()
    {
        btnText.text = "Usando";

        for (int i = 0; i < BolasShop.instance.compraBtnList.Count; i++)
        {
            CompraBola compraBolaScript = BolasShop.instance.compraBtnList[i].GetComponent<CompraBola>();
           
            for (int j = 0; j < BolasShop.instance.bolasList.Count; j++)
            {
                if (BolasShop.instance.bolasList[j].bolasID == compraBolaScript.bolasIDe)
                {
                    BolasShop.instance.SalvaBolasLojaText(compraBolaScript.bolasIDe, "Usando");

                    if (BolasShop.instance.bolasList[j].bolasID == compraBolaScript.bolasIDe && BolasShop.instance.bolasList[j].bolascomprou && BolasShop.instance.bolasList[j].bolasID == bolasIDe)
                    {
                        OndeEstou.instance.bolaEmUso = compraBolaScript.bolasIDe;
                    }
                }

                if (BolasShop.instance.bolasList[j].bolasID == compraBolaScript.bolasIDe && BolasShop.instance.bolasList[j].bolascomprou && BolasShop.instance.bolasList[j].bolasID != bolasIDe)
                {
                    compraBolaScript.btnText.text = "Use";

                    BolasShop.instance.SalvaBolasLojaText(compraBolaScript.bolasIDe, "Use");
                }
            }
        }

    }
    public void FalidoInverso()
    {
        falido = GameObject.FindGameObjectWithTag("falido").GetComponent<Animator>();
        falido.Play("FalidoInverso");
    }

}
