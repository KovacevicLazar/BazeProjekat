   M S B A M L   `   `   `  ����]  YIntervencije_VatrogasnihJedinicaUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullc6clr-namespace:Intervencije_VatrogasnihJedinicaUI.Views(Intervencije_VatrogasnihJedinicaUI.Views  5   	   L    FIntervencije_VatrogasnihJedinicaUI.Views.PromenaVSJISmeneZaRadnikaView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Hlocal6clr-namespace:Intervencije_VatrogasnihJedinicaUI.Views     5   	   $
��Bold"�5   
     � Title$4  .Promena vatrogasne jedinice i smene za radnika��5	   	   $��410.2��6@   $��433.496��6O    � 
ResizeMode$ NoResize=�6_    � WindowStartupLocation$ CenterScreen=�6u   .��5
      � .+�5   
   �� $��Premeštaj radnika:��6   $��Center=�6-   $��20(�6Q   $
��Left=�6_   $	��Top=�6z   $	��426��6�   $��0,10,0,0q�6�   �� 5   
   -   5         ��Name$ 
RadnikInfo��5      $��Center=�6$   $��16(�6H   $
��Left=�6V   $	��Top=�6q   $	��426��6�   $��0,47,0,0q�6�   $��37��6�   �� 5   
   -   5         ��Name$ VatrogasneJedinice��5      $��Center=�60    �� DisplayMemberPath$ Naziv��6R   $ �� IsSynchronizedWithCurrentItem$
 TrueY�6�   $
��Left=�6�   $��214,110,0,0q�6�   $	��Top=�6  $��28��6   $	��130��6,   J� RenderTransformOrigin$ 
0.493,0.48&�68   �� SelectedItem 6l   �� 	 �� Path$ 	 IzabranaVatrogasnaJedinica�
 �� Mode$
 TwoWay=�68  �� 5   
   $��Vatrogasna jedinica.:��6   $
��Left=�60   $��
80,110,0,0q�6K   $	��Top=�6_   $	��129��6w   $��28��6�   �� 5   
   $$��Smena........................:��6   $
��Left=�69   $��
80,168,0,0q�6T   $	��Top=�6h   $	��129��6�   $��28��6�   �� 5   
   -   5        $ Smene��5      $��Center=�6#    � ToolTip$( "Prvo izaberite Vatrogasnu jedinicu��6E   $ 
NazivSmene��6r   $
 TrueY�6�   $
��Left=�6�   $��214,168,0,0q�6  $	��Top=�6   $	��130��68  $��28��6D   6�   �� $	 IzabranaSmena�$
 TwoWay=�6D  (  "System.Windows.Controls.DatePicker  5   
      SelectedDateFormat$ Short=�6L   $
��Left=�6g   $��Center=�6�   $��214,230,0,0q�6�   $	��Top=�6�   $	��130��6�   $��28��6�      SelectedDate 6   �� *DatumPremestaja+$
 TwoWay=�6�   �� 5   
   $��Datum premeštaja...:��6   $
��Left=�6/   $��
80,230,0,0q�6J   $	��Top=�6^   $	��129��6v   $��28��6�   �� 5   
   -   5         ��Name$# PorukaGreskeZaDatumPremestaja��5      $��12(�6;   
���  ��$
��Left=�6Z   $��
22,258,0,0q�6u   $
��Wrap=�6�   $	��Top=�6�   $��64��6�   $	��380��6�   �� 5   
   -   5        $ PorukaGreskeZaVSJ��5      $��14(�6+   $��Normal"�69   
���  ��$��Center=�6^   $
��Left=�6�   $��
80,131,0,0q�6�   $	��Top=�6�   $��32��6�   $	��271��6�   �� 5   
   -   5        $ PorukaGreskeZaSmenu��5      $��14(�6-   $��Normal"�6;   
���  ��$��Center=�6`   $
��Left=�6�   $��
10,192,0,0q�6�   $	��Top=�6�   $��33��6�   $	��413��6�   �� 5   
   -   5         ��Name$ SacuvajIzmene��5      $��18(�6(   $��Sačuvaj��66   $
��Left=�6H   $��
22,327,0,0q�6c   $	��Top=�6w   $	��115��6�   $��37��6�   �� 5   
   $��Vrati se��6   $��18(�6$   $
��Left=�62   $��287,327,0,0q�6M   $	��Top=�6b   $	��115��6z    �� IsCancel . $��37��6�   5      5      