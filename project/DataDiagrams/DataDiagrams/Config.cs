using System;
using System.IO;
namespace DataDiagrams
{
    public class Config
    {
        private static readonly char seperator = Path.AltDirectorySeparatorChar;

        /// <summary>
        /// Returns the absolute path of the project directory for this project.
        /// </summary>
        /// <returns>The absolute path of the project directory for this project.</returns>
        public String GetProjectDirectory()
        {
            //TODO: Update this 
            //return "/Users/jcollard/git/ap-compsci-2021-2022/project_ideas/DataDiagrams/project/";
            return @"D:\git\ap-compsci-2021-2022\project_ideas\DataDiagrams\project";
        }

        public IFiveTwoOneOneDecoder GetDecoder()
        {
            //TODO: Update to return your Decoder
            return null;
        }

        /// <summary>
        /// Returns the absolute path to the test_data directory which is used
        /// by <a cref="Support.ReadBytes(string, int)">Support.ReadBytes</a>
        /// </summary>
        /// <returns></returns>
        public String GetTestDirectory()
        {
            return GetProjectDirectory() + seperator + "test_data" + seperator;
        }


    }
}
