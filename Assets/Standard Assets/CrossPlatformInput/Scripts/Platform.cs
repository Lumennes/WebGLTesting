using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class Platform
{
    bool taked;
    bool mobile;

    public static bool IsMobileBrowser()
    {


#if UNITY_EDITOR
        /* return false;*/ // value to return in Play Mode (in the editor)
        //UnityEngine.Debug.Log($"isEditor: {UnityEngine.Application.isEditor}");
        return UnityEngine.Device.SystemInfo.deviceType != DeviceType.Desktop;        
#elif UNITY_WEBGL
        if(!taked)
        {
            mobile = WebGLHandler.IsMobileBrowserInternal();
            taked = true;
        }
        //    return mobile; // value based on the current browser
        //}
        //else
        //{
            return mobile; 
        //}
#else
        return false; // value for builds other than WebGL
#endif
    }
}