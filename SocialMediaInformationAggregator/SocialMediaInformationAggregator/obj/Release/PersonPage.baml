   M S B A M L   `   `   `  ���� [  WSocialMediaInformationAggregator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullS.clr-namespace:SocialMediaInformationAggregator SocialMediaInformationAggregator  1    +SocialMediaInformationAggregator.PersonPage   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     @local.clr-namespace:SocialMediaInformationAggregator       N� Title$  
PersonPage��.��� 
������� � ColumnDefinitions �� $��* ��� $��2* ��� $��* �.+�� $��1��$��0, 60, 0, 0q� � RowDefinitions �� $	��100 ��� $��* �.+��  �� $��* ��� $��2* � �� �� .+��� -   $��FullNameTextBlock��$��Имя Фамилия��$��1��$��Center=�$��20, 0, 0, 0q�$
��16pt(�$
��Wrap=��� -   $��YearTextBlock��$
��1998��$��1��$��1��$	��Top=�$��20, 10, 0, 0q�$
��13pt(�� $��1�� �� $
��40px ��� $
��auto ��� $
��auto ��� $
��auto ���  �� �� �� .+��� -   $��VkTextBlock��
����  �$��1��$��Center=�$��Center=�$
��12pt(��� -    �Name$ VkHyperLink��$��https://www.google.ru/?�
����  � �� TextDecorations Z� .�ВКонтакте�� -   $��OkTextBlock��$��2��$��Center=�$��Center=�$
��12pt(��� -   $ OkHyperLink��
��� E�� Z� .�Одноклассники�� -   $��EducationTextBlock��$��1��$��Образование��$��Center=�$��5q�$
��10pt(��� -   $��EducationVkStackPanel��$��Stretch=�$��1��$��1��$��5q��� -	   $��EducationOkStackPanel��$��1��$��2��$��Center=�$��5q��� -
   $��CitiesTextBlock��$��2��$'��!Города проживания��$��Center=�$��5q�$
��10pt(��� -   $��CitiesVkStackPanel��$��Center=�$��1��$��2��$��5q��� -   $��CitiesOkStackPanel��$��2��$��2��$��Center=�$��5q��� $��1��$��3��.+��� -   $��
SaveButton��$��Сохранить��$��0, 30, 0, 10q�$��Center=��� -   $��SaveTextBlock��$%��Данные сохранены��$��Center=�
���  ��$y�Hidden=�$
��Wrap=��� -   $��SaveErrorTextBlock��$9��3Данные не удалось сохранить��$��Center=�
���  ��$y�	Collapsed=�$
��Wrap=�