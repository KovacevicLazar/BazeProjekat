   M S B A M L   `   `   `  ����&  "Intervencije_VatrogasnihJedinicaUI9    3Intervencije_VatrogasnihJedinicaUI.Views.VozilaView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    6L   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     6�   @d2http://schemas.microsoft.com/expression/blend/2008     6�   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     6  $
��Bold"�6Z  .��5      � $
��1259��6   $	��675��6   ���	#FFF9F7F6.+�5   
   &   System.Windows.Controls.DataGrid      AlternatingRowBackground  �	#FFD8D6D6$��12(�69      AutoGenerateColumns .     
IsReadOnly . $
��Left=�6�   $	��575��6�   $��	93,69,0,0q�6	  $	��Top=�6  $	��885��64  ��6c   �� *	SvaVozila+ �� Mode$ OneWay=� �� SelectedItem 6�   �� *OznacenoVozilo+$ OneWayToSource=� � 	Resources 5       �� Color��%T   (��       5   "   * SystemColors.HighlightBrushKey+)�� 6   $ #9C918E��6T   5         Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$	 ID:��6<   	   Width5  /System.Windows.Controls.DataGridLengthConverter$	 70 6I   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 6%   �� *ID+6I     5	      $ Registarska 
oznaka: ��6K   $		 120 6n   
 6%   �� *RegistarskaOznaka+6n     5
      $ Marka:��6?   $		 130 6O   
 6%   �� *Marka+6O     5      $ Model:��6?   $		 120 6O   
 6%   �� *Model+6O     5      $ 
Godište: ��6A   $	 90 6T   
 6%   �� *	Godiste+6T     5      $ Tip 
Vozila: ��6=   $		 120 6X   
 6%   �� *Tip+6X     5      $ Vatrogasna 
jedinica: ��6R   $		 250 6v   
 6%   �� *VatrogasnaJedinica.Naziv+6v   5      �� 5   
   $��Vozila:��6   $��28(�6"   $��Center=�60   $
��Left=�6T   $	��Top=�6o   $
��1259��6�   $��54��6�   $��0,10,0,0q�6�   �� 5   
   -   5         ��Name$ Obrisi��5      $��Obriši��6!   $
��Left=�62   $��
998,69,0,0q�6M   $	��Top=�6a   $	��180��6y   $��35��6�   �� 5   
   -   5        $ Izmeni��5      $��Izmeni��6!   $
��Left=�62   $��998,114,0,0q�6M   $	��Top=�6b   $	��180��6z   $��35��6�   �� 5   
   -   5        $ Dodaj��5      $��Dodaj��6    $
��Left=�60   $��998,160,0,0q�6K   $	��Top=�6`   $	��180��6x   $��36��6�   �� 5   
   -   5         ��Name$ Poruka��5      $��14(�6$   
���  ��$
��Left=�6C   $��998,196,0,0q�6^   $
��Wrap=�6s   $	��Top=�6�   $	��218��6�   $	��180��6�   5      5      