   M S B A M L   `   `   `  ����B  >uChatAI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:uChatAI.ControlsuChatAI.Controls  5      I EGarnetControls, Version=1.1.2.0, Culture=neutral, PublicKeyToken=nullY=clr-namespace:GarnetControls.Controls;assembly=GarnetControlsGarnetControls.Controls 5      9!clr-namespace:uChatAI.Views.PagesuChatAI.Views.Pages  5	      "    uChatAI.Views.Pages.MainPage   5      Z VDevExpress.Mvvm.UI, Version=22.1.0.0, Culture=neutral, PublicKeyToken=382ad28f6ae31f30W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35J 9http://schemas.microsoft.com/winfx/2006/xaml/presentation       5      R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      ^	 ZICSharpCode.AvalonEdit, Version=6.2.0.78, Culture=neutral, PublicKeyToken=9cc39be672370310>	AvaonEdit.http://icsharpcode.net/sharpdevelop/avalonedit 	 5      'ccclr-namespace:uChatAI.Controls 	 5      :d2http://schemas.microsoft.com/expression/blend/2008 	 5      Fgc=clr-namespace:GarnetControls.Controls;assembly=GarnetControls 	 5      -local!clr-namespace:uChatAI.Views.Pages 	 5	      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006 	 5
      _
 [MaterialDesignThemes.Wpf, Version=4.8.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962a:md1http://materialdesigninxaml.net/winfx/xaml/themes 
 5        N� Title$  MainPage��5       � DataContext 5      �� *MainViewModel+   ViewModelLocator �� Source# [  .��5      �  � RowDefinitions 5   
   �� 5      $��35 �6   �� 5      $��* �6   �� 5      $
��auto �5      $��20��5      $	��180��5      .+�5   
   � $��0��6   .+�5      �� $��1��5      $
��Left=�5       �� Orientation$ 
Horizontal=�5       .+�5!      $  GarnetControls.Controls.Button  $	��120��5"      $��30��5#      $��1q�5$      $��
Clear Chat��5&      ��5%      �� *ClearChatCommand+5&        5'      $	��120��5(      $��30��5)      $��1q�5*      $��Delete Chat��5,      ��5+      �� *DeleteChatCommand+5,      5-      �� 5.      $��1��5/      $��Right=�50      $ 
Horizontal=�51      .+�52        $��30��53      $��1q�54      ��55      �� *SettingsCommand+��56      ' 
 !MaterialDesignThemes.Wpf.PackIcon  57         Kind$ Settings=�6&   59      5:      5;      � 5=   
   $��1��6    � ColumnDefinitions 5>      �� 5?      $��* �6#   $	��400��6-   �� 5@      $��4 �6#   �� 5A      $��0.25* �6#   $��4��61   .+�5D      �� -   5        $��0��5E      $��Stretch=�5F      $��Stretch=�5G       J� 	AllowDrop$
 True��5H      $
��Auto=�5J      $
��Auto=�5K      .��5L      �� ���#292E32$��0q�5N      ��5O      �� *
Messages+ �� UpdateSourceTrigger$ PropertyChanged=���5P      �� 5Q      .R�5R      �� 5S      ��5V      �� 5W      .R�5X      �� .+�5Y   "   �  5Z   &   �� 5[   *   $��Auto  �68   �� 5\   *   $
��Auto �68   .+�5^   &   �� $ 
Horizontal=�61   .+�5_   *   3  -GarnetControls.Controls.SelectableListBoxItem  $
��Auto��5`   -   $��5,5,0,5q�5a   -   $��5q�5b   -   $��16(�5c   -   	   Radius$	 15��5e   -   
   Icon
 5d   -   �� *Icon+   Text 5f   -   �� *Text+  5g   *   $��40��5h   -   $��0,22,0,0q�5i   -   ���#fff$ 	Translate=�5k   -   y�5l   -   �� *TranslationVisibility+5m   '   �� 5n   &   $��1��5o   )   $ 
Horizontal=�5p   )   y�5q   )   �� *SubMessageVisibility+.+�5r   *     $��40��5s   -   ���#fff$
 User=�5u   -   �� 5v   *   $��5,0,0,0q�5w   -   $��Stretch=�5x   -   $��Stretch=�5y   -   $��0q�5z   -   $��12(�5{   -   ���#fff �� 
IsReadOnly$
 True��5}   -   ��5~   -   �� *UserSubMessage+5   '   5�   #   5�      5�      5�      5�      �� 5�      $��1��5�      $��4��5�      $��Stretch=�5�      ���#343a405�      �� 5�      $��2��5�      $��Stretch=�5�      $��Stretch=�5�      $
��True��5�      $
��Auto=�5�      $
��Auto=�5�      .��5�      �� ���#292E32$��0q�5�      ��5�      �� *Codes+��5�      �� 5�      .R�5�      �� 5�      ��5�      �� 5�      .R�5�      �� .+�5�   "   �� $��5q�6-   .+�5�   &   �� $ 
Horizontal=�61   .+�5�   *   �� 
������ 
������ $��0q�5�   -   ���#fff$
 True��5�   -   ��5�   -   �� *Id+�� 5�   *   
������ 
������ $��0q�5�   -   $
��Bold"�5�   -   ���#fff$
 True��5�   -   ��5�   -   �� *Title+5�   '   "   uChatAI.Controls.CodePreview  5�   &      Document 65   �� *
Document+5�   #   5�      5�      5�      5�      5�      � 5�   
   $��2��6    5�      �� 5�      $
��auto �6#   �� 5�      $��* �6#   �� 5�      $
��auto �6#   .+�5�        $��0��5�      $	��180��5�      $��Right=�5�      ��5�      �� *
OcrCommand+��5�        5�      $ FileTextAdd=�6"   5�      �� 5�      $��1��5�      $
��auto��5�      $
��auto��5�      $	��180��5�      $��0q�5�       �� AcceptsReturn$
 True��5�       �� 
AcceptsTab$
 True��5�      ���#44474e���#343a40$��0q�5�      $��18(�5�      ���#fff �� TextWrapping$
 Wrap=�5�      " �� VerticalScrollBarVisibility$
 Auto=�5�      ��5�      �� *	Message+$ PropertyChanged=�.��5�   4    J� InputBindings 5�      �� 5�       �� Gesture$ 
CTRL+ENTER��6H    �� Command 6!   �� *SendMessageCommand+6H   .��5�   )   5�        5�      $��2��5�      $	��180��5�      $��Right=�5�      ��5�      �� *SendMessageCommand+��5�      �� 5�      J 9http://schemas.microsoft.com/winfx/2006/xaml/presentation       5�      :x,http://schemas.microsoft.com/winfx/2006/xaml     5�      $��24��5�      $��24��5�      .+�5�      F� F������ @o@���^ � р� ��- р� ��� �@f � р� ��� р� @o@	���#fff6H   5�      5�      5�      5�      5�      