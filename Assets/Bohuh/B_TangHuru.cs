using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class B_TangHuru : MonoBehaviour
{
    [SerializeField] int thisTangHuru;
    Transform strawberryContainer;
    Transform grapeContainer;
    Transform orangeContainer;
    Transform pineappleContainer;
    Transform blueberryContainer;
    Transform thisPosition;

    Vector3 mousePositionOffset;
    Collider2D collide;
    float curTime = 0f;
    private void Awake()
    {
        collide = GetComponent<Collider2D>();
    }

    private void OnEnable()
    {
        thisTangHuru = (int)DataManager.Instance.selectedFruit;
        collide.enabled = false;
        strawberryContainer = B_GameManager.Instance.strawberryContainer.GetComponent<Transform>();
        grapeContainer = B_GameManager.Instance.grapeContainer.GetComponent<Transform>();
        orangeContainer = B_GameManager.Instance.orangeContaner.GetComponent<Transform>();
        pineappleContainer = B_GameManager.Instance.pineappleContainer.GetComponent<Transform>();
        blueberryContainer = B_GameManager.Instance.blueberryContainer.GetComponent<Transform>();
        thisPosition = B_Spawnner.Instance.randomSpawnPoint;
    }

    private void Update()
    {
        curTime += Time.deltaTime;
        if(curTime > 3f)
        {
            collide.enabled = true;   
        }
    }

    private Vector3 GetMouseWorldPosition()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    /// <summary>
    /// 마우스 클릭시
    /// </summary>
    private void OnMouseDown()
    {
            mousePositionOffset = gameObject.transform.position - GetMouseWorldPosition();
    }
    /// <summary>
    /// 마우스 드래그
    /// </summary>
    private void OnMouseDrag()
    {
           transform.position = GetMouseWorldPosition() + mousePositionOffset;
    }
    /// <summary>
    /// 마우스 언클릭시
    /// </summary>
    private void OnMouseUp()
    {
        ///탕후루와 구치소가 충돌한 경우 
        if (Mathf.Abs(this.transform.position.x - strawberryContainer.transform.position.x) <= 0.5f &&
            Mathf.Abs(this.transform.position.y - strawberryContainer.transform.position.y) <= 0.5f && thisTangHuru == 0)
        {
            this.transform.position = 
                new Vector3(strawberryContainer.transform.position.x, strawberryContainer.transform.position.y, strawberryContainer.transform.position.z);
            DataManager.Instance.strawberryTangHuru++;
            this.gameObject.SetActive(false);
            thisPosition.GetComponent<B_SpawnPoint>().IsPlaceable = true;
        }
        else if(Mathf.Abs(this.transform.position.x - grapeContainer.transform.position.x) <= 0.5f &&
            Mathf.Abs(this.transform.position.y - grapeContainer.transform.position.y) <= 0.5f && thisTangHuru == 1)
        {
            this.transform.position =
                new Vector3(grapeContainer.transform.position.x, grapeContainer.transform.position.y, grapeContainer.transform.position.z);
            DataManager.Instance.grapeTangHuru++;
            this.gameObject.SetActive(false);
            thisPosition.GetComponent<B_SpawnPoint>().IsPlaceable = true;
        }
        else if(Mathf.Abs(this.transform.position.x - orangeContainer.transform.position.x) <= 0.5f &&
            Mathf.Abs(this.transform.position.y - orangeContainer.transform.position.y) <= 0.5f && thisTangHuru == 2)
        {
            this.transform.position =
                new Vector3(orangeContainer.transform.position.x, orangeContainer.transform.position.y, orangeContainer.transform.position.z);
            DataManager.Instance.orangeTangHuru++;
            this.gameObject.SetActive(false);
            thisPosition.GetComponent<B_SpawnPoint>().IsPlaceable = true;
        }
        else if(Mathf.Abs(this.transform.position.x - pineappleContainer.transform.position.x) <= 0.5f &&
            Mathf.Abs(this.transform.position.y - pineappleContainer.transform.position.y) <= 0.5f && thisTangHuru == 3)
        {
            this.transform.position =
                new Vector3(pineappleContainer.transform.position.x, pineappleContainer.transform.position.y, pineappleContainer.transform.position.z);
            DataManager.Instance.pineappleTangHuru++;
            this.gameObject.SetActive(false);
            thisPosition.GetComponent<B_SpawnPoint>().IsPlaceable = true;
        }
        else if(Mathf.Abs(this.transform.position.x - blueberryContainer.transform.position.x) <= 0.5f &&
            Mathf.Abs(this.transform.position.y - blueberryContainer.transform.position.y) <= 0.5f && thisTangHuru == 4)
        {
            this.transform.position =
                new Vector3(blueberryContainer.transform.position.x, blueberryContainer.transform.position.y, blueberryContainer.transform.position.z);
            DataManager.Instance.blueberryTangHuru++;
            this.gameObject.SetActive(false);
            thisPosition.GetComponent<B_SpawnPoint>().IsPlaceable = true;
        }
        else
        {
            this.transform.position = thisPosition.transform.position;
        }
    }
}
