   M S B A M L   `   `   `  ����H  DUserInterface, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:UserInterfaceUserInterface  5          UserInterface.Owner   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -localclr-namespace:UserInterface     5      -   5          N� Title$  Owner��5	      .��5      � .+�5   
   �� .+�5      �� $��30(�6   $
��Bold"�6"   .��64   
Clients:6>   &   System.Windows.Controls.DataGrid  5      -   5          Name$ OWNER_DG��5      $��0,10,0,0q�6)   $	��400��6;   $	��150��6J      AutoGenerateColumns .     
IsReadOnly .    Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Owner ID��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6W      
FontWeight$
 Bold"�6a   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6;   �� *	OwnerID+6a     5      $ Surname��6)   $ * 6V   $
 Bold"�6`    6:   �� *	Surname+6`     5      $ 
Given Name��6)   $ * 6[   $
 Bold"�6e    6=   �� *	GivenName+6e     5      $ Phone #��6)   $ * 6T   $
 Bold"�6^    6:   �� *Phone+6^   5      �� 5      .��6   	Surname6   �� 5      -   5        	 ��Name$	 
txtSurname��5      6,   �� 5      .��6   
Given Name6    �� 5      -   5        $	 txtGivenName��5      6.   �� 5      .��6   Phone Number6"   �� 5      -   5        $	 txtPhone��5      6*   �� 5      
 �� Orientation$
 
Horizontal=�6   $��Center=�62   .+�5      �� -   5         ��Name$ 
Create_BTN��5      $��10q�6-   $	��100��69   .��6a   Create6i   �� 5      -   5        $ 
Update_BTN��5      $��10q�6-   $	��100��69   .��6b   Update6j   �� 5      -   5        $ 
Delete_BTN��5      $��10q�6-   $	��100��69   .��6a   Delete6i   5       5!      �� 5"   
   -	   5        $ Back_BTN��5"      $��Right=�6#   $��Bottom=�6?   .��6q   Back6w   5#      5$      