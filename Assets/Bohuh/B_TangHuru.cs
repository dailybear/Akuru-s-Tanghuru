using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class B_TangHuru : MonoBehaviour
{
    Transform targetConrainer;
    Transform thisPosition;
    Vector3 mousePositionOffset;
    Collider2D collide;
    Vector3 resetPosition;
    bool isActive = false;
    float curTime = 0f;
    private void Awake()
    {
        collide = GetComponent<Collider2D>();
    }

    private void OnEnable()
    {
        collide.enabled = false;
        targetConrainer = B_GameManager.Instance.restingContainer.GetComponent<Transform>();
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
        if(Mathf.Abs(this.transform.position.x - targetConrainer.transform.position.x)<=0.5f &&
            Mathf.Abs(this.transform.position.y - targetConrainer.transform.position.y) <= 0.5f)
        {
            this.transform.position = 
                new Vector3(targetConrainer.transform.position.x, targetConrainer.transform.position.y, targetConrainer.transform.position.z);
            DataManager.Instance.strawberryTangHuru++;
            this.gameObject.SetActive(false);
            thisPosition.GetComponent<B_SpawnPoint>().IsPlaceable = true;
        }
        else
        {
            this.transform.position = thisPosition.transform.position;
        }
    }
}
