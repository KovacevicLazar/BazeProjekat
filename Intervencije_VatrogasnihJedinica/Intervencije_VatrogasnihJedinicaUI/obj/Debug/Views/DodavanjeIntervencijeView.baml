   M S B A M L   `   `   `  ����]  YIntervencije_VatrogasnihJedinicaUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulle7clr-namespace:Intervencije_VatrogasnihJedinicaUI.Models)Intervencije_VatrogasnihJedinicaUI.Models  5   h  H    BIntervencije_VatrogasnihJedinicaUI.Views.DodavanjeIntervencijeView   6	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    ^ ZCaliburn.Micro.Platform, Version=3.2.0.0, Culture=neutral, PublicKeyToken=8e5891231f2ed21f(calhttp://www.caliburnproject.org  6K   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     6v   @d2http://schemas.microsoft.com/expression/blend/2008     6�   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     6�   X TXceed.Wpf.Toolkit, Version=4.0.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  61  Dmodels7clr-namespace:Intervencije_VatrogasnihJedinicaUI.Models  6h  $
��Bold"�6    � WindowStartupLocation$  CenterScreen=�6   � 
ResizeMode$ NoResize=�6D   � Title$' !Dodavanje ili izmena intervencije��6Z  $��594.587��6�  $��1210.474��6�   � 	Resources 5      I  CIntervencije_VatrogasnihJedinicaUI.Models.SadrzajDugmetaDodajIzmeni   SadrzajDugmetaDodajIzmeniI   CIntervencije_VatrogasnihJedinicaUI.Models.NullToIsReadOnlyConverter  NullToIsReadOnlyConverter��%:   &	        &	        5   
   6+     5   
   6+   5      .��5      � .+�5   
   �� $!��Informacije o intervenciji:��6   $��Center=�66   $��20(�6Z   $
��Left=�6h   $	��Top=�6�   $
��1227��6�   $��0,10,0,0q�6�   �� 5   
   $��Adresa:��6   $
��Left=�6"   $��
71,239,0,0q�6=   $	��Top=�6Q   $	��109��6i   �� 5	   
   $��	Opština:��6   $
��Left=�6#   $��
71,179,0,0q�6>   $	��Top=�6R   $	��104��6j   �� 5
   
   $��Datum:��6   $
��Left=�6!   $��
71,299,0,0q�6<   $	��Top=�6P   $	��109��6h   $��28��6t   �� 5   
   -   5         ��Name$ Adresa��5      $��Center=�6"   $
��Left=�6D   $��26��6_   $��180,239,0,0q�6k    �� TextWrapping$
 Wrap=�6�   $�� ��6�   $	��Top=�6�   $	��154��6�   �� 5   
   -   5         ��Name$ Opstine��5      $��Center=�6Z    �� DisplayMemberPath$ NazivOpstine��6|   $
��Left=�6�   $��180,179,0,0q�6�   $	��Top=�6�   $	��154��6�   $��26��6�    �� SelectedItem 6$   �� *IzabranaOpstina+	 �� Mode$	 TwoWay=�6�   (  "System.Windows.Controls.DatePicker  5   
   
   SelectedDateFormat$
 Short=�6A   $
��Left=�6\   $��Center=�6w   $��180,299,0,0q�6�   $	��Top=�6�   $	��154��6�   $��28��6�      SelectedDate 6   �� *Datum+$	 TwoWay=�6�   �� 5   
   $��Vreme:��6   $
��Left=�6!   $��
71,361,0,0q�6<   $	��Top=�6P   $	��104��6h   $��28��6t   �� 5   
   $��:��6   $��23(�6   $
��Left=�6*   $	��Top=�6E   $��23��6]   $��35��6h   $��247,354,0,0q�6t   %  Xceed.Wpf.Toolkit.IntegerUpDown  5   
   -   5          Name$
 Sati��5      $��Center=�6O   �  �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.Int32, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]   Minimum$ 0X�6q      Maximum$ 23X�6}   $
��Left=�6�   $��191,361,0,0q�6�   $	��Top=�6�   $��28��6�   $��46��6�      Value 6+   �� *Sati+$	 TwoWay=�6�     5   
   -   5        $ Minuti��5      $��Center=�6-   $ 0X�6u   $ 59X�6�   $
��Left=�6�   $��275,361,0,0q�6�   $	��Top=�6�   $��28��6�   $��46��6�    6O   �� *Minuti+$	 TwoWay=�6�   �� 5   
   -   5        $ TipoviIntervencije��5      $��Center=�6�   $
��Left=�6�   $��180,118,0,0q�6  $	��Top=�6  $	��154��6.  $��26��6:  {�6/   �� *Intervencija+ �� 	Converter# [  6�   ��  �� Path$ TipIntervencije�$	 TwoWay=�6:  �� 5   
   $��Tip intervencije: ��6   $
��Left=�6-   $��
71,118,0,0q�6H   $	��Top=�6\   $	��104��6t   �� 5   
   -   5         ��Name$ DodajIzmeni��5      $
��Left=�6}   $��
29,497,0,0q�6�   $	��Top=�6�   $	��114��6�   $��38��6�   ��6&   �� *Intervencija+# [  6�   �� 5   
   $��Vrati se��6   $
��Left=�6$   $��1051,497,0,0q�6?   $	��Top=�6U    �� IsCancel . $	��115��6}   $��38��6�   �� 5   
   -   5         ��Name$ PorukaGreskeZaOpstinu��5      $��14(�6/   $��Normal"�6=   
���  ��$��Center=�6b   $
��Left=�6�   $��	5,205,0,0q�6�   $	��Top=�6�   $	��362��6�   $��29��6�   �� 5   
   -   5        $ PorukaGreskeZaAdresu��5      $��14(�6.   $��Normal"�6<   
���  ��$��Center=�6a   $
��Left=�6�   $��
10,265,0,0q�6�   $	��Top=�6�   $��29��6�   $	��362��6�   �� 5   
   -	   5        $ PorukaGreskeZaDatum��5      $��14(�6-   $��Normal"�6;   
���  ��$��Center=�6`   $
��Left=�6�   $��	5,327,0,0q�6�   $	��Top=�6�   $��29��6�   $	��367��6�   �� 5   
   -
   5        $ PorukaGreskeZaVreme��5      $��14(�6-   $��Normal"�6;   
���  ��$��Center=�6`   $
��Left=�6�   $��
29,389,0,0q�6�   $	��Top=�6�   $��29��6�   $	��338��6�   �� 5   
   -   5         ��Name$ Vozila��5      $��377,118,0,0q�6N   $
��Left=�6c   $	��240��6~   $	��300��6�   $	��Top=�6�   ��6"   �� *Vozila+$	 TwoWay=���5      �� 5      .R�5      ��  ��Name$ chkitems��6   $��Center=�6`    d� 	IsChecked 62   �� *
IsSelected+$	 TwoWay=�.��5      �� .+�5      �� $��14(�6(   ��5    "   `� 5!   &    �� StringFormat$ Vozilo: {0} {1}��63   .1�5"   *   �� $ Vozilo.Marka�62   �� 5#   *   $ Vozilo.Model�62   5$   '   5%   4   �� 5&      $��Normal"�6(   ��6<   �� *Vozilo.Godiste+$  {0}.godište���� 5'      $��Normal"�6(   ��5(   "   `� 5)   &   $ VSJ: {1} ID:{0}��63   .1�5*   *   �� $" Vozilo.VatrogasnaJedinica.ID�62   �� 5+   *   $% Vozilo.VatrogasnaJedinica.Naziv�62   5,   '   5-   4   5.      5/      50      52      �� 53   
   -   5        $ Smene��53      $��651,118,0,0q�6L   $
��Left=�6a   $	��240��6|   $	��300��6�   $	��Top=�6�   ��6!   �� *Smene+$	 TwoWay=���54      �� 55      .R�56      ��   Caliburn.Micro.Message   Attach$# InicijalizacijaListeRadnika()��6N   $��Center=�6�    6    �� *
IsSelected+$	 TwoWay=�.��57      �� .+�58      �� $��14(�6(   ��59   "   `� 5:   &   $  {0} ID:{1}��63   .1�5;   *   �� $ Smena.NazivSmene�62   �� 5<   *   $ Smena.ID�62   5=   '   5>   4   �� 5?      $��Normal"�6(   ��5@   "   `� 5A   &   $ VSJ: {1} ID:{0}��63   .1�5B   *   �� $! Smena.VatrogasnaJedinica.ID�62   �� 5C   *   $$ Smena.VatrogasnaJedinica.Naziv�62   5D   '   5E   4   5F      5G      5H      5J      �� 5K   
   $��Vozila:��6   $
��Left=�6"   $��377,100,0,0q�6=   $	��Top=�6R   $	��162��6j   �� 5L   
   $��Smene:��6   $
��Left=�6!   $��651,100,0,0q�6<   $	��Top=�6Q   $	��158��6i   �� 5M   
   $4��.Označite smene i vozila koja su učestvovala:��6   $��Center=�6G   $��Center=�6i   $
��Left=�6�   $��
372,83,0,0q�6�   $	��Top=�6�   $	��794��6�   �� 5N   
   -   5         ��Name$  PorukaGreskeZaSmeneIVozila��5N      $��14(�68   $��Normal"�6F   
���  ��$
��Left=�6l   $��372,418,0,0q�6�   $
��Wrap=�6�   $	��Top=�6�   $	��794��6�   $��60��6�   �� 5O   
   -   5        $ 
Smene_Copy��5O      $��926,118,0,0q�6S   $
��Left=�6h   $	��240��6�   $	��300��6�   $	��Top=�6�   ��6&   �� *	Radnici+$	 TwoWay=���5P      �� 5Q      .R�5R      �� $ chkitems��6   $��Center=�6_    61   �� *
IsSelected+$	 TwoWay=�.��5S      �� .+�5T      �� $��14(�6(   ��5U   "   `� 5V   &   $  {0} {1} ID:{2}��63   .1�5W   *   �� $ RadnikUSmeni.Radnik.Ime�62   �� 5X   *   $! RadnikUSmeni.Radnik.Prezime�62   �� 5Y   *   $ RadnikUSmeni.Radnik.ID�62   5Z   '   5[   4   �� 5\      ��6(   �� * RadnikUSmeni.Radnik.RadnoMesto+�� 5]      $��Normal"�6(   ��5^   "   `� 5_   &   $ VSJ ID:{2} - {0} ID:{1} ��63   .1�5`   *   �� $# RadnikUSmeni.Smena.NazivSmene�62   �� 5a   *   $ RadnikUSmeni.Smena.ID�62   �� 5b   *   $. (RadnikUSmeni.Radnik.VatrogasnaJedinicaID�62   5c   '   5d   4   5e      5f      5g      5i      �� 5j   
   $��Vozači i Vatrogasci:��6   $
��Left=�6/   $��926,100,0,0q�6J   $	��Top=�6_   $	��158��6w   5k      5l      