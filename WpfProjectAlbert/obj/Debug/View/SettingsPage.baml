   M S B A M L   `   `   `  ����K  GWpfProjectAlbert, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:WpfProjectAlbert.ViewWpfProjectAlbert.View  5      (    "WpfProjectAlbert.View.SettingsPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      5local#clr-namespace:WpfProjectAlbert.View     5      b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5        N� Title$  SettingsPage��5
         MaterialDesignBody#���   5   	   $��Regular"�5   	   $��13(�5   	   &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignPaper N� 
Background# �  5   	     MaterialDesignFont N� 
FontFamily# �  5   	    � DataContext 5      ��   mainViewModelLocator �� Source# [  �� Path$ SettingsViewModel�.��5      � $
��1000��6   $	��650��6   $��Center=�6%   $��Center=�6@    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   	 � ColumnDefinitions	 5   
   �� 5      $	��400 �6   �� 5      $��* �6   .+�5!   
   �� $��0��6   $��0��6"   $��2��62   
 �� Orientation$
 Vertical=�6F   $��0,0,0,20q�6]   .+�5"      (  "MaterialDesignThemes.Wpf.ColorZone     Mode$ PrimaryDark=�6'   $��16q�6:   .��5#      ]� .+�5$      �� $
��Left=�6    # MaterialDesignRaisedLightButton#��[ 5%      ��5$   4   �� *ToHomeCommand+.��5&      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ ArrowLeftThick=�62   5'      �� 5(      $
 
Horizontal=�6!   $��Center=�6:   .+�5)      �� $��Center=�6$   $��16 0 0 0q�6?   4 OP EEN RIJ5+      5,      5-      5.      5/      �� 51   
   $��1��6   $��0��6"   $
 Vertical=�62   $��
80,20,20,0q�6I   .+�52      �� )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Roepnaam��53       % !MaterialDesignFloatingHintTextBox#��[ 54      $��Bottom=�56      ��55      �� *ActieveGebruiker.Roepnaam+ �� Mode$ TwoWay=�56      57      �� 58   
   $��2��6   $��0��6"   $
 Vertical=�62   $��
80,0,20,20q�6I   .+�59      ��  �� 
IsReadOnly . $ Gebruikersnaam��5:      #��[ 5<      $	��Top=�5=      ��5;      �� *!ActieveGebruiker.Gebruikersnaam+5=      5>      �� 5?   
   $��3��6   $��0��6"   $
 Vertical=�62   $��
80,0,20,20q�6I   .+�5@      (  "System.Windows.Controls.DatePicker  $ Geboortedatum��5A       ( $MaterialDesignFloatingHintDatePicker#��[ 5B      $	��300��5D         SelectedDate 5C      �� * ActieveGebruiker.Geboortedatum+$ TwoWay=�5D      5F      �� 5G   
   $��4��6   $��0��6"   $
 Vertical=�62   $��
80,0,20,20q�6I   .+�5H      �� $ Pincode��5I      #��[ 5K      $	��Top=�5L      ��5J      �� *ActieveGebruiker.Pin+$ TwoWay=�5L      5M      �� 5N   
   $��5��6   $��0��6"   $
 Vertical=�62   $��0,0,0,0q�6I   .+�5O      ��  " MaterialDesignRaisedDarkButton#��[ 6   $	��150��5P      $��0,0,0,15q�6@    � ToolTip$8 2Resource name: MaterialDesignRaisedLightDarkButton��5Q      ��5P      �� *EditAccountCommand+.��5Q   J   Wijziging opslaan5R      �� 5S      #��[ 6   $	��150��5T      $8 2Resource name: MaterialDesignRaisedLightDarkButton��5U      ��5T      �� *DeleteAccountCommand+.��5U   J   Verwijder profiel5V      5X      5Y      5Z      