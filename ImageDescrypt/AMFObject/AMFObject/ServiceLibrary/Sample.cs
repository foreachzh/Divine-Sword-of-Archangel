using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using FluorineFx;
using FluorineFx.AMF3;

namespace ServiceLibrary
{
    /// <summary>
    /// Fluorine sample service.
    /// </summary>
    [RemotingService("Fluorine sample service")]
    public class Sample
    {
        public Sample()
        {
        }

        public string Echo(string text)
        {
            return "Hello word: " + text;
            
        }

        private static void Test()
        {
            byte[] barr = new byte[10];
            FluorineFx.AMF3.ByteArray arr = new ByteArray();
            
            
        }
    }
}
