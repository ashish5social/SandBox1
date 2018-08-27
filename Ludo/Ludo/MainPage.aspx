<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainPage.aspx.cs" Inherits="Ludo.MainPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>LUDO game</title>
	<style type="text/css">
		#row1 {
			width: 900px;
			height: 300px;
			border: 2px solid #4cff00
		}
		#row2 {
			width: 900px;
			height: 70px;
			border: 2px solid #ffff00
		}
		#row3 {
			width: 900px;
			height: 70px;
			border: 2px solid #4cffff
		}
		#row4 {
			width: 900px;
			height: 70px;
			border: 2px solid #4c0000
		}
		#row5 {
			width: 900px;
			height: 300px;
			border: 2px solid #ff0000
		}
		tr {
			height: 40px; 
		}
		
		.row1col1, .row1col5 {
			width: 300px;
			border: 1px solid #ff0000
		}
		.row1col2, .row1col3, .row1col4 {
			width: 70px;
			border: 6px solid #00ff00
		}

	</style>
</head>
<body>
    <form class="form1" runat="server">
        <div>
			<h1>Ludo game</h1>
        	<%Response.Write("This is first page"); %>
			<table>
				
				<tr>
					<td class="row1col1"></td>
					<td class="row1col2"></td>
					<td class="row1col3"></td>
					<td class="row1col4"></td>
					<td class="row1col5"></td>
				</tr>
				
					<tr>
					<td class="row1col1"></td>
					<td class="row1col2"></td>
					<td class="row1col3"></td>
					<td class="row1col4"></td>
					<td class="row1col5"></td>
				</tr>

				<tr>
					<td class="row1col1"></td>
					<td class="row1col2"></td>
					<td class="row1col3"></td>
					<td class="row1col4"></td>
					<td class="row1col5"></td>
				</tr>

				<tr>
					<td class="row1col1"></td>
					<td class="row1col2"></td>
					<td class="row1col3"></td>
					<td class="row1col4"></td>
					<td class="row1col5"></td>
				</tr>

				<tr>
					<td class="row1col1"></td>
					<td class="row1col2"></td>
					<td class="row1col3"></td>
					<td class="row1col4"></td>
					<td class="row1col5"></td>
				</tr>


			</table>

        </div>
    	<asp:Table ID="Table2" runat="server" Height="135px" Width="321px">
		</asp:Table>
		<asp:Table ID="Table1" runat="server" Height="136px" Width="426px">
		</asp:Table>
    </form>
</body>
</html>
