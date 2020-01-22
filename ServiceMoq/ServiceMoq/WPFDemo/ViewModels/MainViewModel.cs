using System.Windows.Controls;
using WPFDemo.Models;

namespace WPFDemo.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private ContentControl m_ContentField;

        public MainViewModel()
        {
            m_ContentField = new Views.DemoView();
        }

        public ContentControl ContentField
        {
            get { return m_ContentField; }
            set
            {
                m_ContentField = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand btnwsArm_Click
        {
            get
            {
                return new RelayCommand((obj) =>
                {
                    ContentField = new Views.wsArmView();
                });
            }
        }

        public RelayCommand btnwsArmProxy_Click
        {
            get
            {
                return new RelayCommand((obj) =>
                {
                    ContentField = new Views.wsArmProxyView();
                });
            }
        }

        public RelayCommand btnwsRsaBso_Click
        {
            get
            {
                return new RelayCommand((obj) =>
                {
                    ContentField = new Views.wsRsaBsoView();
                });
            }
        }

    }
}
