   M S B A M L   `   `   `  ����G  Cgeldautomaat, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:geldautomaatgeldautomaat  5   	       geldautomaat.dashboard   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:geldautomaat     5   	     � Title$  	dashboard��5   	   $	��450��6   $	��800��6(   .��5	      � .+�5
   
   �� -   5         ��Name$ lblSaldo��5
      $
��0,00��6"   $
��Left=�61   $��
679,33,0,0q�6L   $	��Top=�6`   $��22(�6x   $
��Bold"�6�   �� 5   
   -   5         ��Name$ btnBack��5      $��Cancel��6"   $
��Left=�63   $	��Top=�6N   $	��103��6f   $��
10,368,0,0q�6r   $��42��6�   6�   �� 5   
   -   5        $ btnTakeMoney��5      $��geld opnemen��6'   $
��Left=�6>   $	��Top=�6Y   $	��103��6q   $��114,102,0,0q�6}   $��42��6�   6�   �� 5   
   -   5        $ btnGiveMoney��5      $��geld storten��6'   $
��Left=�6>   $	��Top=�6Y   $	��103��6q   $��114,169,0,0q�6}   $��42��6�   6�   �� 5   
   $��uw saldo is €��6   $
��Left=�6(   $��
509,33,0,0q�6C   $	��Top=�6W   $��22(�6o   $
��Bold"�6}   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dgTransactions��5         AutoGenerateColumns .  $
��Left=�6G   $   HorizontalScrollBarVisibility$ Disabled=�6b   $	��170��5      $	��Top=�6$   $	��368��6<      CanUserResizeRows .     CanUserAddRows .  $��348,151,0,0q�5   H   ��5   H   ��  �� Path$ LoadDataBinding�	   Columns	 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn
   Header$
 
transactie��6E      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6Y      
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� $ amount�6c     5      $
 datum��6C   $ * 6R    .  6%   �� $
 date�6\   5      �� 5   
   $��Uw laatste 3 transacties��6   $
��Left=�63   $��
348,97,0,0q�6N   $	��Top=�6b   $��14(�6z   5      5      