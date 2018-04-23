Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports DevExpress.XtraPivotGrid
Imports DevExpress.XtraPivotGrid.Data

Namespace EmptyWinApp
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub
		Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
			Me.productReportsTableAdapter.Fill(Me.productReports._ProductReports)
		End Sub
		Private Sub pivotGridControl1_CustomFilterPopupItems(ByVal sender As Object, _
						ByVal e As PivotCustomFilterPopupItemsEventArgs) _
						Handles pivotGridControl1.CustomFilterPopupItems

			' Fetches and sorts visible values of the current field.
			Dim values As List(Of Object) = e.Field.GetVisibleValues()
			values.Sort()

			' Checks whether the filter drop-down customization logic differs
			' depending on the currently selected filter type.
			' If so, the filter type decides which filter items
			' will be hidden.
			Dim removingCriteria As Nullable(Of Boolean)
			If (CType(sender, PivotGridControl)).OptionsFilterPopup.AllowFilterTypeChanging = False Then
				removingCriteria = True
			Else
				removingCriteria = e.Field.FilterValues.FilterType <> PivotFilterType.Excluded
			End If

			' Hides filter items that are not currently visible
			' due to the filtering applied.
			For i As Integer = e.Items.Count - 1 To 0 Step -1
				If e.Items(i).IsChecked.Equals(removingCriteria) AndAlso _
						values.BinarySearch(e.Items(i).Value) < 0 Then
					e.Items.RemoveAt(i)
				End If
			Next i
		End Sub
	End Class
End Namespace