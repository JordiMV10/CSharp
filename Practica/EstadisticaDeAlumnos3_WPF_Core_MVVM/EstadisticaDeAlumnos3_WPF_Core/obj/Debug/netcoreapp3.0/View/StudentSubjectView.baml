   M S B A M L   `   `   `  ����Y  UEstadisticaDeAlumnos3_WPF_Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullY1clr-namespace:EstadisticaDeAlumnos3_WPF_Core.View#EstadisticaDeAlumnos3_WPF_Core.View  5      <    6EstadisticaDeAlumnos3_WPF_Core.View.StudentSubjectView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Clocal1clr-namespace:EstadisticaDeAlumnos3_WPF_Core.View     5      .��5	      �   � RowDefinitions  5
   
   �� 5      $��* �6   6)   �� 5      $��6* �6   6*    � ColumnDefinitions 5   
   �� 5      6!   �� 5      6!   �� 5      6!   .+�5   
   � -   5        $	��wp1��5      $��3q�6   $��0��6*   $��0��67   .+�5      �� $��	_Student:��6   $��50��6R    �� Target 6(   ��  �� ElementName$ 
txtStudent��6R   �� 5      -   5        $��
txtStudent��5   1   $��Center=�6   $	��193��6�   ��6C   �� *
StudentDni+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�6�   �� 5      $��	_Subject:��6   $��50��6R    6(   �� $ 
txtSubject��6R   �� 5      -   5        $��
txtSubject��5      $��Center=�6(   $	��193��6�   ��6C   �� *SubjectName+$ TwoWay=�$ PropertyChanged=�6�   5      � 5   
   $��3q�6   $��0��6   $��2��6'    5      �� 5      $��* �6#   6/   �� 5      $��* �6#   6/   �� 5      $��* �6#   6/   .+�5      �� -   5        $��butt1��5      $	��Add��6"   $��0��6]   ��60   �� *AddStudentSubjectCommand+{�6m   ��  �� Path$ Enable_N�6�   �� 5       -   5        $��	butt_updt��5       $��Update��6&   $��1��6`   ��67   �� *UpdateStudentCommand+{�6p   �� $ Enable�6�   �� 5!      -   5        $��
butt_clear��5!      $��Clear��6'   $��2��6_   ��67   �� *ClearStudentCommand+6q   5"      &   System.Windows.Controls.DataGrid  5#   
   -   5        $��lstbox2��5#   �      
IsReadOnly$
 True��6      AutoGenerateColumns$ False��6g   $��5q�6  $��1��6  $��3��6  	 �� SelectedItem	 6%   �� $ SelectedStudentSubject�$ TwoWay=���6�   �� *StudentSubjects+$ TwoWay=�$ PropertyChanged=�
   Columns
 5$      0  *System.Windows.Controls.DataGridTextColumn  5%      ,  &System.Windows.Controls.DataGridColumn   Header$
 Name��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ 4* 6[   1  +System.Windows.Controls.DataGridBoundColumn   Binding 63   �� $ Student.Name�6[     5&      $	 Dni��6%   $ 4* 6Y    62   �� $ Student.Dni�6Y     5'      $ Subject��6%   $ 3* 6^    66   �� $ Subject.Name�   ElementStyle 5(      �� 5)       �� 
TargetType" ��6    .�5*      ��  �� Property � �� �� Value$
 Left=�6D   5+      5-      4  .System.Windows.Controls.DataGridTemplateColumn  5.      $
 1.5* 6)      CellTemplate 5/      �� 50      .R�51      �� $
��Edit��6%   ��64   ��  �� RelativeSource �� *FindAncestor+ �� AncestorType<   6EstadisticaDeAlumnos3_WPF_Core.View.StudentSubjectView"  $$ DataContext.EditStudentCommand�6�   52      54        55      $
 1.5* 6)    56      �� 57      .R�58      �� $��Delete��6%   ��66   ��  �� *FindAncestor+"  $- 'DataContext.DeleteStudentSubjectCommand�6�   59      5;      5=      5>      5?      