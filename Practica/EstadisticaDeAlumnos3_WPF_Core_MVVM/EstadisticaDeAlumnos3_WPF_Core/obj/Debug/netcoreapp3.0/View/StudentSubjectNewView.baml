   M S B A M L   `   `   `  ����"  EstadisticaDeAlumnos3_WPF_Core?    9EstadisticaDeAlumnos3_WPF_Core.View.StudentSubjectNewView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      .��5      �   � RowDefinitions  5	   
   �� 5
      $��* �6   6)   �� 5      $��6* �6   6*    � ColumnDefinitions 5   
   �� 5      6!   �� 5      6!   �� 5      6!   .+�5   
   � -   5        $	��wp1��5      $��3q�6   $��0��6*   $��0��67   .+�5      �� $��	_Student:��6   $��50��6R    �� Target 6(   ��  �� ElementName$ 
txtStudent��6R   �� 5      -   5        $
��cmb1��5      $	��100��6E    �� DisplayMemberPath$
 Name��5      $��Stretch=�60   $��10,0,0,0q�6N    �� SelectedValuePath$	 Dni��5      ��5   $   �� *
Students+ �� SelectedValue 5      ��  �� Path$ DniEntry�5      � 5   
   $��3q�6   $��0��6   $��2��6'    5      �� 5      $��* �6#   6/   �� 5      $��* �6#   6/   �� 5      $��* �6#   6/   .+�5       �� -   5        $��butt1��5       $	��Add��6"   $��0��6]   ��60   �� *AddStudentSubjectCommand+{�6m   �� $ Enable_N�6�   �� 5!      -   5        $��	butt_updt��5!      $��Update��6&   $��1��6g   ��67   �� *UpdateStudentSubjectCommand+{�6w   �� $ Enable�6�   �� 5"      -   5        $��
butt_clear��5"      $��Clear��6'   $��2��6g   ��67   �� *DeleteStudentSubjectCommand+6y   5#      &   System.Windows.Controls.DataGrid  5$   
   -   5        $��
dtgridSSNV��5'         
IsReadOnly$
 True��5$      	   AutoGenerateColumns$	 False��5&      $��5q�5)      $��1��5*      $��2��6    
 �� SelectedItem
 5%      �� $ SelectedStudentSubject� �� Mode$ TwoWay=���5(      �� *SubjectsByStudent+$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�   Columns 5+      0  *System.Windows.Controls.DataGridTextColumn  5,      ,  &System.Windows.Controls.DataGridColumn   Header$
 Name��6E   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� $
 Name�6E   5/        50   
   -   5        $��dtgridSSNV2��53      $
 True��50      $	 False��52      $��5q�55      $��1��56      $��2��6    
 51      �� $ SelectedSubject�$ TwoWay=���54      �� *
Subjects+$ TwoWay=�$ PropertyChanged=� 57        58      $
 Name��6E    6%   �� $
 Name�6E   5;      5<      5=      