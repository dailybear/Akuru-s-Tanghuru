using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ButtonHandler : MonoBehaviour
{
    public GameObject backgroundPanel;

    public PanelHandler popupWindow;

    public void OnButtonClick()
    {
        SoundManager.Instance.PlayTapSound();
        var seq = DOTween.Sequence();

        seq.Append(transform.DOScale(0.95f, 0.1f));
        seq.Append(transform.DOScale(1.05f, 0.1f));
        seq.Append(transform.DOScale(1f, 0.1f));

        seq.Play().OnComplete(() => {
            backgroundPanel.SetActive(true);
            popupWindow.Show();
        });
    }
}
