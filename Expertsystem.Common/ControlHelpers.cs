using System.Windows.Controls;

namespace Expertsystem.Common
{
    public static class ControlHelpers
    {
        public static void ClearInputControls(Panel container)
        {
            foreach (var control in container.Children)
            {
                switch (control)
                {
                    case TextBox textBox:
                        textBox.Clear();
                        break;
                    case PasswordBox passwordBox:
                        passwordBox.Password = string.Empty;
                        break;

                }
            }
        }
    }
}

