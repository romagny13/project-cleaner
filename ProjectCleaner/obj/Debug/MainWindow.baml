   M S B A M L   `   `   `  ����I  EProjectCleaner, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:ProjectCleanerProjectCleaner  5   	       ProjectCleaner.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:ProjectCleaner     5   	     � WindowStartupLocation$  CenterScreen=�5   	    � Title$ Project cleaner��5	   	   $	��360��6!   $	��640��6.    � Icon$ cleaner.ico��6:   .��5
      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      �� 5      $
��Auto �6   .+�5   
   � $��10q�6    � ColumnDefinitions 5      �� 5      �� 5      $
��Auto �6#    5      �� 5      $
��Auto �6    �� 5      .+�5      �� -   5         ��Name$  SolutionDirectoryTextBlock��5      $��5q�6[   ��6<   �� *BaseDirectory+6[   �� 5      -   5         ��Name$ SelectDirectoryButton��5      $��Select a directory��64   $	��120��5      $��5q�6    $��2��6+   ��5   Q   �� *SelectCommand+5   +   �� 5       -   5        $ CleanButton��5       $��Clean��6*   $	��120��6\   $��5q�5!      $��2��6    $��1��64   $��Right=�6A   ��5    :   �� *CleanCommand+5!   A   5"      � 5$   
   $��2��6    5%      �� 5&      �� 5'      .+�5*      � $��10q�6    5+      �� 5,      $
��Auto �6$   �� 5-      .+�50      � $��20��6    51      �� 52      �� 53      $
��Auto �6,   .+�56      �� $��Directories to remove��6    $
��Bold"�6=   �� 58       �� Orientation$ 
Horizontal=�6!   $��Right=�6:   .+�59      �� -   5        $��+��59   !   $��20��6-   68   �� 5:      -   5        $��-��5:   !   $��20��6-   68   5;      5=      �� 5?      -   5         ��Name$! DirectoriesToRemoveListView��5?      $��1��6l   ��6@   �� *DirectoriesToRemove+6l   5@      � 5B      $��10q�6   $��1��6    5C      �� 5D      $
��Auto �6$   �� 5E      .+�5H      �� $��Directories removed��6   $
��Bold"�67   $��20��6I   �� 5I      $��1��6F   ��6   �� *RemovedDirectories+6F   5J      5K      �� 5M   
   $��3��6   .@�5N      �� .��5O      �� -   5        $ StatusMessage��5O      5P      �� 5Q      $��Right=�6   .��5R      � -   5        	 �Name$	 ProgressBar��5R      $y�	Collapsed=�63   
 � IsIndeterminate
 . $��80��6a   $��25��6l   5S      5T      5U      5V      