   M S B A M L   `   `   `  ����I  EMonitor_Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:Monitor_Client.ViewsMonitor_Client.Views  5      $    Monitor_Client.Views.ChartView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      4local"clr-namespace:Monitor_Client.Views     5      b ^Syncfusion.SfChart.WPF, Version=30.1462.42.0, Culture=neutral, PublicKeyToken=3d67ed1f87d44c892
syncfusion!http://schemas.syncfusion.com/wpf  5      .��5
      �� .+�5   
   �� $��Chart��6   '  !Syncfusion.UI.Xaml.Charts.SfChart  5   
   -   5        $��SfChart1��5          PrimaryAxis  5      ,  &Syncfusion.UI.Xaml.Charts.CategoryAxis  5      )  #Syncfusion.UI.Xaml.Charts.ChartAxis   Header$
 Date��6*      SecondaryAxis 5      -  'Syncfusion.UI.Xaml.Charts.NumericalAxis  5      $ Value��6+      Minimum$	 -20X�6:      Maximum$	 120X�6H      Series. 5      *  $Syncfusion.UI.Xaml.Charts.LineSeries  /  )Syncfusion.UI.Xaml.Charts.ChartSeriesBase   XBindingPath$
 Date��5   $   ,  &Syncfusion.UI.Xaml.Charts.XyDataSeries   YBindingPath$ Value��5   $      Label$ Sensor 1��5   $   	   Interior
	 ��  �
   ShowTooltip
 .    ItemsSource 5   $   �� *	Series1+5   $     5      $
 Date��5   $   $ Value��5   $   $ Sensor 2��5   $   
	 �  ��
 .  5   $   �� *	Series2+5    $     5"      $
 Date��5#   $   $ Value��5$   $   $ Sensor 3��5%   $   
	 �   �
 .  5"   $   �� *	Series3+5'   $   5(      5)      5*      