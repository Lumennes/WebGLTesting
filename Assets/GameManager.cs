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


    // ������������� �� ������� GetDataEvent � OnEnable
    private void OnEnable() => YandexGame.GetDataEvent += GetData;


    // ������������ �� ������� GetDataEvent � OnDisable
    private void OnDisable() => YandexGame.GetDataEvent -= GetData;


    // Start is called before the first frame update
    void Start()
    {
        // ��������� ���������� �� ������
        if (YandexGame.SDKEnabled == true)
        {
            // ���� ����������, �� ��������� ��� �����
            GetData();

            // ���� ������ ��� �� �����������, �� ����� �� ����������� � ������ Start,
            // �� �� ���������� ��� ������ ������� GetDataEvent, ����� ��������� �������
        }
    }


    // ��� �����, ������� ����� ����������� � ������
    public void GetData()
    {
        if (geter)
            return;

        print($"Time.time: {Time.time}");

        // �������� ������ �� ������� � ������ � ���� ��� �����

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
