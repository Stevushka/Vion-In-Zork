using System;
using System.Diagnostics;

namespace Vion
{
    public static class Assert
    {
        [Conditional("DEBUG")]
        public static void IsTrue(bool expression, string message = null)
        {
            if(expression == false) 
            {
                throw new Exception(message);
            }
        }

        [Conditional("DEBUG")]
        public static void IsNotNull(object expression, string message = null)
        {
            if (expression == null)
            {
                throw new Exception(message);
            }
        }
    }
}