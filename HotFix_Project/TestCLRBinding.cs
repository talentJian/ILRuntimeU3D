using System;
using System.Collections.Generic;
using UnityEngine;

namespace HotFix_Project
{
    public class TestCLRBinding
    {
        public static void RunTest()
        {
            //int
            Debug.Log("Fuck Start Realse");
            for (int i = 0; i < 100000; i++)
            {
                CLRBindingTestClass.DoSomeTest(i, i+1);
                //for (int j = 0; j < 1000; j++)
                //{
                //     CLRBindingTestClass.DoSomeTest(i, i);
                //}
               
            }
        }

        public static double Test9()
        {
            int[] array = new int[1024];
            for (int i = 0; i < 1024; ++i)
            {
                array[i] = i;
            }

            int total = 0;
            //long ts = DateTime.Now.Ticks;

            for (int j = 1; j < 10000; ++j)
            {
                for (int i = 1; i < 1024; ++i)
                {
                    //total = total + array[i];
                    total = i / j;
                    total = total * j;

                    total = total + j;
                   
                    
                    
                }
            }

            //array[0] = total;

            return total;
        }
    }
}
