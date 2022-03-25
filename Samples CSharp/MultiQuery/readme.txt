*************************************************************
*                                                           *
*             Therefore™ SDK Version 2.0                    *
*															*
*             COPYRIGHT ® 2015 Therefore Corporation.       *
*             All rights reserved.                          *
*                                                           *
*************************************************************
Sample:
MultiQuery

Description:
This sample shows how to do queries on multiple categories and how to process the result data.
The source code is taken from the API Documentation as followed:

Method				API Documentation Chapter
btn_execute_Click	Developers Guide->Queries->Find Documents->Query in Multiple Categories
btn_process_Click	Developers Guide->Queries->Find Documents->Process Multi-Query Results


Requirements:
* The Table created by the DataType.sql file hast to exist in your Therefore Database
* The categories "Files" and "Simple Invoice" must have been importet or the category names in lines 46 & 53 have to be changed as well.
* You need to have at least one document in each category.

Build-Steps:
* If you change the category name you may also have to change the field names in lines 48 & 49.