using Expertsystem.Modules.ModuleName.ViewModels;
using Expertsystem.Common;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;
using System.ComponentModel;
using Prism.Events;
using Expertsystem.Core.Events;

namespace Expertsystem.Modules.ModuleName.Views
{
    public partial class UserVerificationControl : UserControl
    {
        private readonly IEventAggregator _eventAggregator;
        public UserVerificationControl(IEventAggregator eventAggregator)
        {
            InitializeComponent();
            _eventAggregator = eventAggregator;
            _eventAggregator.GetEvent<MessageEvent>().Subscribe(ClearTextBoxes);
        }

        private void ClearTextBoxes(string msg)
        {
            if (msg.Equals("UserVerificationControl"))
            {
                ControlHelpers.ClearInputControls(TextBoxContainer);
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var viewModel = DataContext as UserVerificationControlViewModel;
            if (viewModel == null) return;
            var textBoxes = TextBoxContainer.Children.OfType<TextBox>().ToArray();
            var textBox = sender as TextBox;
            if (textBox != null && textBox.Text.Length == 1)
            {
                var request = new TraversalRequest(FocusNavigationDirection.Next);
                request.Wrapped = true;
                textBox.MoveFocus(request);
            }

            var combinedText = string.Concat(textBoxes.Select(tb => tb.Text));
            viewModel.EmailVerificationCode = combinedText;
        }
    }
}
