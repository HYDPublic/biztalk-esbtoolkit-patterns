using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Samples.Tests.Common
{
    public class TestHelper
    {
        public static string ReadFile(string path)
        {
            using (StreamReader streamReader = new StreamReader(path, true))
            {
                return streamReader.ReadToEnd();
            }
        }
    }
}
