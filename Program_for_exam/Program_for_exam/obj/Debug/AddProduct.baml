   M S B A M L   `   `   `  ����K  GProgram_for_exam, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:Program_for_examProgram_for_exam  5   	   !    Program_for_exam.AddProduct   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:Program_for_exam     5   	     � Title$!  Добавить товар��5   	   $��313.127��6    $��783.634��61    � 	Resources 5
         DefaultColor��%+   &	        ��5   
   	#FFABADB3��60   5      .��5      � $��
0,0,-0.4,0q�6   .+�5   
   �� -   5         ��Name$ nameProductTextBox��5      $
��Left=�6.   $��23��6I    �� TextWrapping$
 Wrap=�6U   $	��Top=�6i   $	��150��6�   $��	23,49,0,0q�6�   .��6�    � ToolTip 5      _� 5      -   5         _�Name$ nameProductToolTip��5      $y�Hidden=�66   $2��,Укажите название товара��6J   .��5      5      �� 5   
   -   5        $ typeProductTextBox��5      $
��Left=�6.   $��23��6I   $
 Wrap=�6U   $	��Top=�6i   $	��150��6�   $��
23,107,0,0q�6�   .��6�    5      _� 5      -   5        $ typeProductToolTip��5      $y�Hidden=�66   $(��"Укажите тип товара��6J   .��5      5      �� 5   
   -   5        $ nameFabricatorTextBox��5      $
��Left=�61   $��23��6L   $
 Wrap=�6X   $	��Top=�6l   $	��150��6�   $��
23,166,0,0q�6�   .��6�    5      _� 5      -   5        $ nameFabricatorToolTip��5      $y�Hidden=�69   $@��:Укажите название производителя��6M   .��5      5      �� 5   
   -   5        $ priceProductTextBox��5      $
��Left=�6/   $��23��6J   $
 Wrap=�6V   $	��Top=�6j   $	��150��6�   $��
23,225,0,0q�6�   .��6�    5       _� 5!      -   5        $ priceProductToolTip��5!      $y�Hidden=�67   $*��$Укажите цену товара��6K   .��5"      5#      �� 5%   
   $#��Название товара��6   $
��Left=�6*   $	��Top=�6E   $��	23,23,0,0q�6]   �� 5&   
   $��Тип товара��6   $
��Left=�6%   $	��Top=�6@   $��	23,81,0,0q�6X   �� 5'   
   $1��+Название производителя��6   $
��Left=�61   $	��Top=�6L   $��
23,140,0,0q�6d    J� RenderTransformOrigin$ 0.636,1.435&�6x   �� 5(   
   $��Цена товара��6   $
��Left=�6&   $	��Top=�6A   $��
23,199,0,0q�6Y   �� 5*   
   -	   5        $��Добавить��5*      $
��Left=�6$   $��220,225,0,0q�6?   $	��Top=�6T   $��75��6l   $ 0.548,1.856&�6�   $��23��6�   &   System.Windows.Controls.DataGrid  5,   
   -
   5          Name$ listProductDataGrid��5,      $
��Left=�60   $	��159��6K   $	��Top=�6X   $��
220,50,0,0q�6p      Columns 5-      0  *System.Windows.Controls.DataGridTextColumn  5.      ,  &System.Windows.Controls.DataGridColumn	   Header$	 Название��6%   
   Width5  /System.Windows.Controls.DataGridLengthConverter$	
 150 6\   1  +System.Windows.Controls.DataGridBoundColumn   Binding 67   ��  �� Path$ nameProduct�   ElementStyle 5/      �� 50       �� 
TargetType" ��6    .�51      ��  �� Property � �� �� Value$
 Wrap=�6=   52      54        55      $	 Тип��6%   $	
 110 6W    62   �� $ typeProduct� 56      �� 57      " ��6    .�58      ��  � ��$
 Wrap=�6=   59      5;        5<      $ 	 Производитель��6%   $	
 150 6d    6<   �� $ nameFabricator� 5=      �� 5>      " ��6    .�5?      ��  � ��$
 Wrap=�6=   5@      5B        5C      $	 Цена��6%   $	
 100 6Y    63   �� $ priceProduct�6Y   5E      5G      5H      