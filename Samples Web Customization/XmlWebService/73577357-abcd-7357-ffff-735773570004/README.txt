XmlWebService AddIn Customization

INFO:
	With this Customization it is possible to use the Xml Web Service.

HOWTO:
	Replace the following data in "FunctionFile.html":

	[[THEJSADDINPATH]]
		Info:
			The Url Path to the Javascript AddIn Framework.
		Format:
			(//[Host])?/TWA/AddIn/therefore.debug.js
		Example:
			/TWA/AddIn/therefore.debug.js
			//localhost/TWA/AddIn/therefore.debug.js

	[[URLXMLWEBSERVICE]]
		Info:
			The Url to the Xml Web Service.
		Format:
			//[Host]:[Port]/
		Example:
			//server.domain.net:8001/