   M S B A M L   `   `   `  ����Z  VExpertsystem.Modules.ModuleName, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]3clr-namespace:Expertsystem.Modules.ModuleName.Views%Expertsystem.Modules.ModuleName.Views  5      Q MExpertsystem.Component, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null_Dclr-namespace:Expertsystem.Component;assembly=Expertsystem.ComponentExpertsystem.Component 5      9    3Expertsystem.Modules.ModuleName.Views.SignUpControl   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      Elocal3clr-namespace:Expertsystem.Modules.ModuleName.Views     5      Z	pwdHelperDclr-namespace:Expertsystem.Component;assembly=Expertsystem.Component     5      T PPrism.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59$prismhttp://prismlibrary.com/  5	      !  Prism.Mvvm.ViewModelLocator    AutoWireViewModel  True5
      $	��391��5      $	��680��5       � 	Resources 5       �� MergedDictionaries �� Source�� 5   
    5      �� 5      $U Opack://application:,,,/Expertsystem.Common;component/Themes/LoginViewStyle.xaml?�6%   %    5      .��5      �  � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5       $��* �6   �� 5!      $��10 �6   �� 5"      $��* �6   �� 5#      $��30 �6   �� 5$      $��* �6    � ColumnDefinitions 5'   
   �� 5(      $��* �6   �� 5)      $��10 �6   �� 5*      $��60 �6   �� 5+      $��10 �6   �� 5,      $��50 �6   �� 5-      $��10 �6   �� 5.      $	��130 �6   .+�52   
   �� $��0��53      $��0��54      $��7��55      .+�56      �� $��Company Name��6      TextboxTitleStyle#��[  6+   �� 57      -   5         ��Name$ textBoxCompanyName��58      $	��389��59        VaildationTextBoxStyle#��[ 5:      ��5;      �� *SignUpModel.CompanyName+ �� ValidatesOnDataErrors$
 True�� �� NotifyOnValidationError$
 True��	 �� UpdateSourceTrigger$	 PropertyChanged=�5<      �� 5?   
   $��1��5@      $��0��5A      $��3��5B      $��0,2,0,0q�5C      .+�5D      �� $��Create Password��6   #��[  6.   G� 5E      -   5        
 G�Name$
 CreatePasswordBox��5F      $	��190��5G        VaildationPasswordBoxStyle#��[ 5H      .  (Expertsystem.Component.PasswordBoxHelper   Attach$
 True��5K      
 � Tag 5I      �� *SignUpModel.CreatePassword+$
 True��$
 True��   Password 5J      �� *SignUpModel.CreatePassword+ �� Mode$ TwoWay=�$	 PropertyChanged=�$
 True��5K      5L      �� 5O   
   $��1��5P      $��4��5Q      $��3��5R      $��0,2,0,0q�5S      .+�5T      �� $��Confirm Password��6   #��[  6/   G� 5U      -   5        $
 ConfirmPasswordBox��5V      $	��189��5W      #��[ 5X      $
 True��5[       5Y      �� *SignUpModel.ConfirmPassword+$
 True��$
 True��$	 PropertyChanged=� 5Z      �� *SignUpModel.ConfirmPassword+$ TwoWay=�$	 PropertyChanged=�$
 True��5[      5\      �� 5_   
   $��2��5`      $��0��5a      $��5��5b      $��0,2,5,0q�5c      .+�5d      �� $��Company Address��6   #��[  6.   �� 5e      -   5        $ textBoxCompanyAddress��5f      $	��245��5g      #��[ 5h      ��5i      �� *SignUpModel.CompanyAddress+$
 True��$
 True��$	 PropertyChanged=�5j      �� 5o   
   $��2��5p      $��5��5q      $��3��5r      $��10,2,0,0q�5s      .+�5t      �� $��Postal Code��6   #��[  6*   �� 5u      -   5        $ textBoxPostalCode��5v      $	��129��5w      #��[ 5x      ��5y      �� *SignUpModel.PostalCode+$
 True��$
 True��$	 PropertyChanged=�5z      �� 5}   
   $��3��5~      $��0��5      $��0,2,0,0q�5�      .+�5�      �� $��Country��6   #��[  6&   �� 5�      -   5         ��Name$ comboBoxCountry��5�      $	��115��5�       �� DisplayMemberPath$
 Name��5�       �� SelectedValuePath$
 Code��5�        ComboboxStyle#��[ 5�      ��5�      �� *SignUpModel.Countries+ �� SelectedItem 5�      �� *SignUpModel.SelectedCountry+5�      5�      �� 5�   
   $��3��5�      $��2��5�      $��3��5�      $��0,2,0,0q�5�      .+�5�      �� $��Province/State��6   #��[  6-   �� 5�      -   5        $ comboBoxState��5�      $	��115��5�      #��[ 5�      ��5�      �� *SignUpModel.StatesList+ 5�      �� *SignUpModel.State+5�      5�      �� 5�   
   $��3��5�      $��6��5�      $��3��5�      $��0,2,0,0q�5�      .+�5�      �� $
��City��6   #��[  6#   �� 5�      -   5        $ textBoxCity��5�      $	��129��5�      #��[ 5�      ��5�      �� *SignUpModel.City+$
 True��$
 True��$	 PropertyChanged=�5�      �� 5�   
   $��4��5�      $��0��5�      $��5��5�      $��0,2,5,0q�5�      .+�5�      �� $��Company Email��6   #��[  6,   �� 5�      -	   5        $ textBoxCompanyEmail��5�      $	��245��5�      #��[ 5�      ��5�      �� *SignUpModel.CompanyEmail+$
 True��$
 True��$	 PropertyChanged=�5�      �� 5�   
   $��4��5�      $��6��5�      $��3��5�      $��0,2,0,0q�5�      .+�5�      �� $��Company Phone��6   #��[  6,   �� 5�      -
   5        $ textBoxCompanyPhoneNumber��5�      $	��129��5�       �� 	MaxLength$ 12��5�      #��[ 5�      ��5�      �� * SignUpModel.CompanyPhoneNumber+$
 True��$
 True��$	 PropertyChanged=�5�      �� 5�   
   $��5��5�      $��0��5�      $��7��5�      $��0,2,0,0q�5�      .+�5�      �� $��Reason For Contact��6   #��[  61   �� 5�      -   5        $ comboBoxReasonForContact��5�      $	��390��5�      #��[ 5�      ��5�      �� *" SignUpModel.ReasonForContactList+ 5�      �� *SignUpModel.ReasonForContact+$
 True��$
 True��$	 PropertyChanged=�5�      5�      �� 5�   
   $��6��5�      $��0��5�      $��5��5�      $��0,2,2,0q�5�      .+�5�      �� $��Contact Person��6   #��[  6-   �� 5�      -   5        $ textBoxContactPerson��5�      $	��245��5�      #��[ 5�      ��5�      �� *SignUpModel.ContactPerson+$
 True��$
 True��$	 PropertyChanged=�5�      �� 5�   
   $��6��5�      $��6��5�      $��3��5�      $��0,2,0,0q�5�      .+�5�      �� $��Contact Phone��6   #��[  6,   �� 5�      -   5        $% textBoxContactPersonPhoneNumber��5�      $	��129��5�      $ 12��5�      #��[ 5�      ��5�      �� *&$SignUpModel.ContactPersonPhoneNumber+$
 True��$
 True��$	 PropertyChanged=�5�      �� 5�   
   $��7��5�      $��3��5�      $��0��5�      $��8��5�      $��	0,10,0,10q�5�       �� Orientation$ Vertical=�5�      .+�5�      �� $
��Auto��5�      $��50��5�      $��0,20,0,0q�5�      ���#004225$��SUBMIT��5      $��22(�5     $��SemiBold"�5     ���#CBB26B��5�      �� *SignUpCommand+��5     �� 5      �� 
TargetType" ��6&   .R�5     ��  �� Padding$ 7q�5     ���#004225 �� CornerRadius$ 1��5	     ._�5
     �� $��Center=�6/   $��Center=�6L   5     5     5     �� 5     -   5         ��Name$ SignUpResultMessage��5     
���  ��  SignupResultMessageStyle#��[ 5      �� TextAlignment$ Center=�5     ��5     �� *SignUpModel.ErrorMsg+$ OneWay=�5     5     �� 5  
   $��10��5     $��0��5     $��8��5     $��0q�5     $	��Top=�5     .+�5     �� $
��Auto��5     $
��Auto��5      $��0q�5!     $
��Left=�5"     
�������$��Already have an account��5%     $��14(�5&     $��Regular"�5'     ���#0085FF��5$     �� *ShowSignInCommand+��5)     �� 5*     " ��6&   .R�5+     �� $ 0q�5,     
������ $ 1��5.     ._�5/     �� $��Center=�6/   $��Center=�6L   50     51     53     �� 54     $��0,3,0,0q�55       TermPolicyStyle#��[ 56     $R��LBy using this application, you agree to our Terms of Use and Privacy Policy.��57     58     59     5:     