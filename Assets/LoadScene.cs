using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadScene : MonoBehaviour
{
    public GameObject LoadSceneByAddressGO;

    // Start is called before the first frame update
    void Start()
    {
        if (!LoadSceneByAddress.Instance && LoadSceneByAddressGO)
            Instantiate(LoadSceneByAddressGO);
    }

    public void LoadSceneByKey(string key)
    {       
        if(LoadSceneByAddress.Instance)
            LoadSceneByAddress.Instance.LoadScene(key);
    }

    // Update is called once per frame
    //void Update()
    //{
        
    //}
}
