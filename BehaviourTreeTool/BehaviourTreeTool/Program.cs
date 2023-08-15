using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
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
        static Dictionary<string, string> _args;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            _args = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            {
                var arguments = Environment.GetCommandLineArgs();
                for (int i = 0; i < arguments.Length; i++)
                {
                    var match = Regex.Match(arguments[i], "-([^=]+)=(.*)");
                    if (!match.Success) continue;
                    var vName = match.Groups[1].Value;
                    var vValue = match.Groups[2].Value;
                    _args[vName] = vValue;

                    if (_args[vName].Substring(_args[vName].Length - 1) == "\"")
                        _args[vName] = _args[vName].Substring(0, _args[vName].Length - 1);
                }
            }

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

        public static string GetArgument(string name)
        {
            if (_args.ContainsKey(name))
                return _args[name];
            return null;
        }
    }
}
