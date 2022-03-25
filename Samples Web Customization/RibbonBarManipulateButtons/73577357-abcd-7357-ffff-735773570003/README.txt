RibbonBar-ManipulateButtons AddIn Customization

INFO:
	With this Customization it is possible to manipulate Buttons from the RibbonBar.

HOWTO:
	For disabling existing RibbonBar Controls, uncomment the desired <ControlId> Tags in <HideList>
	Replace the following data in "FunctionFile.html":

	[[THEJSADDINPATH]]
		Info:
			The Url Path to the Javascript AddIn Framework.
		Format:
			(//[Host])?/TWA/AddIn/therefore.debug.js
		Example:
			/TWA/AddIn/therefore.debug.js
			//localhost/TWA/AddIn/therefore.debug.js