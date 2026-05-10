using System;
using System.Collections.Generic;
using System.Data;

namespace EBAP.Core
{
    /// <summary>
    /// DataTable Class 확장 메서드 입니다.
    /// </summary>
    /// <remarks>
    /// 2023-02-01 최초생성 : 오인봉
    /// 변경내역
    /// 
    /// </remarks>
    public static class ADOExtension
    {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Extention Method
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: AddColumn :: 해당 DataTable에 컬럼을 추가합니다.

        /// <summary>
        /// 해당 DataTable에 컬럼을 추가합니다.
        /// </summary>
        /// <param name="dt">해당 DataTable</param>
        /// <param name="cols">Columns</param>
        public static void AddColumn(this DataTable dt, params string[] cols)
        {
            foreach (string col in cols)
            {
                if (dt.Columns.Contains(col)) continue;

                dt.Columns.Add(col);
            }

            dt.AcceptChanges();
        }

        #endregion

        #region :: SelectData :: DataTable에서 조건에 맞는 데이터를 추출합니다.

        /// <summary>
        /// DataTable에서 조건에 맞는 데이터를 추출합니다.
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="filterExpresstion"></param>
        /// <returns></returns>
        public static DataTable SelectData(this DataTable dt, string filterExpresstion)
        {
            DataTable rDt = dt.Clone();

            DataRow[] drs = dt.Select(filterExpresstion);

            foreach (DataRow dr in drs)
            {
                rDt.ImportRow(dr);
            }

            return rDt;
        }

        #endregion

        #region :: ToUpperColumnName :: 컬럼명을 대문자로 변환합니다.

        /// <summary>
        /// 컬럼명을 대문자로 변환합니다.
        /// </summary>
        /// <param name="dt"></param>
        public static void ToUpperColumnName(this DataTable dt)
        {
            foreach (DataColumn col in dt.Columns)
            {
                col.ColumnName = col.ColumnName.ToUpper();
            }
        }

        #endregion

        #region :: TrimColumnData :: 해당 DataTable의 컬럼 데이터의 공백을 제거합니다.

        /// <summary>
        /// 해당 DataTable의 컬럼 데이터의 공백을 제거합니다.
        /// </summary>
        /// <param name="dt">해당 DataTable</param>
        public static void TrimColumnData(this DataTable dt)
        {
            foreach (DataRow dr in dt.Rows)
            {
                foreach (DataColumn col in dt.Columns)
                {
                    if (col.DataType.Name != "String") continue;

                    dr[col.ColumnName] = dr[col.ColumnName].ToString().Trim();
                }
            }

            dt.AcceptChanges();
        }

        /// <summary>
        /// 해당 DataTable의 컬럼 데이터의 공백을 제거합니다.
        /// </summary>
        /// <param name="dt">해당 DataTable</param>
        /// <param name="cols">Columns</param>
        public static void TrimColumnData(this DataTable dt, params string[] cols)
        {
            foreach (DataRow dr in dt.Rows)
            {
                foreach (string col in cols)
                {
                    if (!dt.Columns.Contains(col)) continue;

                    dr[col] = dr[col].ToString().Trim();
                }
            }

            dt.AcceptChanges();
        }

        #endregion

        #region :: AddColumnWithValue :: 해당 DataTable에 컬럼을 추가하며 일괄적으로 값을 입력합니다.

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="col"></param>
        /// <param name="value"></param>
        public static void SetColumnValue(this DataTable dt, string col, object value)
        {
            if (!dt.Columns.Contains(col))
                dt.Columns.Add(col, value.GetType());

            foreach (DataRow row in dt.Rows)
            {
                row[col] = value;
            }
            dt.AcceptChanges();
        }

        /// <summary>
        /// 해당 DataTable에 컬럼을 추가하며 일괄적으로 값을 입력합니다.
        /// </summary>
        /// <param name="dt">해당 DataTable</param>
        /// <param name="cols">Columns</param>
        /// <param name="values">Value</param>
        public static void AddColumnWithValue(this DataTable dt, string[] cols, object[] values)
        {
            Array.ForEach(cols, col =>
            {
                if (!dt.Columns.Contains(col))
                    dt.Columns.Add(col);
            });

            foreach (DataRow row in dt.Rows)
            {
                for (int idx = 0; idx < cols.Length; idx++)
                    row[cols[idx]] = values[idx];
            }

            dt.AcceptChanges();
        }

        /// <summary>
        /// 해당 DataTable에 컬럼을 추가하며 일괄적으로 값을 입력합니다.
        /// </summary>
        /// <param name="dt">해당 DataTable</param>
        /// <param name="cols">Columns</param>
        /// <param name="values">Value</param>
        public static void AddColumnWithValueType(this DataTable dt, string[] cols, object[] values)
        {
            for (int i = 0; i < cols.Length; i++)
            {
                if (!dt.Columns.Contains(cols[i]))
                    dt.Columns.Add(cols[i], values[i].GetType());
            }

            foreach (DataRow row in dt.Rows)
            {
                for (int idx = 0; idx < cols.Length; idx++)
                    row[cols[idx]] = values[idx];
            }

            dt.AcceptChanges();
        }

        #endregion

        #region :: AddColumnWithValueNewRow :: 해당 DataTable에 컬럼을 추가하며 신규 Row를 추가하고 일괄적으로 값을 입력합니다.

        /// <summary>
        /// 해당 DataTable에 컬럼을 추가하며 일괄적으로 값을 입력합니다.
        /// </summary>
        /// <param name="dt">해당 DataTable</param>
        /// <param name="cols">Columns</param>
        /// <param name="values">Value</param>
        public static void AddColumnWithValueNewRow(this DataTable dt, string[] cols, object[] values)
        {
            if (cols == null || values == null) return;

            foreach (string col in cols)
            {
                if (dt.Columns.Contains(col)) continue;

                dt.Columns.Add(col);
            }

            DataRow dr = dt.NewRow();

            foreach (object val in values)
            {
                for (int idx = 0; idx < cols.Length; idx++)
                {
                    dr[cols[idx]] = values[idx];
                }
            }

            dt.Rows.Add(dr);

            dt.AcceptChanges();
        }

        /// <summary>
        /// 해당 DataTable에 컬럼을 추가하며 일괄적으로 값을 입력합니다.
        /// </summary>
        /// <param name="dt">해당 DataTable</param>
        /// <param name="cols">Columns</param>
        /// <param name="values">Value</param>
        /// <param name="pos">넣을 위치</param>
        public static void InsertRow(this DataTable dt, string[] cols, object[] values, int pos = 0)
        {
            if (cols == null || values == null) return;

            foreach (string col in cols)
            {
                if (dt.Columns.Contains(col)) continue;

                dt.Columns.Add(col);
            }

            DataRow dr = dt.NewRow();

            foreach (object val in values)
            {
                for (int idx = 0; idx < cols.Length; idx++)
                {
                    dr[cols[idx]] = values[idx];
                }
            }

            dt.Rows.InsertAt(dr, pos);

            dt.AcceptChanges();
        }

        #endregion

        #region :: CheckDataTableValue :: 데이터 테이블의 값을 검사하여 같은 값이 있으면 False를 Return합니다.

        /// <summary>
        /// 데이터 테이블의 값을 검사하여 같은 값이 있으면 False를 Return합니다.
        /// </summary>
        /// <param name="dt">대상 DataTable</param>
        /// <param name="cols">검사할 Columns</param>
        /// <param name="value">검사 Value</param>
        /// <param name="check">같은 값 : True, 다른 값 : False</param>
        /// <returns></returns>
        public static bool CheckDataTableValue(this DataTable dt, string[] cols, object value, bool check)
        {
            foreach (DataRow dr in dt.Rows)
            {
                foreach (string col in cols)
                {
                    if ((dr[col].ToString() == value.ToString()) == check)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        #endregion

        #region :: CopyColumnData :: Column Data를 복사합니다.

        /// <summary>
        /// Column Data를 복사합니다.
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="source"></param>
        /// <param name="target"></param>
        public static void CopyColumnData(this DataTable dt, string source, string target)
        {
            foreach (DataRow dr in dt.Rows)
            {
                dr[target] = dr[source];
            }
            dt.AcceptChanges();
        }

        #endregion

        #region :: Data Table에서 Row를 삭제합니다.

        /// <summary>
        /// Data Table에서 Row를 삭제합니다.
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="col"></param>
        /// <param name="value"></param>
        public static void DeleteRow(this DataTable dt, string col, object value)
        {
            List<int> indexs = new List<int>();

            foreach (DataRow dr in dt.Rows)
            {
                if (dr[col].ToString().Trim() == value.ToString().Trim())
                    indexs.Add(dt.Rows.IndexOf(dr));
            }

            foreach (int idx in indexs)
            {
                dt.Rows.RemoveAt(idx);
            }
        }

        #endregion

        #region :: 데이터가 비어있는지 확인합니다.

        /// <summary>
        /// 데이터가 비어있는지 확인합니다.
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static bool IsEmpty(this DataTable dt)
        {
            if (dt == null || dt.Rows.Count == 0) return true;

            return false;
        }

        #endregion

        #region :: GetColumnsFromDataTable :: DataTable에서 Column을 가져옵니다.

        /// <summary>
        /// DataTable에서 Column을 가져옵니다.
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static string[] GetColumnsFromDataTable(this DataTable dt)
        {
            List<string> columnFields = new List<string>();

            foreach (DataColumn dc in dt.Columns)
            {
                columnFields.Add(dc.ColumnName);
            }

            return columnFields.ToArray();
        }

        #endregion

        #region :: GetStringFromColumnValue :: 컬럼의 값을 연결하여 가져옵니다.

        /// <summary>
        /// 컬럼의 값을 연결하여 가져옵니다.
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="column"></param>
        /// <returns></returns>
        public static string GetStringFromColumnValue(this DataTable dt, string column)
        {
            string value = string.Empty;

            int idx = 0;

            foreach (DataRow dr in dt.Rows)
            {
                value += dr[column].ToString();

                if (idx < dt.Rows.Count - 1)
                    value += ",";

                idx++;
            }

            return value;
        }

        #endregion

        #region :: GetDataTableColumns :: DataTable에서 Column을 가져옵니다.

        /// <summary>
        /// DataTable에서 Column을 가져옵니다.
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static string[] GetColumns(this DataTable dt)
        {
            List<string> columnFields = new List<string>();

            foreach (DataColumn dc in dt.Columns)
            {
                columnFields.Add(dc.ColumnName);
            }

            return columnFields.ToArray();
        }

        #endregion

        #region :: MakeDataTableScheme :: DataTable Scheme를 생성합니다.

        /// <summary>
        /// DataTable Scheme를 생성합니다.
        /// </summary>
        /// <param name="ds">기본으로 생성된 DataSet</param>
        /// <param name="cols">Column Field</param>
        /// <returns></returns>
        public static DataTable MakeDataTableScheme(this DataSet ds, params string[] cols)
        {
            DataTable dt = null;
            if (ds.Tables.Count == 0)
                dt = new DataTable();
            else
                dt = ds.Tables[0];

            if (dt == null) return null;

            foreach (string col in cols)
            {
                if (dt.Columns.Contains(col)) continue;

                dt.Columns.Add(col);
            }

            return dt;
        }

        /// <summary>
        /// DataTable Scheme를 생성합니다.
        /// </summary>
        /// <param name="dt">기본으로 생성된 DataTable</param>
        /// <param name="cols">Column Field</param>
        /// <returns></returns>
        public static DataTable MakeDataTableScheme(this DataTable dt, params string[] cols)
        {
            if (dt == null) return null;

            foreach (string col in cols)
            {
                if (dt.Columns.Contains(col)) continue;

                dt.Columns.Add(col);
            }

            return dt;
        }

        #endregion

        #region :: RemoveColumn :: DataTable 컬럼을 삭제합니다.

        /// <summary>
        /// 해당 DataTable 컬럼을 삭제합니다.
        /// </summary>
        /// <param name="dt">해당 DataTable</param>
        /// <param name="match">포함된 컬럼여부</param>
        /// <param name="cols">삭제할 컬럼</param>
        /// <returns></returns>
        public static DataTable RemoveColumn(this DataTable dt, bool match, params string[] cols)
        {
            DataTable dataTable = dt.Clone();

            dataTable.Merge(dt, false, MissingSchemaAction.Ignore);

            foreach (DataColumn column in dt.Columns)
            {
                foreach (string col in cols)
                {
                    if (match == column.ColumnName.Contains(col))
                        dataTable.Columns.Remove(column.ColumnName);
                }
            }

            return dataTable;
        }
        #endregion

        #region :: RemoveRow :: 해당 DataTable의 컬럼에 지정된 값이 있는 Row를 삭제합니다.

        /// <summary>
        /// 해당 DataTable의 컬럼에 지정된 값이 있는 Row를 삭제합니다.
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="column"></param>
        /// <param name="value"></param>
        public static void RemoveRow(this DataTable dt, string column, object value)
        {
            foreach (DataRow dr in dt.Rows)
            {
                if (dr[column].ToString() == value.ToString())
                    dr.Delete();
            }
            dt.AcceptChanges();
        }

        #endregion
    }
}
