using Invector.vCharacterController;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;

public class GameManager : MonoBehaviour
{
    //public bool simulateMobile;


    bool geter;


    [SerializeField] GameObject MobileUI_MeleeMobile_Inventory;
    [SerializeField] GameObject EquipmentDisplayWindow;
    [SerializeField] GameObject OpenInventory;


    [SerializeField] vMeleeCombatInput vMeleeCombatInput;


    // Подписываемся на событие GetDataEvent в OnEnable
    private void OnEnable() => YandexGame.GetDataEvent += GetData;


    // Отписываемся от события GetDataEvent в OnDisable
    private void OnDisable() => YandexGame.GetDataEvent -= GetData;


    private void Awake()
    {
        //Globals.MOBILE_INPUT = simulateMobile;
    }

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

        
        //Globals.MOBILE_INPUT = simulateMobile;

        //Globals.MOBILE_INPUT = true;
        print($"Globals.MOBILE_INPUT: {Globals.MOBILE_INPUT}");

        //if (YandexGame.EnvironmentData.deviceType == "desktop" && !simulateMobile)
        if (!Platform.IsMobileBrowser())
        {
            if (vMeleeCombatInput)
            {
                vMeleeCombatInput.showCursorOnStart = false;
                vMeleeCombatInput.unlockCursorOnStart = false;
                vMeleeCombatInput.ShowCursor(vMeleeCombatInput.showCursorOnStart);
                vMeleeCombatInput.LockCursor(!vMeleeCombatInput.unlockCursorOnStart);
            }

            if (MobileUI_MeleeMobile_Inventory) MobileUI_MeleeMobile_Inventory.SetActive(false);
            if (EquipmentDisplayWindow) EquipmentDisplayWindow.SetActive(false);
            if (OpenInventory) OpenInventory.SetActive(false);
        }
        //else if (YandexGame.EnvironmentData.deviceType == "mobile" || simulateMobile)
        else if (Platform.IsMobileBrowser())
        {
            //if (vMeleeCombatInput)
            //{
            //    vMeleeCombatInput.showCursorOnStart = true;
            //    vMeleeCombatInput.unlockCursorOnStart = true;
            //    vMeleeCombatInput.ShowCursor(true);
            //    vMeleeCombatInput.LockCursor(false);
            //}

            //if (MobileUI_MeleeMobile_Inventory) MobileUI_MeleeMobile_Inventory.SetActive(true);
            //if (EquipmentDisplayWindow) EquipmentDisplayWindow.SetActive(true);
            //if (OpenInventory) OpenInventory.SetActive(true);
        }
    }


    // Ваш метод, который будет запускаться в старте
    public void GetData()
    {
        if (geter)
            return;

        print($"Time.time: {Time.time}");

        // Получаем данные из плагина и делаем с ними что хотим

       

        geter = true;
    }


    // Update is called once per frame
    //void Update()
    //{

    //}
}
