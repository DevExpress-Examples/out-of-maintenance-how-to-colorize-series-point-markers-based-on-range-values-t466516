<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128568901/16.2.3%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T466516)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* **[MainWindow.xaml](./CS/RangeColorizer3DExample/MainWindow.xaml) (VB: [MainWindow.xaml](./VB/RangeColorizer3DExample/MainWindow.xaml))**
* [GdpViewModel.cs](./CS/RangeColorizer3DExample/ViewModel/GdpViewModel.cs) (VB: [GdpViewModel.vb](./VB/RangeColorizer3DExample/ViewModel/GdpViewModel.vb))
<!-- default file list end -->
# How to colorize series point markers based on range values


This example demonstrates how to colorize series point markers based on range values.


<h3>Description</h3>

<p>To do this, assign a&nbsp;<a href="https://documentation.devexpress.com/#WPF/clsDevExpressXpfChartsRangeColorizer3Dtopic">RangeColorizer3D</a>&nbsp;object to the&nbsp;<a href="https://documentation.devexpress.com/#WPF/DevExpressXpfChartsSeries3DViewBase_Colorizertopic">Series3DViewBase.Colorizer</a>&nbsp;property. Then, configure range stops using the&nbsp;<a href="https://documentation.devexpress.com/#WPF/DevExpressXpfChartsRangeColorizer3D_RangeStopstopic">RangeColorizer3D.RangeStops</a>&nbsp;property and optionally, configure required colors using the&nbsp;<a href="https://documentation.devexpress.com/#WPF/DevExpressXpfChartsPaletteColorizer3DBase_Palettetopic">PaletteColorizer3DBase.Palette</a>&nbsp;property. Finally, specify which values should be measured - you can do this using the&nbsp;<a href="https://documentation.devexpress.com/#WPF/DevExpressXpfChartsRangeColorizer3D_ValueProvidertopic">RangeColorizer3D.ValueProvider</a>&nbsp;property.</p>

<br/>


