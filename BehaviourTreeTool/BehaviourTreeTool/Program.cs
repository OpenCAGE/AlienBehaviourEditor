using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BehaviourTreeTool
{
    public static class SharedData
    {
        public static string pathToAI = "";
        public static string pathToBehaviourTrees = "BEHAVIOUR_TREES/"; //Should match debug_workspaces.xml
    }

    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            //Set path to AI
            if (GetArgument("pathToAI") != null)
                SharedData.pathToAI = GetArgument("pathToAI");
            else
                SharedData.pathToAI = Environment.CurrentDirectory;
            SharedData.pathToBehaviourTrees = SharedData.pathToAI + "/DATA/MODTOOLS/BEHAVIOUR_TREES/";

            //Verify location
            if (!File.Exists(SharedData.pathToAI + "/AI.exe")) 
                throw new Exception("This tool was launched incorrectly, or was not placed within the Alien: Isolation directory.");

            //Create required directories
            if (!Directory.Exists(SharedData.pathToBehaviourTrees)) 
                Directory.CreateDirectory(SharedData.pathToBehaviourTrees);

            //Run app
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(true);
            Application.Run(new Landing());
        }

        static string GetArgument(string name)
        {
            string[] args = Environment.GetCommandLineArgs();
            for (int i = 0; i < args.Length; i++)
            {
                if (args[i].Contains(name))
                {
                    return args[i + 1];
                }
            }
            return null;
        }
    }
}
