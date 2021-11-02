using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DentiNovin
{
    class SampleClass
    {
        public int prop1;
        public int prop2;


        /// <summary>
        /// 
        /// darin soorat mitoonim harvaght methodo seda mizanim badesh maghadire prop1 va prop2 ro begirim:
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        public void CalculateMethod1(int a, int b)
        {
            int sum = a + b;
            int mul = a * b;
            prop1 = sum;
            prop2 = mul;
        }


        /// <summary>
        /// darin soorat mitoonim harvaght methodo seda mizanim badesh sum ro az tarighe outparam va mul ro az tarighe meghrade bazgashtie tabe bedast biarim.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="outputparam"></param>
        /// <returns></returns>
        public int CalculateMethod2(int a, int b,out int outparam)
        {
            int sum = a + b;
            int mul = a * b;
            outparam = sum;
            return mul;
        }

        /// <summary>
        /// darin soorat mitoonim harvaght methodo seda mizanim meghdare bazgashtish ke az jense classie ke khodemoon tarif kardim ro berizim tooye moteghayeri az hamin jens:
        /// 
        /// returnsample objsamp=CalculateMethod3(10, 100);
        /// int retSum=objsamp.SumProp;
        /// int retMul=objsamp.MulProp;
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public returnsample CalculateMethod3(int a, int b)
        {
            int sum = a + b;
            int mul = a * b;
            returnsample objreturnsample = new returnsample();
            objreturnsample.SumProp = sum;
            objreturnsample.MulProp = mul;
            return objreturnsample;
        }
    }

    class returnsample
    {
        public int SumProp { get; set; }
        public int MulProp { get; set; }
    }
}
