   M S B A M L   `   `   `  ����H  DUserInterface, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:UserInterfaceUserInterface  5          UserInterface.Procedures   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -localclr-namespace:UserInterface     5      -   5          N� Title$  
Procedures��5	      .��5      � .+�5   
   �� .+�5      �� -   5         ��Name$ Owner��5      $	��100��6$   $
��Left=�60   $��Bottom=�6K   .��6z   
Owner Menu6�   �� 5      $
��Bold"�6   $��30(�6&   .��64   
PROCEDURES6@   &   System.Windows.Controls.DataGrid  5      -   5          Name$ PROC_DG��5      $��0,10,0,0q�6(   $	��400��6:   $	��150��6I      AutoGenerateColumns .     
IsReadOnly .    Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ ProcedureID��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6^      
FontWeight$
 Bold"�6h   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 6>   �� *ProcedureID+6h     5      $ Description��6)   $ * 6^   $
 Bold"�6h   	 6>   �� *Description+6h     5      $ Price��6)   $ * 6R   $
 Bold"�6\   	 68   �� *Price+6\   5      �� 5      $
��Bold"�6   $��30(�6&   .��64   
Treatments6@     5      -   5        $ TREAT_DG��5      $��0,10,0,0q�6)   $	��400��6;   $	��150��6J    .   .  5        5      $ PetID��6)   $ * 6T   $
 Bold"�6^   	 68   �� *	PetName+6^     5      $ Date Of Procedure��6)   $ * 6]   $
 Bold"�6g   	 6D   �� *Date+6g     5      $ Notes��6)   $ * 6R   $
 Bold"�6\   	 68   �� *Notes+6\     5      $ Price��6)   $ * 6R   $
 Bold"�6\   	 68   �� *Price+6\   5      5!      5#      5$      