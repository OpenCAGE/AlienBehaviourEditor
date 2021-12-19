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
            //Set paths
            if (args.Length > 0 && args[0] == "-opencage") for (int i = 1; i < args.Length; i++) SharedData.pathToAI += args[i] + " ";
            else SharedData.pathToAI = Environment.CurrentDirectory + " ";
            SharedData.pathToAI = SharedData.pathToAI.Substring(0, SharedData.pathToAI.Length - 1);
            //SharedData.pathToBehaviourTrees = SharedData.pathToAI + "/DATA/MODTOOLS/BEHAVIOUR_TREES/";

            //Verify location
            if (!File.Exists(SharedData.pathToAI + "/AI.exe")) throw new Exception("This tool was launched incorrectly, or was not placed within the Alien: Isolation directory.");

            //Create required directories
            if (!Directory.Exists(SharedData.pathToBehaviourTrees)) Directory.CreateDirectory(SharedData.pathToBehaviourTrees);

            //Add font resources for use
            FontManager.AddFont(Properties.Resources.Isolation_Isolation);
            FontManager.AddFont(Properties.Resources.JixellationBold_Jixellation);
            FontManager.AddFont(Properties.Resources.NostromoBoldCond_Nostromo_Cond);

            //Run app
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(true);
            Application.Run(new BehaviourPacker());
        }
    }
}
