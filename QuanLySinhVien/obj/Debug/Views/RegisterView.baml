   M S B A M L   `   `   `  ����I  EQuanLySinhVien, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:QuanLySinhVien.ViewsQuanLySinhVien.Views  5   	   '    !QuanLySinhVien.Views.RegisterView   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  5   	   .local"clr-namespace:QuanLySinhVien.Views  5   	   -   5        $��registerView��5   	     � SizeToContent$  WidthAndHeight=�5	   	    � Title$ RegisterView��5
   	    � WindowStartupLocation$ CenterScreen=�5   	   ���#2E3137 � WindowStyle$
 None=�5   	      
RegisterVM � DataContext# [  5   	   .��5      �� ���#171835 �� CornerRadius$ 20��5      $��20q�5      ._�5   
   �  � RowDefinitions 5      �� 5      $��* �6    �� 5      $��* �6    �� 5      $��* �6    �� 5      $��* �6    �� 5      $��* �6    �� 5      $��* �6    �� 5      $��* �6    �� 5      $��* �6    �� 5      $��* �6    �� 5      $��* �6    �� 5      $��* �6    .+�5"      �� $��0��6   $��15(�5#      $
��Bold"�5$      
�������$��10q�5&      $��Center=�5'      Tạo tài khoản6D   �� 5(      $��1��6    �� Orientation$ 
Horizontal=�5)      .+�5*      �� $��Tên tài khoản��6   $��10q�5+      
�������5,      �� 5-      $��30 10q�5.      $	��150��5/      $��30��50      ��5-      �� *TenTaiKhoan+50      51      �� 52      $��2��6   $ 
Horizontal=�53      .+�54      �� $��Mật khẩu��6   $��10q�55      
�������56      G� 57      -   5        $��
pwbMatKhau��57      $	��150��58      $��30��59      $��50 10q�5:      $��5q�5;      *  $Microsoft.Xaml.Behaviors.Interaction   Triggers 5<      +  %Microsoft.Xaml.Behaviors.EventTrigger  5=      	   	EventName$	 PasswordChanged��6)   *  $Microsoft.Xaml.Behaviors.TriggerBase
   Actions.
 5>      2  ,Microsoft.Xaml.Behaviors.InvokeCommandAction     Command 64   �� * PasswordChangedCommand_MatKhau+   CommandParameter 5?   4   ��  �� ElementName$ 
pwbMatKhau��5@      5B      5C      �� 5D      $��3��6   $ 
Horizontal=�5E      .+�5F      �� $��Nhập lại mật khẩu��6   $��10q�5G      
�������5H      G� 5I      -   5        $��pwbNhapLaiMK��5I      $	��150��5J      $��30��5K      $
��3 10q�5L      $��5q�5M       5N        5O      $	 PasswordChanged��6)   .
 5P         64   �� *" PasswordChangedCommand_NhapLaiMK+ 5Q   4   �� $ pwbNhapLaiMK��5R      5T      5U      �� 5V      $��4��6   $ 
Horizontal=�5W      .+�5X      �� $��Họ đệm��6   $��10q�5Y      
�������5Z      �� 5[      $��57 10q�5\      $��30��5]      $	��150��5^      ��5[      �� *HoDem+5^      5_      �� 5`      $��5��6   $ 
Horizontal=�5a      .+�5b      �� $
��Tên��6   $��10q�5c      
�������5d      �� 5e      $��81 10q�5f      $��30��5g      $	��150��5h      ��5e      �� *Ten+5h      5i      �� 5j      $��6��6   $ 
Horizontal=�5k      .+�5l      �� $��Giới tính��6   $��10q�5m      
�������5n      �� 5o      $��55 10q�5p      $��30��5q      $	��150��5r      ��5o      �� *
GioiTinh+5r      5s      �� 5t      $��7��6   $ 
Horizontal=�5u      .+�5v      �� $��
Ngày sinh��6   $��10q�5w      
�������5x      (  "System.Windows.Controls.DatePicker  5y      $��47 10q�5z      $��30��5{      $	��150��5|         SelectedDate 5y      �� *
NgaySinh+5|      5}      �� 5~      $��8��6   $ 
Horizontal=�5      .+�5�      �� $��
Quê quán��6   $��10q�5�      
�������5�      �� 5�      $��47 10q�5�      $��30��5�      $	��150��5�      ��5�      �� *	QueQuan+5�      5�      �� 5�      $��9��6   $ 
Horizontal=�5�      .+�5�      �� $��Số điện thoại��6   $��10q�5�      
�������5�      �� 5�      $��30 10q�5�      $��30��5�      $	��150��5�      ��5�      �� *SoDT+5�      5�      �� 5�      $��10��6   $ 
Horizontal=�5�      $��Center=�5�      .+�5�      �� $��Tạo tài khoản��6   $��20 10q�5�        	ButtonRed#��[ 5�      $	��100��5�      $��30��5�      
���������5�      �� *TaoTaiKhoanCommand+5�      �� 5�      $��Thoát��6   $��20 10q�5�        ButtonGreen#��[ 5�      $	��100��5�      $��30��5�      
���������5�      �� *ExitCommand+��5�      �� $ registerView��5�      5�      5�      5�      5�      