IndexDataDialog-CalcSum AddIn Customization

INFO:
	With this Customization it is possible to sum up the Cell values of a Table Column and output the calculated result into a field.
	The calculated result will also be validated against another field.
	Depending on if the value is greater, equal or lower than the calculated field, the background color of the field will be set to red, blue or green.

HOWTO:
	Replace the following data in "FunctionFile.html" and "manifestAddIn_IndexDataDialog-CalcSum.xml":

	[[CategoryNumber]]
		Info:
			The ID from the Category in which the Customization should be applied
		Example:
			14

	[[UrlFunctionFile]]
		Info:
			The Url Path of the FunctionFile.
		Format:
			(//[Host])?/TWA/Client/AddIn/TWA/[GUID]/FunctionFile.html
		Example:
			/TWA/Client/AddIn/TWA/73577357-abcd-7357-ffff-735773570001/FunctionFile.html
			//localhost/TWA/Client/AddIn/TWA/73577357-abcd-7357-ffff-735773570001/FunctionFile.html

	[[THEJSADDINPATH]]
		Info:
			The Url Path to the Javascript AddIn Framework.
		Format:
			(//[Host])?/TWA/AddIn/therefore.debug.js
		Example:
			/TWA/AddIn/therefore.debug.js
			//localhost/TWA/AddIn/therefore.debug.js

	[[ColumnMoneyPos]]
		Info:
			The ColumnName of the Table [[FieldTable]].
			The Cells of the Column will be summed up.

	[[FieldTable]]
		Info:
			The Table which contains the Cells to be summed up.
		Format:
			TWF + [Table ID Number]
			Note: [Table ID Number] can be retrieved from Designer as "TheIxTable + [Table ID Number]"
				e.g. TheIxTable224 where "224" is [Table ID Number]
		Example:
			TWF224

	[[FieldMoneyCalcSum]]
		Info:
			The Field in which the calculated value will be shown.

	[[FieldMoneyTotal]]
		Info:
			The Field which will be validated against [[FieldMoneyCalcSum]].
			Depending on if the value is greater, equal or lower than the [[FieldMoneyCalcSum]], the background color of this Field will be changed.

	