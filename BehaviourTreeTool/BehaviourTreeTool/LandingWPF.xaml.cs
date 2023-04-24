using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BehaviourTreeTool
{
    /// <summary>
    /// Interaction logic for LandingWPF.xaml
    /// </summary>
    public partial class LandingWPF : UserControl
    {
        public Action OnEditorOpenRequest;
        public Action OnCompileRequest;
        public Action OnResetRequest;

        public LandingWPF()
        {
            InitializeComponent();
        }
        public void SetVersionInfo(string version)
        {
            VersionText.Content = "Version " + version;
        }

        private void EditorBtnClick(object sender, RoutedEventArgs e)
        {
            OnEditorOpenRequest?.Invoke();
        }
        private void CompileBtnClick(object sender, RoutedEventArgs e)
        {
            OnCompileRequest?.Invoke();
        }
        private void ResetBtnClick(object sender, RoutedEventArgs e)
        {
            OnResetRequest?.Invoke();
        }
    }
}
