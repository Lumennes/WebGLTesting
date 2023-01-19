using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class Globals
{
    //static bool mobile_input;



    public static bool MOBILE_INPUT
    {
        get
        {
            //#if MOBILE_INPUT
            //            return true;
            //#else
            //            return false;
            //#endif
            //return mobile_input;
            return Platform.IsMobileBrowser();
        }

        //set
        //{
        //    mobile_input = value;
        //}
    }
}