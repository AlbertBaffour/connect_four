   M S B A M L   `   `   `  ����K  GWpfProjectAlbert, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:WpfProjectAlbert.ViewWpfProjectAlbert.View  5      '    !WpfProjectAlbert.View.WelcomePage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      5local#clr-namespace:WpfProjectAlbert.View     5      b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5        N� Title$  4 op een rij - Welkom��5
         MaterialDesignBody#���   5   	   $��Regular"�5   	   $��13(�5   	   &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignPaper N� 
Background# �  5   	     MaterialDesignFont N� 
FontFamily# �  5   	    � DataContext 5   	   ��   mainViewModelLocator �� Source# [  �� Path$ WelcomeViewModel�.��5      � $
��1000��6   $	��650��6   $��Center=�6&   $��Center=�6A    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   	 � ColumnDefinitions	 5   
   �� 5      $
��1000 �6   .+�5   
   �� $��0��6   $��0��6"   $��2��62   
 �� Orientation$
 Vertical=�6F   .+�5      (  "MaterialDesignThemes.Wpf.ColorZone     Mode$ PrimaryDark=�6'   $��16q�6:   .��5      ]� .+�5      '  !MaterialDesignThemes.Wpf.PopupBox  $��Right=�6.      PlacementMode$ BottomAndAlignRightEdges=�6E      PopupContent. 5       �� .@�5"      �� .��5#   "   ��    MaterialDesignOutlinedButton#��[ 5$       � ToolTip$" MaterialDesignOutlinedButton��5%      ��5&   %   �� *InstructionsCommand+.��6M   
Spelregels5(   #   5)      �� 5*      #��[ 5+      $" MaterialDesignOutlinedButton��5,      ��5*   %   �� *SettingsCommand+.��5,   ,   	Profiel5.      �� 5/      .��50   "   �� #��[ 51      $" MaterialDesignOutlinedButton��52      ��50   )   �� *UitloggenCommand+.��52   ,   
Afmelden54   #   55      56      57      �� 58      $
 
Horizontal=�6!   $��Center=�6:   .+�59      �� $��Center=�6$   $��16 0 0 0q�6?   4 OP EEN RIJ5;      5<      5=      5>      5?      �� 5A   
   $��2��6   $��1��6"   $
 Vertical=�62   $��0,0,0,0q�6I   .+�5B      �� $��/Resources/bg.png��6   5C      �� 5D   
   $��2��6   $��1��6"   $
 Vertical=�62   $��0,10,0,0q�6I   .+�5F      #  MaterialDesignThemes.Wpf.Card    PrimaryHueLightBrush#���  5G       " PrimaryHueLightForegroundBrush#���  5H      $	��200��5I      $��8q�5J      .��5K      �� $��Center=�6   $��16(�5L      ��5K   :   �� *ActieveGebruiker.Roepnaam+ �� Mode$ OneWay=�5N      5O      5Q      �� 5S   
   $��3��6   $��1��6"   $
 Vertical=�62   $��20,200,20,0q�6I   .+�5V      ��  # MaterialDesignRaisedLightButton#��[ 5W      3  -MaterialDesignThemes.Wpf.ButtonProgressAssist   Value$ -1Q�5X         IsIndicatorVisible .    IsIndeterminate . $��Spelen��5[      $	��200��5]      $��60��6   $
��20px(�6   $��verdana)�6-   ��5\      �� *PlayCommand+5]   -   � 5^       5_      �� 5`      6&   �� 5a      6&   	 5c      �� 5d      6)   �� 5e      6)   .+�5g      �� $��0��6   $��0��6%   $	��100��65   $��	ExtraBold"�6A   $��Center=�6X   .��6t   
Gewonnen :6�   �� 5h      $��0��6   $��1��6&   $��Center=�66   $	��100��6Q   $	��100(�6]   ��6m   �� *
Gewonnen+�� 5i      $��1��6   $��0��6%   $��Center=�65   $��	ExtraBold"�6P   $	��100��6g   .��6t   
Verloren :6�   �� 5j      $��1��6   $��1��6&   $��Center=�66   $	��100��6Q   
���  ��$	��100(�6n   ��6}   �� *
Verloren+5k      5l      5n      5o      