   M S B A M L   `   `   `  ����A  =WpfApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:WpfAppWpfApp  5   	       WpfApp.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:WpfApp     5   	     � Title$  
MainWindow��5   	   $	��300��6   $	��350��6)   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $
��Auto �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� -   5         ��Name$ 	setButton��5      $��Set Name��6$   $��0��67   $��0��6G   $
��Left=�6T   $��10,15q�6o   $	��Top=�6~   $��75��6�   6�   �� 5   
   -   5        $ 	retButton��5      $��Ret Name��6$   $��0��67   $��1��6G   $
��Left=�6T   $��10,15q�6o   $	��Top=�6~   $��75��6�   6�   �� 5   
   -   5         ��Name$ setText��5      $��1��6#   $��0��63   $��Stretch=�6@   $	��Top=�6^   $��23��6v   $��10,15q�6�   6�   �� 5   
   -   5         ��Name$ retLabel��5      $��1��6"   $��1��62   $��Label��6?   $
��Left=�6O   $��10,15q�6j   $	��Top=�6y   �� 5   
   -   5        $ NewWindowButton��5      $��0��6*   $��2��6:   $��
New Window��6G   $
��Left=�6\   $��10,15q�6w   $	��Top=�6�   $��75��6�   6�   �� 5   
   -   5         ��Name$ txtBlock��5      $��1��6&   $��2��66   $��10,15q�6C   $	��Top=�6R   $
��Wrap=�6j   5      5      