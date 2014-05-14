// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      Mono Runtime Version: 4.0.30319.1
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------

/*
 *  Created by CS on 14 May
 */
using System;
//using System.Data;
using System.Collections;
using Mono.Data.Sqlite;
using UnityEngine;
namespace AssemblyCSharpfirstpass
{
	public class DBAccessBase
	{
		private SqliteConnection 	mDBConnection;
		private SqliteCommand	 	mDBCommand;
		private SqliteDataReader	mDBReader;

		public DBAccessBase ()
		{

		}

//		public DBAccessBase(string sDBName)
//		{
//			OpenDB(sDBName);
//		}

		/*
		 * @brief: Open a DB File
		 * @param: sDBName
		 * 		the path of db file
		 */
		public void OpenDB(string sDBName)
		{
			try
			{
				mDBConnection = new SqliteConnection(sDBName);
				mDBConnection.Open();
				Debug.Log("Success To Connect to DB:" + sDBName);

			}
			catch(Exception e)
			{
				Debug.Log("Failed To Connect to DB:" + sDBName +" error:" + e.ToString());
			}
		}

		/*
		 * @brief:	at last time, you need to close db connection
		 */
		public void CloseDB()
		{
			if(mDBCommand != null)
			{
				mDBCommand.Dispose();
				mDBCommand = null;
			}
			if(mDBReader != null)
			{
				mDBReader.Close();
				mDBReader = null;
			}
			if(mDBConnection != null)
			{
				mDBConnection.Close();
				mDBConnection = null;
			}

			Debug.Log("Close DB Connection.");
		}

		/*
		 * @brief:	execute any sql statement
		 */
		public SqliteDataReader ExecuteSql(string sqlStr)
		{
			mDBCommand = mDBConnection.CreateCommand();
			mDBCommand.CommandText = sqlStr;
			mDBReader = mDBCommand.ExecuteReader();
			return mDBReader;
		}

		/*
		 * @brief: create a table
		 * @param: tableName
		 * 		the table name you will create
		 * @param: colsStr
		 * 		the column names and types,like:
		 * 		columnName1 columnType1, columnName2 columnType2, ...
		 */
		public SqliteDataReader CreateTable(string tableName,string colsStr)
		{
			string sqlStr = "CREATE TABLE " + tableName + " ( " + colsStr + " )";
			return ExecuteSql(sqlStr);
		}

		/*
		 * @brief: update info with one condition
		 * @param: tableName
		 * 		the table name you will update
		 * @param: cols
		 * 		the columns'names of table you will update
		 * @param: colsValues
		 * 		the values of columns you will update
		 * @param: condition
		 * 		the condition looks like : conditionKey = conditionValue AND(OR) ...
		 */
		public SqliteDataReader UpdateInto(string tableName, string[] cols, string[] colsValues, string condition)
		{
			if(cols.Length != colsValues.Length)
			{
				Debug.LogError("[DBAccessBase:UpdateInto] : wrong cols and colsValues ");
				return null;
			}
			string sqlStr = "UPDATE " + tableName + " SET " + cols[0] + " = " + colsValues[0];
			for(int i=1; i<cols.Length; ++i)
			{
				sqlStr += ", " + cols[i] + " = " + colsValues[i];
			}
			sqlStr += " WHERE " + condition;

			return ExecuteSql(sqlStr);
		}

		/*
		 * @brief:	select some columns info with some condition
		 * @param:	tableName
		 * 		the table name you select
		 * @param:	cols
		 * 		the columns names you need select
		 * @param:	condition
		 * 		the condition looks like : conditionKey = conditionValue AND(OR) ...
		 */
		public SqliteDataReader SelectInfo(string tableName, string[] cols, string condition)
		{
			string sqlStr = "SELECT " + cols[0];
			for(int i=1; i<cols.Length; ++i)
			{
				sqlStr += ", " + cols[i];
			}
			sqlStr += " FROM " + tableName + " WHERE " + condition;

			return ExecuteSql(sqlStr);
		}

		public SqliteDataReader SelectAllInfo(string tableName, string condition)
		{
			string sqlStr = "SELECT * FROM " + tableName + " WHERE " + condition;

			return ExecuteSql(sqlStr);
		}
	}
}
