   M S B A M L   `   `   `  ����  ToastmastersGuestBook.UI8    2ToastmastersGuestBook.UI.View.GuestDetailViewModel   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      X TXceed.Wpf.Toolkit, Version=3.4.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f47toolkit)http://schemas.xceed.com/wpf/xaml/toolkit  5      .��5	      � .+�5
   
   �   � RowDefinitions  5      �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      �� 5      $
��Auto �6    .+�5      �� $��
Guest Name��6   $��10 0 0 0q�5      �� 5      $��1��6   $��1��5      $��10 0 0 0q�5      ��5       �� *Guest.GuestName+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=��� 5#      $��2��6   $��Guest Email��5$      $��	10 25 0 0q�5%      �� 5&      $��3��6   $��1��5'      $��10 5 0 0q�5(      ��5)      �� *Guest.GuestEmail+$ TwoWay=�$ PropertyChanged=��� 5+      $��4��6   $��How you find us?��6!   $
��10 0q�6<   �� 5,      $��5��6    �� DisplayMemberPath$ DisplayGuest��5-       �� SelectedValuePath$ Id��5.      $��
10 0 10 10q�50       �� SelectedValue 5/      �� *Guest.SocialMediaId+$ TwoWay=���51      �� *SocialNetworks+]� 53      $��6��6   $��10q�6%   .+�54      �� $��Right=�6   .+�55      �� $	��Add��6   $	��125��56      $��10q�57      ��58      �� *AddGuestNumberCommand+�� 59      $��Remove��6   $	��125��5:      $��10q�5;      ��5<      �� *RemoveGuestNumberCommand+5=      &   System.Windows.Controls.DataGrid  5>         AutoGenerateColumns .     RowHeaderWidth$ 0Q�5A      ��5>      �� *GuestNumbers+ �� SelectedItem 5?      �� *SelectedPhoneNumber+$ TwoWay=�	   Columns	 5B      0  *System.Windows.Controls.DataGridTextColumn  5C         DataGridColumnStyle1  +System.Windows.Controls.DataGridBoundColumn
   ElementStyle#
 [  6-     DataGridEditingColumnStyle   EditingElementStyle# [ 5D   -   ,  &System.Windows.Controls.DataGridColumn   Header$ Phone Numbers��5E   -      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 5F   -      Binding 5G   -   �� *Number+$ TwoWay=�$ PropertyChanged=�5I      5J      ]� 5K      $��8��6   $
��10 0q�6%   .+�5L      �� $��Right=�6   .+�5M      �� $��Sign ins��6   $	��125��5N      $��10q�5O      ��5P      �� *AddGuestSigninCommand+5Q      5R      ]� 5T      $��9��6   .+�5U         .  $ 0Q�5W      "   VerticalScrollBarVisibility$
 Auto=�5X      ��5U      �� *GuestSignins+	 5Y        5Z      $ * 6-    5[   -   �� *
DateSignin+$ TwoWay=�$ PropertyChanged=�5]      5^      �� 5_      $��10��6    �� Orientation$ 
Horizontal=�6'   .+�5`      �� $
��Save��6   $	��125��5a      $��10q�5b      ��5c      �� *SaveCommand+�� 5d      $��Delete��6   $	��125��5e      $��10q�5f      ��5g      �� *DeleteCommand+5h      5i      5j      5k      