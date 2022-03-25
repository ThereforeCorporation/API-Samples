*************************************************************
*                                                           *
*             Therefore™ SDK Version 2.0                    *
*															*
*             COPYRIGHT ® 2015 Therefore Corporation.       *
*             All rights reserved.                          *
*                                                           *
*************************************************************
Sample:
ThereforeRightsServer

Description:
This sample shows how to create a custom rights server for the Therefore system.
Be aware that you can directly execute SQL statements on the server. This can help you to reduce serverload.
In this sample the Method GetCtgryRight() in line 161 specifies the special rules of this Therefore Rights Server.
For information about installing a Therefore Rights Server go to "Developers Guid->AddIns->Rights Server" in the 
Therefore API Documentation.

Requirements:
* The binaries produced by compiling the Therefore Rights Server AddIn need to be located on the Therefore server.

Build-Steps:
* Assure that the number values in line 165 are valid values.