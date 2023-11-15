using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class TangHuruDisplay : MonoBehaviour
{
    [SerializeField] Transform[] spawnPoints;
    public GameObject[] prefab;
    public GameObject alert;
    int spawnPoint = 0;

    public  void DisplayStrawberryTangHuru()
    {
        SoundManager.Instance.PlayTapSound();
        if (DataManager.Instance.sellingTangHuru >= 6)
        {
            Debug.Log("판매대가 모자랍니다");
            alert.SetActive(true);
            StartCoroutine("AlertDelay");
            return;
        }
        if (DataManager.Instance.strawberryTangHuru >= 1)
        {
            SoundManager.Instance.PlayTapSound();
            DataManager.Instance.strawberryTangHuru--;
            DataManager.Instance.sellingStarwberryTangHuru++;
            Debug.Log("소환");
            Instantiate(prefab[0], spawnPoints[DataManager.Instance.sellingTangHuru].position, spawnPoints[DataManager.Instance.sellingTangHuru].rotation);
            DataManager.Instance.sellingTangHuru++;
        }
    }
    public void DisplayGrapeTangHuru()
    {
        SoundManager.Instance.PlayTapSound();
        if (DataManager.Instance.sellingTangHuru >= 6)
        {
            Debug.Log("판매대가 모자랍니다");
            alert.SetActive(true);
            StartCoroutine("AlertDelay");
            return;
        }
        if (DataManager.Instance.grapeTangHuru >= 1)
        {
            SoundManager.Instance.PlayTapSound();
            DataManager.Instance.grapeTangHuru--;
            DataManager.Instance.sellingGrapeTangHuru++;
            Debug.Log("소환");
            Instantiate(prefab[1], spawnPoints[DataManager.Instance.sellingTangHuru].position, spawnPoints[DataManager.Instance.sellingTangHuru].rotation);
            DataManager.Instance.sellingTangHuru++;
        }
    }
    public void DisplayOrangeTangHuru()
    {
        SoundManager.Instance.PlayTapSound();
        if (DataManager.Instance.sellingTangHuru >= 6)
        {
            Debug.Log("판매대가 모자랍니다");
            alert.SetActive(true);
            StartCoroutine("AlertDelay");
            return;
        }
        if (DataManager.Instance.orangeTangHuru >= 1)
        {
            SoundManager.Instance.PlayTapSound();
            DataManager.Instance.orangeTangHuru--;
            DataManager.Instance.sellingOrangeTangHuru++;
            Debug.Log("소환");
            Instantiate(prefab[2], spawnPoints[DataManager.Instance.sellingTangHuru].position, spawnPoints[DataManager.Instance.sellingTangHuru].rotation);
            DataManager.Instance.sellingTangHuru++;
        }
    }
    public void DispalyPineappleTangHuru()
    {
        SoundManager.Instance.PlayTapSound();
        if (DataManager.Instance.sellingTangHuru >= 6)
        {
            Debug.Log("판매대가 모자랍니다");
            alert.SetActive(true);
            StartCoroutine("AlertDelay");
            return;
        }
        if (DataManager.Instance.pineappleTangHuru >= 1)
        {
            SoundManager.Instance.PlayTapSound();
            DataManager.Instance.pineappleTangHuru--;
            DataManager.Instance.sellingPineappleTangHuru++;
            Debug.Log("소환");
            Instantiate(prefab[3], spawnPoints[DataManager.Instance.sellingTangHuru].position, spawnPoints[DataManager.Instance.sellingTangHuru].rotation);
            DataManager.Instance.sellingTangHuru++;
        }
    }
    public void DisaplyBlueberryTangHuru()
    {
        SoundManager.Instance.PlayTapSound();
        if (DataManager.Instance.sellingTangHuru >= 6)
        {
            Debug.Log("판매대가 모자랍니다");
            alert.SetActive(true);
            StartCoroutine("AlertDelay");
            return;
        }
        if (DataManager.Instance.blueberryTangHuru >= 1)
        {
            SoundManager.Instance.PlayTapSound();
            DataManager.Instance.blueberryTangHuru--;
            DataManager.Instance.SellingBlueberryTangHuru++;
            Debug.Log("소환");
            Instantiate(prefab[4], spawnPoints[DataManager.Instance.sellingTangHuru].position, spawnPoints[DataManager.Instance.sellingTangHuru].rotation);
            DataManager.Instance.sellingTangHuru++;
        }
    }

    IEnumerator AlertDelay()
    {
        yield return new WaitForSeconds(3f);
        alert.SetActive(false);
    }
}
