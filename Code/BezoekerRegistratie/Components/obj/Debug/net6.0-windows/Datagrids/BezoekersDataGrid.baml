   M S B A M L   `   `   `  ????E  AComponents, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:Components.DatagridsComponents.Datagrids  5      ;,clr-namespace:Components;assembly=Components
Components  5      ,    &Components.Datagrids.BezoekersDataGrid   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      4local"clr-namespace:Components.Datagrids     5      <UIC,clr-namespace:Components;assembly=Components     5      .??5      ?? -   5          ??Name$  
stackPanel??5      .+?5   
   ? 
??????? ? ColumnDefinitions 5      ?? 5      $
??auto ?6#   ?? 5      $??* ?6#   ?? 5      $
??auto ?6#   ?? 5      $??* ?6#    ? RowDefinitions 5      ?? 5      $
??auto ?6    ?? 5      $
??auto ?6    ?? 5      $
??auto ?6    ?? 5      $
??auto ?6    .+?5      ?? $??Voornaam??6   $??0??5      $??0??6!   $??10q?5      ?? 5      $??0??6   $??1??6#   $??10q?63   ?? 5      $??
Achternaam??6   $??0??5       $??2??6!   $??10q?5!      ?? 5"      $??0??6   $??3??6#   $??10q?5#      ?? 5%      $??Email??6   $??1??5&      $??0??6!   $??10q?5'      ?? 5(      $??1??6   $??1??6#   $??10q?5)      ?? 5+      $??Bedrijf??6   $??2??5,      $??0??6!   $??10q?5-      ?? 5.      $??2??6   $??1??6#   $??10q?5/      ?? 51      $??2??6   $??3??6"   $??5q?52      $	??100??6    $??Zoeken??53      $??20(?6&   54      &   System.Windows.Controls.DataGrid  56   
   -   5          Name$ dataGrid??56         
IsReadOnly$ False??57      $	??600??5:      $
??1000??6    ??5;      ?? *
Bezoeker+   Columns 5=      0  *System.Windows.Controls.DataGridTextColumn  5>      ,  &System.Windows.Controls.DataGridColumn   Header$ Voornaam??6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 67   ?? *
Voornaam+  5?      $ 
Achternaam??6%    69   ?? *
Achternaam+4  .System.Windows.Controls.DataGridCheckBoxColumn  5@      $ Email??6)    68   ?? *Email+  5A      $ Bedrijf??6%    66   ?? *	Bedrijf+  5B      $ Is aanwezig??6%    6:   ?? *
IsAanwezig+5E      5F      5H      