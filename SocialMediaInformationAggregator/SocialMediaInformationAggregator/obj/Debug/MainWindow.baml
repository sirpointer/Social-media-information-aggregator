   M S B A M L   `   `   `  ����[  WSocialMediaInformationAggregator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullS.clr-namespace:SocialMediaInformationAggregator SocialMediaInformationAggregator  5   	   1    +SocialMediaInformationAggregator.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   @local.clr-namespace:SocialMediaInformationAggregator     5   	     � Title$  
MainWindow��5   	   $	��800��6   $
��1000��6)   $	��800��66   $
��1000��6F   .��5	      � ���	#FF4A76A8 � RowDefinitions 5
   
   �� 5      $
��40px �6   �� 5      .+�5   
   �� -   5        $��
BackButton��5      ���#4872a3$	��2pxq�5      ���	#FF4A76A8
�������$	����5      $��Segoe MDL2 Assets)�5      $
��Left=�5      $��Center=�5      $��5q�5      $��5q�5      $
��Bold"�5      $
��12pt(�5      �� 5   
   -   5        $��LoginAndHistorySP��5   z    �� Orientation$ 
Horizontal=�6   $��Right=�6.   $��Center=�6J   $��0, 0, 10, 0q�6e   .+�5       �� -   5        $��HistoryButton��5#      ���#4872a3$	��2pxq�5"      $��История��5$      $��0, 0, 40, 0q�5%      ���	#FF4A76A8
�������$
��Bold"�5)      $
��12pt(�5*      �� 5,      -   5        $��LoginTextBlock��5/      $��15, 5q�5-      $$��Неавторизирован��5.      ���	#FF4A76A8
�������$
��12pt(�52      �� 53      -   5        $��LoginButton��54      $��
Войти��56      ���	#FF4A76A8
�������$
��Bold"�59      $
��12pt(�5:      ���#4872a3$	��2pxq�5<      �� 5=      -   5        $��LogoutButton��5>      $��
Выйти��5@      $y�	Collapsed=�5A      ���	#FF4A76A8
�������$
��Bold"�5D      $
��12pt(�5E      ���#4872a3$	��2pxq�5G      5H       � 5K   
   -   5        $��
PagesFrame��5K   H   
�������$��1��6#     � Source$ InputPage.xaml?�60     � NavigationUIVisibility$ Hidden=�6Z   5M      5N      5O      