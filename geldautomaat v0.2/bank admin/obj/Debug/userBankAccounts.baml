   M S B A M L   `   `   `  ����E  Abank admin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:bank_admin
bank_admin  5   	   !    bank_admin.userBankAccounts   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:bank_admin     5   	     � Title$  bankAccounts��5   	   $	��450��6   $	��800��6+   .��5	      � .+�5
   
   &   System.Windows.Controls.DataGrid  -   5          Name$ dgUserBankAccounts��5
         AutoGenerateColumns .  $
��Left=�6K   $   HorizontalScrollBarVisibility$ Disabled=�6f   $	��243��6�   $��0,90,-0.4,0q�6�   $	��Top=�6�   $	��794��6�      CanUserResizeRows .     CanUserAddRows .  $��2��5   H   ��5
   �   ��  �� Path$ LoadDataBinding�   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ id��6A   	   Width5  /System.Windows.Controls.DataGridLengthConverter$	 * 6M   
   
IsReadOnly
 . 1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� $ id�6W     5      $ number��6E   $	 * 6U   
 .  6%   �� $ number�6_     5      $ saldo��6D   $	 * 6S   
 .  6%   �� $ saldo�6]     5      $ datum��6C   $	 * 6R   
 .  6%   �� $
 date�6\     5      $ blocked��6F   $	 * 6W   
 .  6%   �� $ blocked�6a   4  .System.Windows.Controls.DataGridTemplateColumn  5      $	 * 6)      CellTemplate 5      �� 5      .R�5      �� -   5        $��Delete��5   %   66   5      5      5      �� 5   
   -   5         ��Name$ btnBack��5      $��cancel��6"   $
��Left=�63   $��
10,373,0,0q�6N   $	��Top=�6b   $��99��6z   $��37��6�   6�   �� 5   
   -   5        $ btnAddAccount��5      $��add bank account��6(   $
��Left=�6C   $��665,373,0,0q�6^   $	��Top=�6s   $	��119��6�   $��37��6�   6�   �� 5   
   -   5         ��Name$ txbSort��5      $
��Left=�6#   $��23��6>   $��
207,29,0,0q�6J    �� TextWrapping$
 Wrap=�6^   $	��Top=�6r   $	��146��6�   �� 5   
   -   5        $ btnSortAccounts��5      $��sorteren��6*   $
��Left=�6=   $��
414,29,0,0q�6X   $	��Top=�6l   $��86��6�   $��37��6�   6�   5      5       