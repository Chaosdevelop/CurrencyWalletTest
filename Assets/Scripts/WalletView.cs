using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CurrencyWallet;
using UnityEngine.UI;

public class WalletView : MonoBehaviour
{
    [SerializeField]
    CurrencyView currencyViewPrefab;
    [SerializeField]
    Transform currencyViewsContainer;

    IWallet wallet;


    public void SetModel(IWallet wallet) {
        this.wallet = wallet;
        var availableCurrency = wallet.AvailableCurrency;

        foreach (var currency in availableCurrency)
		{
            var currencyView = Instantiate(currencyViewPrefab, currencyViewsContainer);
            currencyView.SetModel(currency);
        }

    }



}
