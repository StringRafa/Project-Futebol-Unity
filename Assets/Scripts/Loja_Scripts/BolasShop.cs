using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolasShop : MonoBehaviour
{
    public static BolasShop instance;

    public List<Bolas> bolasList = new List<Bolas>();
    public List<GameObject> bolaSuporteList = new List<GameObject>();
    public List<GameObject> compraBtnList = new List<GameObject>();


    public GameObject baseBolaItem;
    public Transform conteudo;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        //PlayerPrefs.DeleteAll();  //Apaga os dados salvos
        FillList();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FillList()
    {
        foreach (Bolas b in bolasList)
        {
            GameObject itensBolas = Instantiate(baseBolaItem) as GameObject;
            itensBolas.transform.SetParent(conteudo, false);
            BolasSuporte item = itensBolas.GetComponent<BolasSuporte>();

            item.bolaID = b.bolasID;
            item.bolaPreco.text = b.bolasPreco.ToString ();
            item.btnCompra.GetComponent<CompraBola>().bolasIDe = b.bolasID;

            //Lista CompraBTN
            compraBtnList.Add(item.btnCompra);

            //Lista bolaSuporteList
            bolaSuporteList.Add(itensBolas);

            if (PlayerPrefs.GetInt("BTN"+item.bolaID) == 1)
            {
                b.bolascomprou = true;
            }

            if (PlayerPrefs.HasKey("BTNS"+item.bolaID) && b.bolascomprou)
            {
                item.btnCompra.GetComponent<CompraBola>().btnText.text = PlayerPrefs.GetString("BTNS" + item.bolaID);
            }

            if (b.bolascomprou == true)
            {
                item.bolaSprite.sprite = Resources.Load<Sprite>("Sprites/" + b.bolasnomeSprite);
                item.bolaPreco.text = " ";

                if (PlayerPrefs.HasKey("BTNS"+item.bolaID) == false)
                {
                    item.btnCompra.GetComponent<CompraBola>().btnText.text = "Using";
                }

            }
            else
            {
                item.bolaSprite.sprite = Resources.Load<Sprite>("Sprites/" + b.bolasnomeSprite + "_cinza");
            }
        }
    }

    public void UpdateSprite(int bola_id)
    {
        for (int i = 0; i < bolaSuporteList.Count;i++)
        {
            BolasSuporte bolasSuportScript = bolaSuporteList[i].GetComponent<BolasSuporte>();
            
            if (bolasSuportScript.bolaID == bola_id)
            {
                for (int j = 0; j < bolasList.Count;j++)
                {
                    if (bolasList[j].bolasID == bola_id)
                    {
                        if (bolasList[j].bolascomprou == true)
                        {
                            bolasSuportScript.bolaSprite.sprite = Resources.Load<Sprite>("Sprites/" + bolasList[j].bolasnomeSprite);
                            bolasSuportScript.bolaPreco.text = " ";
                            SalvaBolasLojaInfo(bolasSuportScript.bolaID);
                        }
                        else
                        {
                            bolasSuportScript.bolaSprite.sprite = Resources.Load<Sprite>("Sprites/" + bolasList[j].bolasnomeSprite + "_cinza");
                        }
                    }
                }
            }
        }
    }

    void SalvaBolasLojaInfo(int idBola)
    {
        for (int i = 0; i < bolasList.Count; i++)
        {
            BolasSuporte bolasSup = bolaSuporteList[i].GetComponent<BolasSuporte>();

            if (bolasSup.bolaID == idBola)
            {
                PlayerPrefs.SetInt("BTN" + bolasSup.bolaID, bolasSup.btnCompra ? 1 : 0);
            }
        }
    }

    public void SalvaBolasLojaText(int idBola, string s)
    {
        for (int i = 0; i < bolasList.Count; i++)
        {
            BolasSuporte bolasSup = bolaSuporteList[i].GetComponent<BolasSuporte>();

            if (bolasSup.bolaID == idBola)
            {
                PlayerPrefs.SetString("BTNS"+bolasSup.bolaID,s);
            }
        }
    }
}
