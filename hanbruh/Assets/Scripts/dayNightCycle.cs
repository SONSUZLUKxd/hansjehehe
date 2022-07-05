using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dayNightCycle : MonoBehaviour
{
    public float hiz, saat, dakika, zaman, zaman2;
    public Text timeText;
    private void Start()
    {
        zaman = (saat * 15) + (dakika * 0.25f);
    }
    private void Update()
    {
        zaman += hiz * Time.deltaTime;
        zaman2 = zaman / 0.25f;
        dakika = zaman2 % 60;
        saat = (zaman2 - dakika) / 60;
        if(zaman > 360) { zaman = 0; }
        transform.eulerAngles = new Vector3(zaman - 90, 0, 0);
        timeText.text = saat.ToString() + ":" + dakika.ToString("0");
    }
}
