using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CurrencyWallet;

public enum PreferredSaver { 
    PlayerPrefs = 1,
    Binary = 2
}

public class Controller : MonoBehaviour
{
    [SerializeField]
    WalletView walletViewPrefab;
    [SerializeField]
    Transform walletViewContainer;

    [SerializeField]
    Button saveButton;
    [SerializeField]
    Button loadButton;

    [SerializeField]
    PlayerPrefsSaver prefsSaver;

    [SerializeField]
    BinarySaver binarySaver;
    [SerializeField]
    PreferredSaver preferredSaver = PreferredSaver.PlayerPrefs;

    ISaveProvider currentSaver;

    [SerializeField]
    SimpleWallet wallet;

    WalletView walletView;

    private void Awake()
    {
        SelectSaver(preferredSaver);
        InitButtons();
        InitWallet();
    }

    private void SelectSaver(PreferredSaver saverType)
    {
		switch (saverType)
		{
			case PreferredSaver.PlayerPrefs:
                currentSaver = prefsSaver;
                break;
			case PreferredSaver.Binary:
                currentSaver = binarySaver;
                break;
			default:
				break;
		}
	}

    private void InitWallet()
    {
        walletView = Instantiate(walletViewPrefab, walletViewContainer);
        walletView.SetModel(wallet);

    }

    private void InitButtons()
    {
        saveButton.onClick.AddListener(Save);
        loadButton.onClick.AddListener(Load);
    }

    void Save() {
        currentSaver.Save(wallet);
    }

    void Load()
    {
        Destroy(walletView);
        wallet = currentSaver.Load<SimpleWallet>();
        InitWallet();

    }
}
