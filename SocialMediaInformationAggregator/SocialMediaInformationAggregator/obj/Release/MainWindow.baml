   M S B A M L   `   `   `  ���� [  WSocialMediaInformationAggregator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullS.clr-namespace:SocialMediaInformationAggregator SocialMediaInformationAggregator  1    +SocialMediaInformationAggregator.MainWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @local.clr-namespace:SocialMediaInformationAggregator       � Title$  
MainWindow��$	��800��$
��1000��$	��800��$
��1000��.��� ���	#FF4A76A8 � RowDefinitions �� $
��40px ��� .+��� -   $��
BackButton�����#4872a3$	��2pxq����	#FF4A76A8
�������$	����$��Segoe MDL2 Assets)�$
��Left=�$��Center=�$��5q�$��5q�$
��Bold"�$
��12pt(��� -   $��LoginAndHistorySP�� �� Orientation$ 
Horizontal=�$��Right=�$��Center=�$��0, 0, 10, 0q�.+��� -   $��HistoryButton�����#4872a3$	��2pxq�$��История��$��0, 0, 40, 0q����	#FF4A76A8
�������$
��Bold"�$
��12pt(��� -   $��LoginTextBlock��$��15, 5q�$$��Неавторизирован�����	#FF4A76A8
�������$
��12pt(��� -   $��LoginButton��$��
Войти�����	#FF4A76A8
�������$
��Bold"�$
��12pt(����#4872a3$	��2pxq��� -   $��LogoutButton��$��
Выйти��$y�	Collapsed=����	#FF4A76A8
�������$
��Bold"�$
��12pt(����#4872a3$	��2pxq� � -   $��
PagesFrame��
�������$��1��  � Source$ InputPage.xaml?�  � NavigationUIVisibility$ Hidden=�