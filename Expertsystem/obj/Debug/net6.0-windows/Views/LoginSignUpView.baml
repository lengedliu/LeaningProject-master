   M S B A M L   `   `   `  ����G  CExpertsystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:Expertsystem.ViewModelsExpertsystem.ViewModels  5      L HExpertsystem.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullP:clr-namespace:Expertsystem.Core;assembly=Expertsystem.CoreExpertsystem.Core 5
      (    "Expertsystem.Views.LoginSignUpView   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      4vm%clr-namespace:Expertsystem.ViewModels     5      Z VPrism.Unity.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59T PPrism.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59&prismhttp://prismlibrary.com/   5      Gcore:clr-namespace:Expertsystem.Core;assembly=Expertsystem.Core   5
      -   5        !  Prism.Mvvm.ViewModelLocator    AutoWireViewModel  True5	       � Title$ LoginSignUpView��5      $
��1024��5      $	��768��5       � AllowsTransparency$
 True��5      ���#FFFFFF � WindowStartupLocation$ CenterScreen=�5       � WindowStyle$
 None=�5       � 	Resources 5       �� MergedDictionaries �� Source�� 5   
    5      �� 5      $U Opack://application:,,,/Expertsystem.Common;component/Themes/LoginViewStyle.xaml?�6%   %    5      .��5      � 
������  � ColumnDefinitions 5   
   �� 5      $��10 �6   �� 5      $	��450 �6   �� 5       $	��100 �6   �� 5"      $��* �6   �� 5#      $��25 �6   �� 5$      $��25 �6   �� 5%      $��10 �6   	 � RowDefinitions	 5(   
   �� 5)      $��10 �6   �� 5*      $��25 �6   �� 5+      $��35 �6   �� 5-      $��* �6   �� 5.      $��10 �6   .+�52   
   �� -   5        $��1��53      $��5��54      $��24��55      $��24��56      $��Center=�57      $��Center=�58      
������ $��0q�5:      $��X��5<      $��16(�5=      ���#2525255>      �� 5A   
   $��0��5B      $��5��5C      $��0��5D      $��2��5E      $��Stretch=�5F      $��Stretch=�5G      ��5H      �� 5I      
 �� ImageSource$;
 5pack://application:,,,/Assets/splash-page-image_1.jpg��6   5K      �� 5N   
   $��2��5O      $��3��5P      $
��Left=�5Q      $��Center=�5R      
������ $��0q�5T      $��13(�5V      $��Regular"�5W      ���#252525��5U      �� *GoBackCommand+y�5Y      �� *GoBackVisibility+.��5Z      �� $��Center=�6    �� Orientation$ 
Horizontal=�64   .+�5[      �� $��12��5\      $��12��5]      $<��6pack://application:,,,/Assets/back_icon-1_darkgray.png��5^      �� 5_      $��Center=�6   $�� BACK��67   5`      5a      �� 5d   
   $��3��5e      $��3��5f      $��Stretch=�5g      $��Stretch=�5h      #  Expertsystem.Core.RegionNames   ContentRegion!  Prism.Regions.RegionManager   
RegionName# Z 5i      5k      5l      