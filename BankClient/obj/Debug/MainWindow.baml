   M S B A M L   `   `   `  ����E  ABankClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:BankClient
BankClient  5   	       BankClient.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:BankClient     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      � .+�5
   
   � -   5         �Name$ 	gridLogin��5
      $
��Left=�6"   $	��400��6=   $��10,10,-0.4,0q�6J   $	��Top=�6`   $	��784��6x   $y�Hidden=�6�   .+�5      �� $��Numer konta:��6   $
��Left=�6+   $��247,172,0,0q�6F   $	��Top=�6[   �� 5      $
��Pin:��6   $
��Left=�6#   $��247,203,0,0q�6>   $	��Top=�6S   �� 5      -   5         ��Name$ textboxAccountNumber��5      $
��Left=�64   $��23��6O   $��355,176,0,0q�6[    �� TextWrapping$
 Wrap=�6p   $	��Top=�6�   $	��120��6�   �� 5      -   5         ��Name$ labelLoginError��5      $��Label��6-   $
��Left=�6=   $��355,235,0,0q�6X   $	��Top=�6m   �� 5      -   5         ��Name$ buttonLogin��5      $��Zaloguj��6*   $
��Left=�6<   $��380,266,0,0q�6W   $	��Top=�6l   $��75��6�   6�   G� 5      -   5         G�Name$ 
textboxPin��5      $
��Left=�6.   $��355,211,0,0q�6I   $	��Top=�6^   $	��120��6v   5      � 5   
   -   5        $ gridClientPanel��5      $
��Left=�6(   $	��400��6C   $��	10,10,0,0q�6P   $	��Top=�6c   $	��774��6{   $y�Visible=�6�   .+�5      �� $��Stan konta: ��6   $
��Left=�6+   $��	66,49,0,0q�6F   $	��Top=�6Y   �� 5      -   5        $ labelAccountBalance��5      $��Label��61   $
��Left=�6A   $��
143,49,0,0q�6\   $	��Top=�6p   �� 5      $��Kwota:��6   $
��Left=�6%   $��208,165,0,0q�6@   $	��Top=�6U   �� 5      $��Numer konta: ��6   $
��Left=�6,   $��208,196,0,0q�6G   $	��Top=�6\   �� 5      -   5        $ textboxAmount��5      $
��Left=�6-   $��23��6H   $��313,169,0,0q�6T   $
 Wrap=�6i   $	��Top=�6}   $	��120��6�   �� 5      -	   5        $ textboxTargetNumber��5      $
��Left=�63   $��23��6N   $��313,200,0,0q�6Z   $
 Wrap=�6o   $	��Top=�6�   $	��120��6�   �� 5      -
   5        $ buttonRefresh��5      $��	Odśwież��6,   $
��Left=�6>   $��164,258,0,0q�6Y   $	��Top=�6n   $��94��6�   $��56��6�   �� 5      -   5        $ buttonDeposit��5      $��Wpłać pieniądze��6,   $
��Left=�6F   $��263,258,0,0q�6a   $	��Top=�6v   $��94��6�   $��56��6�   �� 5      -   5        $ buttonWithdraw��5      $��Wypłać pieniądze��6-   $
��Left=�6H   $��362,258,0,0q�6c   $	��Top=�6x   $	��100��6�   $��56��6�   �� 5      -   5        $ buttonTransfer��5      $��Wykonaj przelew��6-   $
��Left=�6G   $��467,258,0,0q�6b   $	��Top=�6w   $��94��6�   $��56��6�   �� 5      -   5        $ buttonLogout��5      $��Wyloguj��6+   $
��Left=�6=   $��644,169,0,0q�6X   $	��Top=�6m   $��75��6�   6�   �� 5      -   5        $ labelClientError��5      $��Label��6.   $
��Left=�6>   $��490,205,0,0q�6Y   $	��Top=�6n   �� 5      -   5        $ labelCurrency��5      $��Label��6+   $
��Left=�6;   $��
143,75,0,0q�6V   $	��Top=�6j   5       5"      5#      