   M S B A M L   `   `   `  ����E  AWpfAppSQL6, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:WpfAppSQL6
WpfAppSQL6  5   	       WpfAppSQL6.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:WpfAppSQL6     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      �  � RowDefinitions 5
   
   �� 5      $��* �6   6)    � ColumnDefinitions 5   
   �� 5      $��1* �6   6,   �� 5      $��3* �6   6,   .+�5   
   �� $
��Left=�6   $��10, 10, 0, 0q�60   $��0��6F   $��0��6S   .+�5      �� -   5        $��productCountButton��5   I   $	��175��6   $��25��6!   $��
0, 0, 0, 0q�6d   .��6x   Записать XML и XSD6�   �� 5      -   5        $��productListNameButton��5   J   $	��175��6   $��25��6!   $��0, 0, 0, -50q�6h   .��6~   Прочитать6�   5      �� 5   
   $
��Left=�6   $��10, 10, 0, 0q�60   $��0��6F   $��1��6S   .+�5      &   System.Windows.Controls.DataGrid  -   5          Name$ dataGrid��5         AutoGenerateColumns$
 True��6)   $
��auto��6D   5      �� 5   
   $
��Left=�6   $��10, 10, 0, 0q�60   $��0��6F   $��2��6S   .+�5        -   5        $ dataGridInfo��5      $
 True��6-   $
��auto��6H     5      -   5        $ dataGridProcedure��5      $
 True��62   $
��auto��6M   5      5!      5"      