   M S B A M L   `   `   `  ????F  BShopManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:ShopManagerShopManager  5          ShopManager.InventoryTab   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      +localclr-namespace:ShopManager     5      -   5          N? Title$  InventoryTab??5
      .??5      ?? 
??????? ?? Orientation$ Vertical=?6$   .+?5   
   ?? $ 
Horizontal=?6   .+?5      ?? -   5         ??Name$ addNewProduct??5      $??Add new product??6,   $??0,3,3,3q?6b   $??	10,4,10,4q?6s   ?? 5      -   5        $ reload??5      $??Reload??6%   $??3,3,3,3q?6K   $??	10,4,10,4q?6\   ?? 5      -   5        $
 save??5      $
??Save??6#   $??3,3,0,3q?6E   $??	10,4,10,4q?6V   5      &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ itemGrid??5         AutoGenerateColumns .     CanUserAddRows .  ??6%   ?? *
Products+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$
 Name??6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 63   ?? *Name+6N     5      $ Price??6%    64   ?? *Price+6P     5      $ Weight??6%    65   ?? *Weight+6R     5      $ Quantity??6%    67   ?? *
Quantity+6V     5      $	 EAN??6%    62   ?? *Ean+6L   4  .System.Windows.Controls.DataGridTemplateColumn  5      $ Category??6)   	   CellTemplate	 5      ?? 5      .R?5      ?? -   5        ??5   '   ?? 
 ?? Path$
 
Categories? ?? RelativeSource ??  ?? AncestorType" N? ?? SelectedItem 6?   ?? *Category.Name+6?   5      5        5       $
 Shop??6)   	 5!      ?? 5"      .R?5#      ?? -   5        ??5#   '   ?? $
 Shops? ?? " N? 6?   ?? *	Shop.Name+6?   5$      5&      5(      5)      5*      