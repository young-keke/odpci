   M S B A M L   `   `   `  ����D  @WordEater, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:WordEater	WordEater  5   	       WordEater.Program   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:WordEater     5   	     � Title$  Program��5   	   $	��450��6   $	��800��6&   .��5	      � 
������� � RowDefinitions 5
   
   �� 5      $	��100 �6   �� 5      $	��100 �6   �� 5      $	��250 �6   .+�5   
   �� -   5         ��Name$ tb��5      
����� �$��0��60    �� AcceptsReturn . ��. $��Visible=�6w   �� 5   
    �� Orientation$ 
Horizontal=�6   $��1��6.   .+�5      �� -   5         ��Name$ ParseBtn��5      $��Parse��6>   $	��395��6N   $��1q�6Z   �� 5      -   5        $ FindBtn��5      $
��Find��6<   $	��395��6K   5      �� 5   
   -   5        $ Result��5      $��2��6"   5      5      