using Invector.vCharacterController;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;

public class GameManager : MonoBehaviour
{
    public bool simulateMobile;


    bool geter;


    [SerializeField] GameObject MobileUI_MeleeMobile_Inventory;
    [SerializeField] GameObject EquipmentDisplayWindow;
    [SerializeField] GameObject OpenInventory;


    [SerializeField] vMeleeCombatInput vMeleeCombatInput;


    // Подписываемся на событие GetDataEvent в OnEnable
    private void OnEnable() => YandexGame.GetDataEvent += GetData;


    // Отписываемся от события GetDataEvent в OnDisable
    private void OnDisable() => YandexGame.GetDataEvent -= GetData;

     
    // Start is called before the first frame update
    void Start()
    {
        // Проверяем запустился ли плагин
        if (YandexGame.SDKEnabled == true)
        {
            // Если запустился, то запускаем Ваш метод
            GetData();

            // Если плагин еще не прогрузился, то метод не запуститься в методе Start,
            // но он запустится при вызове события GetDataEvent, после прогрузки плагина
        }


        //Globals.MOBILE_INPUT = true;
        print($"Globals.MOBILE_INPUT: {Globals.MOBILE_INPUT}");
    }


    // Ваш метод, который будет запускаться в старте
    public void GetData()
    {
        if (geter)
            return;

        print($"Time.time: {Time.time}");

        // Получаем данные из плагина и делаем с ними что хотим

        if (YandexGame.EnvironmentData.deviceType == "desktop" && !simulateMobile)
        {
            if (vMeleeCombatInput)
            {
                vMeleeCombatInput.unlockCursorOnStart = false;
                vMeleeCombatInput.showCursorOnStart = false;
            }
        }
        else if (YandexGame.EnvironmentData.deviceType == "mobile" || simulateMobile)
        {
            //if (vMeleeCombatInput)
            //{
            //    vMeleeCombatInput.unlockCursorOnStart = true;
            //    vMeleeCombatInput.showCursorOnStart = true;
            //}

            if (MobileUI_MeleeMobile_Inventory) MobileUI_MeleeMobile_Inventory.SetActive(true);
            if (EquipmentDisplayWindow) EquipmentDisplayWindow.SetActive(true);
            if (OpenInventory) OpenInventory.SetActive(true);
        }

        geter = true;
    }


    // Update is called once per frame
    //void Update()
    //{

    //}
}
