   M S B A M L   `   `   `  ����[  WSocialMediaInformationAggregator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullS.clr-namespace:SocialMediaInformationAggregator SocialMediaInformationAggregator  5      1    +SocialMediaInformationAggregator.PersonPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      @local.clr-namespace:SocialMediaInformationAggregator     5        N� Title$  
PersonPage��5	      .��5      � 
������� � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��2* �6   �� 5      $��* �6   .+�5   
   � $��1��6   $��0, 60, 0, 0q�6    � RowDefinitions 5      �� 5      $	��100 �6    �� 5      $��* �6    .+�5      �  5      �� 5      $��* �6'   �� 5      $��2* �6'    5      �� 5      �� 5       .+�5%      �� -   5        $��FullNameTextBlock��5%      $��Имя Фамилия��65   $��1��6H   $��Center=�6X   $��20, 0, 0, 0q�6s   $
��16pt(�6�   $
��Wrap=�6�   �� 5&      -   5        $��YearTextBlock��5&      $
��1998��61   $��1��6=   $��1��6M   $	��Top=�6Z   $��20, 10, 0, 0q�6r   $
��13pt(�6�   5(      � 5*      $��1��6    5+      �� 5,      $
��40px �6$   �� 5-      $
��auto �6$   �� 5.      $
��auto �6$   �� 5/      $
��auto �6$   �� 50       53      �� 54      �� 55      �� 56      .+�5:      �� -   5        $��VkTextBlock��5:      
����  �$��1��6A   $��Center=�6Q   $��Center=�6l   $
��12pt(�6�   �� 5;      -   5         �Name$ VkHyperLink��5;   E   $��https://www.google.ru/?�6    
����  � �� TextDecorations 6X   Z� .�6�   ВКонтакте6�   5<      �� 5=      -   5        $��OkTextBlock��5=      $��2��6/   $��Center=�6?   $��Center=�6Z   $
��12pt(�6w   �� 5>      -   5        $ OkHyperLink��5>       
��� E�� 63   Z� .�6�   Одноклассники6�   5?      �� 5B      -   5        $��EducationTextBlock��5B      $��1��66   $��Образование��6C   $��Center=�6V   $��5q�6s   $
��10pt(�6~   �� 5D      -   5        $��EducationVkStackPanel��5E      $��Stretch=�5F      $��1��5G      $��1��5H      $��5q�5I      5K      �� 5M      -	   5        $��EducationOkStackPanel��5N      $��1��5O      $��2��5P      $��Center=�5Q      $��5q�5R      5T      �� 5W      -
   5        $��CitiesTextBlock��5W      $��2��63   $'��!Города проживания��6@   $��Center=�6Y   $��5q�6v   $
��10pt(�6�   �� 5Y      -   5        $��CitiesVkStackPanel��5Y      $��Center=�67   $��1��6T   $��2��6d   $��5q�6q   5[      �� 5]      -   5        $��CitiesOkStackPanel��5]      $��2��67   $��2��6D   $��Center=�6T   $��5q�6q   5_      �� 5a      $��1��6   $��3��6-   .+�5b      �� -   5        $��
SaveButton��5b      $��Сохранить��6/   $��0, 30, 0, 10q�6C   $��Center=�6Y   6v   �� 5c      -   5        $��SaveTextBlock��5d      $%��Данные сохранены��5e      $��Center=�5f      
���  ��$y�Hidden=�5h      $
��Wrap=�5i      �� 5j      -   5        $��SaveErrorTextBlock��5k      $9��3Данные не удалось сохранить��5l      $��Center=�5m      
���  ��$y�	Collapsed=�5o      $
��Wrap=�5p      5q      5t      5u      5v      5w      