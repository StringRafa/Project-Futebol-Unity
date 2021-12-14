using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AdsUnity : MonoBehaviour , IUnityAdsListener
{
	public static AdsUnity instance;

	[SerializeField] string _gameID = "4141985"; //id da googleplay
	[SerializeField] string myPlacementId = "rewardedVideo";
	[SerializeField] private Button btnAds;
	[SerializeField] bool testeMode = true;
	public bool adsBtnAcionado = false;

	void Start()
	{
		Advertisement.AddListener(this);
		Advertisement.Initialize(_gameID, testeMode);
	}

	void Awake()
	{
		if (instance == null)
		{
			instance = this;
			DontDestroyOnLoad(this.gameObject);
		}
		else
		{
			Destroy(this.gameObject);
		}

		SceneManager.sceneLoaded += PegaBtn;
	}
	
	void PegaBtn(Scene cena, LoadSceneMode modo)
	{

		if (OndeEstou.instance.fase == 2)
		{
			btnAds = GameObject.Find("AdsBtn").GetComponent<Button>();
			btnAds.onClick.AddListener(AdsBtn);

		}
	}
	
	
	public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
	{
		if (showResult == ShowResult.Finished)
		{
			ScoreManager.instance.ColetaMoedas(100);// jogador ganha 50 moedas após ver video
			Debug.Log("Você ganhou 100.00 moedas !!");
		}
		else if (showResult == ShowResult.Skipped)
		{
			Debug.Log("Você pulou o anúncio !!");
		}
		else if (showResult == ShowResult.Failed)
		{
			Debug.LogWarning("Failed.");
		}
	}
	
	void AdsBtn()
	{
		if (Advertisement.IsReady(myPlacementId))
		{
			Advertisement.Show(myPlacementId);
			adsBtnAcionado = true;
		}
		else
		{
			Debug.Log("Rewarded video is not ready at the moment! Please try again later!");
		}
	}

	public void showAds()
	{
		if (PlayerPrefs.HasKey("AdsUnity"))
		{
			if (PlayerPrefs.GetInt("AdsUnity") == 5)
			{
				if (Advertisement.IsReady("video"))
				{
					Advertisement.Show("video");
				}
				PlayerPrefs.SetInt("AdsUnity", 1);
			}
			else
			{
				PlayerPrefs.SetInt("AdsUnity", PlayerPrefs.GetInt("AdsUnity") + 1);
			}
		}
		else
		{
			PlayerPrefs.SetInt("AdsUnity", 1);
		}
	}
	
	public void OnDestroy()
	{
		Advertisement.RemoveListener(this);
	}
	
	public void OnUnityAdsReady(string placementId)
	{
		Debug.Log("Ready: " + placementId);
	}

	public void OnUnityAdsDidError(string message)
	{
		Debug.Log("Error: " + message);
	}

	public void OnUnityAdsDidStart(string placementId)
	{
		Debug.Log("Start: " + placementId);
	}
}
