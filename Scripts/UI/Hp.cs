using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //추가

public class HealthBar : MonoBehaviour
{
    Image HPBar; //이미지 파일
    int HP;
    int MaxHP;
    void Start()
    {
        HPBar = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        HPBar.fillAmount = (float)HP / (float)MaxHP;

    }
}