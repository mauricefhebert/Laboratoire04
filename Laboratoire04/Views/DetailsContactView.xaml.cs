using Laboratoire04.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Laboratoire04.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailsContactView : ContentPage
    {
        public DetailsContactView()
        {
            InitializeComponent();
            this.BindingContext = new DetailsContactViewModel();
        }

        private void ToolBarEditMenu_Clicked(object sender, EventArgs e)
        {
            var GridContainer = DetailsContactContainerGrid.Children;
            foreach (var frame in GridContainer)
            {
                if(frame is Frame)
                {
                    foreach(var entry in ((Frame)frame)) // Get children of frame here
                    {
                        if (entry is Entry)
                        {
                            if (!(entry as Entry).IsEnabled)
                            {
                                (entry as Entry).IsEnabled = true;
                            }
                        }
                    }
                }
            }
        }
    }
}