   M S B A M L   `   `   `  ���� [  WSocialMediaInformationAggregator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullS.clr-namespace:SocialMediaInformationAggregator SocialMediaInformationAggregator  0    *SocialMediaInformationAggregator.InputPage   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     @local.clr-namespace:SocialMediaInformationAggregator       N� Title$  	InputPage��.��� 
������� � ColumnDefinitions �� $��* ��� $��2* ��� $��* �.+��� $��1��$��Center=�$��Center=�.+��� $��Фамилия��$��40, 0, 0, 0q�$��10(��� -   $��LastNameComboBox�� �� 
IsEditable . $	��120��$
��12pt(�$��40, 0, 10, 10q�$
��Left=��� $��Имя��$��40, 0, 0, 0q�$��10(��� -   $��NameComboBox��$
��Left=�$	��120��$
��12pt(�$��40, 0, 10, 10q� . �� -   $��NameErrorTextBlock��$C��=Имя и Фамилия - обязательные поля.��
���  ��$	��8pt(�$y�	Collapsed=��� $��Возраст��$��30, 0, 0, 0q�$��10(���  �� Orientation$ 
Horizontal=�$��10, 0, 0, 10q�.+��� -   $��YearFromOption��$��+��$
��14pt(�$
��Bold"��� $��20, 0, 0, 0q�$
��от���� -   $��
FromYearCB��$
��10pt(�$��10, 0q� �� MaxDropDownHeight$	 200��$��80���� -   $��YearToOption��$
��14pt(�$��+��$��20, 0, 0 ,0q�$
��Bold"��� $��10, 0, 0, 0q�$
��до���� -   $��ToYearCB��$��10, 0q�$	 200��$��80��$
��10pt(��� $��
Город��$��30, 0, 0, 0q�$��10(��� $ 
Horizontal=�$��10, 0, 0, 10q�.+��� -   $��
CityOption��$
��14pt(�$
��Bold"�$��+���� -	   $��CityComboBox�� . $	��120��$
��12pt(�$��20, 0q��� $��Университет��$��30, 0, 0, 0q�$��10(��� $ 
Horizontal=�$��10, 0, 0, 10q�.+��� -
   $��UniversityOption��$
��Bold"�$
��14pt(�$��+���� -   $��UniversityComboBox�� . $	��120��$
��12pt(�$��20, 0q��� $��
Школа��$��30, 0, 0, 0q�$��10(��� $ 
Horizontal=�$��10, 0, 0, 10q�.+��� -   $��SchoolOption��$
��Bold"�$
��14pt(�$��+���� -   $��SchoolComboBox�� . $	��120��$
��12pt(�$��20, 0q��� -   $��EmptyCityErrorTextBlock��$��Center=�$g��aДля ввода университета или школы нужно указать город��$
��Wrap=�
���  ��$y�Hidden=��� -   $��
FindButton��$��
Найти��$
��10pt(�$��Bottom=�$��Center=�$��20q�$��10, 5q��� -   $��NotFoundTextBlock��$<��6Не найдено ни одного человека��
���  ��$��Center=�$��10q�$y�	Collapsed=�