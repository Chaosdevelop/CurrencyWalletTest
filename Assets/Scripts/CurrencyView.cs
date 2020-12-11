using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CurrencyWallet;
using UnityEngine.UI;

public class CurrencyView : MonoBehaviour
{
	[SerializeField]
	Text balanceText;
	[SerializeField]
	Text currencyNameText;
	[SerializeField]
	Button resetBalanceButton;
	[SerializeField]
	Button incrementBalanceButton;

	ICurrency currency;

	private void Awake()
	{
		InitButtons();
	}
	private void InitButtons()
	{
		resetBalanceButton.onClick.AddListener(ResetBalance);
		incrementBalanceButton.onClick.AddListener(IncrementBalance);
	}
	public void SetModel(ICurrency currency)
	{
		this.currency = currency;
		currencyNameText.text = currency.Name;
		balanceText.text = currency.Balance.ToString();
		currency.AddBallanceChangeListener(OnBalanceChanged);
	}

	void OnBalanceChanged(uint balance) {
		balanceText.text = currency.Balance.ToString();
	}

	private void OnDestroy()
	{
		currency.RemoveBallanceChangeListener(OnBalanceChanged);
	}

	void ResetBalance(){
		currency.Balance = 0;
	}

	void IncrementBalance()
	{
		currency.Balance ++;
	}
}
