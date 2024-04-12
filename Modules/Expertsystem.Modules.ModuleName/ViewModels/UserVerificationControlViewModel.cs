using CommunityToolkit.Mvvm.Messaging;
using Expertsystem.Core;
using Expertsystem.Core.Events;
using Expertsystem.Core.Mvvm;
using Expertsystem.Services.Interfaces;
using Prism.Commands;
using Prism.Events;
using Prism.Regions;
using System;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Threading;

namespace Expertsystem.Modules.ModuleName.ViewModels
{
    public class UserVerificationControlViewModel : RegionViewModelBase
    {
        private string _message;
        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }


        private string _emailVerificationCode;
        public string EmailVerificationCode
        {
            get { return _emailVerificationCode; }
            set { SetProperty(ref _emailVerificationCode, value); }
        }

        private Brush _brushColor = Brushes.Red;

        public Brush BrushColor
        {
            get => _brushColor;
            set => SetProperty(ref _brushColor, value);
        }

        private string _verificationCodeErrorBlock;
        public string VerificationCodeErrorBlock
        {
            get { return _verificationCodeErrorBlock; }
            set { SetProperty(ref _verificationCodeErrorBlock, value); }
        }
        private IEventAggregator _eventAggregator;
        private readonly IRegionManager _regionManager;
        public UserVerificationControlViewModel(IRegionManager regionManager, IMessageService messageService, IEventAggregator eventAggregator) :
            base(regionManager)
        {
            _regionManager = regionManager;
            Message = messageService.GetMessage();
            VerificationCodeCommand = new DelegateCommand(VerificationCodeSubmit);
            _eventAggregator = eventAggregator;
        }


        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            //do something
        }

        public DelegateCommand VerificationCodeCommand { get; set; }
        private void VerificationCodeSubmit()
        {
            if (string.IsNullOrEmpty(EmailVerificationCode) || EmailVerificationCode.Length < 6)
            {

                VerificationCodeErrorBlock = "Verification Code must be 6 characters long.";
                return;
            }

            try
            {
                //var result = await _cognitoService.ConfirmSignUp(_SignUpEmail, EmailVerificationCode);
                var result = new Response();
                if (!result.Success)
                {
                    VerificationCodeErrorBlock = result.Message;
                }
                else
                {
                    VerificationCodeErrorBlock = "Sign up is sucessfull. Our team will contact you soon.";
                    _regionManager.Regions[RegionNames.ContentRegion].RequestNavigate("SignUpSuccessControl");
                    BrushColor = Brushes.Green;
                    _eventAggregator.GetEvent<MessageEvent>().Publish("UserVerificationControl");
                }
            }
            catch
            {
                BrushColor = Brushes.Red;
                VerificationCodeErrorBlock = "Error Occured. Please Contact support";
            }
        }
        private void VerificationCodeError()
        {
            var timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(3) };
            timer.Tick += (sender, args) =>
            {
                VerificationCodeErrorBlock = string.Empty;
                timer.Stop();
            };
            timer.Start();
        }

    }
}
