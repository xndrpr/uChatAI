   M S B A M L   `   `   `  ���� B  >uChatAI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:uChatAI.ControlsuChatAI.Controls  I EGarnetControls, Version=1.1.2.0, Culture=neutral, PublicKeyToken=nullY=clr-namespace:GarnetControls.Controls;assembly=GarnetControlsGarnetControls.Controls 9!clr-namespace:uChatAI.Views.PagesuChatAI.Views.Pages  "    uChatAI.Views.Pages.MainPage   Z VDevExpress.Mvvm.UI, Version=22.1.0.0, Culture=neutral, PublicKeyToken=382ad28f6ae31f30W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35J 9http://schemas.microsoft.com/winfx/2006/xaml/presentation       R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     ^	 ZICSharpCode.AvalonEdit, Version=6.2.0.78, Culture=neutral, PublicKeyToken=9cc39be672370310>	AvaonEdit.http://icsharpcode.net/sharpdevelop/avalonedit 	 'ccclr-namespace:uChatAI.Controls 	 :d2http://schemas.microsoft.com/expression/blend/2008 	 Fgc=clr-namespace:GarnetControls.Controls;assembly=GarnetControls 	 -local!clr-namespace:uChatAI.Views.Pages 	 Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006 	   N� Title$  MainPage�� � DataContext �� *MainViewModel+   ViewModelLocator �� Source# [  .���  � RowDefinitions �� $��35 ��� $��* ��� $
��auto �$��20��$	��180��.+�� $��0��.+��� $��1��$
��Left=� �� Orientation$ 
Horizontal=�.+�$  GarnetControls.Controls.Button  $	��120��$��30��$��1q�$��
Clear Chat������ *ClearChatCommand+  $	��120��$��30��$��1q�$��Delete Chat������ *DeleteChatCommand+� $��1�� � ColumnDefinitions �� $��* �$	��400���� $��4 ��� $��0.25* �$��4��.+��� $��0��$��Stretch=�$��Stretch=�$
��Auto=�$
��Auto=�.���� ���#292E32$��0q����� *
Messages+���� .R��� ���� .R��� .+�� .+�3  -GarnetControls.Controls.SelectableListBoxItem  $��5q�$��5q�$��Stretch=�$��Stretch=�$��16(�   Radius$ 15��   Icon �� *Icon+   Text �� *Text+�� $��1��$��4��$��Stretch=����#343a40�� $��2��$��Stretch=�$��Stretch=�$
��True��$
��Auto=�$
��Auto=�.���� ���#292E32$��0q����� *Codes+���� .R��� ���� .R��� .+��� $��5q�.+��� $ 
Horizontal=�.+��� 
������ 
������ $��0q����#fff	 �� 
IsReadOnly$
	 True������ *Id+�� 
������ 
������ $��0q�$
��Bold"����#fff$
	 True������ *Title+"   uChatAI.Controls.CodePreview  
   Document
 �� *
Document+� $��2�� �� $��* ��� $
��auto �.+��� $��0��$
��auto��$
��auto��$	��180��$��0q� �� AcceptsReturn$
 True�� �� 
AcceptsTab$
 True�����#44474e���#343a40$��0q�$��18(����#fff �� TextWrapping$
 Wrap=�" �� VerticalScrollBarVisibility$
 Auto=����� *	Message+ �� UpdateSourceTrigger$ PropertyChanged=�.�� J� InputBindings ��  �� Gesture$ 
CTRL+ENTER�� �� Command �� *SendMessageCommand+.��  $��1��$	��180��$��Right=����� *SendMessageCommand+���� J 9http://schemas.microsoft.com/winfx/2006/xaml/presentation       :x,http://schemas.microsoft.com/winfx/2006/xaml     $��24��$��24��.+�F� F������ @o@���^ � р� ��- р� ��� �@f � р� ��� р� @o@	���#fff