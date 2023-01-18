using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class Globals
{
    public static bool MOBILE_INPUT
    {
        get
        {
#if MOBILE_INPUT
            return true;
#else
            return false;
#endif
        }
    }
}