   M S B A M L   `   `   `  ����E  Abank admin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:bank_admin
bank_admin  5   	       bank_admin.bankUsers   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:bank_admin     5   	     � Title$  bankAccounts��5   	   $	��450��6   $	��800��6+   .��5	      � .+�5
   
   &   System.Windows.Controls.DataGrid  -   5          Name$ dgBankaccounts��5
         AutoGenerateColumns .  $
��Left=�6G   $   HorizontalScrollBarVisibility$ Disabled=�6b   $	��243��6�   $��0,90,-0.4,0q�6�   $	��Top=�6�   $	��794��6�      CanUserResizeRows .     CanUserAddRows .  $��2��5   H   ��5
   �   ��  �� Path$ LoadDataBinding�   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ number��6A   	   Width5  /System.Windows.Controls.DataGridLengthConverter$	 * 6Q   
   
IsReadOnly
 . 1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� $ id�6[     5      $ 	firstname��6H   $	 * 6[   
 .  6%   �� $ 	firstname�6e     5      $ lastname��6G   $	 * 6Y   
 .  6%   �� $ lastname�6c     5      $ email��6D   $	 * 6S   
 .  6%   �� $ email�6]     5      $ home adress��6J   $	 * 6_   
 .  6%   �� $ home_adress�6i     5      $ postcode��6G   $	 * 6Y   
 .  6%   �� $ postcode�6c     5      $ woonaplaats��6I   $	 * 6^   
 .  6%   �� $ 
woonplaats�6h     5      $
 date��6C   $	 * 6Q   
 .  6%   �� $
 date�6[   4  .System.Windows.Controls.DataGridTemplateColumn  5      $	 * 6)      CellTemplate 5      �� 5      .R�5      ��  ��Name$ btnUserEdit��6%   -   5        $
��Edit��5   :   6I   5      5        5      $	 * 6)    5      �� 5      .R�5      �� -   5        $��Delete��5   %   66   5       5"        5#      $	 * 6)    5$      �� 5%      .R�5&      �� $ btnAddAccount��6%   -   5        $��rekening��5&   <   6O   5'      5)      5+      �� 5,   
   -   5        $ btnRegister��5,      $��add new admin��6&   $
��Left=�6>   $��
642,25,0,0q�6Y   $	��Top=�6m   $��30��6�   $	��130��6�   6�   �� 5-   
   -   5        $ 	btnLogOut��5-      $��log out��6$   $
��Left=�66   $��683,371,0,0q�6Q   $	��Top=�6f   $��89��6~   $��30��6�   6�   �� 5.   
   -   5        $ add_user��5.      $��add user��6#   $
��Left=�66   $��
22,371,0,0q�6Q   $	��Top=�6e   $��81��6}   $��30��6�   6�   �� 5/   
   -   5         ��Name$ 	txbSearch��5/      $
��Left=�6%   $��23��6@   $��	22,32,0,0q�6L    �� TextWrapping$
 Wrap=�6_   $	��Top=�6s   $	��120��6�   �� 50   
   $��(Achter) Naam��6   $
��Left=�6(   $��
148,32,0,0q�6C   $	��Top=�6W   �� 51   
   -	   5        $ btnSearchUser��51      $��zoeken��6(   $
��Left=�69   $��
491,25,0,0q�6T   $	��Top=�6h   $��86��6�   $��30��6�   6�   �� 52   
   -
   5        $ btnShowAllAccounts��52      $��Alle Rekeningen��6-   $
��Left=�6G   $��325,371,0,0q�6b   $	��Top=�6w   $	��103��6�   $��30��6�   6�   �� 53   
   -   5        $ txbSearchAdress��53      $
��Left=�6+   $��23��6F   $��
257,32,0,0q�6R   $
 Wrap=�6f   $	��Top=�6z   $	��120��6�   �� 54   
   $��huis adress��6   $
��Left=�6&   $��
401,32,0,0q�6A   $	��Top=�6U   55      56      