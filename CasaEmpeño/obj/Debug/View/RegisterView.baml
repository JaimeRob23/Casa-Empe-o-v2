   M S B A M L   `   `   `  ����F  BCasaEmpeño, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:CasaEmpeño.CustomControlsCasaEmpeño.CustomControls  5   	   #    CasaEmpeño.View.RegisterView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   CCustomControls(clr-namespace:CasaEmpeño.CustomControls     5   	     � Title$  Registro de Usuario��5   	   $	��700��6%   $	��400��62    � WindowStyle$
 None=�5	   	    � WindowStartupLocation$ CenterScreen=�5
   	   
������  � AllowsTransparency . .��5      ��  �� CornerRadius$ 12��6   $��2q�6    J� Opacity$
 0.95Q�63   ��5   
   �� 5       �� 
StartPoint$	 0,0&�6"    �� EndPoint$	 1,1&�63   .��5      �  � Color$ White��6   	 � Offset$		 0.2Q�6-   5      ._�5   
   � 
 � RowDefinitions
 5      �� 5      $��30 �6    �� 5      .+�5      � $��0��6    � ColumnDefinitions 5      �� 5      �� 5      $��25 �6'   �� 5       $��25 �6'   �� 5!      $��5 �6'   .+�5#      �� $��Registro��6   
���   �$��15(�5%      $��
Montserrat)�5&      $��0��5'      $��Center=�5(      $��10,0,0,0q�5)      �� 5+      -   5         ��Name$ btnMinimizar��5+      $��-��5,      
�������$��16(�5.      $��
Montserrat)�5/       � Cursor$
 Hand��50      $��1��51      ��53      �� 54       �� 
TargetType" ��6    .�55      ��  �� Property � �� �� Value
 �   �6;    �� Triggers 56      P� 57   "    P� Property �@J�IsMouseOver P� Value . . �58   &   ��  � ��
 � ���6C   59   #   5;      ��5=      �� 5>       �� 
TargetType" ��6*   .R�5?      �� $��18��6%   $��18��60   $ 9��6<   #��z��6M   ._�5@   "   �� $��Center=�63   $��Center=�6N   5A      5B      5D      �� 5F      -   5        $ 	btnCerrar��5F      $��X��5G      
�������$��16(�5I      $��
Montserrat)�5J      $
 Hand��5K      $��2��5L      ��5N      �� 5O      " ��6    .�5P      ��  � ��
 �   �6;    5Q      P� 5R   "    �@J�IsMouseOver . . �5S   &   ��  � ��
 �  ��6C   5T   #   5V      ��5X      �� 5Y      " ��6*   .R�5Z      �� $��18��6%   $��18��60   $ 9��6<   #��z��6M   ._�5[   "   �� $��Center=�63   $��Center=�6N   5\      5]      5_      5`      �� 5c      $��1��6   $	��300��6&   $��Center=�62   $��Center=�6O   $��	0,20,0,20q�6j   .+�5d      �� $'��!/Images/lgoCasaEmpenoSinFondo.png��6   $	��100��6C   $	��100��6O   $��Center=�6\   $��0,0,0,20q�6y   �� 5f      $��Nombre de Usuario��6   $��0,5,0,0q�65   $��
Montserrat)�6F   $��12(�6^   �� 5g      $��0,5,0,10q�64   $��28��6F   $��
Montserrat)�6R   ��6   �� *
Username+6R   �� 5i      $��Contraseña��6   $��0,5,0,0q�6.   $��
Montserrat)�6?   $��12(�6W   4   .CasaEmpeño.CustomControls.BindablePasswordBox  5j      $��0,5,0,10q�6�   $��28��6�      Password 65   �� *
Password+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�6�   �� 5l      $��Nombre��6   $��0,5,0,0q�6*   $��
Montserrat)�6;   $��12(�6S   �� 5m      $��0,5,0,10q�60   $��28��6B   $��
Montserrat)�6N   ��6   �� *Name+6N   �� 5o      $��Apellido��6   $��0,5,0,0q�6,   $��
Montserrat)�6=   $��12(�6U   �� 5p      $��0,5,0,10q�64   $��28��6F   $��
Montserrat)�6R   ��6   �� *
LastName+6R   �� 5r      $��Correo Electrónico��6   $��0,5,0,0q�66   $��
Montserrat)�6G   $��12(�6_   �� 5s      $��0,5,0,20q�61   $��28��6C   $��
Montserrat)�6O   ��6   �� *Email+6O   �� 5u      $��Registrarse��6   ���	#FF3F5093
�������$��
Montserrat)�5y      $��35��5z      $��0,10,0,0q�5{      $
 Hand��5|      ��5v      �� *RegisterCommand+5|      �� 5~      
���  ��$��0,10,0,0q�6K   $
��Wrap=�6]   $��Center=�6q   ��6   �� *ErrorMessage+6q   5      5�      5�      5�      