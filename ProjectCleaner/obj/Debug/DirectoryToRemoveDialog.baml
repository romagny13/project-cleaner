   M S B A M L   `   `   `  ����I  EProjectCleaner, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:ProjectCleanerProjectCleaner  5   	   ,    &ProjectCleaner.DirectoryToRemoveDialog   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:ProjectCleaner     5   	     � 
ResizeMode$  NoResize=�5   	    � WindowStartupLocation$ CenterScreen=�5	   	    � Title$ Directory To Remove��5
   	   $	��180��6%   $	��350��62   .��5      � $��10q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      .+�5   
   �� .+�5      �� $.��(Enter the name of a directory to remove:��6   $
��Bold"�6H   $��5q�6Z   �� 5      -   5         ��Name$ DirectoryToRemoveTextBox��5      $��25��68   $��5q�6D   �� 5      -   5         ��Name$ MessageTextBlock��5      
���  ��$��5q�6C   5      �� 5   
    �� Orientation$ 
Horizontal=�6   $��Right=�6.   $��1��6J   .+�5      �� -   5        $��Ok��5      $��80��6"   $��5q�6?   �� 5      -   5        $��Cancel��5      $��80��6&   $��5q�6H   5      5      5      