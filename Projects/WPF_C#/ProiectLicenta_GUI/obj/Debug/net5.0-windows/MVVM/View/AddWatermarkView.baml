   M S B A M L   `   `   `  ����M  IProiectLicenta_GUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:ProiectLicenta_GUI.MVVM.ViewProiectLicenta_GUI.MVVM.View  5      U/clr-namespace:ProiectLicenta_GUI.MVVM.ViewModel!ProiectLicenta_GUI.MVVM.ViewModel  5      3    -ProiectLicenta_GUI.MVVM.View.AddWatermarkView   5      \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      <local*clr-namespace:ProiectLicenta_GUI.MVVM.View     5      E	viewModel/clr-namespace:ProiectLicenta_GUI.MVVM.ViewModel     5      .��5      �   � ColumnDefinitions  5   
   �� 5      $��1* �6   �� 5      $��1* �6    � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $��1* �6   �� 5      $
��auto �6   �� 5      $��1* �6   �� 5      $
��auto �6   �� 5      $��1* �6   �� 5      $
��auto �6   �� 5      $��1* �6   .+�5   
   �� $��Add Watermark to an Image��6   $��26(�65   $
��Bold"�6C   $��0��5      $��0��6%   $��2��62   $��Center=�6F   5      �� 5"   
   $��0��6   $��2��6%   $��2��62    �� Orientation$ 
Horizontal=�5#      $��Center=�6.   .+�5$      �� $&�� Please insert the Watermark Key:��6   $��20(�6@   $��0,0,10,0q�6N   5%      �� 5'      $	��150��6I   $��16(�6U    �� 	MaxLength$ 15��5(       � ToolTip$9 3Insert a key for the watermark (max 15 characters).��6%   ��5'      �� *WatermarkKey+ �� Mode$ OneWayToSource=�.��5(   c   5)      5*      �� 5-   
   $��0��6   $��4��6%   $��2��62   $ 
Horizontal=�5.      $��Center=�6.   .+�5/      �� $��Select Export Format:��6   $��20(�65   $��0,0,10,0q�6C   50      �� 52      $	��140��6S   $��16(�53      $. (Select the format of the exported image.��6%    �� SelectedValue 52      �� *ExportFromat+$ OneWayToSource=�.@�54      �� $��PNG (lossless)��6    �� 
IsSelected$
 True��68   6L   �� 55      $��BMP (lossless)��6   6;   �� 56      $��JPEG (lossy)��6   69   �� 57      $��JPG (lossy)��6   68   58      59      �� 5<   
   $��0��6   $��6��6%   $��2��62   $ 
Horizontal=�5=      $��Center=�6.   .+�5>      �� $$��Add Watermark and Export Image��6   $	��250��6>   $��16(�6J   $3 -Add the watermark to the image and export it.��5?      ��5@      �� *AddWatermarkCommand+5A      5C      5D      