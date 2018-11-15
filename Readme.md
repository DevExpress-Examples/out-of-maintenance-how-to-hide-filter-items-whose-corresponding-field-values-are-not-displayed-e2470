<!-- default file list -->
*Files to look at*:

* [Form1.cs](./CS/EmptyWinApp/Form1.cs) (VB: [Form1.vb](./VB/EmptyWinApp/Form1.vb))
* [Program.cs](./CS/EmptyWinApp/Program.cs) (VB: [Program.vb](./VB/EmptyWinApp/Program.vb))
<!-- default file list end -->
# How to hide filter items whose corresponding field values are not displayed


<p>The following example shows how to hide filter items whose corresponding field values are not displayed.</p><p>In this example, the Row Header Area of the PivotGrid contains two fields: 'Category Name' and 'Product Name'. If an end-user hides a particular product category via the 'Category Name' field's filter drop-down, the corresponding products will be excluded from the filter drop-down of the 'Product Name' field. To hide filter items, the CustomFilterPopupItems event is handled.</p>

<br/>


