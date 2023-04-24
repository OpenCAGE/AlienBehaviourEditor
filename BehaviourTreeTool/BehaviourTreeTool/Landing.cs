using System;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Collections.Generic;

namespace BehaviourTreeTool
{
    public partial class Landing : Form
    {
        /* ONLOAD */
        public Landing()
        {
            InitializeComponent();
            this.Focus();
        }
        private void BehaviourPacker_Load(object sender, EventArgs e)
        {
            LandingWPF wpf = (LandingWPF)elementHost1.Child;
            wpf.SetVersionInfo(ProductVersion);
            wpf.OnEditorOpenRequest += UnpackTreesAndOpenEditor;
            wpf.OnCompileRequest += CompileBehaviourTrees;
            wpf.OnResetRequest += ResetBehaviourTrees;
        }

        /* UNPACK */
        private void UnpackTreesAndOpenEditor()
        {
            if (!Directory.Exists(SharedData.pathToBehaviourTrees)) Directory.CreateDirectory(SharedData.pathToBehaviourTrees);
            if (!File.Exists(SharedData.pathToBehaviourTrees + "alien_all_search_variants.xml")) {
                Cursor.Current = Cursors.WaitCursor;

                //Convert BML to XML
                File.Copy(SharedData.pathToAI + @"\DATA\BINARY_BEHAVIOR\_DIRECTORY_CONTENTS.BML", SharedData.pathToBehaviourTrees + "_DIRECTORY_CONTENTS.BML");
                new AlienConverter(SharedData.pathToBehaviourTrees + "_DIRECTORY_CONTENTS.BML", SharedData.pathToBehaviourTrees + "_DIRECTORY_CONTENTS.xml").Run();

                //Extract XML to separate files
                string directoryContentsXML = File.ReadAllText(SharedData.pathToBehaviourTrees + "_DIRECTORY_CONTENTS.xml"); //Get contents from newly converted _DIRECTORY_CONTENTS
                string fileHeader = "<?xml version='1.0' encoding='utf-8'?>\n<Behavior>"; //Premade file header
                int count = 0;
                foreach (string currentFile in Regex.Split(directoryContentsXML, "<File name="))
                {
                    count += 1;
                    if (count != 1)
                    {
                        string[] extractedContents = Regex.Split(currentFile, "<Behavior>"); //Split filename and contents
                        string[] extractedContentsMain = Regex.Split(extractedContents[1], "</File>"); //Split contents and footer
                        string[] fileContents = { fileHeader, extractedContentsMain[0] }; //Write preset header and newly grabbed contents
                        string fileName = extractedContents[0].Substring(1).Split(new string[] { ".bml" }, StringSplitOptions.None)[0]; //Grab filename

                        File.WriteAllLines(SharedData.pathToBehaviourTrees + fileName + ".xml", fileContents); //Write new file
                    }
                }

                File.Delete(SharedData.pathToBehaviourTrees + "_DIRECTORY_CONTENTS.BML");
                File.Delete(SharedData.pathToBehaviourTrees + "_DIRECTORY_CONTENTS.xml");

                Cursor.Current = Cursors.Default;
            }

            //Open Brainiac Designer
            ProcessStartInfo brainiacProcess = new ProcessStartInfo();
            brainiacProcess.WorkingDirectory = Environment.CurrentDirectory;
            brainiacProcess.FileName = Environment.CurrentDirectory + "/Brainiac Designer.exe";
            Process.Start(brainiacProcess);
        }

        /* REPACK */
        private void CompileBehaviourTrees()
        {
            if (!Directory.Exists(SharedData.pathToBehaviourTrees)) Directory.CreateDirectory(SharedData.pathToBehaviourTrees);
            if (!File.Exists(SharedData.pathToBehaviourTrees + "alien_all_search_variants.xml"))
            {
                MessageBox.Show("No modifications have been made! Nothing to import.", "No changes.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Cursor.Current = Cursors.WaitCursor;

                //Create new XML to write
                string compiledBinaryBehaviourContents = "<?xml version=\"1.0\" encoding=\"utf-8\"?><DIR>"; //Start file
                DirectoryInfo workingDirectoryInfo = new DirectoryInfo(SharedData.pathToBehaviourTrees); //Get all files in directory
                foreach (FileInfo currentFile in workingDirectoryInfo.GetFiles())
                {
                    string fileContents = File.ReadAllText(currentFile.FullName); //Current file contents
                    string fileName = currentFile.Name; //Current file name
                    string customFileHeader = "<File name=\"" + fileName.Substring(0, fileName.Length - 3) + "bml\">"; //File header
                    string customFileFooter = "</File>"; //File footer

                    compiledBinaryBehaviourContents += customFileHeader + fileContents.Substring(38) + customFileFooter; //Add to file string
                }
                compiledBinaryBehaviourContents += "</DIR>"; //Finish off file string

                //Write and convert to BML
                File.WriteAllText(SharedData.pathToBehaviourTrees + "_DIRECTORY_CONTENTS.xml", compiledBinaryBehaviourContents); 
                new AlienConverter(SharedData.pathToBehaviourTrees + "_DIRECTORY_CONTENTS.xml", SharedData.pathToBehaviourTrees + "_DIRECTORY_CONTENTS.bml").Run();

                File.Delete(SharedData.pathToAI + @"\DATA\BINARY_BEHAVIOR\_DIRECTORY_CONTENTS.BML");
                File.Copy(SharedData.pathToBehaviourTrees + "_DIRECTORY_CONTENTS.bml", SharedData.pathToAI + @"\DATA\BINARY_BEHAVIOR\_DIRECTORY_CONTENTS.BML");
                File.Delete(SharedData.pathToBehaviourTrees + "_DIRECTORY_CONTENTS.bml");
                File.Delete(SharedData.pathToBehaviourTrees + "_DIRECTORY_CONTENTS.xml");

                Cursor.Current = Cursors.Default;

                MessageBox.Show("Modifications have been imported.", "Import complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /* RESET */
        private void ResetBehaviourTrees()
        {
            Cursor.Current = Cursors.WaitCursor;

            //Kill Brainiac
            List<Process> allProcesses = new List<Process>(Process.GetProcessesByName("Brainiac Designer"));
            for (int i = 0; i < allProcesses.Count; i++) allProcesses[i].Kill();

            //Reset files
            File.WriteAllBytes(SharedData.pathToAI + @"\DATA\BINARY_BEHAVIOR\_DIRECTORY_CONTENTS.BML", Properties.Resources._DIRECTORY_CONTENTS);
            if (Directory.Exists(SharedData.pathToBehaviourTrees))
            {
                string[] trees = Directory.GetFiles(SharedData.pathToBehaviourTrees, "*.xml", SearchOption.TopDirectoryOnly);
                for (int i = 0; i < trees.Length; i++) File.Delete(trees[i]);
            }

            Cursor.Current = Cursors.Default;

            MessageBox.Show("Behaviour trees have been reset to defaults!", "Reset complete.", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
