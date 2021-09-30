using System;
using System.IO;
namespace DataDiagrams
{
    public class Config
    {
        private static readonly char seperator = Path.AltDirectorySeparatorChar;

        public String GetProjectDirectory()
        {
            //TODO: Update this 
            return "/Users/jcollard/git/ap-compsci-2021-2022/project_ideas/DataDiagrams/project/";
        }

        public String GetTestDirectory()
        {
            
            return GetProjectDirectory() + seperator + "test_data" + seperator;
        }
    }
}
