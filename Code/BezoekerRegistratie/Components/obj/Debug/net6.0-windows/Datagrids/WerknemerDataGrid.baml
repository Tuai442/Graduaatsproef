   M S B A M L   `   `   `  ????E  AComponents, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:Components.DatagridsComponents.Datagrids  5      ,    &Components.Datagrids.WerknemerDataGrid   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      4local"clr-namespace:Components.Datagrids     5      BedrijfEnumBed     5      .??5      ?? -   5          ??Name$  
stackPanel??5      .+?5   
   ?? 
???   ?$??3q?5       ?? CornerRadius$ 15??5      $??10q?5      
???????._?5      #   Components.Datagrids.Zoekbalk  -   5          Name$ zoekbalk??5      5      &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dataGrid??5         
IsReadOnly$ False??5      $	??600??5      $
??1000??6    ??5      ?? *WerknemerView+   Columns 5       0  *System.Windows.Controls.DataGridTextColumn  5!      ,  &System.Windows.Controls.DataGridColumn   Header$ Voornaam??6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 67   ?? *
Voornaam+  5"      $ 
Achternaam??6%    69   ?? *
Achternaam+4  .System.Windows.Controls.DataGridCheckBoxColumn  5#      $ Email??6)    68   ?? *Email+  5$      $ Funtie??6%    65   ?? *	Functie+4  .System.Windows.Controls.DataGridComboBoxColumn  5&      $ Bedri??6)      DisplayMemberPath$ Bedrijf??5(   )   	   ItemsSource	 5'   )   ?? *	Bedrijven+
 ?? Source$
 WerknemerView??5(   )   50      51      52      